<!DOCTYPE html>
<html>
<head>
    <title>@ViewData("Title")</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
    
    
    <script src="@Url.Content("~/Scripts/jquery.validate.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.js")" type="text/javascript"></script>
<!--    <script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.js")" type="text/javascript"></script> -->
    <script src="@Url.Content("~/Scripts/MicrosoftAjax.js")" type="text/javascript"></script> 
    <script src="@Url.Content("~/Scripts/MicrosoftMvcAjax.js")" type="text/javascript"></script> 
    <script src="@Url.Content("~/Scripts/MicrosoftMvcValidation.js")" type="text/javascript"></script> 
    
</head>

<body>
    @RenderBody()
</body>
</html>
