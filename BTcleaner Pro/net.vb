Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks


Public Class net

    ' Windows tema rengini saklamak için bir değişken
    Private systemColor As Color

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean) As Integer
    End Function







    Private Sub net_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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



    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim publicIp As String = Await GetPublicIpAddressAsync()
            Label4.Text = "Public IP Adresiniz: " & publicIp
        Catch ex As Exception
            Label4.Text = "HATA IP adresi alınamadı: " & ex.Message
        End Try
    End Sub

    Private Async Function GetPublicIpAddressAsync() As Task(Of String)
        Using httpClient As New HttpClient()
            ' API'ye istek gönder ve IP adresini al
            Dim ip As String = Await httpClient.GetStringAsync("https://api.ipify.org")
            Return ip
        End Using
    End Function

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Dim pinger As New Ping()
        Dim reply As PingReply = pinger.Send("google.com")
        If reply.Status = IPStatus.Success Then
            Label3.Text = "İnternet Bağlantınız Var"
            Label3.ForeColor = Color.FromArgb(39, 240, 36)
        Else
            Label3.Text = "İnternet Bağlantınız Yok"
            Label3.ForeColor = Color.FromArgb(240, 36, 36)

        End If



    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            Dim psi As New ProcessStartInfo("cmd.exe", "/c ipconfig /flushdns")
            psi.WindowStyle = ProcessWindowStyle.Hidden
            psi.CreateNoWindow = True
            psi.UseShellExecute = False
            Process.Start(psi)

            Label2.Text = "İşlem Başarıyla tamamlandı"
            Label2.ForeColor = Color.FromArgb(39, 240, 36)

        Catch ex As Exception
            Label2.Text = "Hata"
        End Try
    End Sub
End Class