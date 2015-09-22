Imports System.Net.Mail

Public Class mailSender
    Shared Property fromMail As String = "soporte@asistenciatecnica.net"
    Shared Property credentialUserName As String = "soporte@asistenciatecnica.net"
    Shared Property credentialPassword As String = "69.s0p@"
    Shared Property smtpServer As String = "smtp.edorteam.com"


    Public Shared Sub sendMail(ByVal sendToAdress As String, ByVal subject As String, ByVal htmlbody As String)
        Try
            Dim strsubject As String = subject

            Dim MailMsg As New MailMessage(New MailAddress(fromMail), New MailAddress(sendToAdress))

            MailMsg.Subject = strsubject.Trim()
            MailMsg.Body = htmlbody

            MailMsg.Priority = MailPriority.Normal
            MailMsg.IsBodyHtml = True

            ' crear la variable de "conexion"
            Dim SmtpMail As New SmtpClient


            ' enviar datos login
            Dim theCredential As New System.Net.NetworkCredential(credentialUserName, credentialPassword)
            SmtpMail.Credentials = theCredential

            ' indicar el host
            SmtpMail.Host = smtpServer
            SmtpMail.Send(MailMsg)


        Catch ex As Exception


        End Try
    End Sub


End Class
