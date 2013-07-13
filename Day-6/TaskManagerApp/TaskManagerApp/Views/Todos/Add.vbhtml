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
    @Using (Html.BeginForm())
    @<div>
        Task : @Html.TextBoxFor(Function(m) m.Name)  
    </div>
    @<input type="submit" name="submit" value="Save" />
        
    End Using
    
    
</body>
</html>
