Public Class Book

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

    Public Overrides Function ToString() As String
        Return String.Format("{0},{1},{2:c},{3}", Id, Title, Cost, Stock).Replace(",", vbTab)
    End Function

End Class
