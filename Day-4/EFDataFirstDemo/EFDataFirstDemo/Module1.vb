Module Module1
    Dim db As New NorthwindEntities()
    Sub Main()
        'PrintAllProducts()
        'SaveNewProduct()
        'UpdateProduct()
        'AssignCategory()
        'PrintCategoriesAndProductsUsingLazyLoading()
        PrintCategoriesAndProductsUsingEagerLoading()
        Console.WriteLine("Done")
        Console.ReadLine()
    End Sub
    Private Sub PrintCategoriesAndProductsUsingEagerLoading()
        For Each category In db.Categories.Include("Products")
            Dim categoryName As String = category.CategoryName
            Dim categoryProductsCount = category.Products.Count
            Console.WriteLine("{0} - {1} Products", categoryName, categoryProductsCount)
            For Each product In category.Products
                Console.WriteLine(vbTab + product.ToString())
            Next
        Next
    End Sub

    Private Sub PrintCategoriesAndProductsUsingLazyLoading()
        For Each category In db.Categories
            Dim categoryName As String = category.CategoryName
            Dim categoryProductsCount = category.Products.Count
            Console.WriteLine("{0} - {1} Products", categoryName, categoryProductsCount)
            For Each product In category.Products
                Console.WriteLine(vbTab + product.ToString())
            Next
        Next
    End Sub

    Sub AssignCategory()
        Dim mouse As Product = db.Products.Single(Function(p) p.ProductID = 79)
        Dim electronicsCategory As New Category With _
            {.CategoryName = "Electronics", .Description = "Electronics Products"}

        electronicsCategory.Products.Add(mouse)
        mouse.Category = electronicsCategory
        db.SaveChanges()
    End Sub
    Sub UpdateProduct()
        Dim mouse As Product = db.Products.Single(Function(p) p.ProductID = 79)
        With mouse
            .ProductName = "Optical Mouse"
            .UnitPrice = 600
            .UnitsInStock = 100
        End With
        db.SaveChanges()

    End Sub
    Sub PrintAllProducts()
        For Each product In db.Products
            Console.WriteLine(product)
        Next
    End Sub
    Sub SaveNewProduct()

        Dim chaiProduct As Product = db.Products.Single(Function(p) p.ProductID = 1)
        Console.WriteLine(chaiProduct)

        Dim newProduct As New Product With {.ProductName = "Mouse"}
        Console.WriteLine("Before saving")
        Console.WriteLine(newProduct)
        Console.ReadLine()

        Console.WriteLine()
        Console.WriteLine("After saving")
        db.AddToProducts(newProduct)
        db.SaveChanges()
        Console.WriteLine(newProduct)
    End Sub

    
End Module

Partial Public Class Product
    Public Overrides Function ToString() As String
        Return String.Format("{0},{1},{2},{3},{4}", ProductID, ProductName, CategoryID, UnitPrice, UnitsInStock)
    End Function
End Class