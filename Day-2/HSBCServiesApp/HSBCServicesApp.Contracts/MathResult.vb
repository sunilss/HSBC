Imports System.Runtime.Serialization

<DataContract()>
Public Class MathResult
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


    Private _result As Integer
    <DataMember()>
    Public Property Result() As Integer
        Get
            Return _result
        End Get
        Set(ByVal value As Integer)
            _result = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("Number1={0}, Number2={1}, Opeation={2}, Result={3}", Number1, Number2, Operation, Result)
    End Function
End Class
