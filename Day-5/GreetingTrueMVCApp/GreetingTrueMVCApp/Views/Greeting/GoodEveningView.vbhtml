@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <title>GoodEveningView</title>
    <style type="text/css">
        .greeting 
        { 
            color : red;
        }
    </style>
</head>
<body>
    <div class="greeting">
        @ViewData("Message") 
    </div>
</body>
</html>
