Imports 行星.Xdll

Public Class 一局
    Private Shared 連線得分()() As Integer = {
        New Integer() {128, 384, 1024}, '1F
        New Integer() {128, 384, 1024}, '2F
        New Integer() {256, 768, 2048}, '3F
        New Integer() {256, 768, 2048}, '4F
        New Integer() {512, 1536, 4096}, '5F
        New Integer() {512, 1536, 4096}, '6F
        New Integer() {768, 2304, 6144}, '7F
        New Integer() {768, 2304, 6144}, '8F
        New Integer() {1000, 3000, 10000}, '9F
        New Integer() {1000, 3000, 10000}} '10F

    Public Enum UP類 As Byte
        無 = 0
        升1樓 = 1
        升2樓 = 2
        乘2倍 = 3
    End Enum
    Public Enum 保送類 As Byte
        無 = 0
        入紅洞 = 1
        入黃洞 = 2
    End Enum
    Public Enum 送燈類 As Byte
        無 = 0
        縱 = 1
        橫 = 2
        縱橫 = 3
    End Enum
    Public Enum e四角燈 As Byte
        無 = 0
        小 = 1
        大 = 2
    End Enum
    Public Class 宮格
        Public 亮燈 As Boolean
        Public 號碼 As Byte
        Public 送燈 As Boolean
    End Class

    Private 隨機送燈位 As New List(Of Byte)

    Public 樓層 As Byte
    Public 押注額 As UInteger
    Public 得分額 As ULong
    Public 連線位 As UInteger
    Public 第45球位(1) As Integer '期望後2球進洞位
    Public 旋轉次(3) As Byte '最佳策略的各區旋轉次

    Public 紅球紅洞 As Boolean
    Public 紅球黃洞 As Boolean
    Public 黃球黃洞 As Boolean
    Public UP As UP類 = UP類.無
    Public 保送 As 保送類 = 保送類.無
    Public 四角燈 As e四角燈 = e四角燈.無
    Public 縱橫燈 As 送燈類 = 送燈類.無
    Public 宮格s As 宮格()
    Public 號碼s As 宮格()

    '0  1   2   3   4
    '5  6   7   8   9
    '10 11  12  13  14
    '15 16  17  18  19
    '20 21  22  23  24
    Public Sub 旋轉D()
        Dim 暫時 As 宮格 = Me.宮格s(18)
        Me.宮格s(18) = Me.宮格s(23)
        Me.宮格s(23) = Me.宮格s(24)
        Me.宮格s(24) = Me.宮格s(19)
        Me.宮格s(19) = 暫時
    End Sub
    Public Sub 旋轉C()
        Dim 暫時 As 宮格 = Me.宮格s(15)
        Me.宮格s(15) = Me.宮格s(20)
        Me.宮格s(20) = Me.宮格s(21)
        Me.宮格s(21) = Me.宮格s(16)
        Me.宮格s(16) = 暫時
    End Sub
    Public Sub 旋轉B()
        Dim 暫時 As 宮格 = Me.宮格s(3)
        Me.宮格s(3) = Me.宮格s(8)
        Me.宮格s(8) = Me.宮格s(9)
        Me.宮格s(9) = Me.宮格s(4)
        Me.宮格s(4) = 暫時
    End Sub
    Public Sub 旋轉A()
        Dim 暫時 As 宮格 = Me.宮格s(0)
        Me.宮格s(0) = Me.宮格s(5)
        Me.宮格s(5) = Me.宮格s(6)
        Me.宮格s(6) = Me.宮格s(1)
        Me.宮格s(1) = 暫時
    End Sub
    Public Sub New()
        ReDim Me.宮格s(24)
        ReDim Me.號碼s(25)
        For i As Integer = 0 To Me.宮格s.Length - 1
            Me.宮格s(i) = New 宮格()
        Next
    End Sub
    Public Sub CopyFrom(局 As 一局)
        Array.Copy(局.旋轉次, 0, Me.旋轉次, 0, Me.旋轉次.Length)
        For i As Integer = 0 To Me.宮格s.Length - 1
            Me.宮格s(i).亮燈 = 局.宮格s(i).亮燈
            Me.宮格s(i).號碼 = 局.宮格s(i).號碼
            Me.宮格s(i).送燈 = 局.宮格s(i).送燈
            Me.號碼s(Me.宮格s(i).號碼) = Me.宮格s(i)
        Next
        Me.樓層 = 局.樓層
        Me.押注額 = 局.押注額
        Me.得分額 = 局.得分額
        Me.連線位 = 局.連線位
        Me.第45球位(0) = 局.第45球位(0) : Me.第45球位(1) = 局.第45球位(1)

        Me.紅球紅洞 = 局.紅球紅洞
        Me.紅球黃洞 = 局.紅球黃洞
        Me.黃球黃洞 = 局.黃球黃洞
        Me.UP = 局.UP
        Me.保送 = 局.保送
        Me.四角燈 = 局.四角燈
        Me.縱橫燈 = 局.縱橫燈
    End Sub
    Public Sub 新局()
        Me.隨機送燈位.Clear()
        Me.隨機送燈位.AddRange(New Byte() {7, 11, 12, 13, 17})

        Dim lis As New List(Of Integer)(Enumerable.Range(1, 25))
        Dim k As Integer = 0
        For i As Integer = 0 To Me.宮格s.Length - 1
            Me.宮格s(i).亮燈 = False : Me.宮格s(i).號碼 = 0 : Me.宮格s(i).送燈 = False
            k = Xdll.Mo.取亂數(lis.Count)
            Me.宮格s(i).號碼 = lis(k)
            Me.號碼s(Me.宮格s(i).號碼) = Me.宮格s(i)
            lis.RemoveAt(k)
        Next
        Me.樓層 = 0
        Me.押注額 = 0
        Me.得分額 = 0
        Me.連線位 = 0
        Me.第45球位(0) = -1 : Me.第45球位(1) = -1

        Me.紅球紅洞 = False
        Me.紅球黃洞 = False
        Me.黃球黃洞 = False
        Me.UP = UP類.無
        Me.保送 = 保送類.無
        Me.四角燈 = e四角燈.無
        Me.縱橫燈 = 送燈類.無
        For i As Integer = 0 To Me.旋轉次.Length - 1
            Me.旋轉次(i) = 0
        Next
    End Sub
    Public Sub 顯示()
        For k As Integer = 0 To 4
            Dim s As String = ""
            For i As Integer = 0 To 4
                If Me.宮格s(k * 5 + i).亮燈 Then
                    Select Case Me.宮格s(k * 5 + i).號碼
                        Case 1 : s = s & "①" & vbTab
                        Case 2 : s = s & "②" & vbTab
                        Case 3 : s = s & "③" & vbTab
                        Case 4 : s = s & "④" & vbTab
                        Case 5 : s = s & "⑤" & vbTab
                        Case 6 : s = s & "⑥" & vbTab
                        Case 7 : s = s & "⑦" & vbTab
                        Case 8 : s = s & "⑧" & vbTab
                        Case 9 : s = s & "⑨" & vbTab
                        Case 10 : s = s & "⑩" & vbTab
                        Case 11 : s = s & "⑪" & vbTab
                        Case 12 : s = s & "⑫" & vbTab
                        Case 13 : s = s & "⑬" & vbTab
                        Case 14 : s = s & "⑭" & vbTab
                        Case 15 : s = s & "⑮" & vbTab
                        Case 16 : s = s & "⑯" & vbTab
                        Case 17 : s = s & "⑰" & vbTab
                        Case 18 : s = s & "⑱" & vbTab
                        Case 19 : s = s & "⑲" & vbTab
                        Case 20 : s = s & "⑳" & vbTab
                        Case 21 : s = s & "㉑" & vbTab
                        Case 22 : s = s & "㉒" & vbTab
                        Case 23 : s = s & "㉓" & vbTab
                        Case 24 : s = s & "㉔" & vbTab
                        Case 25 : s = s & "㉕" & vbTab
                    End Select
                Else
                    s = s & Me.宮格s(k * 5 + i).號碼 & vbTab
                End If
            Next
            Debug.Print(s)
        Next
        Debug.Print("")
    End Sub

    Public Sub 押一注()
        Me.押注額 += 10
        If Me.樓層 < 9 AndAlso Xdll.Mo.取亂數((Me.樓層 + 1) * 2) = 0 Then
            Me.樓層 += 1
        End If

        If Me.隨機送燈位.Count > 0 AndAlso Xdll.Mo.取亂數(Math.Floor(500 / Me.隨機送燈位.Count)) = 0 Then '只會出現在中間十字共5格
            Dim Index As Byte = Xdll.Mo.取亂數(Me.隨機送燈位.Count)
            Me.宮格s(Me.隨機送燈位(Index)).亮燈 = True
            Me.宮格s(Me.隨機送燈位(Index)).送燈 = True
            Me.隨機送燈位.RemoveAt(Index)
        End If

        If Me.縱橫燈 = 送燈類.無 AndAlso Xdll.Mo.取亂數(30) = 0 Then
            Select Case Xdll.Mo.取亂數(11)
                Case 0 : Me.縱橫燈 = 送燈類.縱橫
                Case 1 To 5 : Me.縱橫燈 = 送燈類.縱
                Case Else : Me.縱橫燈 = 送燈類.橫
            End Select
        End If

        Select Case Me.UP
            Case UP類.無
                If Xdll.Mo.取亂數(15) Then Me.UP = UP類.升1樓
            Case UP類.升1樓
                Select Case Xdll.Mo.取亂數(11)
                    Case 0 : Me.UP = UP類.乘2倍
                    Case 1 To 5 : Me.UP = UP類.升2樓
                End Select
            Case UP類.升2樓
                If Xdll.Mo.取亂數(10) Then Me.UP = UP類.乘2倍
        End Select

        Select Case Me.保送
            Case 保送類.無
                Select Case Xdll.Mo.取亂數(100)
                    Case 0 To 1 : Me.保送 = 保送類.入黃洞
                    Case 2 To 7 : Me.保送 = 保送類.入紅洞
                End Select
        End Select

        If Me.四角燈 <> e四角燈.大 AndAlso Xdll.Mo.取亂數(20) = 0 Then
            If Me.四角燈 = e四角燈.無 Then
                Me.四角燈 = e四角燈.小
            ElseIf Me.四角燈 = e四角燈.小 Then
                Me.四角燈 = e四角燈.大
            End If
        End If
    End Sub

    Public Function 計算連線得分() As Integer
        Me.得分額 = 0 : Me.連線位 = 0

        Dim 連線數 As Byte
        Dim 有送燈 As Boolean
        Dim 連線位 As UInteger
        Dim 值 As Integer = 0, 十字外贈 As Integer = 0, 五碰外贈 As Integer = 0, 四角外贈 As Integer = 0

        Dim 得分樓層 As Byte = Me.樓層
        If Me.UP = UP類.升1樓 Then
            得分樓層 += 1
        ElseIf Me.UP = UP類.升2樓 Then
            得分樓層 += 2
        End If
        If 得分樓層 > 9 Then 得分樓層 = 9

        For i As Integer = 0 To Mo.連線表.Length - 1
            值 = 0 : 連線位 = 0 : 連線數 = 0 : 有送燈 = False
            For j As Integer = 0 To Mo.連線表(i).Length - 1
                If Me.宮格s(Mo.連線表(i)(j)).亮燈 Then
                    值 += 1
                    連線位 = 連線位 Or (1 << Mo.連線表(i)(j))
                    If Me.宮格s(Mo.連線表(i)(j)).送燈 Then 有送燈 = True
                End If
                If j < Mo.連線表(i).Length - 1 Then 值 = 值 << 1
            Next
            Select Case 值
                Case 31 : 連線數 = 5
                Case 15, 30 : 連線數 = 4
                Case 7, 14, 23, 28, 29 : 連線數 = 3
                Case 3, 6, 11, 12, 13, 19, 22, 24, 25, 26, 27 : 連線數 = 2
            End Select

            If 連線數 < 5 Then
                Select Case i
                    Case 0 To 4 : If Me.縱橫燈 = 送燈類.橫 OrElse Me.縱橫燈 = 送燈類.縱橫 Then 連線數 += 1
                    Case 5 To 9 : If Me.縱橫燈 = 送燈類.縱 OrElse Me.縱橫燈 = 送燈類.縱橫 Then 連線數 += 1
                End Select
                If 連線數 = 5 Then 有送燈 = True
            End If
            If 連線數 >= 3 Then
                If 連線數 = 5 Then
                    If i = 2 OrElse i = 7 Then
                        If 有送燈 = False Then '十字正五碰
                            十字外贈 = 40000
                        Else '十字副五碰
                            十字外贈 = 10000
                        End If
                    Else
                        If 有送燈 = False Then '正五碰
                            五碰外贈 = 20000
                        Else '副五碰
                            五碰外贈 = 5000
                        End If
                    End If
                End If
                If i >= 10 Then '交叉連線得分X2
                    Me.得分額 += (連線得分(得分樓層)(連線數 - 3) * 2)
                Else
                    Me.得分額 += 連線得分(得分樓層)(連線數 - 3)
                End If
                Me.連線位 = Me.連線位 Or 連線位
            End If
        Next
        If Me.UP = UP類.乘2倍 AndAlso Me.黃球黃洞 Then Me.得分額 *= 2

        If Me.宮格s(0).亮燈 AndAlso Me.宮格s(4).亮燈 AndAlso Me.宮格s(16).亮燈 AndAlso Me.宮格s(24).亮燈 Then '判斷四角燈(即便有黃球進黃洞也不會加倍)
            If Me.四角燈 <> e四角燈.無 Then
                Select Case Me.四角燈
                    Case e四角燈.小 : Me.得分額 += 200
                    Case e四角燈.大 : Me.得分額 += 500
                End Select
            End If
            四角外贈 = 2000
        End If

        If Me.押注額 >= 700 AndAlso (十字外贈 > 0 OrElse 五碰外贈 > 0 OrElse 四角外贈 > 0) Then
            Dim 外贈獎金 As Integer = 0
            If 十字外贈 > 0 Then
                外贈獎金 = 十字外贈
            ElseIf 五碰外贈 > 0 Then
                外贈獎金 = 五碰外贈
            Else
                外贈獎金 = 四角外贈
            End If
            If Me.樓層 < 6 Then 外贈獎金 /= 2
            Me.得分額 += 外贈獎金
        End If
        Return Me.得分額
    End Function
End Class