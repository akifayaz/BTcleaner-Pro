<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home
    Inherits System.Windows.Forms.Form

    'Form, bileşen listesini temizlemeyi bırakmayı geçersiz kılar.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form Tasarımcısı tarafından gerektirilir
    Private components As System.ComponentModel.IContainer

    'NOT: Aşağıdaki yordam Windows Form Tasarımcısı için gereklidir
    'Windows Form Tasarımcısı kullanılarak değiştirilebilir.  
    'Kod düzenleyicisini kullanarak değiştirmeyin.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(home))
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        PictureBox1 = New PictureBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Guna2ProgressBar1 = New Guna.UI2.WinForms.Guna2ProgressBar()
        clbGlobal = New CheckedListBox()
        clbPerUser = New CheckedListBox()
        clbUsers = New CheckedListBox()
        btnClean = New Guna.UI2.WinForms.Guna2Button()
        btnCancel = New Guna.UI2.WinForms.Guna2Button()
        progbarGlobal = New Guna.UI2.WinForms.Guna2ProgressBar()
        Panel1 = New Panel()
        btnAdvanced = New Button()
        chkDeleteOrphans = New CheckBox()
        chkDeleteInvalid = New CheckBox()
        chkCheckValid = New CheckBox()
        btnConnect = New Button()
        txtHost = New TextBox()
        rbRemote = New RadioButton()
        rbLocal = New RadioButton()
        Panel2 = New Panel()
        rbSelected = New RadioButton()
        rbAll = New RadioButton()
        txtLog = New Guna.UI2.WinForms.Guna2TextBox()
        Label1 = New Label()
        NotifyIcon1 = New NotifyIcon(components)
        PictureBox2 = New PictureBox()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.trash
        PictureBox1.Location = New Point(10, 168)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(54, 41)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 21
        PictureBox1.TabStop = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.White
        Label8.Location = New Point(65, 168)
        Label8.Name = "Label8"
        Label8.Size = New Size(264, 38)
        Label8.TabIndex = 20
        Label8.Text = "Gereksiz Dosyalar - "
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(331, 171)
        Label7.Name = "Label7"
        Label7.Size = New Size(77, 38)
        Label7.TabIndex = 19
        Label7.Text = "X GB"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(340, 105)
        Label6.Name = "Label6"
        Label6.Size = New Size(163, 25)
        Label6.TabIndex = 18
        Label6.Text = "boş alan: XX,XX GB"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(11, 105)
        Label5.Name = "Label5"
        Label5.Size = New Size(85, 25)
        Label5.TabIndex = 17
        Label5.Text = "kullanılan"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(309, 21)
        Label4.Name = "Label4"
        Label4.Size = New Size(91, 46)
        Label4.TabIndex = 16
        Label4.Text = "X GB"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(74, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(246, 46)
        Label3.TabIndex = 15
        Label3.Text = "Yerel Disk (C) - "
        ' 
        ' Guna2ProgressBar1
        ' 
        Guna2ProgressBar1.CustomizableEdges = CustomizableEdges1
        Guna2ProgressBar1.Location = New Point(12, 78)
        Guna2ProgressBar1.Name = "Guna2ProgressBar1"
        Guna2ProgressBar1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2ProgressBar1.Size = New Size(491, 24)
        Guna2ProgressBar1.TabIndex = 14
        Guna2ProgressBar1.Text = "Guna2ProgressBar1"
        Guna2ProgressBar1.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        ' 
        ' clbGlobal
        ' 
        clbGlobal.BackColor = Color.Black
        clbGlobal.BorderStyle = BorderStyle.None
        clbGlobal.ForeColor = Color.White
        clbGlobal.FormattingEnabled = True
        clbGlobal.Items.AddRange(New Object() {"$Recycle.bin", "PerfLogs", "temp", "Windows\Prefetch", "Windows\System32\winevt\Logs", "Windows\System32\spool\PRINTERS", "Windows\temp"})
        clbGlobal.Location = New Point(394, 523)
        clbGlobal.Name = "clbGlobal"
        clbGlobal.Size = New Size(137, 66)
        clbGlobal.TabIndex = 13
        clbGlobal.Visible = False
        ' 
        ' clbPerUser
        ' 
        clbPerUser.BackColor = Color.Black
        clbPerUser.BorderStyle = BorderStyle.None
        clbPerUser.ForeColor = Color.White
        clbPerUser.FormattingEnabled = True
        clbPerUser.Items.AddRange(New Object() {"AppData\Local\Opera Software\Opera Stable\Cache", "AppData\Local\Google\Chrome\User Data\Default\Code Cache\js", "AppData\Local\DirectTV Player", "AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\CacheStorage", "AppData\Local\Google\Chrome\User Data\Default\Cache", "AppData\Local\Microsoft\Office\12.0\OfficeFileCache", "AppData\Local\Microsoft\Office\14.0\OfficeFileCache", "AppData\Local\Microsoft\Office\16.0\OfficeFileCache", "AppData\Local\Microsoft\Windows\Caches", "AppData\Local\Microsoft\Windows\Temporary Internet Files", "AppData\Local\Microsoft\Windows Media", "AppData\Local\Symantec\Symantec Endpoint Protection\Logs", "AppData\Local\Temp", "AppData\LocalLow\Adobe\Common\Media Cache Files", "AppData\LocalLow\Adobe\Common\Media Cache", "AppData\LocalLow\Sun\Java\Deployment\cache", "AppData\LocalLow\Sun\Java\Deployment\SystemCache", "AppData\LocalLow\Sun\Java\Deployment\tmp", "AppData\Roaming\Adobe\Flash Player\AssetCache", "AppData\Roaming\Adobe\Flash Player\Icon Cache", "AppData\Roaming\Adobe\Flash Player\NativeCache", "AppData\Roaming\Apple Computer\Logs", "AppData\Roaming\Macromedia\Flash Player", "AppData\Roaming\Microsoft\Windows\Cookies"})
        clbPerUser.Location = New Point(552, 523)
        clbPerUser.Name = "clbPerUser"
        clbPerUser.Size = New Size(109, 66)
        clbPerUser.TabIndex = 22
        clbPerUser.Visible = False
        ' 
        ' clbUsers
        ' 
        clbUsers.BackColor = Color.Black
        clbUsers.BorderStyle = BorderStyle.None
        clbUsers.ForeColor = Color.White
        clbUsers.FormattingEnabled = True
        clbUsers.Location = New Point(691, 12)
        clbUsers.Name = "clbUsers"
        clbUsers.Size = New Size(109, 66)
        clbUsers.TabIndex = 23
        clbUsers.Visible = False
        ' 
        ' btnClean
        ' 
        btnClean.CustomizableEdges = CustomizableEdges3
        btnClean.DisabledState.BorderColor = Color.DarkGray
        btnClean.DisabledState.CustomBorderColor = Color.DarkGray
        btnClean.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnClean.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnClean.FillColor = Color.Cyan
        btnClean.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point)
        btnClean.ForeColor = Color.White
        btnClean.Location = New Point(19, 253)
        btnClean.Name = "btnClean"
        btnClean.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnClean.Size = New Size(245, 52)
        btnClean.TabIndex = 24
        btnClean.Text = "Temizlemeyi Başlat"
        ' 
        ' btnCancel
        ' 
        btnCancel.CustomizableEdges = CustomizableEdges5
        btnCancel.DisabledState.BorderColor = Color.DarkGray
        btnCancel.DisabledState.CustomBorderColor = Color.DarkGray
        btnCancel.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCancel.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCancel.FillColor = Color.FromArgb(CByte(31), CByte(31), CByte(31))
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(270, 253)
        btnCancel.Name = "btnCancel"
        btnCancel.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnCancel.Size = New Size(100, 52)
        btnCancel.TabIndex = 25
        btnCancel.Text = "İptal Et"
        ' 
        ' progbarGlobal
        ' 
        progbarGlobal.CustomizableEdges = CustomizableEdges7
        progbarGlobal.Location = New Point(691, 42)
        progbarGlobal.Name = "progbarGlobal"
        progbarGlobal.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        progbarGlobal.Size = New Size(43, 23)
        progbarGlobal.TabIndex = 27
        progbarGlobal.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        progbarGlobal.Visible = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Panel1.Controls.Add(btnAdvanced)
        Panel1.Controls.Add(chkDeleteOrphans)
        Panel1.Controls.Add(chkDeleteInvalid)
        Panel1.Controls.Add(chkCheckValid)
        Panel1.Controls.Add(btnConnect)
        Panel1.Controls.Add(txtHost)
        Panel1.Controls.Add(rbRemote)
        Panel1.Controls.Add(rbLocal)
        Panel1.Location = New Point(20, 523)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(354, 73)
        Panel1.TabIndex = 28
        Panel1.Visible = False
        ' 
        ' btnAdvanced
        ' 
        btnAdvanced.Location = New Point(130, 46)
        btnAdvanced.Name = "btnAdvanced"
        btnAdvanced.Size = New Size(45, 24)
        btnAdvanced.TabIndex = 7
        btnAdvanced.Text = "Button1"
        btnAdvanced.UseVisualStyleBackColor = True
        ' 
        ' chkDeleteOrphans
        ' 
        chkDeleteOrphans.AutoSize = True
        chkDeleteOrphans.Location = New Point(208, 33)
        chkDeleteOrphans.Name = "chkDeleteOrphans"
        chkDeleteOrphans.Size = New Size(103, 24)
        chkDeleteOrphans.TabIndex = 6
        chkDeleteOrphans.Text = "CheckBox3"
        chkDeleteOrphans.UseVisualStyleBackColor = True
        ' 
        ' chkDeleteInvalid
        ' 
        chkDeleteInvalid.AutoSize = True
        chkDeleteInvalid.Location = New Point(208, 4)
        chkDeleteInvalid.Name = "chkDeleteInvalid"
        chkDeleteInvalid.Size = New Size(103, 24)
        chkDeleteInvalid.TabIndex = 5
        chkDeleteInvalid.Text = "CheckBox2"
        chkDeleteInvalid.UseVisualStyleBackColor = True
        ' 
        ' chkCheckValid
        ' 
        chkCheckValid.AutoSize = True
        chkCheckValid.Location = New Point(95, 3)
        chkCheckValid.Name = "chkCheckValid"
        chkCheckValid.Size = New Size(103, 24)
        chkCheckValid.TabIndex = 4
        chkCheckValid.Text = "CheckBox1"
        chkCheckValid.UseVisualStyleBackColor = True
        ' 
        ' btnConnect
        ' 
        btnConnect.Location = New Point(130, 20)
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(45, 24)
        btnConnect.TabIndex = 3
        btnConnect.Text = "Button1"
        btnConnect.UseVisualStyleBackColor = True
        ' 
        ' txtHost
        ' 
        txtHost.Location = New Point(95, 32)
        txtHost.Name = "txtHost"
        txtHost.Size = New Size(29, 27)
        txtHost.TabIndex = 2
        ' 
        ' rbRemote
        ' 
        rbRemote.AutoSize = True
        rbRemote.Location = New Point(3, 33)
        rbRemote.Name = "rbRemote"
        rbRemote.Size = New Size(96, 24)
        rbRemote.TabIndex = 1
        rbRemote.TabStop = True
        rbRemote.Text = "rbRemote"
        rbRemote.UseVisualStyleBackColor = True
        ' 
        ' rbLocal
        ' 
        rbLocal.AutoSize = True
        rbLocal.Location = New Point(3, 3)
        rbLocal.Name = "rbLocal"
        rbLocal.Size = New Size(79, 24)
        rbLocal.TabIndex = 0
        rbLocal.TabStop = True
        rbLocal.Text = "rbLocal"
        rbLocal.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DimGray
        Panel2.Controls.Add(rbSelected)
        Panel2.Controls.Add(rbAll)
        Panel2.Location = New Point(673, 506)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(121, 83)
        Panel2.TabIndex = 29
        Panel2.Visible = False
        ' 
        ' rbSelected
        ' 
        rbSelected.AutoSize = True
        rbSelected.Location = New Point(3, 33)
        rbSelected.Name = "rbSelected"
        rbSelected.Size = New Size(121, 24)
        rbSelected.TabIndex = 1
        rbSelected.TabStop = True
        rbSelected.Text = "RadioButton1"
        rbSelected.UseVisualStyleBackColor = True
        ' 
        ' rbAll
        ' 
        rbAll.AutoSize = True
        rbAll.Checked = True
        rbAll.Location = New Point(0, 3)
        rbAll.Name = "rbAll"
        rbAll.Size = New Size(121, 24)
        rbAll.TabIndex = 0
        rbAll.TabStop = True
        rbAll.Text = "RadioButton1"
        rbAll.UseVisualStyleBackColor = True
        ' 
        ' txtLog
        ' 
        txtLog.BorderColor = Color.Black
        txtLog.CustomizableEdges = CustomizableEdges9
        txtLog.DefaultText = ""
        txtLog.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtLog.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtLog.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtLog.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtLog.FillColor = Color.Black
        txtLog.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtLog.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        txtLog.ForeColor = Color.White
        txtLog.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtLog.Location = New Point(12, 387)
        txtLog.Margin = New Padding(4, 4, 4, 4)
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.PasswordChar = ChrW(0)
        txtLog.PlaceholderText = ""
        txtLog.SelectedText = ""
        txtLog.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        txtLog.Size = New Size(788, 209)
        txtLog.TabIndex = 30
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(19, 330)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 38)
        Label1.TabIndex = 31
        Label1.Text = "Loglar"
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        NotifyIcon1.Text = "BTcleaner Pro"
        NotifyIcon1.Visible = True
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.icons8_hdd_64
        PictureBox2.Location = New Point(10, 21)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(63, 51)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 32
        PictureBox2.TabStop = False
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.Cursor = Cursors.Help
        Guna2Button1.CustomizableEdges = CustomizableEdges11
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.Transparent
        Guna2Button1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Location = New Point(606, 12)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        Guna2Button1.Size = New Size(188, 29)
        Guna2Button1.TabIndex = 33
        Guna2Button1.Text = "Program Neleri Siliyor?"
        ' 
        ' home
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(812, 601)
        ControlBox = False
        Controls.Add(Guna2Button1)
        Controls.Add(PictureBox2)
        Controls.Add(Label1)
        Controls.Add(txtLog)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(progbarGlobal)
        Controls.Add(btnCancel)
        Controls.Add(btnClean)
        Controls.Add(clbUsers)
        Controls.Add(clbPerUser)
        Controls.Add(PictureBox1)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Guna2ProgressBar1)
        Controls.Add(clbGlobal)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximumSize = New Size(812, 601)
        MinimumSize = New Size(812, 601)
        Name = "home"
        ShowInTaskbar = False
        Text = "anasayfa"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2ProgressBar1 As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents clbGlobal As CheckedListBox
    Friend WithEvents clbPerUser As CheckedListBox
    Friend WithEvents clbUsers As CheckedListBox
    Friend WithEvents btnClean As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents progbarGlobal As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnConnect As Button
    Friend WithEvents txtHost As TextBox
    Friend WithEvents rbRemote As RadioButton
    Friend WithEvents rbLocal As RadioButton
    Friend WithEvents btnAdvanced As Button
    Friend WithEvents chkDeleteOrphans As CheckBox
    Friend WithEvents chkDeleteInvalid As CheckBox
    Friend WithEvents chkCheckValid As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents rbSelected As RadioButton
    Friend WithEvents txtLog As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
End Class
