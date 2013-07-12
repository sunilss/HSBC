@ModelType GreetingTrueMVCApp.GreetModel

@Code
    Layout = Nothing
    
End Code

@Code
    'Dim model As GreetingTrueMVCApp.GreetModel = IIf(ViewData("model") Is Nothing, New GreetingTrueMVCApp.GreetModel(), CType(ViewData("model"), GreetingTrueMVCApp.GreetModel))
    
End Code
<!DOCTYPE html>

<html>
<head runat="server">
    <title>GreetInput</title>
    <style type="text/css">
        .error-field
        {
            border : 3px solid red;
            background-color : lightpink;
        }
    </style>
</head>
<body>
    <div>
        <form action="/Greeting/Greet" method="post">
        <div>
        First Name : 
            <input type="text" name="firstName" value="@Model.FirstName" class="@IIf(Model.ErrorMessages.ContainsKey("FirstName"), "error-field", "") " />
        </div>
        <div>
        Last Name : 
            <input type="text" name="lastName" value="@Model.LastName" class="@IIf(Model.ErrorMessages.ContainsKey("LastName"), "error-field", "") "/>
        </div>
        <input type="submit" name="submit" value="Submit" />
        </form>        
    </div>
    <ul>
        
    
    @code
        
        If (model.ErrorMessages IsNot Nothing) Then
            For Each e In model.ErrorMessages
                    @<li>@e.Value</li>        
            Next
        End If
    End Code
    </ul>
</body>
</html>
