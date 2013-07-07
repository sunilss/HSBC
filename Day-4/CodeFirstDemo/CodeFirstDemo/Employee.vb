Public Class Employee

    Public Overrides Function ToString() As String
        Return String.Format("{0},{1},{2}", EId, FirstName, LastName)
    End Function
    Private _id As Integer
    Public Property EId() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _doj As DateTime
    Public Property DateOfJoining() As DateTime
        Get
            Return _doj
        End Get
        Set(ByVal value As DateTime)
            _doj = value
        End Set
    End Property



    Private _firstName As String
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property


    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property



    Private _department As Department
    Public Property Department() As Department
        Get
            Return _department
        End Get
        Set(ByVal value As Department)
            _department = value
        End Set
    End Property
End Class
