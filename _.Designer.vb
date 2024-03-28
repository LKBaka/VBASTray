<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class __
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(__))
        DontCloseThisWindow = New Label()
        Btn_MinWindow = New Label()
        NotifyIcon1 = New NotifyIcon(components)
        ContextMenuStrip2 = New ContextMenuStrip(components)
        退出主防ToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip2.SuspendLayout()
        SuspendLayout()
        ' 
        ' DontCloseThisWindow
        ' 
        DontCloseThisWindow.AutoSize = True
        DontCloseThisWindow.Font = New Font("黑体", 42F, FontStyle.Regular, GraphicsUnit.Point)
        DontCloseThisWindow.ForeColor = Color.DarkRed
        DontCloseThisWindow.Location = New Point(102, 185)
        DontCloseThisWindow.Name = "DontCloseThisWindow"
        DontCloseThisWindow.Size = New Size(660, 70)
        DontCloseThisWindow.TabIndex = 0
        DontCloseThisWindow.Text = "不要关闭此窗口！！"
        ' 
        ' Btn_MinWindow
        ' 
        Btn_MinWindow.AutoSize = True
        Btn_MinWindow.Font = New Font("黑体", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Btn_MinWindow.Location = New Point(807, 9)
        Btn_MinWindow.Name = "Btn_MinWindow"
        Btn_MinWindow.Size = New Size(22, 23)
        Btn_MinWindow.TabIndex = 2
        Btn_MinWindow.Text = "-"
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip2
        NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        NotifyIcon1.Text = "VBASTray"
        NotifyIcon1.Visible = True
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {退出主防ToolStripMenuItem})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(139, 28)
        ' 
        ' 退出主防ToolStripMenuItem
        ' 
        退出主防ToolStripMenuItem.Name = "退出主防ToolStripMenuItem"
        退出主防ToolStripMenuItem.Size = New Size(138, 24)
        退出主防ToolStripMenuItem.Text = "退出主防"
        ' 
        ' __
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(841, 516)
        Controls.Add(Btn_MinWindow)
        Controls.Add(DontCloseThisWindow)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        Name = "__"
        Text = "__"
        ContextMenuStrip2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DontCloseThisWindow As Label
    Friend WithEvents Btn_MinWindow As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents 退出主防ToolStripMenuItem As ToolStripMenuItem
End Class
