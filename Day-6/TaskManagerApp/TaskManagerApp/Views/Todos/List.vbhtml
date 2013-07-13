@ModelType IEnumerable(Of TaskManagerApp.Todo)
<ul>
    @For Each todo In Model
        @<li><span class="@IIf(todo.IsCompleted, "completed","")">@todo.Name  </span> <a href="/Todos/Remove?Id=@todo.Id">Remove</a> @Ajax.ActionLink("Complete","Complete", New With {.Id = todo.Id }, New AjaxOptions With {.UpdateTargetId = "divTodoList"})   </li> 
    Next
</ul>
