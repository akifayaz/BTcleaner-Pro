<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sistem
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(sistem))
        ProgressBar2 = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        Label2 = New Label()
        Timer1 = New Timer(components)
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        NotifyIcon1 = New NotifyIcon(components)
        SuspendLayout()
        ' 
        ' ProgressBar2
        ' 
        ProgressBar2.FillColor = Color.White
        ProgressBar2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ProgressBar2.ForeColor = Color.Transparent
        ProgressBar2.Location = New Point(242, 45)
        ProgressBar2.Minimum = 0
        ProgressBar2.Name = "ProgressBar2"
        ProgressBar2.ProgressColor = Color.Cyan
        ProgressBar2.ProgressColor2 = Color.Cyan
        ProgressBar2.ShadowDecoration.CustomizableEdges = CustomizableEdges1
        ProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        ProgressBar2.Size = New Size(330, 330)
        ProgressBar2.TabIndex = 1
        ProgressBar2.Text = "Guna2CircleProgressBar2"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(271, 389)
        Label2.Name = "Label2"
        Label2.Size = New Size(275, 38)
        Label2.TabIndex = 3
        Label2.Text = "RAM Kullanımı: %00"
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.CustomizableEdges = CustomizableEdges2
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.Cyan
        Guna2Button1.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Location = New Point(188, 449)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        Guna2Button1.Size = New Size(422, 71)
        Guna2Button1.TabIndex = 4
        Guna2Button1.Text = "Optimize Et"
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        NotifyIcon1.Text = "BTcleaner Pro"
        ' 
        ' sistem
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(812, 601)
        Controls.Add(Guna2Button1)
        Controls.Add(ProgressBar2)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximumSize = New Size(812, 601)
        MinimumSize = New Size(812, 601)
        Name = "sistem"
        Text = "sistem"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ProgressBar2 As Guna.UI2.WinForms.Guna2CircleProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
End Class
