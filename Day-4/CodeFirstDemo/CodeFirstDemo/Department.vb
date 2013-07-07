Public Class Department

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property


    Private _employees As ICollection(Of Employee)
    Public Overridable Property Employees() As ICollection(Of Employee)
        Get
            Return _employees
        End Get
        Set(ByVal value As ICollection(Of Employee))
            _employees = value
        End Set
    End Property

    Sub New()
        Employees = New List(Of Employee)()
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("Id = {0}, Name = {1}", Id, Name)
    End Function



End Class
