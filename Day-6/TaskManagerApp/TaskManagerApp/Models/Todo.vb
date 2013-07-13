Public Class Todo
    Public Property Id As Integer
    Public Property Name As String

    Private _isCompleted As Boolean
    Public ReadOnly Property IsCompleted() As Boolean
        Get
            Return _isCompleted
        End Get

    End Property

    Public Sub Complete()
        _isCompleted = True
    End Sub

End Class
