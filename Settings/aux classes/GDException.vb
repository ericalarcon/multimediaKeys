Imports System.Text.RegularExpressions

Public Class GDException
    Inherits Exception

    Property obj As Object

    Public Sub New(ByVal classObj As Object, ByVal code As exceptionCode, Optional ByVal referenceObject As Object = Nothing)
        Dim msg As String = classObj.ToString.ToUpper.Replace(".", "_") & "_" & CInt(code).ToString("000")
        If code.ToString.StartsWith("general_") Then
            msg = "GENERAL_" & CInt(code).ToString("000")
        End If
      
        Throw New GDException(msg, referenceObject)
    End Sub

    Public Sub New(msg As String, ByVal referenceObject As Object)
        MyBase.New(msg)
        If Not referenceObject Is Nothing Then
            obj = referenceObject
        End If
    End Sub
    Public ReadOnly Property localizedDescription(Optional ByVal uiculture As String = "en")
        Get
            If uiculture Is Nothing Then uiculture = "en"
            If obj Is Nothing Then
                obj = New Object
            End If
            Return String.Format(My.Resources.errors.ResourceManager.GetString(Message, New System.Globalization.CultureInfo(uiculture)), obj.ToString)
        End Get
    End Property

    Public ReadOnly Property englishDescription
        Get
            Return String.Format(My.Resources.errors.ResourceManager.GetString(Message, New System.Globalization.CultureInfo("en")), obj.ToString)
        End Get
    End Property
End Class


Public Enum exceptionCode
   
    'usersBrain
    usersBrain_err000 = 0 'El usuario {0} ya existe
    usersBrain_err001 = 1 'No se puede modificar el id del usuario
    usersBrain_err002 = 2 'El usuario con id {0} no existe
    usersBrain_err003 = 3 'El usuario con mail {0} no existe

    'tokensBrain
    tokensBrain_err000 = 0 'La contraseña introducida para el usuario {0} no es correcta.

    'APIloginImplementation
    APILoginImplementation_err000 = 0 'validación del hash incorrecta
    APILoginImplementation_err001 = 1 ' la petición ha expirado

    APILoginImplementation_err005 = 5 'el parámetro deviceBrand debe ser 'windows', 'iphone', 'android', o 'web'

    
    'api parameterValidations
    parameterValidations_err000 = 0 'el parámetro {0} no puede estar en blanco
    parameterValidations_err001 = 0 'el parámetro {0} debe ser un número

    'general
    general_err000 = 999 'Propiedad de sólo lectura
    general_err001 = 998 'Token no válido

End Enum
