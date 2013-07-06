Public Class BookComparerByStock
    Implements IBookComparer

    Public Function Compare(ByVal leftBook As Book, ByVal rightBook As Book) As Integer Implements IBookComparer.Compare
        Return Math.Sign(leftBook.Stock - rightBook.Stock)
    End Function
End Class
