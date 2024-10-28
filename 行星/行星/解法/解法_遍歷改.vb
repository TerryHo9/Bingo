Imports 行星.Xdll
Public Class 解法_遍歷改 : Implements I計算最佳盤面
    Public Function 解法(局 As 一局) As Integer Implements I計算最佳盤面.解法
        Dim 號碼(1) As Byte, 四五球位(1) As Byte
        Dim 次 As Byte, 索引1 As Byte, 索引2 As Byte
        Dim 期望值 As Double = 0, 最大期望值 As Double = 0
        Dim 紅球紅洞 As Boolean, 紅球黃洞 As Boolean, 黃球黃洞 As Boolean
        Dim 得分 As Integer = 0, 最大得分 As ULong = 0, 連線位 As UInteger = 0, 計算次 As Integer = 0

        Dim 未亮燈 As New List(Of Byte)
        For A As Byte = 0 To 3 'worst case:4*4*4*4*(231+?)
            For B As Byte = 0 To 3
                For C As Byte = 0 To 3
                    For D As Byte = 0 To 3
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
                        局.旋轉D()
                    Next
                    局.旋轉C()
                Next
                局.旋轉B()
            Next
            局.旋轉A()
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