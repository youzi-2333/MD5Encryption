Imports System
Imports System.Security.Cryptography
Imports System.Text
Module main
    Function GetMd5Hash(input As String) As String
        Dim md5Hasher As New MD5CryptoServiceProvider()
        '将输入的字符串转换为字节数组，并计算哈希。
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        '创建一个新的 StringBuilder 收集的字节，并创建一个字符串。
        Dim sBuilder As New StringBuilder()

        '通过每个字节的哈希数据和格式为十六进制字符串的每一个循环。
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next
        '返回十六进制字符串。
        Return sBuilder.ToString()
    End Function


    '验证对一个字符串的哈希值。

    Function VerifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        '哈希的输入。
        Dim hashOfInput As String = GetMd5Hash(input)

        '创建 StringComparer 的哈希进行比较。
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        Return comparer.Compare(hashOfInput, hash) = 0
    End Function


    Sub Main()
        Dim source As String = Command()
        Dim hash As String = GetMd5Hash(source)

        If VerifyMd5Hash(source, hash) Then
            '哈希值相同
            Console.WriteLine(hash)
        Else
            '哈希值不同
            Console.WriteLine("0x0000000")
            Console.WriteLine("Error: Hash values are different.")
            Console.WriteLine("This would usually caused by the system delay.")
            Console.WriteLine("Please retry to solve this problem.")
        End If
    End Sub
End Module