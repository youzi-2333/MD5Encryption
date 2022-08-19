Imports System
Imports System.Security.Cryptography
Imports System.Text
Module main
    Function GetMd5Hash(input As String) As String
        Dim md5Hasher As New MD5CryptoServiceProvider()
        '��������ַ���ת��Ϊ�ֽ����飬�������ϣ��
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        '����һ���µ� StringBuilder �ռ����ֽڣ�������һ���ַ�����
        Dim sBuilder As New StringBuilder()

        'ͨ��ÿ���ֽڵĹ�ϣ���ݺ͸�ʽΪʮ�������ַ�����ÿһ��ѭ����
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next
        '����ʮ�������ַ�����
        Return sBuilder.ToString()
    End Function


    '��֤��һ���ַ����Ĺ�ϣֵ��

    Function VerifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        '��ϣ�����롣
        Dim hashOfInput As String = GetMd5Hash(input)

        '���� StringComparer �Ĺ�ϣ���бȽϡ�
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        Return comparer.Compare(hashOfInput, hash) = 0
    End Function


    Sub Main()
        Dim source As String = Command()
        Dim hash As String = GetMd5Hash(source)

        If VerifyMd5Hash(source, hash) Then
            '��ϣֵ��ͬ
            Console.WriteLine(hash)
        Else
            '��ϣֵ��ͬ
            Console.WriteLine("0x0000000")
            Console.WriteLine("Error: Hash values are different.")
            Console.WriteLine("This would usually caused by the system delay.")
            Console.WriteLine("Please retry to solve this problem.")
        End If
    End Sub
End Module