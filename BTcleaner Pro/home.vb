Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Reflection.Emit
Imports System.Net
Imports System.Security.Principal
Imports System.ComponentModel
Imports System.DirectoryServices
Imports Microsoft.Win32
Imports Guna.UI2.WinForms

Public Class home





    ' FİREFOX YÜKLÜ İSE
    ' Varsayılan Mozilla Firefox profili adını almak için
    Private Function GetDefaultFirefoxProfilePath() As String
        Try
            ' Doğru kullanıcı profil yolunu al
            Dim userProfilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            Dim profilesIniPath As String = Path.Combine(userProfilePath, "AppData\Roaming\Mozilla\Firefox\profiles.ini")
            Dim profilesPath As String = Path.Combine(userProfilePath, "AppData\Local\Mozilla\Firefox\Profiles")

            ' Profil dosyasını kontrol et
            If File.Exists(profilesIniPath) Then
                Dim iniLines As String() = File.ReadAllLines(profilesIniPath)
                Dim defaultProfilePath As String = Nothing

                ' Varsayılan profil yolunu bul
                For i As Integer = 0 To iniLines.Length - 1
                    If iniLines(i).Contains("Default=1") Then
                        ' Path satırını bul ve değerini al
                        Dim pathLine As String = iniLines(i - 1)
                        Dim profilePath As String = pathLine.Split("="c)(1).Trim()

                        ' Path 'Profiles/' ile başlıyorsa, doğru yol formatı oluşturulmalı
                        If profilePath.StartsWith("Profiles/") Then
                            profilePath = profilePath.Substring("Profiles/".Length)
                        End If

                        ' Profil yolunu tamamla
                        defaultProfilePath = Path.Combine(profilesPath, profilePath)
                        Exit For
                    End If
                Next

                ' Varsayılan profil yolunu kullanarak cache2 yolunu oluştur
                If Not String.IsNullOrEmpty(defaultProfilePath) AndAlso Directory.Exists(defaultProfilePath) Then
                    Dim cachePath As String = Path.Combine(defaultProfilePath, "cache2")


                    Return cachePath
                Else
                End If
            Else
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function









    '------------------------------------------------
    ' UZAK BAĞLANTI AYARLARI DEVRE DIŞI BIRAKILMIŞTIR
    '------------------------------------------------



    Private Const BytesInMB As Double = 1048576.0
    Private Const BytesInGB As Double = 1073741824.0

    Private Host As String = Environment.MachineName
    Private Drive As String = "C:"
    Private IsXP As Boolean = False
    Private IsUNC As Boolean = False
    Private lFreeBytes As Long = 0
    Private lTotalBytes As Long = 0
    Private lTotalFreeBytes As Long = 0
    Private IsSilent As Boolean = False
    Private IsInstallMode As Boolean = False
    Private WithEvents TrayIcon As New NotifyIcon
    Private ProfilesToDelete() As String = {}
    Private ProfilesToDeleteCount As Integer = 0
    Private UsersToDelete() As String = {}
    Private UsersToDeleteCount As Integer = 0

    Private WithEvents bgwGlobal As BackgroundWorker
    Private WithEvents bgwUser As BackgroundWorker

    Declare Auto Function DeleteFile Lib "kernel32" (ByVal lpFilePath As String) As Boolean

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function GetDiskFreeSpaceEx(ByVal lpDirectoryName As String, ByRef lpFreeBytesAvailable As ULong, ByRef lpTotalNumberOfBytes As ULong, ByRef lpTotalNumberOfFreeBytes As ULong) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Function GetUserIDFromSID(ByVal SID As String) As String

        'Dim domain As String = ""
        Dim username As String = "unknown"
        'Dim QualifiedName As String = "unknown"

        Try
            Dim de As New DirectoryEntry(String.Format("LDAP://<SID={0}>", SID))
            Dim mySearcher As DirectorySearcher = New DirectorySearcher(de)
            mySearcher.SearchScope = SearchScope.Subtree
            mySearcher.PropertiesToLoad.Add("name")
            Dim myresult As SearchResult = mySearcher.FindOne
            'For Each p In myresult.Properties.PropertyNames
            '    Try
            '        Debug.Print(p & ": " & myresult.Properties(p)(0).ToString)
            '    Catch
            '    End Try
            'Next

            'Dim temp As String = myresult.Properties("samaccountname")(0)
            'Dim distname As String = myresult.Properties("name")(0)
            'domain = "FORD" & distname.Substring(distname.IndexOf("DC=") + 3, 3).ToUpper
            username = myresult.Properties("name")(0) 'distname.Substring(distname.IndexOf("CN=") + 3, distname.IndexOf(",") - 3).ToUpper
        Catch
        End Try

        'If domain.Length > 0 And username.Length > 0 Then
        '    QualifiedName = username
        'End If

        Return username

    End Function

    Private Sub Log(ByVal txt As String)

        txtLog.AppendText(txt & vbCrLf)
        txtLog.Select(txtLog.Text.Length, 0)
        txtLog.ScrollToCaret()

    End Sub

    Private Sub Reset()

        btnClean.Enabled = True
        btnAdvanced.Enabled = True
        btnConnect.Enabled = True
        clbGlobal.Enabled = True
        clbUsers.Enabled = True
        clbPerUser.Enabled = True
        Panel1.Enabled = True
        Panel2.Enabled = True
        btnCancel.Visible = False
        progbarGlobal.Value = 0



    End Sub

    Private Sub SetOS()

        If Directory.Exists(Drive & "\Users") Then
            IsXP = False
        Else
            IsXP = True
        End If

    End Sub

    Private Sub LocalRemoteChanged()

        txtHost.Enabled = rbRemote.Checked
        btnConnect.Enabled = rbRemote.Checked
        txtHost.Text = Host
        IsUNC = rbRemote.Checked
        If rbLocal.Checked And Me.IsHandleCreated Then
            GetUserDirs()
        End If

    End Sub

    Private Sub GetUserDirs()

        btnClean.Enabled = False
        txtLog.Clear()
        Log("Kullanıcı hesapları aranıyor...")
        Me.Refresh()

        Erase UsersToDelete
        Erase ProfilesToDelete

        Dim UserDir As String = Drive & "\Users"
        Dim OrphanedProfiles As Integer = 0
        Dim OrphanedUserCount As Integer = 0
        Dim BadProfileCount As Integer = 0

        clbUsers.Items.Clear()

        If chkCheckValid.Checked Then
            Try
                Using reg As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host, RegistryView.Default)

                    Using ProfileList As RegistryKey = reg.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList")

                        For Each key As String In ProfileList.GetSubKeyNames
                            If key.Length > 8 And (Not key.EndsWith("-500")) Then
                                Using userkey As RegistryKey = ProfileList.OpenSubKey(key)
                                    Dim guid As String = userkey.GetValue("Guid")
                                    Dim ImagePath As String = userkey.GetValue("ProfileImagepath").ToString.ToUpper.Replace("C:", Drive)
                                    Dim PathExists As Boolean = Directory.Exists(ImagePath)
                                    Dim userSID As String = userkey.Name

                                    If Not guid Is Nothing Then
                                        ' this is a domain account

                                        Dim idx As Integer = userSID.LastIndexOf("\") + 1
                                        userSID = userSID.Substring(idx, userSID.Length - idx)

                                        Dim UserName As String = GetUserIDFromSID(userSID)
                                        If UserName <> "unknown" And UserName <> "" Then
                                            ' this is a valid, active domain account
                                            If PathExists Then
                                                ' this account has a user directory to backup
                                                clbUsers.Items.Add(ImagePath, True)

                                                Me.Refresh()
                                            Else
                                                If chkDeleteOrphans.Checked Then
                                                    ' this account has no user directory, add to this list to remove this registry entry later
                                                    OrphanedUserCount += 1
                                                    ReDim Preserve UsersToDelete(OrphanedUserCount - 1)
                                                    UsersToDelete(OrphanedUserCount - 1) = userSID
                                                End If
                                            End If
                                        Else
                                            If chkDeleteInvalid.Checked Then
                                                ' this user is no longer valid/not in AD, we're going to kill the reg entry
                                                OrphanedUserCount += 1
                                                ReDim Preserve UsersToDelete(OrphanedUserCount - 1)
                                                UsersToDelete(OrphanedUserCount - 1) = userSID
                                                ' now, is there a profile to delete too?
                                                If PathExists Then
                                                    BadProfileCount += 1
                                                    ReDim Preserve ProfilesToDelete(BadProfileCount - 1)
                                                    ProfilesToDelete(BadProfileCount - 1) = ImagePath
                                                    'clbUsers.Items.Add(ImagePath, True)
                                                End If
                                            End If
                                        End If
                                    Else
                                        If chkDeleteInvalid.Checked Then
                                            ' this user is no longer valid/not in AD, we're going to kill the reg entry
                                            OrphanedUserCount += 1
                                            ReDim Preserve UsersToDelete(OrphanedUserCount - 1)
                                            UsersToDelete(OrphanedUserCount - 1) = userSID
                                            ' now, is there a profile to delete too?
                                            If PathExists Then
                                                BadProfileCount += 1
                                                ReDim Preserve ProfilesToDelete(BadProfileCount - 1)
                                                ProfilesToDelete(BadProfileCount - 1) = ImagePath
                                                'clbUsers.Items.Add(ImagePath, True)
                                            End If
                                        End If
                                    End If
                                End Using
                            End If
                        Next
                    End Using
                End Using
            Catch
            End Try

        End If

        ProfilesToDeleteCount = BadProfileCount
        UsersToDeleteCount = OrphanedUserCount

        Try

            Dim DirColl As CheckedListBox.ObjectCollection = clbUsers.Items()

            For Each folder In Directory.GetDirectories(UserDir)

                Dim found As Boolean = False

                If Not folder.ToUpper.EndsWith("ALL USERS") And
                    Not folder.ToUpper.EndsWith("PUBLIC") And
                    Not folder.ToUpper.EndsWith("DEFAULT") And
                    Not folder.ToUpper.EndsWith("DEFAULT USER") And
                    Not folder.ToUpper.Contains("ADMINISTRATOR") And
                    Not folder.ToUpper.Contains("ACRONIS AGENT USER") And
                    Not folder.ToUpper.Contains("AMS_USER") Then

                    For Each FoundDir As String In DirColl
                        ' check if this directory is already in the to-clean list
                        If folder.ToUpper = FoundDir.ToUpper Then
                            found = True
                        End If
                    Next

                    If Not found Then
                        ' check to see if this directory is on the delete list
                        If Not ProfilesToDelete Is Nothing Then
                            For i As Integer = 0 To ProfilesToDelete.GetUpperBound(0)
                                If folder.ToUpper = ProfilesToDelete(i) Then
                                    found = True
                                End If
                            Next
                        End If
                    End If

                    If Not found Then
                        ' it's not on either of our lists
                        If chkDeleteOrphans.Checked Then
                            ' if this was checked, then this folder should exist in either the to-clean list or the to-delete list
                            ' since it was not, it must be an orphan, or another local account that shouldn't exist
                            OrphanedProfiles += 1
                            ProfilesToDeleteCount += 1
                            ReDim Preserve ProfilesToDelete(ProfilesToDeleteCount - 1)
                            ProfilesToDelete(ProfilesToDeleteCount - 1) = folder
                        Else
                            ' since chkDeleteOrphans was not checked, we simply add this dir to the to-clean list
                            clbUsers.Items.Add(folder.ToUpper, True)
                        End If
                    End If

                End If
            Next
        Catch ex As Exception
            If Not IsSilent Then MsgBox(ex.Message)
        End Try

        Log(clbUsers.Items.Count & " Adet kullanıcı bulundu.")

        If chkDeleteOrphans.Checked Then

            Log(OrphanedUserCount & " Kayıt defterinden kaldırılacak yetim veya geçersiz kullanıcı kayıtları.")
            Log(ProfilesToDeleteCount.ToString & " silinecek yetim veya geçersiz kullanıcı profilleri.")
            For i As Integer = 0 To ProfilesToDeleteCount - 1
                Log(vbTab & ProfilesToDelete(i))
            Next

        End If

        Log("Temizlemeye Hazır.")

        btnClean.Enabled = True

    End Sub

    Private Function IsElevated() As Boolean

        Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)

    End Function

    Private Sub OutputHelpMsg()

    End Sub

    Private Sub InstallApp()

        Try
            File.Copy(Application.ExecutablePath, "C:\Windows\CacheCleaner.exe", True)
            Shell("at 5:00AM /EVERY: c:\Windows\CacheCleaner.exe /autoclean", AppWinStyle.Hide, True)

        Catch ex As Exception
            MsgBox("InstallApp(): " & ex.Message)
        End Try

    End Sub








    ' -----------------------------------------------
    '
    ' Windows tema rengini saklamak için bir değişken
    '
    '------------------------------------------------


    Private systemColor As Color

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean) As Integer
    End Function

    ' Klasör boyutunu hesaplayan fonksiyon
    Private Function GetDirectorySize(dir As DirectoryInfo) As Long
        Dim size As Long = 0

        Try
            ' Klasördeki tüm dosyaların boyutunu topla
            For Each file As FileInfo In dir.GetFiles("*", SearchOption.AllDirectories)
                size += file.Length
            Next
        Catch ex As UnauthorizedAccessException
            ' Erişim izni olmayan klasörler için hatayı atla
        End Try

        Return size
    End Function

    Private Sub HesaplaVeGuncelle()
        ' Kullanıcı profil yolunu al
        Dim userProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        Dim cacheFolderPath As String = GetDefaultFirefoxProfilePath()

        ' Belirtilen klasörlerin yolları
        Dim folders As String() = {
        "C:\$Recycle.Bin", ' Geri dönüşüm kutusu
        "C:\PerfLogs", ' windows logları
        "C:\temp", ' windows logları
        "C:\Windows\Prefetch",' windows logları
        "C:\Windows\System32\winevt\Logs",' windows logları
        "C:\Windows\System32\spool\PRINTERS",' windows logları
        "C:\Windows\temp",' windows logları(temp geçici)
        userProfile & "\AppData\Local\DirectTV Player", ' windows logları
        userProfile & "\AppData\Local\Google\Chrome\User Data\Default\Cache", ' Google chrome cashe
        userProfile & "\AppData\Local\Microsoft\Office\12.0\OfficeFileCache", 'ofiice cache
        userProfile & "\AppData\Local\Microsoft\Office\14.0\OfficeFileCache",'ofiice cache
        userProfile & "\AppData\Local\Microsoft\Office\16.0\OfficeFileCache",'ofiice cache
        userProfile & "\AppData\Local\Microsoft\Windows\Caches", 'windows gereksiz cache dosyaları
        userProfile & "\AppData\Local\Microsoft\Windows\Temporary Internet Files", ' Geçici internet dosyaları
        userProfile & "\AppData\Local\Microsoft\Windows Media", 'media cache
        userProfile & "\AppData\Local\Symantec\Symantec Endpoint Protection\Logs", 'Symantec log
        userProfile & "\AppData\Local\Temp", ' geçici dosyalar
        userProfile & "\AppData\LocalLow\Adobe\Common\Media Cache Files", 'adobe cacheleri
        userProfile & "\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\CacheStorage",'ms edge cache
        userProfile & "\AppData\LocalLow\Adobe\Common\Media Cache",'adobe cacheleri
        userProfile & "\AppData\LocalLow\Sun\Java\Deployment\cache", 'java cache
        userProfile & "\AppData\LocalLow\Sun\Java\Deployment\SystemCache", 'java cache
        userProfile & "\AppData\LocalLow\Sun\Java\Deployment\tmp", 'java cache
        userProfile & "\AppData\Roaming\Adobe\Flash Player\AssetCache",'flash player cache
        userProfile & "\AppData\Roaming\Adobe\Flash Player\Icon Cache", 'flash player cache
        userProfile & "\AppData\Roaming\Adobe\Flash Player\NativeCache", 'flash player cache
        userProfile & "\AppData\Roaming\Apple Computer\Logs", 'apple logs
        userProfile & "\AppData\Roaming\Macromedia\Flash Player", 'flash player cache
        userProfile & "\AppData\Roaming\Microsoft\Windows\Cookies", 'windows çerezleri
        userProfile & "\AppData\Local\Opera Software\Opera Stable\Cache", 'opera tarayıcı cache
        userProfile & "\AppData\Local\Google\Chrome\User Data\Default\Code Cache\js", ' google chrome cache
        cacheFolderPath 'firefox cache dosyaları
    }

        ' Toplam boyutu hesapla
        Dim totalSize As Long = 0

        For Each folder As String In folders
            Try
                If Directory.Exists(folder) Then
                    totalSize += GetDirectorySize(New DirectoryInfo(folder))
                End If
            Catch ex As DirectoryNotFoundException
                ' Klasör bulunamadığında hatayı atla
                Continue For
            Catch ex As UnauthorizedAccessException
                ' Erişim izni olmayan klasörler için hatayı atla
                Continue For
            End Try
        Next

        ' Toplam boyutu Label7'ye GB cinsinden yazdır
        Label7.Text = "Toplam Boyut: " & (totalSize / (1024 ^ 3)).ToString("F2") & " GB"
    End Sub



    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HesaplaVeGuncelle()
        '-------------------------------------------
        '
        '-------------------LOAD-------------------
        '
        '--------------------------------------------

        txtLog.ReadOnly = True
        btnCancel.Hide()


        Dim a() As String = System.Environment.GetCommandLineArgs()

        For i As Integer = 1 To a.GetUpperBound(0)
            ' element 0 is always the application path/name
            Select Case a(i).ToLower
                Case "/a", "/autoclean"
                    IsSilent = True
                Case "/i", "/install"
                    IsInstallMode = True
                Case Else
                    Me.Hide()
                    OutputHelpMsg()
                    Application.Exit()
            End Select
        Next

        txtHost.Text = Host

        For i As Integer = 0 To clbGlobal.Items.Count - 1
            If i <> 2 Then clbGlobal.SetItemChecked(i, True)
        Next

        For i As Integer = 0 To clbPerUser.Items.Count - 1
            clbPerUser.SetItemChecked(i, True)
        Next
















        ' ------------------------------
        '
        '  İLK KISIM
        '
        '-------------------------------



        ' ----------------------------------------------------------------------------------

        ' CheckedListBox ayarları
        For i As Integer = 0 To clbGlobal.Items.Count - 1
            clbGlobal.SetItemChecked(i, True)
        Next



        ' Windows tema rengini al ve değişkene ata
        systemColor = GetWindowsThemeColor()

        ' Formun arka plan rengini Windows tema renginden alır
        '  Me.BackColor = systemColor


        ' C: sürücüsündeki disk alanı bilgilerini al
        Dim drive As DriveInfo = New DriveInfo("C")

        ' Toplam alanı byte cinsinden al
        Dim totalSpace As Long = drive.TotalSize

        ' Kullanılan alanı byte cinsinden al
        Dim usedSpace As Long = totalSpace - drive.AvailableFreeSpace

        ' ProgressBar'ın maksimum değerini toplam alan olarak ayarla
        Guna2ProgressBar1.Maximum = Convert.ToInt32(totalSpace / 1024 / 1024) ' MB cinsinden

        ' ProgressBar'ın değerini kullanılan alan olarak ayarla
        Guna2ProgressBar1.Value = Convert.ToInt32(usedSpace / 1024 / 1024) ' MB cinsinden


        Guna2ProgressBar1.ProgressColor = systemColor
        Guna2ProgressBar1.ProgressColor2 = systemColor


        progbarGlobal.ProgressColor = systemColor
        progbarGlobal.ProgressColor2 = systemColor


        ' C diskinin toplam kapasitesi
        Label4.Text = "" & (drive.TotalSize / (1024 ^ 3)).ToString("F2") & " GB"

        ' Label2: C diskinde kullanılan alan
        Label5.Text = "kullanılan alan: " & (usedSpace / (1024 ^ 3)).ToString("F2") & " GB"

        ' Label3: C diskindeki boş alan
        Label6.Text = "boş alan: " & (drive.TotalFreeSpace / (1024 ^ 3)).ToString("F2") & " GB"

        ' PictureBox1 ve PictureBox2'deki mevcut resimleri al
        Dim originalImage1 As Bitmap = CType(PictureBox1.Image, Bitmap)
        Dim originalImage2 As Bitmap = CType(PictureBox2.Image, Bitmap)

        ' İstediğiniz rengi belirleyin (örneğin mavi)
        Dim newColor As Color = systemColor

        ' İkonların rengini değiştir
        Dim recoloredImage1 As Bitmap = ChangeIconColor(originalImage1, newColor)
        Dim recoloredImage2 As Bitmap = ChangeIconColor(originalImage2, newColor)

        ' Değiştirilen resimleri tekrar PictureBox1 ve PictureBox2'ye yerleştir
        PictureBox1.Image = recoloredImage1
        PictureBox2.Image = recoloredImage2


        btnClean.FillColor = systemColor
        txtLog.ForeColor = systemColor




        ' ------------------------------
        '
        '  </load>
        '
        '-------------------------------

    End Sub

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






    ' ------------------------------
    '
    '  TEMİZLEME ADIMLARI
    '
    '-------------------------------

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        GetUserDirs()




    End Sub

    Private Sub rbLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Host = Environment.MachineName
        Drive = "C:"
        If rbLocal.Checked Then btnAdvanced.Enabled = True
        LocalRemoteChanged()

    End Sub

    Private Sub rbRemote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If rbRemote.Checked Then btnAdvanced.Enabled = False
        LocalRemoteChanged()

    End Sub

    Private Sub rbSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSelected.CheckedChanged

        If rbSelected.Checked Then
            For x As Integer = 0 To clbUsers.Items.Count - 1
                clbUsers.SetItemChecked(x, False)
            Next
        End If

    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If rbAll.Checked Then
            For x As Integer = 0 To clbUsers.Items.Count - 1
                clbUsers.SetItemChecked(x, True)
            Next
        End If

    End Sub

    Private Function IsHostWin7(ByVal host As String) As Integer

        Try
            If Directory.Exists("\\" & host & "\c$\ProgramData") Then
                Return 1
            Else
                Return 0
            End If
        Catch
            Return -1
        End Try

    End Function

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Host = txtHost.Text

        Try
            Dim HostAddresses As IPAddress() = Dns.GetHostAddresses(Host)

            For j = 0 To HostAddresses.GetUpperBound(0)
                Dim IP As String = HostAddresses(j).ToString
                If IP.StartsWith("19.129") Then
                    Dim HostEntry As IPHostEntry = Dns.GetHostEntry(IP)
                    If HostEntry.HostName.ToUpper.StartsWith(Host.ToUpper) Then
                        'ping check
                        If My.Computer.Network.Ping(IP) Then
                            If IsHostWin7(Host) Then
                                If Not Directory.Exists("M:\") Then
                                    Drive = "M:"
                                Else
                                    Drive = "N:"
                                End If

                                Shell("net use " & Drive & " /delete", AppWinStyle.Hide, True, 5000)
                                Shell("net use " & Drive & " \\" & Host & "\C$ /P:No", AppWinStyle.Hide, True, 5000)

                                GetUserDirs()
                            Else
                                MsgBox("Windows Vista or higher not detected.")
                            End If
                        Else
                            MsgBox("Cannot ping host name.")
                        End If
                    Else
                        MsgBox("DNS host entry does not match IP address " & IP)
                    End If 'dns check
                End If 'ip check
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
        btnCancel.Show()

        btnClean.Enabled = False
        btnAdvanced.Enabled = False
        btnConnect.Enabled = False
        clbGlobal.Enabled = False
        clbUsers.Enabled = False
        clbPerUser.Enabled = False
        Panel1.Enabled = False
        Panel2.Enabled = False
        btnCancel.Visible = True

        txtLog.Text = ""

        GetDiskFreeSpaceEx(Drive, lFreeBytes, lTotalBytes, lTotalFreeBytes)

        Dim TotalProgItems As Integer = clbGlobal.CheckedItems.Count + (clbUsers.CheckedItems.Count * clbPerUser.CheckedItems.Count) + ProfilesToDeleteCount
        progbarGlobal.Maximum = TotalProgItems

        bgwGlobal = New BackgroundWorker
        bgwGlobal.WorkerReportsProgress = True
        bgwGlobal.WorkerSupportsCancellation = True
        bgwGlobal.RunWorkerAsync()


        ' Özel olarak firefox

        ' Firefox cache yolunu al
        Dim cacheFolderPath As String = GetDefaultFirefoxProfilePath()

        ' Eğer klasör varsa, silme işlemi yap
        If Not String.IsNullOrEmpty(cacheFolderPath) AndAlso Directory.Exists(cacheFolderPath) Then
            Try
                Directory.Delete(cacheFolderPath, True)

            Catch
                ' Hata durumunda herhangi bir işlem yapılmıyor
            End Try
        End If



    End Sub

    Private Sub ClearAttributes(ByVal path As String)

        For Each f In Directory.GetFiles(path)
            Try
                File.SetAttributes(f, FileAttributes.Normal)
            Catch ex As Exception
                Debug.Print("ClearAttributes(" & f & "): " & ex.Message)
            End Try
        Next

        For Each fld In Directory.GetDirectories(path)
            Try
                File.SetAttributes(fld, FileAttributes.Normal)
            Catch ex As Exception
                Debug.Print("ClearAttributes(" & fld & "): " & ex.Message)
            End Try
            ClearAttributes(fld)
        Next

    End Sub

    Private Function DeleteStuff(ByVal path As String) As Integer

        Dim count As Integer = 0

        For Each f In Directory.GetFiles(path)
            Try
                If f.Length < 240 Then
                    Try
                        File.Delete(f)
                    Catch ex As Exception
                        If ex.Message.Contains("too long") Then
                            f = "\\?\" & f 'If(IsUNC, "UNC\" & f.Substring(2, f.Length - 2), f)
                            DeleteFile(f)
                        Else
                            Debug.Print("DeleteStuff(" & f & "): " & ex.Message)
                        End If
                    End Try
                Else
                    f = "\\?\" & f 'If(IsUNC, "UNC\" & f.Substring(2, f.Length - 2), f)
                    Try
                        DeleteFile(f)
                    Catch ex As Exception
                        Debug.Print("DeleteStuff(" & f & "): " & ex.Message)
                    End Try

                End If

                count += 1

            Catch
            End Try
        Next

        For Each fld In Directory.GetDirectories(path)
            Try
                count += DeleteStuff(fld)
                If fld.Length < 240 Then
                    Try
                        Directory.Delete(fld, True)
                    Catch ex As Exception
                        If ex.Message.Contains("too long") Then
                            fld = "\\?\" & fld 'If(IsUNC, "UNC\" & fld.Substring(2, fld.Length - 2), fld)
                            DeleteFile(fld)
                        Else
                            Debug.Print("DeleteStuff(" & fld & "): " & ex.Message)
                        End If
                    End Try
                Else
                    fld = "\\?\" & fld 'If(IsUNC, "UNC\" & fld.Substring(2, fld.Length - 2), fld)
                    Try
                        DeleteFile(fld)
                    Catch ex As Exception
                        Debug.Print("DeleteStuff(" & fld & "): " & ex.Message)
                    End Try
                End If

                count += 1

            Catch
            End Try
        Next

        Return count

    End Function

    Private Sub bgwGlobal_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwGlobal.DoWork

        Dim tempDir As String = ""
        Dim FileCount As Integer = 0

        Shell("cmd.exe /c psexec.exe \\" & Host & " -accepteula -h net stop spooler", AppWinStyle.Hide, True, 5000)

        bgwGlobal.ReportProgress(0, "--Cleaning Global Directories (" & clbGlobal.CheckedItems.Count.ToString & " items selected)--")

        For Each item In clbGlobal.CheckedItems
            Try
                tempDir = Drive & "\" & item.ToString

                If item.ToString <> "" Then
                    If Directory.Exists(tempDir) Then
                        If bgwGlobal.CancellationPending Then Exit Sub

                        ClearAttributes(tempDir)

                        FileCount = DeleteStuff(tempDir)

                    End If
                End If

                bgwGlobal.ReportProgress(0, New String() {1, If(FileCount > 0, tempDir & ":  " & FileCount.ToString & " files", "")})
            Catch
                bgwGlobal.ReportProgress(0, New String() {1, ""})
            End Try
        Next

    End Sub

    Private Sub bgwGlobal_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwGlobal.ProgressChanged

        Try
            progbarGlobal.Increment(e.UserState(0))
            progbarGlobal.Value = e.ProgressPercentage
            If e.UserState(1) <> "" Then
                Log(e.UserState(1))
            End If
        Catch
        End Try

    End Sub

    Private Sub bgwGlobal_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwGlobal.RunWorkerCompleted

        Shell("cmd.exe /c psexec.exe \\" & Host & " -accepteula -h net start spooler", AppWinStyle.Hide, True, 5000)

        ' kick off the next backgroundworker
        bgwUser = New BackgroundWorker
        bgwUser.WorkerReportsProgress = True
        bgwUser.WorkerSupportsCancellation = True
        bgwUser.RunWorkerAsync()

    End Sub

    Private Sub bgwUser_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwUser.DoWork

        Dim UserDir As String = ""
        Dim tempUserDir As String = ""
        Dim FileCount As Integer = 0

        bgwUser.ReportProgress(0, "--Cleaning User Folders (" & clbUsers.CheckedItems.Count & " users selected)--")

        For Each item In clbUsers.CheckedItems

            Try
                If item.ToString <> "" Then

                    UserDir = item.ToString
                    bgwUser.ReportProgress(0, New String() {0, "--" & UserDir & "--"})

                    For Each subdir In clbPerUser.CheckedItems
                        Try
                            If bgwUser.CancellationPending Then Exit Sub

                            If subdir.ToString <> "" Then

                                tempUserDir = UserDir & "\" & subdir.ToString
                                If Directory.Exists(tempUserDir) Then
                                    Try
                                        ClearAttributes(tempUserDir)
                                    Catch
                                    End Try
                                    Try
                                        FileCount = DeleteStuff(tempUserDir)
                                    Catch
                                    End Try
                                End If
                            End If
                            'ProgUserLocCount += ProgUserLocIncrement
                            bgwUser.ReportProgress(0, New String() {1, If(FileCount > 0, tempUserDir & ":  " & FileCount.ToString & " files", "")})
                            FileCount = 0
                        Catch
                            bgwUser.ReportProgress(0, New String() {1, ""})
                        End Try
                    Next

                End If
            Catch
                bgwUser.ReportProgress(0, New String() {0, ""})
            End Try
        Next

        If chkDeleteInvalid.Checked Then
            bgwUser.ReportProgress(0, New String() {0, "--Deleting profiles of invalid/unknown users--"})

            For i As Integer = 0 To ProfilesToDeleteCount - 1

                bgwUser.ReportProgress(0, New String() {0, ProfilesToDelete(i)})

                'Shell("cmd /c takeown /F """ & ProfilesToDelete(i) & """ /R /D Y /A", AppWinStyle.Hide, True)
                'Shell("cmd /c icacls """ & ProfilesToDelete(i) & "\"" /grant Administrators:(F) /T /C /Q", AppWinStyle.Hide, True)

                'Try
                '    ClearAttributes(ProfilesToDelete(i))            ' clear hidden/ro/etc attributes
                'Catch
                'End Try
                'Try
                '    FileCount = DeleteStuff(ProfilesToDelete(i))     ' empty the folder
                'Catch
                'End Try
                'Try
                '    Directory.Delete(ProfilesToDelete(i), True)      ' delete the folder itself
                'Catch
                'End Try
                Try
                    Shell("cmd /c rmdir /S /Q """ & ProfilesToDelete(i) & """", AppWinStyle.Hide, True)
                Catch
                End Try

                bgwUser.ReportProgress(0, New String() {1, ""})
                'ProgUserCount += ProgUserLocIncrement

            Next
        End If

        If chkDeleteOrphans.Checked Then
            bgwUser.ReportProgress(100, "--Removing invalid/orphaned user records from the registry--")
            Try
                Using reg As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host, RegistryView.Default)
                    Using ProfileList As RegistryKey = reg.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", True)
                        For i As Integer = 0 To UsersToDeleteCount - 1
                            If UsersToDelete(i).Length > 0 Then
                                Try
                                    ProfileList.DeleteSubKeyTree(UsersToDelete(i), False)
                                    bgwUser.ReportProgress(100, "Removed " & UsersToDelete(i))
                                Catch
                                End Try
                            End If
                        Next
                    End Using
                End Using
            Catch
            End Try
        End If

    End Sub

    Private Sub bgwUser_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwUser.ProgressChanged

        Try
            progbarGlobal.Increment(e.UserState(0))
            If e.UserState(1) <> "" Then
                Log(e.UserState(1))
            End If
        Catch
        End Try

    End Sub

    Private Sub bgwUser_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwUser.RunWorkerCompleted

        If IsSilent Then Application.Exit()

        Dim tempFreeBytes As Long = 0
        Dim tempTotalBytes As Long = 0
        Dim tempTotalFreeBytes As Long = 0

        Log("")
        Try
            GetDiskFreeSpaceEx(Drive, tempFreeBytes, tempTotalBytes, tempTotalFreeBytes)
            Dim BytesDeleted As Double = CDbl(tempTotalFreeBytes) - CDbl(lTotalFreeBytes)
            Select Case BytesDeleted
                Case Is < BytesInMB
                    Log(Format(BytesDeleted / 1024.0, "###0.00") & " KB temizlendi")
                Case Is > BytesInGB
                    Log(Format(BytesDeleted / BytesInGB, "###0.00") & " GB temizlendi")
                Case Else
                    Log(Format(BytesDeleted / BytesInMB, "###0.00") & " MB temizlendi")
            End Select
        Catch
        End Try

        ' NotifyIcon özelliklerini ayarla
        NotifyIcon1.BalloonTipText = "İşlem Tamamlandı."
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "BTcleaner Pro"



        ' Bildirimi göster
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(5000) ' 5000 ms = 5 saniye boyunca göster        Reset()
        HesaplaVeGuncelle()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If (Not bgwGlobal Is Nothing) And bgwGlobal.IsBusy Then
            bgwGlobal.CancelAsync()
        End If

        If (Not bgwUser Is Nothing) And bgwUser.IsBusy Then
            bgwUser.CancelAsync()
        End If

        Log("Kullanıcı işlemi iptal etti")

        Reset()

    End Sub



    Private Sub TrayIcon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrayIcon.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize


    End Sub

    Private Sub chkCheckValid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim IsChecked As Boolean = chkCheckValid.Checked
        chkDeleteInvalid.Checked = IsChecked
        chkDeleteInvalid.Enabled = IsChecked
        chkDeleteOrphans.Checked = IsChecked
        chkDeleteOrphans.Enabled = IsChecked

        GetUserDirs()

    End Sub

    Private Sub txtHost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtHost.Text = txtHost.Text.Replace(" ", "")
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Process.Start("cmd.exe", $"/c start https://www.bilgisayartime.com/p/btcleaner-neleri-siliyor.html")

    End Sub
End Class