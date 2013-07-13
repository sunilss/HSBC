Imports System.ComponentModel.DataAnnotations

Public Class Todo
    Public Property Id As Integer

    <Required()>
    Public Property Name As String

    Private _isCompleted As Boolean

    <Remote("Validate", "Todos", ErrorMessage:="Field is wrong")>
    Public Property IsCompleted() As Boolean
        Get
            Return _isCompleted
        End Get
        Private Set(value As Boolean)
            _isCompleted = value
        End Set
    End Property

    Public Sub Complete()
        IsCompleted = True
    End Sub

End Class

Public Class MyValidatorAttibute
    Inherits ValidationAttribute

    Protected Overrides Function IsValid(value As Object, validationContext As System.ComponentModel.DataAnnotations.ValidationContext) As System.ComponentModel.DataAnnotations.ValidationResult
        Return MyBase.IsValid(value, validationContext)
    End Function
    Public Overrides Function IsValid(value As Object) As Boolean
        Return MyBase.IsValid(value)
    End Function


End Class
