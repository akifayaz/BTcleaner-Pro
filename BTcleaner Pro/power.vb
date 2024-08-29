Imports System.Runtime.InteropServices

Public Class power



    ' Windows tema rengini saklamak için bir değişken
    Private systemColor As Color

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean) As Integer
    End Function







    Private Sub power_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Kullanıcı profil yolunu al
        Dim userProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)






        ' Windows tema rengini al ve değişkene ata
        systemColor = GetWindowsThemeColor()

        Guna2Button1.FillColor = systemColor
        Guna2Button2.FillColor = systemColor
        Button1.FillColor = systemColor


    End Sub

    Private Function GetWindowsThemeColor() As Color
        Dim color As Integer
        Dim opaque As Boolean
        DwmGetColorizationColor(color, opaque)
        ' Rengi ARGB formatında döndürür
        Return System.Drawing.Color.FromArgb(255, (color >> 16) And 255, (color >> 8) And 255, color And 255)
    End Function























    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Process.Start("shutdown", "/s /t 60") ' 60 saniye sonra kapatır
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("shutdown", "/r /t 60") ' 60 saniye sonra kapatır

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click


        Process.Start("shutdown", "/r /fw /t 0") ' 0 saniye bekleme ile bios menüsünü açmayı emreder
    End Sub
End Class