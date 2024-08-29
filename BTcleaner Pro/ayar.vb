Imports System.Net
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Public Class ayar

    ' Windows tema rengini saklamak için bir değişken
    Private systemColor As Color

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean) As Integer
    End Function

    Private Const URL As String = "https://raw.githubusercontent.com/akifayaz/web-tools/main/ver.txt"
    Private Const ExpectedVersion As String = "1.0"

    Private Function ChangeIconColor(ByVal originalImage As Bitmap, ByVal newColor As Color) As Bitmap
        ' Yeni bir bitmap oluştur
        Dim recoloredImage As New Bitmap(originalImage.Width, originalImage.Height)

        ' Resmin her pikselini dolaş
        For y As Integer = 0 To originalImage.Height - 1
            For x As Integer = 0 To originalImage.Width - 1
                Dim pixelColor As Color = originalImage.GetPixel(x, y)

                ' Şeffaf olan pikselleri koru
                If pixelColor.A = 0 Then
                    recoloredImage.SetPixel(x, y, pixelColor)
                ElseIf pixelColor.R < 50 AndAlso pixelColor.G < 50 AndAlso pixelColor.B < 50 Then
                    ' Eğer piksel siyahsa, yeni rengi uygula
                    recoloredImage.SetPixel(x, y, Color.FromArgb(pixelColor.A, newColor))
                Else
                    ' Diğer pikselleri olduğu gibi bırak
                    recoloredImage.SetPixel(x, y, pixelColor)
                End If
            Next
        Next

        Return recoloredImage
    End Function

    Private Function GetWindowsThemeColor() As Color
        Dim color As Integer
        Dim opaque As Boolean
        DwmGetColorizationColor(color, opaque)
        ' Rengi ARGB formatında döndürür
        Return System.Drawing.Color.FromArgb(255, (color >> 16) And 255, (color >> 8) And 255, color And 255)
    End Function




    Private Sub ayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load







        ' Kullanıcı profil yolunu al
        Dim userProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)






        ' Windows tema rengini al ve değişkene ata
        systemColor = GetWindowsThemeColor()
        '-------------------------------------
        donate.FillColor = systemColor





        ' PictureBox1 ve PictureBox2'deki mevcut resimleri al
        Dim originalImage1 As Bitmap = CType(PictureBox1.Image, Bitmap)
        Dim originalImage2 As Bitmap = CType(PictureBox2.Image, Bitmap)
        Dim originalImage3 As Bitmap = CType(PictureBox3.Image, Bitmap)

        ' İstediğiniz rengi belirleyin (örneğin mavi)
        Dim newColor As Color = systemColor

        ' İkonların rengini değiştir
        Dim recoloredImage1 As Bitmap = ChangeIconColor(originalImage1, newColor)
        Dim recoloredImage2 As Bitmap = ChangeIconColor(originalImage2, newColor)
        Dim recoloredImage3 As Bitmap = ChangeIconColor(originalImage3, newColor)

        ' Değiştirilen resimleri tekrar PictureBox1 ve PictureBox2'ye yerleştir
        PictureBox1.Image = recoloredImage1
        PictureBox2.Image = recoloredImage2
        PictureBox3.Image = recoloredImage3




        CheckVersion()








    End Sub




    Private Sub CheckVersion()
        Dim webClient As New WebClient()
        Try
            ' Metin dosyasını URL'den indir
            Dim content As String = webClient.DownloadString(URL).Trim()

            ' İçeriği "1.0" ile karşılaştır
            If content = ExpectedVersion Then

                ' Threading.Thread.Sleep(3000) ' 3saniye bekle
                Label2.Text = "Sürümünüz güncel"
                Label2.ForeColor = Color.FromArgb(39, 240, 36)
            Else
                Threading.Thread.Sleep(1000) ' 1 saniye bekle
                Label2.Text = "Yeni sürüm bulundu.Butona tıklayarak yeni sürümün indirme sayfasına gidin."
                Label2.ForeColor = Color.FromArgb(240, 36, 36)
                Guna2Button1.Visible = True


            End If
        Catch ex As Exception
            Threading.Thread.Sleep(1000) ' 2 saniye bekle
            Label2.Text = "Kontrol sırasında hata oluştu."
            Label2.ForeColor = Color.FromArgb(240, 36, 36)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Process.Start("cmd.exe", $"/c start https://bilgisayartime.com/btcleanerpro")
    End Sub

    Private Sub donate_Click(sender As Object, e As EventArgs) Handles donate.Click
        Process.Start("cmd.exe", $"/c start https://akif.bilgisayartime.com/pay")
    End Sub
End Class