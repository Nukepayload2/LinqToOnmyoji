Imports Nukepayload2.Linq.Onmyoji

Module Program
    Sub Main()
        Dim ���� = �����ܿ���.����Json�ļ�("��������.json")
        Dim prim = From ���� In ����.����.����
                   Select ����.������.���� Distinct

        Console.WriteLine(String.Join(vbCrLf, prim))
    End Sub

    Private Sub ÿ�����������(���� As �����ܿ���)
        Dim eqId = Aggregate ���� In ����.����.����
                   Group By ����.���� Into Group
                   Select ����, Group.Count Into ToArray

        Console.WriteLine("eqId.Len=" & eqId.Length)
        For Each eq In eqId
            Console.WriteLine(eq)
        Next
    End Sub
End Module
