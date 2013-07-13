@ModelType TaskManagerApp.Todo

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Add</title>
</head>
<body>
    <form action="/Todos/AddNew" method="post">
    
    <div>
        Task : @Html.TextBoxFor(Function(m) m.Name)  
    </div>
    <input type="submit" name="submit" value="Save" />
    </form>
</body>
</html>
