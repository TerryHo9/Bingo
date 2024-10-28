<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        原盤面 = New 元件_25宮格()
        遍歷算法 = New 元件_25宮格()
        Btn新局 = New Button()
        最優算法 = New 元件_25宮格()
        Lb說明 = New Label()
        Btn押1注 = New Button()
        Btn押10注 = New Button()
        Btn開3球 = New Button()
        Timer1 = New Timer(components)
        Btn驗分 = New Button()
        SuspendLayout()
        ' 
        ' 原盤面
        ' 
        原盤面.Location = New Point(12, 5)
        原盤面.Name = "原盤面"
        原盤面.Size = New Size(300, 340)
        原盤面.TabIndex = 0
        ' 
        ' 遍歷算法
        ' 
        遍歷算法.Location = New Point(318, 5)
        遍歷算法.Name = "遍歷算法"
        遍歷算法.Size = New Size(300, 340)
        遍歷算法.TabIndex = 1
        ' 
        ' Btn新局
        ' 
        Btn新局.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        Btn新局.Font = New Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(136))
        Btn新局.Location = New Point(346, 456)
        Btn新局.Name = "Btn新局"
        Btn新局.Size = New Size(140, 80)
        Btn新局.TabIndex = 2
        Btn新局.Text = "新局"
        Btn新局.UseVisualStyleBackColor = False
        ' 
        ' 最優算法
        ' 
        最優算法.Location = New Point(624, 5)
        最優算法.Name = "最優算法"
        最優算法.Size = New Size(300, 340)
        最優算法.TabIndex = 3
        ' 
        ' Lb說明
        ' 
        Lb說明.BorderStyle = BorderStyle.FixedSingle
        Lb說明.Font = New Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(136))
        Lb說明.Location = New Point(24, 350)
        Lb說明.Name = "Lb說明"
        Lb說明.Size = New Size(900, 100)
        Lb說明.TabIndex = 4
        Lb說明.Text = "Label1"
        Lb說明.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Btn押1注
        ' 
        Btn押1注.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        Btn押1注.Font = New Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(136))
        Btn押1注.Location = New Point(492, 456)
        Btn押1注.Name = "Btn押1注"
        Btn押1注.Size = New Size(140, 80)
        Btn押1注.TabIndex = 5
        Btn押1注.Text = "押1注"
        Btn押1注.UseVisualStyleBackColor = False
        ' 
        ' Btn押10注
        ' 
        Btn押10注.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        Btn押10注.Font = New Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(136))
        Btn押10注.Location = New Point(638, 456)
        Btn押10注.Name = "Btn押10注"
        Btn押10注.Size = New Size(140, 80)
        Btn押10注.TabIndex = 6
        Btn押10注.Text = "押10注"
        Btn押10注.UseVisualStyleBackColor = False
        ' 
        ' Btn開3球
        ' 
        Btn開3球.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        Btn開3球.Font = New Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(136))
        Btn開3球.Location = New Point(784, 456)
        Btn開3球.Name = "Btn開3球"
        Btn開3球.Size = New Size(140, 80)
        Btn開3球.TabIndex = 7
        Btn開3球.Text = "開3球"
        Btn開3球.UseVisualStyleBackColor = False
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 10
        ' 
        ' Btn驗分
        ' 
        Btn驗分.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        Btn驗分.Font = New Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(136))
        Btn驗分.Location = New Point(24, 456)
        Btn驗分.Name = "Btn驗分"
        Btn驗分.Size = New Size(140, 80)
        Btn驗分.TabIndex = 8
        Btn驗分.Text = "驗分"
        Btn驗分.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(944, 541)
        Controls.Add(Btn驗分)
        Controls.Add(Btn開3球)
        Controls.Add(Btn押10注)
        Controls.Add(Btn押1注)
        Controls.Add(Lb說明)
        Controls.Add(最優算法)
        Controls.Add(Btn新局)
        Controls.Add(遍歷算法)
        Controls.Add(原盤面)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Friend WithEvents 原盤面 As 元件_25宮格
    Friend WithEvents 遍歷算法 As 元件_25宮格
    Friend WithEvents Btn新局 As Button
    Friend WithEvents 最優算法 As 元件_25宮格
    Friend WithEvents Lb說明 As Label
    Friend WithEvents Btn押1注 As Button
    Friend WithEvents Btn押10注 As Button
    Friend WithEvents Btn開3球 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Btn驗分 As Button

End Class
