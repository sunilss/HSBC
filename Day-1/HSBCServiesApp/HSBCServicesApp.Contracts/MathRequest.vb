Imports System.Runtime.Serialization

<DataContract()>
Public Class MathRequest

    Private _operation As String
    <DataMember()>
    Public Property Operation() As String
        Get
            Return _operation
        End Get
        Set(ByVal value As String)
            _operation = value
        End Set
    End Property


    Private _number1 As Integer

    <DataMember()>
    Public Property Number1() As Integer
        Get
            Return _number1
        End Get
        Set(ByVal value As Integer)
            _number1 = value
        End Set
    End Property


    Private _number2 As Integer
    <DataMember()>
    Public Property Number2() As Integer
        Get
            Return _number2
        End Get
        Set(ByVal value As Integer)
            _number2 = value
        End Set
    End Property
End Class
