Public Class Todos
    Implements IEnumerable(Of Todo)
    Private list As New List(Of Todo)

    Public Sub Add(name As String)
        Dim newId As Integer
        If (list.Any()) Then
            newId = list.Max(Function(t) t.Id) + 1
        Else
            newId = 1
        End If
        list.Add(New Todo() With {.Id = newId, .Name = name})

    End Sub

    Public Sub remove(id As Integer)
        For Each item In list
            If (item.Id = id) Then
                list.Remove(item)
            End If
        Next
    End Sub

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Todo) Implements System.Collections.Generic.IEnumerable(Of Todo).GetEnumerator
        Return list.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return list.GetEnumerator()
    End Function
End Class

Public Class Todo
    Public Property Id As Integer
    Public Property Name As String

End Class
