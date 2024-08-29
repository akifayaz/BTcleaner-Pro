<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ayar
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ayar))
        Label1 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Label3 = New Label()
        PictureBox2 = New PictureBox()
        Label4 = New Label()
        Label5 = New Label()
        PictureBox3 = New PictureBox()
        Label6 = New Label()
        Label7 = New Label()
        donate = New Guna.UI2.WinForms.Guna2Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(123, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(326, 46)
        Label1.TabIndex = 15
        Label1.Text = "Güncelleme Kontrol"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(134, 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(329, 23)
        Label2.TabIndex = 23
        Label2.Text = "Yeni sürüm kontrol ediliyor lütfen bekleyin..."
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.icons8_update_64__1_
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(105, 81)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 24
        PictureBox1.TabStop = False
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.CustomizableEdges = CustomizableEdges1
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Guna2Button1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Location = New Point(134, 96)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Button1.Size = New Size(196, 28)
        Guna2Button1.TabIndex = 25
        Guna2Button1.Text = "Yeni Sürümü İndir"
        Guna2Button1.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(123, 159)
        Label3.Name = "Label3"
        Label3.Size = New Size(289, 46)
        Label3.TabIndex = 26
        Label3.Text = "Geliştirici Bilgileri"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.icons8_developer_64
        PictureBox2.Location = New Point(12, 159)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(105, 91)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 27
        PictureBox2.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(134, 218)
        Label4.Name = "Label4"
        Label4.Size = New Size(184, 32)
        Label4.TabIndex = 28
        Label4.Text = "Ömer Akif Ayaz"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(418, 159)
        Label5.Name = "Label5"
        Label5.Size = New Size(196, 92)
        Label5.TabIndex = 29
        Label5.Text = "Youtube: Bilgisayar Time" & vbCrLf & "Site: bilgisayartime.com " & vbCrLf & "Twitter: akifayz " & vbCrLf & "Github: akifayaz"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.icons8_donate_64
        PictureBox3.Location = New Point(12, 316)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(105, 91)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 30
        PictureBox3.TabStop = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(134, 316)
        Label6.Name = "Label6"
        Label6.Size = New Size(330, 46)
        Label6.TabIndex = 31
        Label6.Text = "Geliştiriciyi Destekle" & vbCrLf
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(145, 372)
        Label7.Name = "Label7"
        Label7.Size = New Size(535, 46)
        Label7.TabIndex = 32
        Label7.Text = "Karşılık beklemeden yapıtığım ve açık kaynak kodlu olarak yayınladığım " & vbCrLf & "projelerimi destekleyebilirsiniz"
        ' 
        ' donate
        ' 
        donate.CustomizableEdges = CustomizableEdges3
        donate.DisabledState.BorderColor = Color.DarkGray
        donate.DisabledState.CustomBorderColor = Color.DarkGray
        donate.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        donate.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        donate.FillColor = Color.Cyan
        donate.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        donate.ForeColor = Color.White
        donate.Location = New Point(172, 450)
        donate.Name = "donate"
        donate.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        donate.Size = New Size(419, 96)
        donate.TabIndex = 33
        donate.Text = "Destek Sayfasını Aç"
        ' 
        ' ayar
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(812, 601)
        ControlBox = False
        Controls.Add(donate)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(PictureBox3)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(PictureBox2)
        Controls.Add(Label3)
        Controls.Add(Guna2Button1)
        Controls.Add(PictureBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximumSize = New Size(812, 601)
        MinimumSize = New Size(812, 601)
        Name = "ayar"
        Text = "ayar"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents donate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
