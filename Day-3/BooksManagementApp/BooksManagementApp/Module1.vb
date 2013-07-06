Imports System.Runtime.CompilerServices

Module Module1

    Sub Main()
        'Dim books As New BooksCollection
        Dim books As New MyCollection(Of Book)
        books.Add(New Book() With {.Id = 7, .Title = "C#", .Cost = 103, .Stock = 12, .CategoryId = 1})
        books.Add(New Book() With {.Id = 1, .Title = "F#", .Cost = 128, .Stock = 22, .CategoryId = 2})
        books.Add(New Book() With {.Id = 3, .Title = "D#", .Cost = 104, .Stock = 62, .CategoryId = 1})
        books.Add(New Book() With {.Id = 4, .Title = "E#", .Cost = 130, .Stock = 23, .CategoryId = 1})
        books.Add(New Book() With {.Id = 9, .Title = "K#", .Cost = 110, .Stock = 32, .CategoryId = 2})


        'For index = 0 To books.Count - 1
        'Console.WriteLine(books(index))
        'Next
        Console.WriteLine("Initial List")
        Console.WriteLine("==================================")
        For Each book In books
            Console.WriteLine(book)
        Next
        Console.WriteLine()

        'Console.WriteLine("After sorting")
        'Console.WriteLine("==================================")
        'books.Sort()
        'For Each book In books
        '    Console.WriteLine(book)
        'Next
        'Console.WriteLine()

        Console.WriteLine("After sorting by Cost")
        Console.WriteLine("==================================")
        books.Sort(New BookComparerByCost())
        For Each book In books
            Console.WriteLine(book)
        Next
        Console.WriteLine()

        Console.WriteLine("After sorting by Stock [Using Delegates]")
        Console.WriteLine("==================================")
        'books.Sort(New BookCompareDelegate(AddressOf Module1.CompareBooksByStock))
        'books.Sort(AddressOf Module1.CompareBooksByStock)
        books.Sort(Function(leftBook, rightBook) As Integer
                       Return Math.Sign(leftBook.Stock - rightBook.Stock)
                   End Function)

        For Each book In books
            Console.WriteLine(book)
        Next
        Console.WriteLine()

        Console.WriteLine("Minimum Id = {0}", books.Min(Function(b)
                                                            Return b.Id
                                                        End Function))
        Console.WriteLine()
        Console.WriteLine("Minimum Stock = {0}", books.Min(Function(b)
                                                               Return b.Stock
                                                           End Function))
        Console.WriteLine()
        Console.WriteLine("Maximum Stock = {0}", books.Max(Function(b) b.Stock))

        Console.WriteLine()
        Console.WriteLine("Average Stock = {0}", books.Average(Function(b) b.Stock))

        Console.WriteLine()
        Console.WriteLine("Sum of Stock = {0}", books.Sum(Function(b) b.Stock))

        Console.WriteLine()
        Console.WriteLine("Minimum Cost = {0}", books.Min(Function(b) b.Cost))

        Console.WriteLine()
        Console.WriteLine("Costly books [book.Cost > 110]")
        Console.WriteLine("==========================================")
        Dim costlyBooks As MyCollection(Of Book)
        costlyBooks = books.Filter(Function(b) b.Cost > 110)
        For Each costlyBook In costlyBooks
            Console.WriteLine(costlyBook)
        Next

        Console.WriteLine()
        Console.WriteLine("Cheap books [book.Cost <= 110]")
        Console.WriteLine("==========================================")
        Dim cheapBooks As MyCollection(Of Book)
        cheapBooks = books.Filter(Function(b) b.Cost <= 110)
        For Each cheapBook In cheapBooks
            Console.WriteLine(cheapBook)
        Next
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Books by Category")
        Console.WriteLine("==========================================")
        Dim booksByCategory = books.GroupItem(Of Integer)(Function(b) b.CategoryId)
        For Each category In booksByCategory
            Console.WriteLine("Category Id = {0}", category.Key)
            For Each book In category.Value
                Console.WriteLine(vbTab + book.ToString())
            Next
        Next

        Console.WriteLine()
        Console.WriteLine("Books by Odd/Even Price")
        Console.WriteLine("==========================================")
        Dim booksByOddOrEvenPrice = books.GroupItem(Of String)(Function(b) If(b.Cost Mod 2 = 0, "Even", "Odd"))
        For Each category In booksByOddOrEvenPrice
            Console.WriteLine("Price Category = {0}", category.Key)
            For Each book In category.Value
                Console.WriteLine(vbTab + book.ToString())
            Next
        Next
        Console.WriteLine()

        Console.WriteLine("Joining books with categories")
        Console.WriteLine("==========================================")

        Dim categories = New MyCollection(Of Category)
        categories.Add(New Category() With {.CategoryId = 1, .CategoryName = "Technology"})
        categories.Add(New Category() With {.CategoryId = 2, .CategoryName = "Fiction"})

        Dim bookWithCategoryList = books.JoinItems(Of Category, Integer, BookWithCategory) _
                                   (categories, _
                                    Function(b) b.CategoryId, _
                                    Function(c) c.CategoryId, _
                                    Function(b, c) New BookWithCategory() With {.Id = b.Id, _
                                                                                .Title = b.Title, _
                                                                                .Cost = b.Cost, _
                                                                                .Stock = b.Stock, _
                                                                                .CategoryId = c.CategoryId, _
                                                                                .CategoryName = c.CategoryName
                                                                               })
        For Each bookWithCategory In bookWithCategoryList
            Console.WriteLine(bookWithCategory)
        Next
        Console.ReadLine()
    End Sub

    Public Function CompareBooksByStock(ByVal leftBook As Book, ByVal rightBook As Book) As Integer
        Return Math.Sign(leftBook.Stock - rightBook.Stock)
    End Function



End Module


Public Class Category

    Private _categoryId As Integer
    Public Property CategoryId() As Integer
        Get
            Return _categoryId
        End Get
        Set(ByVal value As Integer)
            _categoryId = value
        End Set
    End Property


    Private _categoryName As String
    Public Property CategoryName() As String
        Get
            Return _categoryName
        End Get
        Set(ByVal value As String)
            _categoryName = value
        End Set
    End Property



End Class

Public Class BookWithCategory
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _title As String
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property


    Private _cost As Decimal
    Public Property Cost() As Decimal
        Get
            Return _cost
        End Get
        Set(ByVal value As Decimal)
            _cost = value
        End Set
    End Property


    Private _stock As Integer
    Public Property Stock() As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property


    Private _categoryId As Integer
    Public Property CategoryId() As Integer
        Get
            Return _categoryId
        End Get
        Set(ByVal value As Integer)
            _categoryId = value
        End Set
    End Property


    Private _categoryName As String
    Public Property CategoryName() As String
        Get
            Return _categoryName
        End Get
        Set(ByVal value As String)
            _categoryName = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Dim s As String = "something"

        Return String.Format("{0},{1},{2:c},{3},{4},{5}", Id, Title, Cost, Stock, CategoryId, CategoryName).Replace(",", vbTab)

    End Function

End Class

Module MyModule
    <Extension()>
    Public Sub Print(ByVal s As String)

    End Sub
End Module