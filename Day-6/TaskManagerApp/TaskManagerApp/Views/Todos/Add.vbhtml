@ModelType TaskManagerApp.Todo
   <script type="text/javascript" language="javascript">
       $.validator.unobtrusive.parse(document);
</script>

@Using (Ajax.BeginForm("Add", "Todos", New AjaxOptions With {.UpdateTargetId = "divTodoList"}))

    @<div>
        Task : @Html.TextBoxFor(Function(m) m.Name)  @Html.ValidationMessageFor(Function (m) m.Name)  
    </div>
    @<div>
        IsCompleted : @Html.CheckBoxFor(Function(m) m.IsCompleted)  @Html.ValidationMessageFor(Function (m) m.IsCompleted )  
    </div>
    @<input type="submit" name="submit" value="Save" />
        
    End Using