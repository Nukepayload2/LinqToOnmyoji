Imports System.IO
Imports Nukepayload2.Linq.Onmyoji
Imports Nukepayload2.Linq.Onmyoji.Utilities

Module Program
    Sub Main(args As String())
        Dim 输入文件 = args.FirstOrDefault
        Try
            If 输入文件 = Nothing OrElse Not File.Exists(输入文件) Then
                Console.WriteLine("需要拖放痒痒熊快照 Json 文件")
                Return
            End If

            Console.WriteLine("载入中...")
            Dim 快照 = 痒痒熊快照.加载Json文件(输入文件)

            Dim 六星御魂 = From s In 快照.数据.御魂 Where s.星级 = 6 AndAlso s.已弃置 = False

            Console.WriteLine($"整理前六星御魂数量: {六星御魂.Count}")

            '御魂整理方案.七老爷三周年庆御魂整理方案(快照)
            御魂整理方案.阿毛缘结神版本御魂整理方案(快照)

            Console.WriteLine($"整理后六星御魂数量: {六星御魂.Count}")
        Catch ex As Exception
            Console.WriteLine($"出现错误: {ex.Message}")
        Finally
            Console.WriteLine("按任意键退出...")
            Console.ReadKey()
        End Try
    End Sub

End Module
