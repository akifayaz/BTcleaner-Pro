Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Public Class Form1

    Sub menuDegis(acilanform As Form)
        panel1.Controls.Clear()
        acilanform.TopLevel = False
        panel1.Controls.Add(acilanform)
        acilanform.Show()

    End Sub



    ' Windows tema rengini saklamak için bir değişken
    Private systemColor As Color

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean) As Integer
    End Function



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ------------------------------
        '
        '  LOAD lOAD LOAD
        '
        '-------------------------------





        menuDegis(home)

        ' Kullanıcı profil yolunu al
        Dim userProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)






        ' Windows tema rengini al ve değişkene ata
        systemColor = GetWindowsThemeColor()

        ' Formun arka plan rengini Windows tema renginden alır
        '  Me.BackColor = systemColor

        ' Label2'nin arka plan rengini Windows tema renginden alır
        Label2.BackColor = systemColor


        Guna2TileButton1.HoverState.CustomBorderColor = systemColor
        Guna2TileButton2.HoverState.CustomBorderColor = systemColor
        Guna2TileButton3.HoverState.CustomBorderColor = systemColor
        Guna2TileButton4.HoverState.CustomBorderColor = systemColor
        Guna2TileButton5.HoverState.CustomBorderColor = systemColor





    End Sub









    Private Function GetWindowsThemeColor() As Color
        Dim color As Integer
        Dim opaque As Boolean
        DwmGetColorizationColor(color, opaque)
        ' Rengi ARGB formatında döndürür
        Return System.Drawing.Color.FromArgb(255, (color >> 16) And 255, (color >> 8) And 255, color And 255)
    End Function

    Private Sub Guna2TileButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2TileButton1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2TileButton1_Click_2(sender As Object, e As EventArgs) Handles Guna2TileButton1.Click
        menuDegis(sistem)
    End Sub

    Private Sub Guna2TileButton2_Click(sender As Object, e As EventArgs) Handles Guna2TileButton2.Click
        menuDegis(home)
    End Sub

    Private Sub Guna2TileButton3_Click(sender As Object, e As EventArgs) Handles Guna2TileButton3.Click
        menuDegis(net)
    End Sub

    Private Sub Guna2TileButton4_Click(sender As Object, e As EventArgs) Handles Guna2TileButton4.Click
        menuDegis(power)
    End Sub

    Private Sub Guna2TileButton5_Click(sender As Object, e As EventArgs) Handles Guna2TileButton5.Click
        menuDegis(ayar)
    End Sub
End Class
