Public Class localSettings
    Shared settings As settingsHandler = settingsHandler.defaultInLocalApplicationData

    Shared Sub deleteAllSettings()
        settings.deleteAllSettings()
    End Sub

#Region "Propiedades"
    Shared Property multimediaKeysEnabled As Boolean
        Get
            Return settings.getValue("multimediaKeysEnabled")
        End Get
        Set(value As Boolean)
            settings.setValue("multimediaKeysEnabled", value)
        End Set
    End Property
    Shared Property windows10TaskViewKeysEnabled As Boolean
        Get
            Return settings.getValue("windows10TaskViewKeysEnabled")
        End Get
        Set(value As Boolean)
            settings.setValue("windows10TaskViewKeysEnabled", value)
        End Set
    End Property



    Shared Property UpVolumeModifier As String
        Get
            Return settings.getValue("UpVolumeModifier")
        End Get
        Set(value As String)
            settings.setValue("UpVolumeModifier", value)
        End Set
    End Property
    Shared Property DownVolumeModifier As String
        Get
            Return settings.getValue("DownVolumeModifier")
        End Get
        Set(value As String)
            settings.setValue("DownVolumeModifier", value)
        End Set
    End Property
    Shared Property MuteModifier As String
        Get
            Return settings.getValue("MuteModifier")
        End Get
        Set(value As String)
            settings.setValue("MuteModifier", value)
        End Set
    End Property
    Shared Property PauseModifier As String
        Get
            Return settings.getValue("PauseModifier")
        End Get
        Set(value As String)
            settings.setValue("PauseModifier", value)
        End Set
    End Property
    Shared Property NextModifier As String
        Get
            Return settings.getValue("NextModifier")
        End Get
        Set(value As String)
            settings.setValue("NextModifier", value)
        End Set
    End Property
    Shared Property PreviousModifier As String
        Get
            Return settings.getValue("PreviousModifier")
        End Get
        Set(value As String)
            settings.setValue("PreviousModifier", value)
        End Set
    End Property




    Shared Property UpVolumeKey As Integer
        Get
            Return settings.getValue("UpVolumeKey")
        End Get
        Set(value As Integer)
            settings.setValue("UpVolumeKey", value)
        End Set
    End Property
    Shared Property DownVolumeKey As Integer
        Get
            Return settings.getValue("DownVolumeKey")
        End Get
        Set(value As Integer)
            settings.setValue("DownVolumeKey", value)
        End Set
    End Property
    Shared Property MuteKey As Integer
        Get
            Return settings.getValue("MuteKey")
        End Get
        Set(value As Integer)
            settings.setValue("MuteKey", value)
        End Set
    End Property
    Shared Property PauseKey As Integer
        Get
            Return settings.getValue("PauseKey")
        End Get
        Set(value As Integer)
            settings.setValue("PauseKey", value)
        End Set
    End Property
    Shared Property NextKey As Integer
        Get
            Return settings.getValue("NextKey")
        End Get
        Set(value As Integer)
            settings.setValue("NextKey", value)
        End Set
    End Property
    Shared Property PreviousKey As Integer
        Get
            Return settings.getValue("PreviousKey")
        End Get
        Set(value As Integer)
            settings.setValue("PreviousKey", value)
        End Set
    End Property
    Shared Property ImprPantKey As Integer
        Get
            Return settings.getValue("ImprPantKey")
        End Get
        Set(value As Integer)
            settings.setValue("ImprPantKey", value)
        End Set
    End Property




    Shared Property UpVolumeKeyName As String
        Get
            Return settings.getValue("UpVolumeKeyName")
        End Get
        Set(value As String)
            settings.setValue("UpVolumeKeyName", value)
        End Set
    End Property
    Shared Property DownVolumeKeyName As String
        Get
            Return settings.getValue("DownVolumeKeyName")
        End Get
        Set(value As String)
            settings.setValue("DownVolumeKeyName", value)
        End Set
    End Property
    Shared Property MuteKeyName As String
        Get
            Return settings.getValue("MuteKeyName")
        End Get
        Set(value As String)
            settings.setValue("MuteKeyName", value)
        End Set
    End Property
    Shared Property PauseKeyName As String
        Get
            Return settings.getValue("PauseKeyName")
        End Get
        Set(value As String)
            settings.setValue("PauseKeyName", value)
        End Set
    End Property
    Shared Property NextKeyName As String
        Get
            Return settings.getValue("NextKeyName")
        End Get
        Set(value As String)
            settings.setValue("NextKeyName", value)
        End Set
    End Property
    Shared Property PreviousKeyName As String
        Get
            Return settings.getValue("PreviousKeyName")
        End Get
        Set(value As String)
            settings.setValue("PreviousKeyName", value)
        End Set
    End Property
    Shared Property ImprPantKeyName As String
        Get
            Return settings.getValue("ImprPantKeyName")
        End Get
        Set(value As String)
            settings.setValue("ImprPantKeyName", value)
        End Set
    End Property







    Shared Property taskViewShowModifierKeyboard As String
        Get
            Return settings.getValue("taskViewShowModifierKeyboard")
        End Get
        Set(value As String)
            settings.setValue("taskViewShowModifierKeyboard", value)
        End Set
    End Property
    Shared Property taskViewShowModifierMouse As String
        Get
            Return settings.getValue("taskViewShowModifierMouse")
        End Get
        Set(value As String)
            settings.setValue("taskViewShowModifierMouse", value)
        End Set
    End Property
    Shared Property taskViewRightModifierKeyboard As String
        Get
            Return settings.getValue("taskViewRightModifierKeyboard")
        End Get
        Set(value As String)
            settings.setValue("taskViewRightModifierKeyboard", value)
        End Set
    End Property
    Shared Property taskViewLeftModifierKeyboard As String
        Get
            Return settings.getValue("taskViewLeftModifierKeyboard")
        End Get
        Set(value As String)
            settings.setValue("taskViewLeftModifierKeyboard", value)
        End Set
    End Property
    Shared Property taskViewRightModifierMouse As String
        Get
            Return settings.getValue("taskViewRightModifierMouse")
        End Get
        Set(value As String)
            settings.setValue("taskViewRightModifierMouse", value)
        End Set
    End Property
    Shared Property taskViewLeftModifierMouse As String
        Get
            Return settings.getValue("taskViewLeftModifierMouse")
        End Get
        Set(value As String)
            settings.setValue("taskViewLeftModifierMouse", value)
        End Set
    End Property


    Shared Property taskViewShowKey As String
        Get
            Return settings.getValue("taskViewShowKey")
        End Get
        Set(value As String)
            settings.setValue("taskViewShowKey", value)
        End Set
    End Property
    Shared Property taskViewRightKey As String
        Get
            Return settings.getValue("taskViewRightKey")
        End Get
        Set(value As String)
            settings.setValue("taskViewRightKey", value)
        End Set
    End Property
    Shared Property taskViewLeftKey As String
        Get
            Return settings.getValue("taskViewLeftKey")
        End Get
        Set(value As String)
            settings.setValue("taskViewLeftKey", value)
        End Set
    End Property

    Shared Property taskViewShowKeyName As String
        Get
            Return settings.getValue("taskViewShowKeyName")
        End Get
        Set(value As String)
            settings.setValue("taskViewShowKeyName", value)
        End Set
    End Property
    Shared Property taskViewRightKeyName As String
        Get
            Return settings.getValue("taskViewRightKeyName")
        End Get
        Set(value As String)
            settings.setValue("taskViewRightKeyName", value)
        End Set
    End Property
    Shared Property taskViewLeftKeyName As String
        Get
            Return settings.getValue("taskViewLeftKeyName")
        End Get
        Set(value As String)
            settings.setValue("taskViewLeftKeyName", value)
        End Set
    End Property


    Shared Property taskViewShowMousebutton As String
        Get
            Return settings.getValue("taskViewShowMousebutton")
        End Get
        Set(value As String)
            settings.setValue("taskViewShowMousebutton", value)
        End Set
    End Property
    Shared Property taskViewRightMousebutton As String
        Get
            Return settings.getValue("taskViewRightMousebutton")
        End Get
        Set(value As String)
            settings.setValue("taskViewRightMousebutton", value)
        End Set
    End Property
    Shared Property taskViewLeftMousebutton As String
        Get
            Return settings.getValue("taskViewLeftMousebutton")
        End Get
        Set(value As String)
            settings.setValue("taskViewLeftMousebutton", value)
        End Set
    End Property



    Shared ReadOnly Property getActionsForButton(opt As optionNames) As List(Of mouseActions)
        Get
            Dim optionName As String = opt.ToString().Replace("_", " ")
            Dim value As List(Of mouseActions) = New List(Of mouseActions)

            If taskViewShowMousebutton = optionName Then
                value.Add(mouseActions.showDesktops)
            End If

            If taskViewRightMousebutton = optionName Then
                value.Add(mouseActions.nextDesktop)
            End If

            If taskViewLeftMousebutton = optionName Then
                value.Add(mouseActions.previousDesktop)
            End If

            Return value
        End Get
    End Property

    Public Enum optionNames
        Botón_derecho
        Botón_izquierdo
        Botón_central
        Scroll_derecha
        Scroll_izquierda
        Scroll_arriba
        Scroll_abajo
    End Enum
    Public Enum mouseActions
        showDesktops
        nextDesktop
        previousDesktop
    End Enum

#End Region



End Class
