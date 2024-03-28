Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Net.WebRequestMethods

Imports System.Security.Cryptography
Imports System.ServiceProcess
Imports System.Threading
Imports Qihoo.CloudEngine
Imports Microsoft.Win32
Imports System.Drawing.Drawing2D

Public Class VBASTrayMain
    Public FileName_Show As String
    Public MalwareType_Show As String
    Public ProcessName
    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)>
    Shared Function LoadLibrary(lpLibFileName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Shared Function FreeLibrary(hLibModule As IntPtr) As Boolean
    End Function
    Declare Function ReleaseCapture Lib "user32" () As Long
    Declare Function SendMessage Lib "user32" _
    Alias "SendMessageA" (
    ByVal hwnd As Long, ByVal wMsg As Long,
    ByVal wParam As Long, lParam As Int32) As Long
    Public Const HTCAPTION = 2
    Public Const WM_NCLBUTTONDOWN = &HA1
    Public NSudoPath = Application.StartupPath + "\NSudoDM.dll"
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Public Async Sub Get_(path, type, pname)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        FileName_Show = path
        MalwareType_Show = type
        ProcessName = pname

        Await Task.Run(Sub()
                           Dim processnameList As Process()
                           processnameList = Process.GetProcessesByName(ProcessName)

                           For Each p In processnameList
                               Try
                                   Dim NsudoDLL As IntPtr = LoadLibrary(NSudoPath)
                                   p.Kill()
                                   FreeLibrary(NsudoDLL)
                               Catch ex As Exception

                               End Try
                           Next
                       End Sub)
        'ProcessName = Name
        UpdateUI()
    End Sub
    Private Sub UpdateUI()
        ' 确保这个方法在UI线程上执行  
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateUI))
            Return
        End If

        ' 更新UI元素  
        Path_.Text = "病毒路径: " & FileName_Show
        MType_.Text = "病毒名称: " & MalwareType_Show
        ' 注意：这里不应该包含加载和卸载DLL的逻辑，除非这是必要的后台任务  
        ' ...（其他需要在UI线程上执行的更新操作）  
    End Sub
    Public Sub MinWindow()

        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub DrawRoundedRectangle(ByVal g As Graphics, ByVal pen As Pen, ByVal rect As Rectangle, ByVal radius As Single)
        Dim path As New GraphicsPath()
        path.AddLine(rect.Left + radius, rect.Top, rect.Left + rect.Width - radius, rect.Top)
        path.AddArc(New RectangleF(rect.Left + rect.Width - radius, rect.Top, radius * 2, radius * 2), -180, 90)
        path.AddLine(rect.Left + rect.Width, rect.Top + radius, rect.Left + rect.Width, rect.Top + rect.Height - radius)
        path.AddArc(New RectangleF(rect.Left + rect.Width - radius, rect.Top + radius, radius * 2, radius * 2), -90, 90)
        path.AddLine(rect.Left + rect.Width - radius, rect.Top + rect.Height, rect.Left, rect.Top + rect.Height)
        path.AddArc(New RectangleF(rect.Left, rect.Top + radius, radius * 2, radius * 2), 0, 90)
        path.AddLine(rect.Left + radius, rect.Top + rect.Height, rect.Left + radius, rect.Top)
        path.AddArc(New RectangleF(rect.Left + radius, rect.Top, radius * 2, radius * 2), 90, 90)
        g.DrawPath(pen, path)
    End Sub






    Private Sub VBASTrayMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 获取当前屏幕的工作区域  
        Dim screen As Screen = Screen.FromControl(Me)
        Dim workingArea As Rectangle = screen.WorkingArea

        ' 计算窗口左上角的X坐标（屏幕宽度减去窗口宽度）  
        Dim x As Integer = workingArea.Width - Me.Width

        ' 计算窗口左上角的Y坐标（屏幕高度减去窗口高度）  
        Dim y As Integer = workingArea.Height - Me.Height

        ' 将窗体移动到计算出的位置  
        Me.Location = New Point(x, y)

        Opacity = 1.0


    End Sub

    Private Sub VBASTrayMain_Click(sender As Object, e As EventArgs) Handles MyBase.Click

        Close()
    End Sub

    Private Sub VBASTrayMain_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

    End Sub
End Class