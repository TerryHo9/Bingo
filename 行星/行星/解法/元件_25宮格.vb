Public Class 元件_25宮格
    Private la() As Label = Nothing
    Private SW As New Stopwatch()
    Public Sub 顯示(局 As 一局, Optional 解法 As I計算最佳盤面 = Nothing)
        If Me.la Is Nothing Then
            Dim 容器 As IEnumerable(Of Control) = (From 元件 As Control In Me.Controls).Where(Function(a As Control) a.GetType().Equals(GetType(Label)))
            ReDim Me.la(容器.Count - 1)
            For Each 格 As Label In 容器
                Me.la(Integer.Parse(格.Text) - 1) = 格
            Next
        End If

        If 解法 IsNot Nothing Then
            SW.Restart()
            Dim 次數 As Integer = 解法.解法(局)
            SW.Stop()
            'Me.TextBox2.Text = $"耗時:{SW.Elapsed.TotalMicroseconds:n1}μs   計算:{次數}次"
            Me.TextBox2.Text = $"耗時:{SW.Elapsed.TotalMilliseconds:n1}ms   計算:{次數}次"
        End If

        For i As Integer = 0 To 局.宮格s.Length - 1
            Me.la(i).Text = 局.宮格s(i).號碼
            If 局.宮格s(i).亮燈 Then
                Me.la(i).BackColor = Color.DeepSkyBlue
                If 局.宮格s(i).送燈 Then
                    Me.la(i).ForeColor = Color.Yellow
                Else
                    Me.la(i).ForeColor = Color.MidnightBlue
                End If
            Else
                Me.la(i).BackColor = Color.MidnightBlue
                Me.la(i).ForeColor = Color.DeepSkyBlue
            End If
        Next
        If 局.第45球位(0) >= 0 Then Me.la(局.第45球位(0)).ForeColor = Color.Orange
        If 局.第45球位(1) >= 0 Then Me.la(局.第45球位(1)).ForeColor = Color.Green
    End Sub
End Class