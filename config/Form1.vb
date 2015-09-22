Public Class config
    Property daemonExecutableName As String = "multimediaKeysDaemon"
    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        killProgram()

        Me.cbEnable.Checked = projectSettings.localSettings.multimediaKeysEnabled
        Me.cbEnableTaskView.Checked = projectSettings.localSettings.windows10TaskViewKeysEnabled
        'Me.TabControl1.TabPages.RemoveAt(1)

        If projectSettings.localSettings.UpVolumeModifier = "" Then projectSettings.localSettings.UpVolumeModifier = "Ninguno"
        If projectSettings.localSettings.DownVolumeModifier = "" Then projectSettings.localSettings.DownVolumeModifier = "Ninguno"
        If projectSettings.localSettings.MuteModifier = "" Then projectSettings.localSettings.MuteModifier = "Ninguno"
        If projectSettings.localSettings.PauseModifier = "" Then projectSettings.localSettings.PauseModifier = "Ninguno"
        If projectSettings.localSettings.NextModifier = "" Then projectSettings.localSettings.NextModifier = "Ninguno"
        If projectSettings.localSettings.PreviousModifier = "" Then projectSettings.localSettings.PreviousModifier = "Ninguno"


        If projectSettings.localSettings.taskViewShowModifierKeyboard = "" Then projectSettings.localSettings.taskViewShowModifierKeyboard = "Ninguno"
        If projectSettings.localSettings.taskViewShowModifierMouse = "" Then projectSettings.localSettings.taskViewShowModifierMouse = "Ninguno"
        If projectSettings.localSettings.taskViewRightModifierKeyboard = "" Then projectSettings.localSettings.taskViewRightModifierKeyboard = "Ninguno"
        If projectSettings.localSettings.taskViewRightModifierMouse = "" Then projectSettings.localSettings.taskViewRightModifierMouse = "Ninguno"
        If projectSettings.localSettings.taskViewLeftModifierKeyboard = "" Then projectSettings.localSettings.taskViewLeftModifierKeyboard = "Ninguno"
        If projectSettings.localSettings.taskViewLeftModifierMouse = "" Then projectSettings.localSettings.taskViewLeftModifierMouse = "Ninguno"

        If projectSettings.localSettings.taskViewShowMousebutton = "" Then projectSettings.localSettings.taskViewShowMousebutton = "-Selecciona un botón-"
        If projectSettings.localSettings.taskViewRightMousebutton = "" Then projectSettings.localSettings.taskViewRightMousebutton = "-Selecciona un botón-"
        If projectSettings.localSettings.taskViewLeftMousebutton = "" Then projectSettings.localSettings.taskViewLeftMousebutton = "-Selecciona un botón-"

        cbModificadorSubirVolumen.Text = projectSettings.localSettings.UpVolumeModifier
        cbModificadorbajarVolumen.Text = projectSettings.localSettings.DownVolumeModifier
        cbModificadorMute.Text = projectSettings.localSettings.MuteModifier
        cbModificadorPausaVolumen.Text = projectSettings.localSettings.PauseModifier
        cbModificadorSiguiente.Text = projectSettings.localSettings.NextModifier
        cbModificadorAnterior.Text = projectSettings.localSettings.PreviousModifier

        cbModificadorMostrarTareasTeclado.Text = projectSettings.localSettings.taskViewShowModifierKeyboard
        cbModificadorMostrarTareasRaton.Text = projectSettings.localSettings.taskViewShowModifierMouse
        cbModificadorAnteriorTeclado.Text = projectSettings.localSettings.taskViewLeftModifierKeyboard
        cbModificadorAnteriorRaton.Text = projectSettings.localSettings.taskViewLeftModifierMouse
        cbModificadorSiguienteTeclado.Text = projectSettings.localSettings.taskViewRightModifierKeyboard
        cbModificadorSiguienteRaton.Text = projectSettings.localSettings.taskViewRightModifierMouse

        tbTeclaSubirVolumen.Text = projectSettings.localSettings.UpVolumeKeyName
        tbTeclaBajarVolumen.Text = projectSettings.localSettings.DownVolumeKeyName
        tbTeclaSilenciar.Text = projectSettings.localSettings.MuteKeyName
        tbTeclaPausa.Text = projectSettings.localSettings.PauseKeyName
        tbTeclaSiguiente.Text = projectSettings.localSettings.NextKeyName
        tbTeclaAnterior.Text = projectSettings.localSettings.PreviousKeyName

        tbTeclaTareas.Text = projectSettings.localSettings.taskViewShowKeyName
        tbTeclaEscritorioSiguiente.Text = projectSettings.localSettings.taskViewRightKeyName
        tbTeclaEscritorioAnterior.Text = projectSettings.localSettings.taskViewLeftKeyName

        cbTareasRaton.Text = projectSettings.localSettings.taskViewShowMousebutton
        cbTareasSiguiente.Text = projectSettings.localSettings.taskViewRightMousebutton
        cbTareasAnterior.Text = projectSettings.localSettings.taskViewLeftMousebutton

    End Sub



    Private Sub cbModificadorSubirVolumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorSubirVolumen.SelectedIndexChanged
        Try
            projectSettings.localSettings.UpVolumeModifier = cbModificadorSubirVolumen.Text
        Catch ex As Exception

        End Try


    End Sub
    Private Sub cbModificadorbajarVolumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorbajarVolumen.SelectedIndexChanged
        Try
            projectSettings.localSettings.DownVolumeModifier = cbModificadorbajarVolumen.Text
        Catch ex As Exception

        End Try


    End Sub
    Private Sub cbModificadorMute_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorMute.SelectedIndexChanged
        Try
            projectSettings.localSettings.MuteModifier = cbModificadorMute.Text
        Catch ex As Exception

        End Try


    End Sub
    Private Sub cbModificadorPausaVolumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorPausaVolumen.SelectedIndexChanged
        Try
            projectSettings.localSettings.PauseModifier = cbModificadorPausaVolumen.Text
        Catch ex As Exception

        End Try


    End Sub
    Private Sub cbModificadorSiguiente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorSiguiente.SelectedIndexChanged
        Try
            projectSettings.localSettings.NextModifier = cbModificadorSiguiente.Text
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cbModificadorAnterior_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorAnterior.SelectedIndexChanged
        Try
            projectSettings.localSettings.PreviousModifier = cbModificadorAnterior.Text
        Catch ex As Exception

        End Try


    End Sub


    Private Sub tbTeclaSubirVolumen_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaSubirVolumen.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.UpVolumeKey, projectSettings.localSettings.UpVolumeKeyName, sender)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tbTeclaBajarVolumen_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaBajarVolumen.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.DownVolumeKey, projectSettings.localSettings.DownVolumeKeyName, sender)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tbTeclaSilenciar_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaSilenciar.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.MuteKey, projectSettings.localSettings.MuteKeyName, sender)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tbTeclaPausa_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaPausa.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.PauseKey, projectSettings.localSettings.PauseKeyName, sender)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tbTeclaSiguiente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaSiguiente.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.NextKey, projectSettings.localSettings.NextKeyName, sender)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tbTeclaAnterior_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaAnterior.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.PreviousKey, projectSettings.localSettings.PreviousKeyName, sender)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub tbTeclaImprPant_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            keyPressedAction(e, projectSettings.localSettings.ImprPantKey, projectSettings.localSettings.ImprPantKeyName, sender)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub keyPressedAction(e As KeyEventArgs, ByRef settingKey As Object, ByRef settingKeyName As Object, tb As TextBox)
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Back Then
            tb.Text = ""
            settingKey = -1
            settingKeyName = ""
            Exit Sub
        End If
        tb.Text = e.KeyCode.ToString
        settingKey = e.KeyCode
        settingKeyName = e.KeyCode.ToString
        tb.Select(0, tb.Text.Length)
    End Sub
    Private Sub restartProgram()
