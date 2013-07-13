@ModelType TaskManagerApp.Todos

@Code
    ViewData("Title") = "Index"
End Code

<h2>Tasks</h2>
<hr />
<ul>
    @For Each todo In Model
        @<li>@todo.Name </li>
    Next
</ul>
<a href="/Todos/Add">Add New</a>
