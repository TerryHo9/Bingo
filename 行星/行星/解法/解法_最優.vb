Imports 行星.Xdll

Public Class 解法_最優 : Implements I計算最佳盤面 '這解法未完成,先忽略不要採用
    'Private Class 各區
    '    Public 亮燈格 As New List(Of 座標格)
    '    Public 亮燈格緊鄰 As Boolean
    '    Public 亮燈格斜相鄰 As Boolean
    '    Public 已定 As Boolean
    'End Class
    'Private Class 座標格
    '    Public 索引 As Integer
    '    Public 列 As Integer
    '    Public 欄 As Integer
    '    Public Function 是否緊鄰(格 As 座標格) As Boolean '水平或垂直
    '        Return Math.Abs(Me.列 - 格.列) + Math.Abs(Me.欄 - 格.欄) = 1
    '    End Function
    '    Public Function 是否斜角相鄰(格 As 座標格) As Boolean
    '        Return Math.Abs(Me.列 - 格.列) = 1 AndAlso Math.Abs(Me.欄 - 格.欄) = 1
    '    End Function
    'End Class
    'Private Sub Set最佳盤面(盤面() As Boolean, ParamArray 亮燈位() As Byte)
    '    Array.ForEach(亮燈位, Sub(a) 盤面(a) = True)
    'End Sub
    'Public Function 新解法2(局 As 一局) As Integer
    '    Dim 索引 As Integer, 最大倍 As Integer = 0
    '    Dim 區() As 各區
    '    ReDim 區(3)
    '    Dim 最佳盤面(局.宮格s.Length - 1) As Boolean '該亮燈的地方
    '    For i As Integer = 0 To 局.宮格s.Length - 1
    '        If 局.宮格s(i).亮燈 Then
    '            Select Case i
    '                Case 0, 1, 5, 6 : 索引 = 0 'A
    '                Case 3, 4, 8, 9 : 索引 = 1 'B
    '                Case 15, 16, 20, 21 : 索引 = 2 'C
    '                Case 18, 19, 23, 24 : 索引 = 3 'D
    '                Case Else : 最佳盤面(i) = True '十字部份不能加壓旋轉所以都直接維持原本的亮燈狀態
    '            End Select
    '            區(索引).亮燈格.Add(New 座標格 With {.索引 = i, .列 = Math.Floor(i / 5), .欄 = i Mod 5})
    '        End If
    '    Next
    '    For Each b As 各區 In 區
    '        If b.亮燈格.Count = 2 Then
    '            b.亮燈格緊鄰 = b.亮燈格(0).是否緊鄰(b.亮燈格(1)) : b.亮燈格斜相鄰 = Not b.亮燈格緊鄰
    '        ElseIf b.亮燈格.Count >= 3 Then
    '            b.亮燈格緊鄰 = True : b.亮燈格斜相鄰 = True
    '        End If
    '    Next

    '    If 局.宮格s(12).亮燈 Then '先找X5連線
    '        If 區(0).亮燈格斜相鄰 AndAlso 區(3).亮燈格斜相鄰 Then '\ 5連線
    '            區(0).已定 = True
    '            Select Case 區(0).亮燈格.Count
    '                Case 2 : Me.Set最佳盤面(最佳盤面, 0, 6)
    '                Case 3 '只有2種情況0,1,6或0,5,6亮,所以要判斷B區和C區狀況,看怎麼連較佳
    '                    If 局.宮格s(2).亮燈 AndAlso 局.宮格s(10).亮燈 = False Then
    '                        Me.Set最佳盤面(最佳盤面, 0, 1, 6)
    '                    ElseIf 局.宮格s(2).亮燈 = False AndAlso 局.宮格s(10).亮燈 Then
    '                        Me.Set最佳盤面(最佳盤面, 0, 5, 6)
    '                    ElseIf 局.宮格s(2).亮燈 = False AndAlso 局.宮格s(10).亮燈 = False Then '不管哪種不會和BC連線,所以任選沒差
    '                        If Xdll.Mo.取亂數(2) = 0 Then
    '                            Me.Set最佳盤面(最佳盤面, 0, 1, 6)
    '                        Else
    '                            Me.Set最佳盤面(最佳盤面, 0, 5, 6)
    '                        End If
    '                    Else '2種都可達成連線,後續處理
    '                        區(0).已定 = False
    '                    End If

    '                Case 4 : Me.Set最佳盤面(最佳盤面, 0, 1, 5, 6)
    '            End Select

    '            區(3).已定 = True
    '            Select Case 區(3).亮燈格.Count
    '                Case 2 : Me.Set最佳盤面(最佳盤面, 18, 24)
    '                Case 3 '只有2種情況18,23,24或18,19,24亮,所以要判斷B區和C區狀況,看怎麼連較佳
    '                    If 局.宮格s(22).亮燈 AndAlso 局.宮格s(14).亮燈 = False Then
    '                        Me.Set最佳盤面(最佳盤面, 18, 23, 24)
    '                    ElseIf 局.宮格s(22).亮燈 = False AndAlso 局.宮格s(14).亮燈 Then
    '                        Me.Set最佳盤面(最佳盤面, 18, 19, 24)
    '                    ElseIf 局.宮格s(22).亮燈 = False AndAlso 局.宮格s(14).亮燈 = False Then '不管哪種不會和BC連線,所以任選沒差
    '                        If Xdll.Mo.取亂數(2) = 0 Then
    '                            Me.Set最佳盤面(最佳盤面, 18, 23, 24)
    '                        Else
    '                            Me.Set最佳盤面(最佳盤面, 18, 19, 24)
    '                        End If
    '                    Else '2種都可達成連線,後續處理
    '                        區(3).已定 = False
    '                    End If
    '                Case 4 : Me.Set最佳盤面(最佳盤面, 18, 19, 23, 24)
    '            End Select
    '        End If

    '        If 區(1).亮燈格斜相鄰 AndAlso 區(2).亮燈格斜相鄰 Then '/ 5連線
    '            區(1).已定 = True
    '            Select Case 區(1).亮燈格.Count
    '                Case 2 : Me.Set最佳盤面(最佳盤面, 4, 8)
    '                Case 3 '只有2種情況3,4,8或4,8,9亮,所以要判斷A區和D區狀況,看怎麼連較佳
    '                    If 局.宮格s(2).亮燈 AndAlso 局.宮格s(14).亮燈 = False Then
    '                        Me.Set最佳盤面(最佳盤面, 3, 4, 8)
    '                    ElseIf 局.宮格s(2).亮燈 = False AndAlso 局.宮格s(14).亮燈 Then
    '                        Me.Set最佳盤面(最佳盤面, 4, 8, 9)
    '                    ElseIf 局.宮格s(2).亮燈 = False AndAlso 局.宮格s(14).亮燈 = False Then '不管哪種不會和AD連線,所以任選沒差
    '                        If Xdll.Mo.取亂數(2) = 0 Then
    '                            Me.Set最佳盤面(最佳盤面, 3, 4, 8)
    '                        Else
    '                            Me.Set最佳盤面(最佳盤面, 4, 8, 9)
    '                        End If
    '                    Else '2種都可達成連線,後續處理
    '                        區(1).已定 = False
    '                    End If
    '                Case 4 : Me.Set最佳盤面(最佳盤面, 3, 4, 8, 9)
    '            End Select

    '            區(2).已定 = True
    '            Select Case 區(2).亮燈格.Count
    '                Case 2 : Me.Set最佳盤面(最佳盤面, 16, 20)
    '                Case 3 '只有2種情況15,16,20或16,20,21亮,所以要判斷A區和D區狀況,看怎麼連較佳
    '                    If 局.宮格s(10).亮燈 AndAlso 局.宮格s(22).亮燈 = False Then
    '                        Me.Set最佳盤面(最佳盤面, 15, 16, 20)
    '                    ElseIf 局.宮格s(10).亮燈 = False AndAlso 局.宮格s(22).亮燈 Then
    '                        Me.Set最佳盤面(最佳盤面, 16, 20, 21)
    '                    ElseIf 局.宮格s(10).亮燈 = False AndAlso 局.宮格s(22).亮燈 = False Then '不管哪種不會和AD連線,所以任選沒差
    '                        If Xdll.Mo.取亂數(2) = 0 Then
    '                            Me.Set最佳盤面(最佳盤面, 15, 16, 20)
    '                        Else
    '                            Me.Set最佳盤面(最佳盤面, 16, 20, 21)
    '                        End If
    '                    Else '2種都可達成連線,後續處理
    '                        區(2).已定 = False
    '                    End If
    '                Case 4 : Me.Set最佳盤面(最佳盤面, 15, 16, 20, 21)
    '            End Select
    '        End If
    '    End If
    '    Return 1
    'End Function

    'Public Function 新解法(局 As 一局) As Integer
    '    Dim 全亮位 As New Dictionary(Of Integer, 座標格) '用2D平面距離來解
    '    For i As Integer = 0 To 局.宮格s.Length - 1
    '        If 局.宮格s(i).亮燈 Then 全亮位.Add(i, New 解法_最優.座標格 With {.索引 = i, .列 = Math.Floor(i / 5), .欄 = i Mod 5})
    '    Next

    '    Dim 相鄰 As New List(Of 座標格)
    '    Dim 總相鄰 As New List(Of List(Of 座標格))
    '    Dim 可找 As New List(Of 座標格)(全亮位.Values)
    '    While 可找.Count > 0 '找水平
    '        相鄰.Clear() : 相鄰.Add(可找(0))
    '        For i As Integer = 1 To (4 - 可找(0).欄) '目前位置往右方
    '            If 全亮位.ContainsKey(可找(0).索引 + i) = False Then Exit For
    '            相鄰.Add(全亮位(可找(0).索引 + i)) : 可找.Remove(全亮位(可找(0).索引 + i))
    '        Next
    '        For i As Integer = 1 To 可找(0).欄 '目前位置往左方
    '            If 全亮位.ContainsKey(可找(0).索引 - i) = False Then Exit For
    '            相鄰.Add(全亮位(可找(0).索引 - i)) : 可找.Remove(全亮位(可找(0).索引 - i))
    '        Next
    '        If 相鄰.Count >= 3 Then 總相鄰.Add(New List(Of 座標格)(相鄰))
    '        可找.RemoveAt(0)
    '    End While

    '    可找.Clear() : 可找.AddRange(全亮位.Values)
    '    While 可找.Count > 0 '找垂直
    '        相鄰.Clear() : 相鄰.Add(可找(0))
    '        For i As Integer = 1 To (4 - 可找(0).列) '目前位置往下方
    '            If 全亮位.ContainsKey(可找(0).索引 + (i * 5)) = False Then Exit For
    '            相鄰.Add(全亮位(可找(0).索引 + (i * 5))) : 可找.Remove(全亮位(可找(0).索引 + (i * 5)))
    '        Next
    '        For i As Integer = 1 To 可找(0).列 '目前位置往上方
    '            If 全亮位.ContainsKey(可找(0).索引 - (i * 5)) = False Then Exit For
    '            相鄰.Add(全亮位(可找(0).索引 - (i * 5))) : 可找.Remove(全亮位(可找(0).索引 - (i * 5)))
    '        Next
    '        If 相鄰.Count >= 3 Then 總相鄰.Add(New List(Of 座標格)(相鄰))
    '        可找.RemoveAt(0)
    '    End While

    '    可找.Clear() : 可找.AddRange(全亮位.Where(Function(a) a.Key Mod 4 = 0 OrElse a.Key Mod 6 = 0)) '在X線上才處理
    '    While 可找.Count > 0 '找X
    '        相鄰.Clear() : 相鄰.Add(可找(0)) : 可找.RemoveAt(0)

    '    End While
    '    For i As Integer = 0 To 可找.Count - 1
    '        相鄰.Clear() : 相鄰.Add(可找(i))
    '        For j As Integer = i + 1 To 可找.Count - 1
    '            If Math.Abs(可找(i).列 - 可找(j).列) = 1 AndAlso Math.Abs(可找(i).欄 - 可找(j).欄) = 1 Then
    '                相鄰.Add(可找(j))
    '            End If
    '        Next
    '    Next

    '    Dim abc As Integer = 100

    '    'Dim 亮燈格 = 盤面.宮格s.Where(Function(a) a.亮燈)
    '    'Dim 平面 = 亮燈格.Select(Function(a) (row:=Convert.ToByte(a.號碼 / 5), col:=Convert.ToByte(a.號碼 Mod 5))).ToList()
    '    'Dim 可找 = 平面.ToList()
    '    'If Math.Abs(平面(i).row - 平面(j).row) + Math.Abs(平面(i).col - 平面(j).col) = 1 Then '判斷水平與垂直距離相加是否為1,是的話肯定相鄰
    '    '    相鄰數 += 1
    '    'End If
    '    Return 123
    'End Function
    Private Function Get亮燈所在區(局 As 一局) As List(Of Integer())
        Dim Key As Integer
        Dim 各區 As New List(Of Integer())
        For i As Byte = 0 To 3
            各區.Add({})
        Next
        For i As Integer = 0 To 局.宮格s.Length - 1
            If 局.宮格s(i).亮燈 Then
                Key = Mo.Get所在區(i)
                If Key <> -1 Then
                    ReDim 各區(Key)(各區(Key).Length)
                    各區(Key)(各區(Key).Length - 1) = i
                End If
            End If
        Next
        Return 各區
    End Function
    Public Function 解法(局 As 一局) As Integer Implements I計算最佳盤面.解法 '與遍歷驗分不一致,非最佳策略
        '前面3球最多分散在3個加壓旋轉區,因此先依3個亮燈位落在哪個旋轉區,再以這做組合算出最佳的旋轉策略
        Dim 各區 As List(Of Integer()) = Me.Get亮燈所在區(局)

        '開始分析各種情況
        '1:3個號碼落在3個不同區域則worst case=4*4*4*(231+?)
        '2:某區1個號碼+另1區2個號碼(相鄰或斜角):相鄰worst case:4*4*(231+?), 斜角worst case:4*2*(231+?)
        '3:某區有3個號碼:worst case:4*(231+?)
        Dim 轉次數(各區.Count - 1) As Byte
        For i As Integer = 0 To 各區.Count - 1
            Select Case 各區(i).Length
                Case 0 : 轉次數(i) = 0
                Case 1 : 轉次數(i) = 3
                Case 2
                    If (Math.Abs(各區(i)(0) - 各區(i)(1)) = 1) OrElse (Math.Abs(各區(i)(0) - 各區(i)(1)) = 5) Then
                        轉次數(i) = 3 '相鄰
                    Else
                        轉次數(i) = 1 '斜角
                    End If
                Case 3 : 轉次數(i) = 3
            End Select
        Next

        If 局.UP = 一局.UP類.乘2倍 Then '要特別處理,如果黃球進黃洞的情況下會觸發金牌狀態,連線得分X2倍,所以即使某區目前都沒亮燈也需旋轉
            Dim 所在區 As Integer 'worst case=4*4*4*4*(231+?)
            For i As Integer = 0 To 局.宮格s.Length - 1
                Select Case 局.宮格s(i).號碼
                    Case 5, 10, 15, 20, 25
                        所在區 = Mo.Get所在區(i)
                        If 所在區 <> -1 Then 轉次數(所在區) = 3
                End Select
            Next
        End If

        If (轉次數(0) + 轉次數(1) + 轉次數(2) + 轉次數(3)) = 0 Then Return 0 '完全不用旋轉

        Dim 號碼(1) As Byte, 四五球位(1) As Byte
        Dim 次 As Byte, 索引1 As Byte, 索引2 As Byte
        Dim 期望值 As Double = 0, 最大期望值 As Double = 0
        Dim 紅球紅洞 As Boolean, 紅球黃洞 As Boolean, 黃球黃洞 As Boolean
        Dim 得分 As Integer = 0, 最大得分 As ULong = 0, 連線位 As UInteger = 0, 計算次 As Integer = 0
        Dim 未亮燈 As New List(Of Byte)
        For A As Byte = 0 To 轉次數(0)
            For B As Byte = 0 To 轉次數(1)
                For C As Byte = 0 To 轉次數(2)
                    For D As Byte = 0 To 轉次數(3)
                        未亮燈.Clear()
                        For x As Integer = 0 To 局.宮格s.Length - 1
                            If 局.宮格s(x).亮燈 = False Then 未亮燈.Add(x)
                        Next

                        For aa As Integer = 0 To 未亮燈.Count - 1
                            For bb As Integer = aa + 1 To 未亮燈.Count - 1
                                次 = 0 : 索引1 = 未亮燈(aa) : 索引2 = 未亮燈(bb)
                                '因為進洞順序會影響保送燈,所以要特別處理,連線只和位置有關,順序不影響
                                If 局.UP = 一局.UP類.乘2倍 AndAlso (局.宮格s(索引2).號碼 Mod 5 = 0) Then
                                    次 = 1
                                End If
                                If 局.保送 = 一局.保送類.入紅洞 AndAlso (局.宮格s(索引1).號碼 Mod 10 = 1) Then
                                    次 = 1
                                ElseIf 局.保送 = 一局.保送類.入黃洞 AndAlso (局.宮格s(索引1).號碼 Mod 5 = 0) Then
                                    次 = 1
                                End If

                                For cc As Integer = 0 To 次
                                    局.宮格s(索引1).亮燈 = True : 局.宮格s(索引2).亮燈 = True '預期第4、5球會進這,且不會洗袋
                                    號碼(0) = 局.宮格s(索引1).號碼 : 號碼(1) = 局.宮格s(索引2).號碼

                                    Select Case 號碼(0)
                                        Case 5, 10, 15, 20, 25 : 局.黃球黃洞 = True
                                    End Select
                                    Select Case 號碼(1)
                                        Case 1, 11, 21 : 局.紅球紅洞 = True
                                        Case 5, 10, 15, 20, 25 : 局.紅球黃洞 = True
                                    End Select

                                    計算次 += 1
                                    得分 = 局.計算連線得分()
                                    期望值 = Mo.Get入洞率(號碼(0)) * Mo.Get入洞率(號碼(1)) * 得分

                                    If 期望值 > 最大期望值 Then '目前找最高期望值,也可以變化為最高分或最易得分或是觸發保送優先
                                        連線位 = 局.連線位
                                        最大得分 = 得分
                                        最大期望值 = 期望值
                                        四五球位(0) = 未亮燈(aa) : 四五球位(1) = 未亮燈(bb)
                                        紅球紅洞 = 局.紅球紅洞 : 紅球黃洞 = 局.紅球黃洞 : 黃球黃洞 = 局.黃球黃洞

                                        If ((連線位 And 1) <> 0) OrElse ((連線位 And 2) <> 0) OrElse ((連線位 And 32) <> 0) OrElse ((連線位 And 64) <> 0) Then 'A區有連線
                                            局.旋轉次(0) = A
                                        End If
                                        If ((連線位 And 8) <> 0) OrElse ((連線位 And 16) <> 0) OrElse ((連線位 And 256) <> 0) OrElse ((連線位 And 512) <> 0) Then 'B區有連線
                                            局.旋轉次(1) = B
                                        End If
                                        If ((連線位 And (1 << 15)) <> 0) OrElse ((連線位 And (1 << 16)) <> 0) OrElse ((連線位 And (1 << 20)) <> 0) OrElse ((連線位 And (1 << 21)) <> 0) Then 'C區有連線
                                            局.旋轉次(2) = C
                                        End If
                                        If ((連線位 And (1 << 18)) <> 0) OrElse ((連線位 And (1 << 19)) <> 0) OrElse ((連線位 And (1 << 23)) <> 0) OrElse ((連線位 And (1 << 24)) <> 0) Then 'D區有連線
                                            局.旋轉次(3) = D
                                        End If
                                    End If

                                    '還原
                                    局.紅球紅洞 = False : 局.紅球黃洞 = False : 局.黃球黃洞 = False
                                    局.宮格s(索引1).亮燈 = False : 局.宮格s(索引2).亮燈 = False
                                    索引1 = 未亮燈(bb) : 索引2 = 未亮燈(aa)
                                Next
                            Next
                        Next
                        If 轉次數(3) > 0 Then 局.旋轉D()
                    Next
                    If 轉次數(2) > 0 Then 局.旋轉C()
                Next
                If 轉次數(1) > 0 Then 局.旋轉B()
            Next
            If 轉次數(0) > 0 Then 局.旋轉A()
        Next

        For i As Byte = 0 To 局.旋轉次.Length - 1
            If 局.旋轉次(i) > 0 Then
                For j As Byte = 0 To 局.旋轉次(i) - 1
                    Select Case i
                        Case 0 : 局.旋轉A()
                        Case 1 : 局.旋轉B()
                        Case 2 : 局.旋轉C()
                        Case 3 : 局.旋轉D()
                    End Select
                Next
            End If
        Next

        局.連線位 = 連線位
        局.得分額 = 最大得分
        局.第45球位(0) = 四五球位(0) : 局.第45球位(1) = 四五球位(1)
        局.宮格s(四五球位(0)).亮燈 = True : 局.宮格s(四五球位(1)).亮燈 = True
        局.紅球紅洞 = 紅球紅洞 : 局.紅球黃洞 = 紅球黃洞 : 局.黃球黃洞 = 黃球黃洞

        Return 計算次
    End Function
End Class