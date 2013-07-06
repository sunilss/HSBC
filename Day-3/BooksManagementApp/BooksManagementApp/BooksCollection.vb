Public Class BooksCollection
    Implements IEnumerable
    Implements IEnumerator

    Private list As New ArrayList

    Public Sub Add(ByVal book As Book)
        'Do the validation for avoiding duplicates
        list.Add(book)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        list.RemoveAt(index)
    End Sub


    Public Property Count() As Integer
        Get
            Return list.Count
        End Get

        Private Set(ByVal value As Integer)

        End Set
    End Property

    Default Public Property Item(ByVal index As Long) As Book
        Get
            Return CType(list(index), Book)
        End Get
        Set(ByVal value As Book)
            list(index) = value
        End Set
    End Property

    Public Function GetBook(ByVal index As Integer) As Book
        Return CType(list(index), Book)

    End Function

    'Public Sub Sort()
    '    For i = 0 To list.Count - 2
    '        For j = i + 1 To list.Count - 1
    '            Dim leftBook As Book = CType(list(i), Book)
    '            Dim rightBook As Book = CType(list(j), Book)
    '            If (leftBook.Id > rightBook.Id) Then
    '                Dim temp As Book = leftBook
    '                list(i) = list(j)
    '                list(j) = temp
    '            End If
    '        Next
    '    Next
    'End Sub
    Public Sub Sort(ByVal bookComparer As IBookComparer)
        For i = 0 To list.Count - 2
            For j = i + 1 To list.Count - 1
                Dim leftBook As Book = CType(list(i), Book)
                Dim rightBook As Book = CType(list(j), Book)
                Dim shouldSwap As Boolean = bookComparer.Compare(leftBook, rightBook) > 0
                If (shouldSwap) Then
                    Dim temp As Book = leftBook
                    list(i) = list(j)
                    list(j) = temp
                End If
            Next
        Next
    End Sub

    Public Sub Sort(ByVal compareBooks As BookCompareDelegate)
        For i = 0 To list.Count - 2
            For j = i + 1 To list.Count - 1
                Dim leftBook As Book = CType(list(i), Book)
                Dim rightBook As Book = CType(list(j), Book)
                Dim shouldSwap As Boolean = compareBooks(leftBook, rightBook) > 0
                If (shouldSwap) Then
                    Dim temp As Book = leftBook
                    list(i) = list(j)
                    list(j) = temp
                End If
            Next
        Next
    End Sub

    'Public Function Min() As Integer
    '    Dim result As Integer = Integer.MaxValue
    '    For Each listItem In list
    '        Dim book As Book = CType(listItem, Book)
    '        If (result > book.Id) Then
    '            result = book.Id
    '        End If
    '    Next
    '    Return result
    'End Function

    Public Function Min(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate) As Integer
        Dim result As Integer = Integer.MaxValue
        For Each listItem In list
            Dim book As Book = CType(listItem, Book)
            Dim value As Integer = integerAttributeSelector(book)
            If (result > value) Then
                result = value
            End If
        Next
        Return result
    End Function

    Public Function Max(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate) As Integer
        Dim result As Integer = Integer.MinValue
        For Each listItem In list
            Dim book As Book = CType(listItem, Book)
            Dim value As Integer = integerAttributeSelector(book)
            If (result < value) Then
                result = value
            End If
        Next
        Return result
    End Function

    Public Function Sum(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate) As Integer
        Dim result As Integer = 0
        For Each listItem In list
            Dim book As Book = CType(listItem, Book)
            Dim value As Integer = integerAttributeSelector(book)
            result += value
        Next
        Return result
    End Function

    Public Function Average(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate) As Integer
        Dim result As Integer = 0
        For Each listItem In list
            Dim book As Book = CType(listItem, Book)
            Dim value As Integer = integerAttributeSelector(book)
            result += value
        Next
        Return result / list.Count
    End Function

    Public Function Filter(ByVal filterCriteria As BookFilterCriteriaDelegate) As BooksCollection
        Dim result As New BooksCollection
        For Each listItem In list
            Dim book As Book = CType(listItem, Book)
            If (filterCriteria(book) = True) Then
                result.Add(book)
            End If
        Next
        Return result
    End Function

    Public Function Min(ByVal decimalAttributeSelector As DecimalAttributeSelectorDelegate) As Integer
        Dim result As Decimal = Decimal.MaxValue
        For Each listItem In list
            Dim book As Book = CType(listItem, Book)
            Dim value As Decimal = decimalAttributeSelector(book)
            If (result > value) Then
                result = value
            End If
        Next
        Return result
    End Function


    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me
    End Function

    Private indexer As Integer = -1
    Public ReadOnly Property Current As Object Implements System.Collections.IEnumerator.Current
        Get
            Return CType(list(indexer), Book)
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        indexer += 1
        If (indexer >= list.Count) Then
            Reset()
            Return False
        End If
        Return True
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        indexer = -1
    End Sub
End Class

'Public MustInherit Class BookComparerBase
'    Public Overridable Function Compare(ByVal leftBook As Book, ByVal rightBook As Book) As Integer
'        Return 0
'    End Function
'End Class

Public Delegate Function IntegerAttributeSelectorDelegate(ByVal book As Book) As Integer
Public Delegate Function DecimalAttributeSelectorDelegate(ByVal book As Book) As Decimal

Public Delegate Function BookFilterCriteriaDelegate(ByVal book As Book) As Boolean

