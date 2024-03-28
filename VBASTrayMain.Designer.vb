<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VBASTrayMain
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(VBASTrayMain))
        PictureBox1 = New PictureBox()
        Path_ = New Label()
        MType_ = New Label()
        Label1 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.ErrorImage = My.Resources.Resources.imageres_dll_81_
        PictureBox1.Image = My.Resources.Resources.imageres_dll_81_
        PictureBox1.Location = New Point(12, 9)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(61, 59)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Path_
        ' 
        Path_.AutoSize = True
        Path_.Font = New Font("黑体", 15F, FontStyle.Regular, GraphicsUnit.Point)
        Path_.Location = New Point(12, 83)
        Path_.Name = "Path_"
        Path_.Size = New Size(0, 25)
        Path_.TabIndex = 2
        ' 
        ' MType_
        ' 
        MType_.AutoSize = True
        MType_.Font = New Font("黑体", 15F, FontStyle.Regular, GraphicsUnit.Point)
        MType_.Location = New Point(12, 118)
        MType_.Name = "MType_"
        MType_.Size = New Size(0, 25)
        MType_.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("黑体", 22.5F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(79, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(207, 38)
        Label1.TabIndex = 4
        Label1.Text = "已拦截木马"
        ' 
        ' VBASTrayMain
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSkyBlue
        ClientSize = New Size(690, 209)
        Controls.Add(Label1)
        Controls.Add(MType_)
        Controls.Add(Path_)
        Controls.Add(PictureBox1)
        ForeColor = Color.Black
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "VBASTrayMain"
        Text = "VBASTrayMain"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Pname As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Path_ As Label
    Friend WithEvents MType_ As Label
    Friend WithEvents Label1 As Label
End Class
