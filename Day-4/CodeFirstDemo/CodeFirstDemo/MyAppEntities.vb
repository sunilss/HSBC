Imports System.Data.Entity

Public Class MyAppEntities
    Inherits DbContext

    Private _employees As DbSet(Of Employee)
    Public Property Employees() As DbSet(Of Employee)
        Get
            Return _employees
        End Get
        Set(ByVal value As DbSet(Of Employee))
            _employees = value
        End Set
    End Property


    Private _departments As DbSet(Of Department)
    Public Property Departments() As DbSet(Of Department)
        Get
            Return _departments
        End Get
        Set(ByVal value As DbSet(Of Department))
            _departments = value
        End Set
    End Property


    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As System.Data.Entity.DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        With modelBuilder.Entity(Of Employee)()
            .ToTable("tbl_Employees")
            .HasKey(Of Integer)(Function(e) e.EId)
            .Property(Function(e) e.EId).HasDatabaseGeneratedOption(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            .Property(Function(e) e.FirstName).HasMaxLength(100).IsRequired()
        End With

        With modelBuilder.Entity(Of Department)()
            .ToTable("tbl_Departments")
            .HasKey(Function(d) d.Id)
            .Property(Function(d) d.Id).HasDatabaseGeneratedOption(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            .Property(Function(d) d.Name).HasMaxLength(100).IsRequired()

        End With
        


    End Sub


End Class