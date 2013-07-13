@ModelType TaskManagerApp.TodosViewModel
                               

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<style type="text/css">
    .completed 
    {
        color : Red;
        text-decoration : line-through;
        font-style : italic;
    }
</style>
<script type="text/javascript">

    var onSuccess = function (result) {
        // enable unobtrusive validation for the contents
        // that was injected into the <div id="result"></div> node
        $.validator.unobtrusive.parse($(result));
    };
</script>

<h2>Tasks</h2>
<i>Generated at @DateAndTime.Now.ToLongTimeString()  </i>
<hr />

@Html.ActionLink("All", "Index", New With {.Filter = "All"}) 
@Html.ActionLink("Completed", "Index", New With {.Filter = "Completed"})
@Html.ActionLink("Incomplete", "Index", New With {.Filter = "InComplete"})

@Code
    Html.RenderPartial("Add", Model.NewTodo)
End Code

<div id="divTodoList">
@Code
    Html.RenderPartial("List", Model.Todos)
End Code
</div>
