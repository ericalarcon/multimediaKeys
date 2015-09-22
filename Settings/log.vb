Public Class log
    Private strConexion As String
    Private Shared settings As settingsHandler = settingsHandler.defaultInCommonApplicationData
    Public Shared Sub Anotacion(ByVal Mensaje As Exception)
        Try
            Dim rutaCarpeta As String = settings.SETTINGS_FOLDER
            Dim rutaFichero As String = rutaCarpeta + "\log.txt"

            If Not IO.Directory.Exists(rutaCarpeta) Then
                IO.Directory.CreateDirectory(rutaCarpeta)
            End If
            If Not IO.File.Exists(rutaFichero) Then
                IO.File.Create(rutaFichero)

            End If

            Dim fi As New IO.FileInfo(rutaFichero)
            If fi.Length > 1048576 Then '(1048576 = 1MB)
                IO.File.Delete(rutaFichero)
            End If
            IO.File.AppendAllText(rutaFichero, My.Application.Info.ProductName + " - " + Date.Now + ": " + Mensaje.Message + vbNewLine + _
                                      Mensaje.StackTrace + vbNewLine + "____________________________" + vbNewLine)

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub Anotacion(ByVal Mensaje As String)
        Try
            Dim rutaCarpeta As String = settings.SETTINGS_FOLDER
            Dim rutaFichero As String = rutaCarpeta + "\log.txt"

            If Not IO.Directory.Exists(rutaCarpeta) Then
                IO.Directory.CreateDirectory(rutaCarpeta)
            End If
            If Not IO.File.Exists(rutaFichero) Then
                IO.File.Create(rutaFichero)

            End If

            Dim fi As New IO.FileInfo(rutaFichero)
            If fi.Length > 1048576 Then '(1048576 = 1MB)
                IO.File.Delete(rutaFichero)
            End If
            IO.File.AppendAllText(rutaFichero, My.Application.Info.ProductName + " - " + Date.Now + ": " + Mensaje + vbNewLine + _
                                      "____________________________" + vbNewLine)
        Catch ex As Exception

        End Try
    End Sub
End Class
