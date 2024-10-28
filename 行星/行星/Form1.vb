Imports 行星.一局

Public Class Form1
    Private _局 As 一局 = Nothing
    Private _最優局 As 一局 = Nothing
    Private _解法 As Dictionary(Of String, I計算最佳盤面)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._局 = New 一局()
        Me._最優局 = New 一局()

        Me.原盤面.TextBox1.Text = "原盤面"
        Me.遍歷算法.TextBox1.Text = "解法_遍歷"
        Me.最優算法.TextBox1.Text = "解法_最優"

        Me._解法 = New Dictionary(Of String, I計算最佳盤面)
        Me._解法.Add("遍歷", New 解法_遍歷)
        Me._解法.Add("遍歷改", New 解法_遍歷改)
        Me._解法.Add("最優", New 解法_最優)

        Me.新局_Click(Nothing, EventArgs.Empty)
    End Sub

    Private Sub 新局_Click(sender As Object, e As EventArgs) Handles Btn新局.Click
        Me._局.新局()

        ''測試用
        '_局.押注額 = 40
        '_局.樓層 = 2
        '_局.縱橫燈 = 送燈類.無
        '_局.UP = UP類.升2樓
        '_局.四角燈 = e四角燈.無
        '_局.黃球黃洞 = False

        'Dim 盤面() As Byte = New Byte() {
        '    6, 15, 7, 2, 1,
        '    19, 20, 9, 23, 3,
        '    14, 4, 13, 5, 12,
        '    11, 10, 24, 8, 16,
        '    17, 18, 25, 21, 22}

        'For i As Integer = 0 To 盤面.Length - 1
        '    _局.宮格s(i).號碼 = 盤面(i)
        '    _局.號碼s(_局.宮格s(i).號碼) = _局.宮格s(i)
        'Next

        '_局.宮格s(5).亮燈 = True
        '_局.宮格s(9).亮燈 = True
        '_局.宮格s(20).亮燈 = True
        ''_局.宮格s(13).亮燈 = True
        ''_局.宮格s(17).亮燈 = True

        ''_局.宮格s(13).送燈 = True
        ''_局.宮格s(17).送燈 = True
        ''
        ''Dim 得分 As Integer = _局.計算連線得分()

        'Me._局.顯示()
        Me.原盤面.顯示(Me._局)
        Me.遍歷算法.顯示(Me._局)
        Me.最優算法.顯示(Me._局)
        'Me.遍歷算法.顯示(Me._局, Me._解法("遍歷"))
        'Me.最優算法.顯示(Me._局, Me._解法("最優"))
        Me.更新資訊()
    End Sub
    Private Sub Btn押1注_Click(sender As Object, e As EventArgs) Handles Btn押1注.Click
        Me._局.押一注()
        Me.原盤面.顯示(Me._局)
        Me.更新資訊()
    End Sub
    Private Sub Btn押10注_Click(sender As Object, e As EventArgs) Handles Btn押10注.Click
        For i As Integer = 1 To 10
            Me._局.押一注()
        Next
        Me.原盤面.顯示(Me._局)
        Me.更新資訊()
    End Sub
    Private Sub Btn開3球_Click(sender As Object, e As EventArgs) Handles Btn開3球.Click
        Dim 可選格 As List(Of 宮格) = Me._局.宮格s.Where(Function(a) a.亮燈 = False).ToList
        Dim Index As Byte
        Dim 開球數 As Byte = 3
        While 開球數 > 0
            Index = Xdll.Mo.取亂數(可選格.Count)
            可選格(Index).亮燈 = True
            可選格.RemoveAt(Index)
            開球數 -= 1
        End While

        Me._最優局.CopyFrom(Me._局)

        'Me._局.顯示()
        'Me._最優局.顯示()
        Me.原盤面.顯示(Me._局)
        Me.遍歷算法.顯示(Me._局, Me._解法("遍歷"))
        Me.最優算法.顯示(Me._最優局, Me._解法("遍歷改"))
        'Me.最優算法.顯示(Me._Clone局, Me._解法("最優"))
        Me.更新資訊()
    End Sub

    Private Sub 更新資訊()
        Lb說明.Text = $"押注額:{_局.押注額}   得分額:{_局.得分額}   樓層:{_局.樓層 + 1}   紅球紅洞:{_局.紅球紅洞.ToString}   紅球黃洞:{_局.紅球黃洞.ToString}   黃球黃洞:{_局.黃球黃洞.ToString}{vbCrLf}縱/橫向送燈:{_局.縱橫燈.ToString}   UP燈:{_局.UP.ToString}   四角燈:{_局.四角燈.ToString}"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me._局.新局()
        Me.原盤面.顯示(Me._局)
        Me.遍歷算法.顯示(Me._局)
        Me.最優算法.顯示(Me._局)
        Dim 次數 As Integer = Xdll.Mo.取亂數(30) + 1
        While 次數 > 0
            Me._局.押一注()
            次數 -= 1
        End While
        Me.Btn開3球_Click(Nothing, EventArgs.Empty)
        If Me._局.得分額 <> Me._最優局.得分額 Then
            Stop
        End If
    End Sub

    Private Sub Btn驗分_Click(sender As Object, e As EventArgs) Handles Btn驗分.Click
        Me.Timer1.Enabled = Not Me.Timer1.Enabled
        If Me.Timer1.Enabled Then
            Me.Btn驗分.Text = "驗分中"
        Else
            Me.Btn驗分.Text = "驗分"
        End If
    End Sub
End Class