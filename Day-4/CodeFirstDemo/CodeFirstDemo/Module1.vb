Imports System.Data.Entity

Module Module1

    Sub Main()
        Dim context As New MyAppEntities
        Database.SetInitializer(Of MyAppEntities)(New DropCreateDatabaseIfModelChanges(Of MyAppEntities)())
        context.Departments.Find(1)
        context.Departments.Find(1)
        context.Departments.Find(1)
        context.Departments.Find(1)
        Console.ReadLine()
    End Sub

    Sub PrintDepartment(ByVal dept As Department)
        Console.WriteLine(dept.ToString())
        Console.WriteLine(dept.Employees.Count)
    End Sub
    Sub SeedData()
        Dim context As New MyAppEntities
        Dim dept = New Department With
          {.Name = "Finance"}
        Dim emp = New Employee With
                  {.FirstName = "Suresh", _
                   .LastName = "K", _
                   .DateOfJoining = "01-Jan-2013", _
                   .Department = dept}

        dept.Employees.Add(emp)
        context.Employees.Add(emp)
        context.Departments.Add(dept)
        context.SaveChanges()

    End Sub
End Module



