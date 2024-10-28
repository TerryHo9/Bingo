Namespace Xdll
    Module Mo
        Public 連線表()() As Byte = New Byte()() {
            New Byte() {0, 1, 2, 3, 4},
            New Byte() {5, 6, 7, 8, 9},
            New Byte() {10, 11, 12, 13, 14},
            New Byte() {15, 16, 17, 18, 19},
            New Byte() {20, 21, 22, 23, 24},
            New Byte() {0, 5, 10, 15, 20},
            New Byte() {1, 6, 11, 16, 21},
            New Byte() {2, 7, 12, 17, 22},
            New Byte() {3, 8, 13, 18, 23},
            New Byte() {4, 9, 14, 19, 24},
            New Byte() {0, 6, 12, 18, 24},
            New Byte() {4, 8, 12, 16, 20}}

        Public 各區索引()() As Byte = New Byte()() {New Byte() {0, 1, 5, 6}, New Byte() {3, 4, 8, 9}, New Byte() {15, 16, 20, 21}, New Byte() {18, 19, 23, 24}}
        Private 亂 As New Random
        Public Function 取亂數(值 As Integer) As Integer
            Return 亂.Next(值)
        End Function

        Public Function Get入洞率(位置 As Byte) As Double
            '這邊機率會是錯的,暫時用最單純內中外圈入洞率的假設,先忽略已進洞,未進洞和各洞所在位與發射角優勢洞等問題
            '要整體考量後才能得出較正確的機率
            Select Case Mo.Get所在圈(位置)
                Case 0 : Return 0.25 '外圈
                Case 1 : Return 0.3 '中圈
                Case Else : Return 0.45 '內圈
            End Select
        End Function

        Public Function Get排序By入洞率(位置 As List(Of Byte)) As List(Of Byte)
            '從大到小,假設內圈的入洞率最高,這邊可依需求自訂,目前只是暫定這假的規則
            位置.Sort(Function(a, b) Mo.Get所在圈(a).CompareTo(Mo.Get所在圈(b)) * -1)
            Return 位置
        End Function
        Public Function Get所在圈(號碼 As Byte) As Byte
            If 號碼 >= 21 Then Return 2 '內圈
            If 號碼 >= 11 Then Return 1 '中圈
            Return 0 '外圈
        End Function
        Public Function Get所在區(索引 As Byte) As Integer
            Select Case 索引
                Case 0, 1, 5, 6 : Return 0 'A
                Case 3, 4, 8, 9 : Return 1 'B
                Case 15, 16, 20, 21 : Return 2 'C
                Case 18, 19, 23, 24 : Return 3 'D
            End Select
            Return -1
        End Function
    End Module
End Namespace