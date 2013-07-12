@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <title>GreetInput</title>
</head>
<body>
    <div>
        <form action="/Greeting/Greet" method="post">
        <div>
        First Name : 
            <input type="text" name="firstName" value=" " />
        </div>
        <div>
        Last Name : 
            <input type="text" name="lastName" value=" " />
        </div>
        <input type="submit" name="submit" value="Submit" />
        </form>        
    </div>
</body>
</html>
