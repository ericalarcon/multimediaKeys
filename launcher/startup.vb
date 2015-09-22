Module startup
    Sub main()
        Try
            Process.Start(projectSettings.localSettings.programPath)
        Catch ex As Exception

        End Try

    End Sub
End Module
