Public Interface IBookComparer
    Function Compare(ByVal leftBook As Book, ByVal rightBook As Book) As Integer
End Interface

Public Interface IItemComparer(Of T)
    Function Compare(ByVal leftItem As T, ByVal rightItem As T) As Integer
End Interface

