Public Class MyCollection(Of T)
    Implements IEnumerable(Of T)
    Implements IEnumerator(Of T)

    Private list As New ArrayList

    Public Sub Add(ByVal tItem As T)
        'Do the validation for avoiding duplicates
        list.Add(tItem)
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

    Default Public Property Item(ByVal index As Long) As T
        Get
            Return CType(list(index), T)
        End Get
        Set(ByVal value As T)
            list(index) = value
        End Set
    End Property

    'Public Function GetBook(ByVal index As Integer) As Book
    '    Return CType(list(index), Book)

    'End Function

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
    Public Sub Sort(ByVal comparer As IItemComparer(Of T))

        For i = 0 To list.Count - 2
            For j = i + 1 To list.Count - 1
                Dim leftItem As T = CType(list(i), T)
                Dim rightItem As T = CType(list(j), T)
                Dim shouldSwap As Boolean = comparer.Compare(leftItem, rightItem) > 0
                If (shouldSwap) Then
                    Dim temp As T = leftItem
                    list(i) = list(j)
                    list(j) = temp
                End If
            Next
        Next
    End Sub

    'Public Sub Sort(ByVal compareItems As ItemCompareDelegate(Of T))
    Public Sub Sort(ByVal compareItems As Func(Of T, T, Integer))
        For i = 0 To list.Count - 2
            For j = i + 1 To list.Count - 1
                Dim leftItem As T = CType(list(i), T)
                Dim rightItem As T = CType(list(j), T)
                Dim shouldSwap As Boolean = compareItems(leftItem, rightItem) > 0
                If (shouldSwap) Then
                    Dim temp As T = leftItem
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

    'Public Function Min(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate(Of T)) As Integer
    Public Function Min(ByVal integerAttributeSelector As Func(Of T, Integer)) As Integer
        Dim result As Integer = Integer.MaxValue
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim value As Integer = integerAttributeSelector(tItem)
            If (result > value) Then
                result = value
            End If
        Next
        Return result
    End Function

    'Public Function Max(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate(Of T)) As Integer
    Public Function Max(ByVal integerAttributeSelector As Func(Of T, Integer)) As Integer
        Dim result As Integer = Integer.MinValue
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim value As Integer = integerAttributeSelector(tItem)
            If (result < value) Then
                result = value
            End If
        Next
        Return result

    End Function

    'Public Function Sum(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate(Of T)) As Integer
    Public Function Sum(ByVal integerAttributeSelector As Func(Of T, Integer)) As Integer
        Dim result As Integer = 0
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim value As Integer = integerAttributeSelector(tItem)
            result += value
        Next
        Return result
    End Function

    'Public Function Average(ByVal integerAttributeSelector As IntegerAttributeSelectorDelegate(Of T)) As Integer
    Public Function Average(ByVal integerAttributeSelector As Func(Of T, Integer)) As Integer
        Dim result As Integer = 0
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim value As Integer = integerAttributeSelector(tItem)
            result += value
        Next
        Return result / list.Count
    End Function

    'Public Function Filter(ByVal filterCriteria As ItemFilterCriteriaDelegate(Of T)) As MyCollection(Of T)
    'Public Function Filter(ByVal filterCriteria As Func(Of T, Boolean)) As MyCollection(Of T)
    Public Function Filter(ByVal filterCriteria As Predicate(Of T)) As MyCollection(Of T)
        Dim result As New MyCollection(Of T)()
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            If (filterCriteria(tItem) = True) Then
                result.Add(tItem)
            End If
        Next
        Return result
    End Function

    Public Function Min(ByVal decimalAttributeSelector As Func(Of T, Decimal)) As Integer
        Dim result As Decimal = Decimal.MaxValue
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim value As Decimal = decimalAttributeSelector(tItem)
            If (result > value) Then
                result = value
            End If
        Next
        Return result
    End Function

    Public Function GroupItem(Of TKey)(ByVal keySelector As Func(Of T, TKey)) As Dictionary(Of TKey, List(Of T))
        Dim result As New Dictionary(Of TKey, List(Of T))()
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim key As TKey = keySelector(tItem)
            If (Not result.ContainsKey(key)) Then
                result(key) = New List(Of T)()
            End If
            result(key).Add(tItem)
        Next
        Return result
    End Function

    Public Function JoinItems(Of T2, TKey, TResult)(ByVal joinList As MyCollection(Of T2), _
                                           ByVal leftKeySelector As Func(Of T, TKey), _
                                        ByVal rightKeySelector As Func(Of T2, TKey), _
                                        ByVal combinator As Func(Of T, T2, TResult))
        Dim result As New MyCollection(Of TResult)()
        For Each listItem In list
            Dim tItem As T = CType(listItem, T)
            Dim key = leftKeySelector(tItem)
            For Each jItem In joinList
                Dim jKey = rightKeySelector(jItem)
                If (key.Equals(jKey)) Then
                    Dim combinedObject = combinator(tItem, jItem)
                    result.Add(combinedObject)
                    'Exit For
                End If
            Next

        Next
        Return result
    End Function


    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me
    End Function

    Private indexer As Integer = -1
    Public ReadOnly Property Current As Object Implements System.Collections.IEnumerator.Current
        Get
            Return CType(list(indexer), T)
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

    Public Function GetEnumerator1() As System.Collections.Generic.IEnumerator(Of T) Implements System.Collections.Generic.IEnumerable(Of T).GetEnumerator
        Return Me
    End Function

    Public ReadOnly Property Current1 As T Implements System.Collections.Generic.IEnumerator(Of T).Current
        Get
            Return Current
        End Get
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

'Public MustInherit Class BookComparerBase
'    Public Overridable Function Compare(ByVal leftBook As Book, ByVal rightBook As Book) As Integer
'        Return 0
'    End Function
'End Class

'Public Delegate Function IntegerAttributeSelectorDelegate(ByVal book As Book) As Integer

'Public Delegate Function IntegerAttributeSelectorDelegate(Of T)(ByVal tItem As T) As Integer

'Public Delegate Function DecimalAttributeSelectorDelegate(ByVal book As Book) As Decimal
'Public Delegate Function DecimalAttributeSelectorDelegate(Of T)(ByVal tItem As T) As Decimal

'Public Delegate Function BookFilterCriteriaDelegate(ByVal book As Book) As Boolean
'Public Delegate Function ItemFilterCriteriaDelegate(Of T)(ByVal tItem As T) As Boolean

'Public Delegate Function KeySelector(Of T, TKey)(ByVal tItem As T) As TKey

'Public Delegate Function CombinatorDelegate(Of T1, T2, TResult)(ByVal item1 As T1, ByVal item2 As T2) As TResult

