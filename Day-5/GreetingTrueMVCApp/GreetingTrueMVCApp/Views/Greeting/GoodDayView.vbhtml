@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <title>GoodDayView</title>
    <style type="text/css">
        .greeting 
        { 
            color : Green;
        }
    </style>
</head>
<body>
    <div class="greeting">
        @ViewData("Message") 
    </div>
</body>
</html>
