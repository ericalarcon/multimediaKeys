Imports Microsoft.Win32

Module startup
    Sub main()
        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AeDebug", "UserDebuggerHotKey", 16687, RegistryValueKind.DWord) ' set new value, overwrite any other, creates key if not there.
    End Sub
End Module
