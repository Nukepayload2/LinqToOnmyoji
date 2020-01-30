<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiagnosisMode
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLaunch = New System.Windows.Forms.Button()
        Me.LstAsms = New System.Windows.Forms.ListView()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "已加载的程序集"
        '
        'BtnLaunch
        '
        Me.BtnLaunch.Location = New System.Drawing.Point(112, 579)
        Me.BtnLaunch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnLaunch.Name = "BtnLaunch"
        Me.BtnLaunch.Size = New System.Drawing.Size(87, 33)
        Me.BtnLaunch.TabIndex = 2
        Me.BtnLaunch.Text = "启动..."
        Me.BtnLaunch.UseVisualStyleBackColor = True
        '
        'LstAsms
        '
        Me.LstAsms.HideSelection = False
        Me.LstAsms.Location = New System.Drawing.Point(17, 57)
        Me.LstAsms.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LstAsms.Name = "LstAsms"
        Me.LstAsms.Size = New System.Drawing.Size(901, 513)
        Me.LstAsms.TabIndex = 3
        Me.LstAsms.UseCompatibleStateImageBehavior = False
        Me.LstAsms.View = System.Windows.Forms.View.Details
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Location = New System.Drawing.Point(17, 579)
        Me.BtnRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(87, 33)
        Me.BtnRefresh.TabIndex = 4
        Me.BtnRefresh.Text = "刷新"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'FrmDiagnosisMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 629)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.LstAsms)
        Me.Controls.Add(Me.BtnLaunch)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmDiagnosisMode"
        Me.Text = "御魂方案录制宏桌面版 - 诊断模式"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BtnLaunch As Button
    Friend WithEvents LstAsms As ListView
    Friend WithEvents BtnRefresh As Button
End Class
