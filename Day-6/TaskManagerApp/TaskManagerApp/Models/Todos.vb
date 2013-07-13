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

    Public Sub Remove(id As Integer)
        'For Each item In list
        For index = list.Count - 1 To 0 Step -1
            Dim item = CType(list(index), Todo)
            If (item.Id = id) Then
                list.Remove(item)
            End If
        Next
    End Sub

    Public Function GetById(id As Integer) As Todo
        For Each item In list
            If (item.Id = id) Then
                Return item
            End If

        Next
        Return Nothing
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Todo) Implements System.Collections.Generic.IEnumerable(Of Todo).GetEnumerator
        Return list.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return list.GetEnumerator()
    End Function
End Class

