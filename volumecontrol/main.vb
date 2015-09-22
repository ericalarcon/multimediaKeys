Imports System.Runtime.InteropServices
Imports System.Diagnostics

Public Class main
#Region "volume"
    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const APPCOMMAND_VOLUME_UP As Integer = &HA0000
    Private Const APPCOMMAND_VOLUME_DOWN As Integer = &H90000
    Private Const WM_APPCOMMAND As Integer = &H319


    <DllImport("user32.dll")> _
    Public Shared Function SendMessageW(ByVal hWnd As IntPtr, _
               ByVal Msg As Integer, ByVal wParam As IntPtr, _
               ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Sub mute()
        SendMessageW(Me.Handle, WM_APPCOMMAND, _
                      Me.Handle, New IntPtr(APPCOMMAND_VOLUME_MUTE))
    End Sub

    Private Sub decreaseVolume()
        SendMessageW(Me.Handle, WM_APPCOMMAND, _
                     Me.Handle, New IntPtr(APPCOMMAND_VOLUME_DOWN))
    End Sub

    Private Sub increaseVolume()
        SendMessageW(Me.Handle, WM_APPCOMMAND, _
                     Me.Handle, New IntPtr(APPCOMMAND_VOLUME_UP))
    End Sub


#End Region

    Private WithEvents mHook As MouseHook

    Public Const MOD_ALT As Integer = &H1 'Alt key
    Public Const WM_HOTKEY As Integer = &H312
    Public Const MOD_CTRL As Integer = &H2 'ctrl key
    Public Const SHIFT_CTRL As Integer = &H4 'ctrl key

    <DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer, ByVal fsModifiers As Integer, _
                        ByVal vk As Integer) As Integer
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer) As Integer
    End Function


    Private Sub waitKeysUp(modifiername As String, Optional keyvalue As String = "")
        Dim modifier As Integer = 0
        Select Case modifiername
            Case "Ninguno"
                modifier = 0
            Case "ALT"
                modifier = KeyboardSimulator.VK.MENU
            Case "CTRL"
                modifier = KeyboardSimulator.VK.CONTROL
            Case "SHIFT"
                modifier = KeyboardSimulator.VK.SHIFT
            Case Else
                modifier = 0
        End Select

        If keyvalue <> "" Then
            While KeyboardSimulator.GetAsyncKeyState(keyvalue) <> 0
                Threading.Thread.Sleep(100)
            End While
        End If

        If modifier <> 0 Then
            While KeyboardSimulator.GetAsyncKeyState(modifier) <> 0
                Threading.Thread.Sleep(100)
            End While
        End If

    End Sub

    Private Function checkIfKeyIsPressed(modifiername As String) As Boolean
        Select Case modifiername
            Case "Ninguno"
                Return True
            Case "ALT"
                modifier = KeyboardSimulator.VK.MENU
            Case "CTRL"
                modifier = KeyboardSimulator.VK.CONTROL
            Case "SHIFT"
                modifier = KeyboardSimulator.VK.SHIFT
            Case Else
                Return True
        End Select
        Dim returnvalue As Boolean = KeyboardSimulator.GetAsyncKeyState(modifier) <> 0
        KeyboardSimulator.SimulateKeyUp(modifier)
        Return returnvalue
    End Function

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToString)
                Case "100"
                    increaseVolume()
                Case "101"
                    decreaseVolume()
                Case "102"
                    mute()
                Case "103"
                    KeyboardSimulator.SimulateKeyPress(Keys.MediaPlayPause)
                Case "104"
                    KeyboardSimulator.SimulateKeyPress(Keys.MediaNextTrack)
                Case "105"
                    KeyboardSimulator.SimulateKeyPress(Keys.MediaPreviousTrack)
                Case "106"

                    waitKeysUp(projectSettings.localSettings.taskViewShowModifierKeyboard, projectSettings.localSettings.taskViewShowKey)

                    KeyboardSimulator.SimulateKeyDown(Keys.LWin)
                    KeyboardSimulator.SimulateKeyDown(Keys.Tab)

                    KeyboardSimulator.SimulateKeyUp(Keys.LWin)
                    KeyboardSimulator.SimulateKeyUp(Keys.Tab)

                Case "107"
                    waitKeysUp(projectSettings.localSettings.taskViewRightModifierKeyboard, projectSettings.localSettings.taskViewRightKey)

                    KeyboardSimulator.SimulateKeyDown(Keys.LWin)
                    KeyboardSimulator.SimulateKeyDown(Keys.ControlKey)
                    KeyboardSimulator.SimulateKeyDown(Keys.Right)

                    KeyboardSimulator.SimulateKeyUp(Keys.LWin)
                    KeyboardSimulator.SimulateKeyUp(Keys.ControlKey)
                    KeyboardSimulator.SimulateKeyUp(Keys.Right)

                Case "108"
                    waitKeysUp(projectSettings.localSettings.taskViewLeftModifierKeyboard, projectSettings.localSettings.taskViewLeftKey)

                    KeyboardSimulator.SimulateKeyDown(Keys.LWin)
                    KeyboardSimulator.SimulateKeyDown(Keys.ControlKey)
                    KeyboardSimulator.SimulateKeyDown(Keys.Left)

                    KeyboardSimulator.SimulateKeyUp(Keys.LWin)
                    KeyboardSimulator.SimulateKeyUp(Keys.ControlKey)
                    KeyboardSimulator.SimulateKeyUp(Keys.Left)
                Case "200"

                    Process.Start("SnippingTool.exe")
                    While Process.GetProcessesByName("SnippingTool").Length = 0
                        Threading.Thread.Sleep(200)
                    End While
                    Threading.Thread.Sleep(200)
                    setFocusToProgram("SnippingTool")
                    Threading.Thread.Sleep(200)
                    SendKeys.SendWait("^(N)")

            End Select
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub checkIfNeedsToBeActive()
        If Not projectSettings.localSettings.multimediaKeysEnabled And Not projectSettings.localSettings.windows10TaskViewKeysEnabled Then
            Me.Close()
            Process.GetCurrentProcess().Kill()
        End If
        If projectSettings.localSettings.windows10TaskViewKeysEnabled Then
            mHook = New MouseHook
        End If
    End Sub
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindWindow( _
     ByVal lpClassName As String, _
     ByVal lpWindowName As String) As IntPtr
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Sub setFocusToProgram(programnameWithoutExe As String)
        For Each app As Process In Process.GetProcessesByName(programnameWithoutExe)
            Dim theHandle As IntPtr = FindWindow(Nothing, app.MainWindowTitle)
            If theHandle <> IntPtr.Zero Then
                SetForegroundWindow(theHandle)
            End If
        Next
    End Sub
    Public Sub registrarKeys()
        checkIfNeedsToBeActive()

        Dim modifier1 As String = 0
        Dim modifier2 As String = 0
        Dim modifier3 As String = 0
        Dim modifier4 As String = 0
        Dim modifier5 As String = 0
        Dim modifier6 As String = 0

        Dim modifier7 As String = 0
        Dim modifier8 As String = 0
        Dim modifier9 As String = 0
        Dim modifier10 As String = 0
        Dim modifier11 As String = 0
        Dim modifier12 As String = 0

        Select Case projectSettings.localSettings.UpVolumeModifier
            Case "Ninguno"
                modifier1 = 0
            Case "ALT"
                modifier1 = MOD_ALT
            Case "CTRL"
                modifier1 = MOD_CTRL
            Case "SHIFT"
                modifier1 = SHIFT_CTRL
            Case Else
                modifier1 = 0
        End Select
        Select Case projectSettings.localSettings.DownVolumeModifier
            Case "Ninguno"
                modifier2 = 0
            Case "ALT"
                modifier2 = MOD_ALT
            Case "CTRL"
                modifier2 = MOD_CTRL
            Case "SHIFT"
                modifier2 = SHIFT_CTRL
            Case Else
                modifier2 = 0
        End Select
        Select Case projectSettings.localSettings.MuteModifier
            Case "Ninguno"
                modifier3 = 0
            Case "ALT"
                modifier3 = MOD_ALT
            Case "CTRL"
                modifier3 = MOD_CTRL
            Case "SHIFT"
                modifier3 = SHIFT_CTRL
            Case Else
                modifier3 = 0
        End Select
        Select Case projectSettings.localSettings.PauseModifier
            Case "Ninguno"
                modifier4 = 0
            Case "ALT"
                modifier4 = MOD_ALT
            Case "CTRL"
                modifier4 = MOD_CTRL
            Case "SHIFT"
                modifier4 = SHIFT_CTRL
            Case Else
                modifier4 = 0
        End Select
        Select Case projectSettings.localSettings.NextModifier
            Case "Ninguno"
                modifier5 = 0
            Case "ALT"
                modifier5 = MOD_ALT
            Case "CTRL"
                modifier5 = MOD_CTRL
            Case "SHIFT"
                modifier5 = SHIFT_CTRL
            Case Else
                modifier5 = 0
        End Select
        Select Case projectSettings.localSettings.PreviousModifier
            Case "Ninguno"
                modifier6 = 0
            Case "ALT"
                modifier6 = MOD_ALT
            Case "CTRL"
                modifier6 = MOD_CTRL
            Case "SHIFT"
                modifier6 = SHIFT_CTRL
            Case Else
                modifier6 = 0
        End Select

        '''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''
        Select Case projectSettings.localSettings.taskViewShowModifierKeyboard
            Case "Ninguno"
                modifier7 = 0
            Case "ALT"
                modifier7 = MOD_ALT
            Case "CTRL"
                modifier7 = MOD_CTRL
            Case "SHIFT"
                modifier7 = SHIFT_CTRL
            Case Else
                modifier7 = 0
        End Select
        Select Case projectSettings.localSettings.taskViewRightModifierKeyboard
            Case "Ninguno"
                modifier8 = 0
            Case "ALT"
                modifier8 = MOD_ALT
            Case "CTRL"
                modifier8 = MOD_CTRL
            Case "SHIFT"
                modifier8 = SHIFT_CTRL
            Case Else
                modifier8 = 0
        End Select
        Select Case projectSettings.localSettings.taskViewLeftModifierKeyboard
            Case "Ninguno"
                modifier9 = 0
            Case "ALT"
                modifier9 = MOD_ALT
            Case "CTRL"
                modifier9 = MOD_CTRL
            Case "SHIFT"
                modifier9 = SHIFT_CTRL
            Case Else
                modifier9 = 0
        End Select
        Select Case projectSettings.localSettings.taskViewShowModifierMouse
            Case "Ninguno"
                modifier10 = 0
            Case "ALT"
                modifier10 = MOD_ALT
            Case "CTRL"
                modifier10 = MOD_CTRL
            Case "SHIFT"
                modifier10 = SHIFT_CTRL
            Case Else
                modifier10 = 0
        End Select
        Select Case projectSettings.localSettings.taskViewRightModifierMouse
            Case "Ninguno"
                modifier11 = 0
            Case "ALT"
                modifier11 = MOD_ALT
            Case "CTRL"
                modifier11 = MOD_CTRL
            Case "SHIFT"
                modifier11 = SHIFT_CTRL
            Case Else
                modifier11 = 0
        End Select
        Select Case projectSettings.localSettings.taskViewLeftModifierMouse
            Case "Ninguno"
                modifier12 = 0
            Case "ALT"
                modifier12 = MOD_ALT
            Case "CTRL"
                modifier12 = MOD_CTRL
            Case "SHIFT"
                modifier12 = SHIFT_CTRL
            Case Else
                modifier12 = 0
        End Select
        ''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''
        If projectSettings.localSettings.multimediaKeysEnabled Then
            Try
                RegisterHotKey(Me.Handle, 100, modifier1, projectSettings.localSettings.UpVolumeKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 101, modifier2, projectSettings.localSettings.DownVolumeKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 102, modifier3, projectSettings.localSettings.MuteKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 103, modifier4, projectSettings.localSettings.PauseKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 104, modifier5, projectSettings.localSettings.NextKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 105, modifier6, projectSettings.localSettings.PreviousKey)
            Catch ex As Exception

            End Try
        End If

        If projectSettings.localSettings.windows10TaskViewKeysEnabled Then
            Try
                RegisterHotKey(Me.Handle, 106, modifier7, projectSettings.localSettings.taskViewShowKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 107, modifier8, projectSettings.localSettings.taskViewRightKey)
            Catch ex As Exception

            End Try

            Try
                RegisterHotKey(Me.Handle, 108, modifier9, projectSettings.localSettings.taskViewLeftKey)
            Catch ex As Exception

            End Try
        End If





        'Try
        '    If projectSettings.localSettings.ImprPantKeyName = "" Then
        '        RegisterHotKey(Me.Handle, 200, 0, Keys.PrintScreen)
        '    Else
        '        RegisterHotKey(Me.Handle, 200, 0, projectSettings.localSettings.ImprPantKey)
        '    End If
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub mHook_Mouse_Wheel_horizontal(ByVal ptLocat As System.Drawing.Point, ByVal Direction As MouseHook.Wheel_Direction) Handles mHook.Mouse_Wheel_horizontal
        If Direction = MouseHook.Wheel_Direction.WheelRight Then
            performActionForButton(projectSettings.localSettings.optionNames.Scroll_derecha)
        ElseIf Direction = MouseHook.Wheel_Direction.WheelLeft
            performActionForButton(projectSettings.localSettings.optionNames.Scroll_izquierda)
        End If

    End Sub


    Private Sub mHook_Mouse_Middle_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Middle_Up

        performActionForButton(projectSettings.localSettings.optionNames.Botón_central)


    End Sub

    Private Sub performActionForButton(button As projectSettings.localSettings.optionNames)
        For Each action As projectSettings.localSettings.mouseActions In projectSettings.localSettings.getActionsForButton(button)
            Select Case action
                Case projectSettings.localSettings.mouseActions.showDesktops

                    If checkIfKeyIsPressed(projectSettings.localSettings.taskViewShowModifierMouse) Then

                        showTaskView()
                    End If

                Case projectSettings.localSettings.mouseActions.nextDesktop

                    If checkIfKeyIsPressed(projectSettings.localSettings.taskViewRightModifierMouse) Then
                        showNextDesktop()
                    End If

                Case projectSettings.localSettings.mouseActions.previousDesktop
                    If checkIfKeyIsPressed(projectSettings.localSettings.taskViewLeftModifierMouse) Then
                        showPreviousDesktop()
                    End If

            End Select

        Next
    End Sub
    Private Sub showTaskView()
        KeyboardSimulator.SimulateKeyDown(Keys.LWin)
        KeyboardSimulator.SimulateKeyDown(Keys.Tab)

        KeyboardSimulator.SimulateKeyUp(Keys.LWin)
        KeyboardSimulator.SimulateKeyUp(Keys.Tab)
    End Sub

    Private Sub showNextDesktop()
        KeyboardSimulator.SimulateKeyDown(Keys.LWin)
        KeyboardSimulator.SimulateKeyDown(Keys.ControlKey)
        KeyboardSimulator.SimulateKeyDown(Keys.Right)

        KeyboardSimulator.SimulateKeyUp(Keys.LWin)
        KeyboardSimulator.SimulateKeyUp(Keys.ControlKey)
        KeyboardSimulator.SimulateKeyUp(Keys.Right)
        KeyboardSimulator.SimulateKeyUp(Keys.Left)
    End Sub

    Private Sub showPreviousDesktop()
        KeyboardSimulator.SimulateKeyDown(Keys.LWin)
        KeyboardSimulator.SimulateKeyDown(Keys.ControlKey)
        KeyboardSimulator.SimulateKeyDown(Keys.Left)


        KeyboardSimulator.SimulateKeyUp(Keys.LWin)
        KeyboardSimulator.SimulateKeyUp(Keys.ControlKey)
        KeyboardSimulator.SimulateKeyUp(Keys.Right)
        KeyboardSimulator.SimulateKeyUp(Keys.Left)
    End Sub

    Private Sub mHook_Mouse_Left_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Left_Up
        performActionForButton(projectSettings.localSettings.optionNames.Botón_izquierdo)



    End Sub

    Private Sub mHook_Mouse_Right_Up(ByVal ptLocat As System.Drawing.Point) Handles mHook.Mouse_Right_Up
        performActionForButton(projectSettings.localSettings.optionNames.Botón_derecho)

    End Sub

    Private Sub mHook_Mouse_Wheel(ByVal ptLocat As System.Drawing.Point, ByVal Direction As MouseHook.Wheel_Direction) Handles mHook.Mouse_Wheel
        If Direction = MouseHook.Wheel_Direction.WheelUp Then
            performActionForButton(projectSettings.localSettings.optionNames.Scroll_arriba)
        ElseIf Direction = MouseHook.Wheel_Direction.WheelDown
            performActionForButton(projectSettings.localSettings.optionNames.Scroll_abajo)
        End If




    End Sub

End Class

