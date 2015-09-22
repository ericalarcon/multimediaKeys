Imports System.Management

Public Class pcFingerprint
    Public Shared Function getFingerprint() As String
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
        Dim managementObjects As ManagementObjectCollection = searcher.[Get]()
        Dim returnvalue As String = sha256.GetShaHash("pimpam").Substring(0, 5)
        For Each obj As ManagementObject In managementObjects
            If obj("SerialNumber") IsNot Nothing Then
                Dim serial As String = obj("SerialNumber").ToString()

                returnvalue += serial
            End If
        Next

        Return returnvalue
    End Function

 
End Class
