Imports Nukepayload2.Csv
Imports Nukepayload2.Linq.Onmyoji

Public Class Csv������

    Public Shared Async Function ��������Async(
        ����ǰδ�������� As Dictionary(Of String, ����),
        �����δ�������� As Dictionary(Of String, ����)) As Task(Of String)

        Dim ����ǰδ����Id = ����ǰδ��������.Keys.ToArray
        For Each id In �����δ��������.Keys
            ����ǰδ��������.Remove(id)
        Next
        For Each id In ����ǰδ����Id
            �����δ��������.Remove(id)
        Next

        Dim ���õ����� = From ���� In ����ǰδ��������.Values Select (����, ����:="����")
        Dim �ָ������� = From ���� In �����δ��������.Values Select (����, ����:="�ָ�")

        Return Await ��������Async(���õ�����.Concat(�ָ�������))
    End Function

    Private Shared Async Function ��������Async(
        ���������� As IEnumerable(Of (���� As ����, ���� As String))) As Task(Of String)

        Dim �洢���� =
            From grp In ����������
            Let s = grp.����
            Let ������1 = s.������.ȡԪ��û�оͷ��ؿ�(0)?.���Է���.ToString,
                ������2 = s.������.ȡԪ��û�оͷ��ؿ�(1)?.���Է���.ToString,
                ������3 = s.������.ȡԪ��û�оͷ��ؿ�(2)?.���Է���.ToString,
                ������4 = s.������.ȡԪ��û�оͷ��ؿ�(3)?.���Է���.ToString,
                ������ = s.������.���Է���.ToString
            Select grp.����, ���� = s.����������, s.�Ǽ�,
                   s.�ȼ�, λ�� = s.λ�ô�1��ʼ,
                   ������,
                   ��������ֵ = s.������.��ֵ.ToString(ȡ�������ָ�ʽ(������)),
                   ������1,
                   ������1��ֵ = s.������.ȡԪ��û�оͷ��ؿ�(0)?.��ֵ.ToString(ȡ�������ָ�ʽ(������1)),
                   ������2,
                   ������2��ֵ = s.������.ȡԪ��û�оͷ��ؿ�(1)?.��ֵ.ToString(ȡ�������ָ�ʽ(������2)),
                   ������3,
                   ������3��ֵ = s.������.ȡԪ��û�оͷ��ؿ�(2)?.��ֵ.ToString(ȡ�������ָ�ʽ(������3)),
                   ������4,
                   ������4��ֵ = s.������.ȡԪ��û�оͷ��ؿ�(3)?.��ֵ.ToString(ȡ�������ָ�ʽ(������4))

        Dim csvText = Await Task.Run(Function() CsvConvert.SerializeObject(�洢����.ToArray))
        Return csvText
    End Function

End Class
