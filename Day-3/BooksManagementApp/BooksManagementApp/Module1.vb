Module Module1

    Sub Main()
        Dim books As New BooksCollection
        books.Add(New Book() With {.Id = 7, .Title = "C#", .Cost = 103, .Stock = 12})
        books.Add(New Book() With {.Id = 1, .Title = "F#", .Cost = 108, .Stock = 22})
        books.Add(New Book() With {.Id = 3, .Title = "D#", .Cost = 104, .Stock = 62})
        books.Add(New Book() With {.Id = 4, .Title = "E#", .Cost = 130, .Stock = 23})
        books.Add(New Book() With {.Id = 9, .Title = "K#", .Cost = 110, .Stock = 32})


        'For index = 0 To books.Count - 1
        'Console.WriteLine(books(index))
        'Next
        Console.WriteLine("Initial List")
        Console.WriteLine("==================================")
        For Each book In books
            Console.WriteLine(book)
        Next
        Console.WriteLine()

        Console.WriteLine("After sorting")
        Console.WriteLine("==================================")
        books.Sort()
        For Each book In books
            Console.WriteLine(book)
        Next
        Console.WriteLine()

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

        Console.ReadLine()
    End Sub

    Public Function CompareBooksByStock(ByVal leftBook As Book, ByVal rightBook As Book) As Integer
        Return Math.Sign(leftBook.Stock - rightBook.Stock)
    End Function



End Module
