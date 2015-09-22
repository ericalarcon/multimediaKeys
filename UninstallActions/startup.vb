Imports Microsoft.Win32

Module startup
    Sub main()
        For Each p As Process In Process.GetProcessesByName("multimediaKeysDaemon")
            p.Kill()
        Next
        For Each p As Process In Process.GetProcessesByName("multimediaKeysConfig")
            p.Kill()
        Next
        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AeDebug", "UserDebuggerHotKey", 0, RegistryValueKind.DWord) ' set new value, overwrite any other, creates key if not there.
    End Sub
End Module
