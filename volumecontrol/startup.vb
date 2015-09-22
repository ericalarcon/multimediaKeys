Module startup
    Sub main()
        If Process.GetProcessesByName(My.Application.Info.AssemblyName).Length > 1 Then
            Application.Exit()
        End If

        Dim program As New main
        program.registrarKeys()
        Application.Run()

    End Sub
End Module
