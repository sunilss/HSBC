Imports System.Text

Public Class FakeDateTimeServiceReturningMorningTime
    Implements IDateService

    Public Function GetCurrentDateTime() As Date Implements IDateService.GetCurrentDateTime
        Return New DateTime(2013, 7, 12, 9, 0, 0)
    End Function
End Class

Public Class FakeDateTimeServiceReturningEveningTime
    Implements IDateService

    Public Function GetCurrentDateTime() As Date Implements IDateService.GetCurrentDateTime
        Return New DateTime(2013, 7, 12, 19, 0, 0)
    End Function
End Class


<TestClass()>
Public Class GreeterTests

    <TestMethod()>
    Public Sub When_Greeted_Before_18_Greets_Good_Day()
        'Arrange
        Dim dateTimeService = New FakeDateTimeServiceReturningMorningTime
        Dim sut = New Greeter(dateTimeService)
        Dim name = "magesh"

        'Act
        Dim response = sut.Greet(name)

        'Assert
        Assert.IsTrue(response.StartsWith("Good Day"))
    End Sub

    <TestMethod()>
    Public Sub When_Greeted_After_18_Greets_Good_Evening()
        'Arrange
        Dim dateTimeService = New FakeDateTimeServiceReturningEveningTime
        Dim sut = New Greeter(dateTimeService)
        Dim name = "magesh"

        'Act
        Dim response = sut.Greet(name)

        'Assert
        Assert.IsTrue(response.StartsWith("Good Evening"))
    End Sub

End Class
