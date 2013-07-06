Public Class BookComparerByCost
    'Implements IBookComparer
    Implements IItemComparer(Of Book)

    'Inherits BookComparerBase

    'Public Function Compare(ByVal leftBook As Book, ByVal rightBook As Book) As Integer Implements 
    '    If (leftBook.Cost > rightBook.Cost) Then
    '        Return 1
    '    ElseIf (leftBook.Cost < rightBook.Cost) Then
    '        Return -1
    '    Else
    '        Return 0
    '    End If
    'End Function

    Public Function Compare1(ByVal leftItem As Book, ByVal rightItem As Book) As Integer Implements IItemComparer(Of Book).Compare
        If (leftItem.Cost > rightItem.Cost) Then
            Return 1
        ElseIf (leftItem.Cost < rightItem.Cost) Then
            Return -1
        Else
            Return 0
        End If
    End Function
End Class
