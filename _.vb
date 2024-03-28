Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.ServiceProcess
Imports System.Threading
Imports Qihoo.CloudEngine
Imports Microsoft.Win32
Imports System.ComponentModel
Imports Microsoft.Toolkit.Uwp.Notifications

Public Class __
    Public pname
    Public type
    Public path

    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)>
    Shared Function LoadLibrary(lpLibFileName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Shared Function FreeLibrary(hLibModule As IntPtr) As Boolean
    End Function
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Await ProcessScan()
    End Sub

    Public Async Function ProcessScan() As Task
        Await Task.Run(Async Function()

                           If Me.InvokeRequired Then
                               Me.Invoke(New MethodInvoker(AddressOf Hide))
                           Else
                               Hide()
                           End If
                           Dim NSudoPath = Application.StartupPath + "NSudoDM.dll" 'dll路径
                           Dim prevProcesses() As Process = {}
                           Dim currentProcesses() As Process = Process.GetProcesses()
                           'Dim s As New Scan()
                           While True
                               Dim NSudoDevilModeModuleHandle As IntPtr = LoadLibrary(NSudoPath) ' DLL文件名  

                               ' 获取当前所有进程  
                               Dim currentProcessesSnapshot() As Process
                               currentProcessesSnapshot = Process.GetProcesses()
                               ' 检测新进程  
                               For Each newProcess In currentProcessesSnapshot.Except(prevProcesses).ToList
                                   Try
                                       Dim md5 As String
                                       If Not (IsServiceRunning(newProcess.ProcessName)) Then
                                           md5 = getMD5(newProcess.MainModule.FileName)
                                       Else
                                           Continue For
                                       End If

                                       Dim result As FileHealthResult = FileHealth.CheckAsync(md5).Result
                                       If result IsNot Nothing And result.IsOperationSuccess Then

                                           If result.Level > 50 Then
                                               pname = newProcess.ProcessName
                                               type = result.MalwareType
                                               path = newProcess.MainModule.FileName
                                               Await ShowForm2Async()


                                           End If
                                           Debug.Print("Name=" & newProcess.ProcessName & ",Path=" & newProcess.MainModule.FileName & ",Level=" & result.Level)

                                       End If
                                       prevProcesses.Append(newProcess)
                                   Catch ex As Exception
                                       Debug.Print(ex.Message)
                                   End Try
                               Next

                               ' 更新prevProcesses列表  
                               prevProcesses = currentProcessesSnapshot
                               FreeLibrary(NSudoDevilModeModuleHandle)


                           End While
                       End Function)
    End Function
    Public Function IsServiceRunning(serviceName As String) As Boolean
        Try
            Using serviceController As New ServiceController(serviceName)
                Return serviceController.Status = ServiceControllerStatus.Running
            End Using
        Catch ex As Exception When (TypeOf ex Is InvalidOperationException)
            ' 服务可能不存在，忽略异常并返回False  
            Console.WriteLine("The service does not exist or is not accessible.")
            Return False
        Catch ex As Exception
            ' 处理其他异常  
            Console.WriteLine("An error occurred while checking the service status: " & ex.Message)
            Return False
        End Try
    End Function
    Private Async Function ShowForm2Async() As Task


        ' 确保在UI线程上显示Form2  
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf ShowForm2OnUiThread))
        Else
            ShowForm2OnUiThread()
        End If
    End Function

    Private Sub ShowForm2OnUiThread()
        Dim f As New VBASTrayMain()
        f.Show()
        f.Get_(path:=path, type:=type, pname:=pname)
    End Sub
    Public Function getMD5(ByVal strSource As String) As String
        Dim r As String = ""
        ' If MainForm.State = 0 Then
        Try

            Dim fstream As New FileStream(strSource, FileMode.Open, FileAccess.Read)
            Dim dataToHash(fstream.Length - 1) As Byte
            fstream.Read(dataToHash, 0, fstream.Length)
            fstream.Close()
            Dim hashvalue As Byte() = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(dataToHash)
            Dim i As Integer
            For i = 0 To hashvalue.Length - 1
                r += Microsoft.VisualBasic.Right("00" + Hex(hashvalue(i)).ToLower, 2)
            Next
            Return r
        Catch ex As Exception

            Return r
        End Try
        ' End If
    End Function

    Private Sub Btn_MinWindow_Click(sender As Object, e As EventArgs) Handles Btn_MinWindow.Click
        MinWindow()
    End Sub
    Public Sub MinWindow()

        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub 退出主防ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出主防ToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class