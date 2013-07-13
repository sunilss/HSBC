Imports System.Data.Entity

Public Class MVCAppContext
    Inherits DbContext

    Public Property Todos As DbSet(Of Todo)

End Class
