<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class net
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(net))
        Label1 = New Label()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Label3 = New Label()
        Button1 = New Guna.UI2.WinForms.Guna2Button()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        Label6 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(27, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(271, 46)
        Label1.TabIndex = 0
        Label1.Text = "Bağlantı Kontrol"
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.CustomizableEdges = CustomizableEdges1
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.Cyan
        Guna2Button1.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Location = New Point(454, 65)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Button1.Size = New Size(299, 46)
        Guna2Button1.TabIndex = 5
        Guna2Button1.Text = "Kontrol Et"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(37, 123)
        Label3.Name = "Label3"
        Label3.Size = New Size(254, 23)
        Label3.TabIndex = 6
        Label3.Text = "İnternet Başlantınızı Kontrol Eder"
        ' 
        ' Button1
        ' 
        Button1.CustomizableEdges = CustomizableEdges3
        Button1.DisabledState.BorderColor = Color.DarkGray
        Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Button1.FillColor = Color.Cyan
        Button1.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(454, 258)
        Button1.Name = "Button1"
        Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Button1.Size = New Size(299, 46)
        Button1.TabIndex = 9
        Button1.Text = "IP Adresini Göster"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(27, 258)
        Label5.Name = "Label5"
        Label5.Size = New Size(292, 46)
        Label5.TabIndex = 8
        Label5.Text = "IP Adresini Öğren"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(37, 316)
        Label4.Name = "Label4"
        Label4.Size = New Size(219, 23)
        Label4.TabIndex = 10
        Label4.Text = "Güncel IP Adresinizi Gösterir"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(37, 492)
        Label2.Name = "Label2"
        Label2.Size = New Size(212, 23)
        Label2.TabIndex = 13
        Label2.Text = "flushdns komutunu çalıştırır" & vbCrLf
        ' 
        ' Guna2Button2
        ' 
        Guna2Button2.CustomizableEdges = CustomizableEdges5
        Guna2Button2.DisabledState.BorderColor = Color.DarkGray
        Guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button2.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button2.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button2.FillColor = Color.Cyan
        Guna2Button2.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2Button2.ForeColor = Color.White
        Guna2Button2.Location = New Point(454, 434)
        Guna2Button2.Name = "Guna2Button2"
        Guna2Button2.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2Button2.Size = New Size(299, 46)
        Guna2Button2.TabIndex = 12
        Guna2Button2.Text = "Temizle"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(27, 434)
        Label6.Name = "Label6"
        Label6.Size = New Size(401, 46)
        Label6.TabIndex = 11
        Label6.Text = "DNS Önbelleğini Temizle"
        ' 
        ' net
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(812, 601)
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(Guna2Button2)
        Controls.Add(Label6)
        Controls.Add(Label4)
        Controls.Add(Button1)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Guna2Button1)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximumSize = New Size(812, 601)
        MinimumSize = New Size(812, 601)
        Name = "net"
        Text = "net"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label6 As Label
End Class
