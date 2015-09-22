Public Class timestamp
    Public Shared Function GetUnixTimestamp() As Double
        Return (DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds
    End Function
End Class
