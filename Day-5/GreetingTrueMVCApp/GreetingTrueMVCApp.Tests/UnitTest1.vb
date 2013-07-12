Imports System.Text
Imports GreetingTrueMVCApp.GreetingTrueMVCApp
Imports System.Web.Mvc


<TestClass()>
Public Class GreetingControllerTests

    <TestMethod()>
    Public Sub When_Greeted_after_18_EveningView_Is_Rendered()
        'Arrange
        Dim mockery = New Moq.Mock(Of IDateService)()
        mockery.Setup(Function(ds) ds.GetCurrentDateTime()).Returns(New DateTime(2013, 7, 12, 19, 0, 0))
        Dim dtService = mockery.Object
        Dim greeter = New Greeter(dtService)
        Dim greetController As New GreetingController(dtService, greeter)

        'Act
        Dim result As ViewResult = greetController.Greet("Magesh", "K")


        'Assert
        Assert.IsTrue(result.ViewName = "GoodEveningView")
    End Sub

    <TestMethod()>
    Public Sub When_Greeted_before_18_DayView_Is_Rendered()
        'Arrange
        Dim mockery = New Moq.Mock(Of IDateService)()
        mockery.Setup(Function(ds) ds.GetCurrentDateTime()).Returns(New DateTime(2013, 7, 12, 9, 0, 0))
        Dim dtService = mockery.Object
        Dim greeter = New Greeter(dtService)
        Dim greetController As New GreetingController(dtService, greeter)

        'Act
        Dim result As ViewResult = greetController.Greet("Magesh", "K")


        'Assert
        Assert.IsTrue(result.ViewName = "GoodDayView")
    End Sub

End Class
