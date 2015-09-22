'los objetos normales del framework (string, integer, listas de strings, diccionarios de strings) 
'ya son serializables. Si se crea una clase propia y se desea que sea serializable, hay que añadir:
'<Serializable()> _
'antes de la declaración de la clase (antes del  Public Class xxx)

Public Class serializer
    Public Shared Function objectToString(value As Object) As String
        Try
            Dim a As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

            Using stream As New IO.MemoryStream
                If value.GetType().Name = "String" Then If value = Nothing Then value = ""
                a.Serialize(stream, value)

                Dim buffer() As Byte = stream.ToArray()
                Dim result As String = Convert.ToBase64String(buffer)

                Return result
            End Using
        Catch ex As Exception
            Return ""
        End Try
        
    End Function

    Public Shared Function stringToObject(value As String) As Object
        Dim serializedValue As String = value
        Dim serializedBuffer As Byte() = Convert.FromBase64String(serializedValue)

        Dim stream As New IO.MemoryStream
        stream.Write(serializedBuffer, 0, serializedBuffer.Length)

        Dim a As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Using stream
            stream.Position = 0
            Return a.Deserialize(stream)
        End Using
    End Function
End Class
