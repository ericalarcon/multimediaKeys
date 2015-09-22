Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class sha256
    Public Shared Function GetShaHash(ByVal input As String) As String
        Using shaHash As SHA256Managed = SHA256Managed.Create
            ' Convert the input string to a byte array and compute the hash. 
            Dim data As Byte() = shaHash.ComputeHash(Text.Encoding.UTF8.GetBytes(input))

            ' Create a new Stringbuilder to collect the bytes 
            ' and create a string. 
            Dim sBuilder As New Text.StringBuilder()

            ' Loop through each byte of the hashed data  
            ' and format each one as a hexadecimal string. 
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string. 
            Return sBuilder.ToString()
        End Using
    End Function

    Public Shared Function GetFileSha(ByVal filePath As String) As String
        Dim sha As SHA256CryptoServiceProvider = New SHA256CryptoServiceProvider
        Dim f As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        f = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        sha.ComputeHash(f)
        f.Close()

        Dim hash As Byte() = sha.Hash
        Dim buff As StringBuilder = New StringBuilder
        Dim hashByte As Byte

        For Each hashByte In hash
            buff.Append(String.Format("{0:X2}", hashByte))
        Next

        Dim shastring As String
        shastring = buff.ToString()

        Return shastring

    End Function
End Class
