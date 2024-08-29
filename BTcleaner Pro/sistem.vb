Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Management
Imports System.Runtime.InteropServices
Imports OpenHardwareMonitor.Hardware
Imports System
Imports System.Linq
Imports System.ComponentModel

Public Class sistem

    <DllImport("psapi.dll", SetLastError:=True)>
    Private Shared Function EmptyWorkingSet(hProcess As IntPtr) As Boolean
    End Function

    ' Windows tema rengini saklamak için bir değişken
    Private systemColor As Color

    <DllImport("dwmapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, <MarshalAs(UnmanagedType.Bool)> ByRef pfOpaqueBlend As Boolean) As Integer
    End Function

    Private ramCounter As New PerformanceCounter("Memory", "Available MBytes")
    Private totalRam As Long = My.Computer.Info.TotalPhysicalMemory / (1024 * 1024) ' Toplam RAM MB cinsinden

    Private Sub sistem_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        ' Timer'ı başlatma işlemini arka planda yap
        Task.Run(Sub() UpdateStats())

        ' RENK AYARLARI --------------------
        ' Windows tema rengini al ve değişkene ata
        systemColor = GetWindowsThemeColor()

        ProgressBar2.ProgressColor = systemColor
        ProgressBar2.ProgressColor2 = systemColor
        Guna2Button1.FillColor = systemColor
    End Sub

    ' Windows Tema rengini çekme fonksiyonu
    Private Function GetWindowsThemeColor() As Color
        Dim color As Integer
        Dim opaque As Boolean
        DwmGetColorizationColor(color, opaque)
        Return System.Drawing.Color.FromArgb(255, (color >> 16) And 255, (color >> 8) And 255, color And 255)
    End Function

    ' RAM Kullanımı bilgilerini güncelleme fonksiyonu
    Private Async Function UpdateStats() As Task
        While True
            ' Verileri güncelle
            Dim availableRam As Single = ramCounter.NextValue() ' Boşta RAM miktarı MB cinsinden
            Dim usedRam As Single = totalRam - availableRam ' Kullanılan RAM miktarı
            Dim ramUsage As Single = (usedRam / totalRam) * 100 ' Kullanım yüzdesi

            ' UI'daki bileşenleri güncelle
            If Me.IsHandleCreated Then
                Me.Invoke(Sub()
                              ProgressBar2.Value = Math.Min(100, CInt(ramUsage))
                              Label2.Text = $"RAM Kullanımı: {Math.Round(ramUsage, 2)}%"
                          End Sub)
            End If

            ' 1 saniyede bir güncelle
            Await Task.Delay(1000)
        End While
    End Function

    ' RAM TEMİZLEME fonksiyonu
    Private Sub CleanProcessesWorkingSet()
        For Each process As Process In Process.GetProcesses().Where(Function(p) p IsNot Nothing)
            Try
                Using process
                    If (Not process.HasExited) AndAlso EmptyWorkingSet(process.Handle) = 0 Then
                        Throw New Win32Exception(Marshal.GetLastWin32Error())
                    End If
                End Using
            Catch
                ' Hata yönetimi burada ele alınabilir.
            End Try
        Next process
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        EmptyWorkingSet(Process.GetCurrentProcess().Handle)

        ' Çöp toplayıcı çalıştırılır.
        GC.Collect(1, GCCollectionMode.Forced)
        GC.WaitForPendingFinalizers()

        ' Çalışan işlemlerin çalışma setleri temizlenir.
        CleanProcessesWorkingSet()

        ' RAM bilgisi güncellenir.
        Dim ramMonitor As New ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem")
        Dim totalRam As ULong = 0
        Dim freeRam As ULong = 0

        For Each objram As ManagementObject In ramMonitor.Get()
            totalRam = Convert.ToUInt64(objram("TotalVisibleMemorySize"))
            freeRam = Convert.ToUInt64(objram("FreePhysicalMemory"))
        Next objram

        Dim usedPercent As Double = (freeRam / totalRam) * 100
        Dim usedPercentInt As Integer = CInt(Math.Truncate(Math.Round(usedPercent)))

        ' EmptyStandbyList.exe çalıştırma
        Try
            Dim processInfo As New ProcessStartInfo()
            processInfo.FileName = "ram temizleme (emptystandbylist).exe"
            processInfo.UseShellExecute = False
            processInfo.CreateNoWindow = True
            processInfo.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(processInfo)
        Catch ex As Exception
            ' Hata yönetimi yapılabilir
        End Try

        ' Onay bildirimi
        NotifyIcon1.BalloonTipText = "RAM Temizlendi"
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "BTcleaner Pro"
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(2000)
    End Sub
End Class
