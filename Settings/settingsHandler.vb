#Region "Descripción de la clase"
'DESCRIPCIÓN
'Esta clase permite guardar cualquier tipo de objeto (string, integer, listas, dictionary, arrays...)
'de forma persistente en ficheros

'INSTANCIACIÓN CLASE:
' Dim settings As applicationSettings = applicationSettings.defaultInCommonApplicationData
'o bien
' Dim settings As applicationSettings = applicationSettings.defaultInLocalApplicationData
'o bien
' Dim settings As applicationSettings = new applicationSettings(ruta_carpeta)

'USO DE LA CLASE
'settings.setValue("clave1", "ola k ase programa o k ase") 'el segundo parámetro puede ser cualquier Object
'Dim str as String = applicationSettings.getValue("clave1") 'el output es: str = "ola k ase programa o k ase"
#End Region

Public Class settingsHandler
    Const nombreAplicacion As String = "multimediaKeysDaemon"
    Public Property SETTINGS_FOLDER As String

#Region "privado"
    Private ReadOnly Property rutaSettings(ByVal valueKey As String)
        Get
            Dim ruta As String = SETTINGS_FOLDER
            If Not IO.Directory.Exists(ruta) Then
                IO.Directory.CreateDirectory(ruta)
            End If

            Dim rutaFichero As String = ruta + valueKey + ".txt"
            Return rutaFichero
        End Get
    End Property

    Private Shared Function IsAdmin() As Boolean
        Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
        Dim p As New Security.Principal.WindowsPrincipal(id)
        Return p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator)
    End Function
#End Region

#Region "Instanciación"
    ''' <summary>
    ''' Crea un objecto de applicationSettings. La carpeta settingsFolder no hace falta que exista, se creará automáticamente.
    ''' </summary>
    ''' <param name="settingsFolder">La carpeta settingsFolder no hace falta que exista, se creará automáticamente</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal settingsFolder As String)
        If Not settingsFolder.EndsWith("\") Then settingsFolder += "\"
        SETTINGS_FOLDER = settingsFolder
    End Sub

    ''' <summary>
    ''' Operación inicializadora.
    ''' Retorna un objeto de tipo applicationSettings que guarda en commonApplicationData (para todos los usuarios)
    ''' Es necesario llamar a allowWriteToAllUsers una vez con permisos elevados para dar permiso a todos los usuarios
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function defaultInCommonApplicationData() As settingsHandler
        'La carpeta CommonApplicationData es de todos los usuarios pero sólo puede escribir el propietario o administradores
        'para que la usen todos los usuarios, llamar a la operación allowWriteToAllUsers con permisos elevados previamente
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + _
        "\" + nombreAplicacion + "\settings\"

        Dim appsettings As New settingsHandler(path)

        If Not IO.Directory.Exists(path) Then
            IO.Directory.CreateDirectory(path)
        End If

        Return appsettings
    End Function

    ''' <summary>
    ''' Operación inicializadora.
    ''' Retorna un objeto de tipo applicationSettings que guarda en localApplicationData (para el usuario logueado)
    ''' Cada usuario ve su propia configuración
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function defaultInLocalApplicationData() As settingsHandler
        'La carpeta LocalApplicationData es del usuario logueado. 
        'El usuario puede escribir y leer sin problemas pero la configuración es sólo para el usuario.
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + _
         "\" + nombreAplicacion + "\settings\"

        Dim appsettings As New settingsHandler(path)

        If Not IO.Directory.Exists(path) Then
            IO.Directory.CreateDirectory(path)
        End If

        Return appsettings
    End Function
#End Region

    Public Function getValue(valueKey As String, Optional ByRef exceptionError As Exception = Nothing) As Object
        Try
            'Dim a As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            'Using stream As New IO.FileStream(rutaSettings(valueKey), IO.FileMode.Open)
            '    Return a.Deserialize(stream)
            'End Using

            Return serializer.stringToObject(IO.File.ReadAllText(rutaSettings(valueKey)))
        Catch ex As Exception
            exceptionError = ex
            Return Nothing
        End Try
    End Function

    Public Sub setValue(valueKey As String, value As Object)
        Try
            'Dim a As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

            'Using stream As New IO.FileStream(rutaSettings(valueKey), IO.FileMode.Create)
            '    If value.GetType().Name = "String" Then If value = Nothing Then value = ""
            '    a.Serialize(stream, value)
            'End Using

            IO.File.WriteAllText(rutaSettings(valueKey), serializer.objectToString(value))
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' NECESITA SER LLAMADA CON PERMISOS ELEVADOS
    ''' Da permisos para todos los usuarios para leer/escribir los ficheros de configuración de la ruta especificada
    ''' Útil cuando se escribe en commonApplicationData
    ''' </summary>
    ''' <remarks>NECESITA SER LLAMADA CON PERMISOS ELEVADOS</remarks>
    Public Sub allowWriteToAllUsers()
        If Not IsAdmin() Then
            Throw New Exception("Esta operación necesita ser llamada como administrador")
        End If

        Try
            If Not IO.Directory.Exists(SETTINGS_FOLDER) Then
                IO.Directory.CreateDirectory(SETTINGS_FOLDER)
            End If

            Dim di As IO.DirectoryInfo = New IO.DirectoryInfo(SETTINGS_FOLDER)
            Dim control As System.Security.AccessControl.DirectorySecurity = di.GetAccessControl()

            Dim sid As New System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, Nothing)
            Dim acct As System.Security.Principal.NTAccount = TryCast(sid.Translate(GetType(System.Security.Principal.NTAccount)), System.Security.Principal.NTAccount)
            Dim strEveryoneAccount As String = acct.ToString()

            Dim restriccion1 As New System.Security.AccessControl.FileSystemAccessRule(strEveryoneAccount, _
                                                                                       Security.AccessControl.FileSystemRights.FullControl, _
                                                                                       System.Security.AccessControl.InheritanceFlags.ObjectInherit + Security.AccessControl.InheritanceFlags.ContainerInherit, _
                                                                                       Security.AccessControl.PropagationFlags.None, _
                                                                                       Security.AccessControl.AccessControlType.Allow)

            control.AddAccessRule(restriccion1)
            di.SetAccessControl(control)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub deleteAllSettings()
        If IO.Directory.Exists(SETTINGS_FOLDER) Then
            IO.Directory.Delete(SETTINGS_FOLDER, True)
        End If
    End Sub
End Class