#If DEBUG Then
#Else
    Dim ruta As String = Environment.CurrentDirectory
        ruta += "\"+daemonExecutableName+".exe"

        For Each p As Process In Process.GetProcessesByName(daemonExecutableName)
            p.Kill()
        Next


    Shell(ruta)
#End If
       
    End Sub
    Private Sub killProgram()
#If DEBUG Then
#Else
        For Each p As Process In Process.GetProcessesByName(daemonExecutableName)
            p.Kill()
        Next
#End If

    End Sub

    Private Sub cbEnable_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnable.CheckedChanged
        Me.panelMultimediaConfig.Enabled = cbEnable.Checked
        projectSettings.localSettings.multimediaKeysEnabled = cbEnable.Checked



    End Sub

    Private Sub config_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        restartProgram()

    End Sub

    Private Sub cbEnableTaskView_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnableTaskView.CheckedChanged
        Me.panelTaskViewConfig.Enabled = cbEnableTaskView.Checked
        projectSettings.localSettings.windows10TaskViewKeysEnabled = cbEnableTaskView.Checked
    End Sub

    Private Sub tbTeclaTareas_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaTareas.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.taskViewShowKey, projectSettings.localSettings.taskViewShowKeyName, sender)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbTeclaEscritorioSiguiente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaEscritorioSiguiente.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.taskViewRightKey, projectSettings.localSettings.taskViewRightKeyName, sender)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbTeclaEscritorioAnterior_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTeclaEscritorioAnterior.KeyDown
        Try
            keyPressedAction(e, projectSettings.localSettings.taskViewLeftKey, projectSettings.localSettings.taskViewLeftKeyName, sender)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbTareasRaton_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTareasRaton.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewShowMousebutton = cbTareasRaton.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbTareasSiguiente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTareasSiguiente.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewRightMousebutton = cbTareasSiguiente.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbTareasAnterior_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTareasAnterior.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewLeftMousebutton = cbTareasAnterior.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbModificadorMostrarTareasTeclado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorMostrarTareasTeclado.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewShowModifierKeyboard = cbModificadorMostrarTareasTeclado.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbModificadorSiguienteTeclado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorSiguienteTeclado.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewRightModifierKeyboard = cbModificadorSiguienteTeclado.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbModificadorAnteriorTeclado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorAnteriorTeclado.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewLeftModifierKeyboard = cbModificadorAnteriorTeclado.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbModificadorMostrarTareasRaton_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorMostrarTareasRaton.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewShowModifierMouse = cbModificadorMostrarTareasRaton.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbModificadorSiguienteRaton_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorSiguienteRaton.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewRightModifierMouse = cbModificadorSiguienteRaton.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbModificadorAnteriorRaton_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModificadorAnteriorRaton.SelectedIndexChanged
        Try
            projectSettings.localSettings.taskViewLeftModifierMouse = cbModificadorAnteriorRaton.Text
        Catch ex As Exception

        End Try
    End Sub
End Class
