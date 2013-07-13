@ModelType IEnumerable(Of TaskManagerApp.Todo )
                               

@Code
    ViewData("Title") = "Index"
End Code
<style type="text/css">
    .completed 
    {
        color : Red;
        text-decoration : line-through;
        font-style : italic;
    }
</style>
<h2>Tasks</h2>
<hr />
@Html.ActionLink("All", "Index", New With {.Filter = "All"}) 
@Html.ActionLink("Completed", "Index", New With {.Filter = "Completed"})
@Html.ActionLink("Incomplete", "Index", New With {.Filter = "InComplete"})
<ul>
    @For Each todo In Model
        @<li><span class="@IIf(todo.IsCompleted, "completed","")">@todo.Name </span> <a href="/Todos/Remove?Id=@todo.Id">Remove</a> @Html.ActionLink("Complete","Complete", New With {.Id = todo.Id })   </li> 
    Next
</ul>
<a href="/Todos/Add">Add New</a>
