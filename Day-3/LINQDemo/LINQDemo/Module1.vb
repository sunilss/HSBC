Module Module1

    Sub Main()
        Dim books As New List(Of Book)
        books.Add(New Book() With {.Id = 7, .Title = "C#", .Cost = 103, .Stock = 12, .CategoryId = 1})
        books.Add(New Book() With {.Id = 1, .Title = "F#", .Cost = 128, .Stock = 22, .CategoryId = 2})
        books.Add(New Book() With {.Id = 3, .Title = "D#", .Cost = 104, .Stock = 62, .CategoryId = 1})
        books.Add(New Book() With {.Id = 4, .Title = "E#", .Cost = 130, .Stock = 23, .CategoryId = 1})
        books.Add(New Book() With {.Id = 9, .Title = "K#", .Cost = 110, .Stock = 32, .CategoryId = 2})

        Console.WriteLine(books.Min(Of Decimal)(Function(b) b.Cost))
        Console.WriteLine(books.Max(Of Integer)(Function(b) b.Stock))
        Console.WriteLine(books.Average(Function(b) b.Cost))
        'Dim BooksWithCategoryOne = books.Where(Function(b) b.CategoryId = 1)
        Dim BooksWithCategoryOne = From book In books Where book.CategoryId = 1 Select book

        For Each bookWithCategoryOne In BooksWithCategoryOne
            Console.WriteLine(bookWithCategoryOne)
        Next
        Console.WriteLine()

        Console.WriteLine("All Books with Cost > 100 = {0}", books.All(Function(b) b.Cost > 100))
        Console.WriteLine("Any C# Books = {0}", books.Any(Function(b) b.Title.Contains("C#")))
        Console.ReadLine()
    End Sub

End Module
