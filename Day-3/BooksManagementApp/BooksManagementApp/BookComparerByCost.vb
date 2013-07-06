Public Class BookComparerByCost
    Implements IBookComparer
    'Inherits BookComparerBase

    Public Function Compare(ByVal leftBook As Book, ByVal rightBook As Book) As Integer Implements IBookComparer.Compare
        If (leftBook.Cost > rightBook.Cost) Then
            Return 1
        ElseIf (leftBook.Cost < rightBook.Cost) Then
            Return -1
        Else
            Return 0
        End If
    End Function
End Class
