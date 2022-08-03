using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ToDoApp.Blazor.Pages;

public partial class Index
{
    [Inject]
    private IToDoAppService ToDoAppService { get; set; }

    private List<ToDoItemDto> ToDoItems { get; set; } = new List<ToDoItemDto>();

    private string NewToDoText { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ToDoItems = await ToDoAppService.GetListAsync();
    }

    private async Task Create()
    {
        var result = await ToDoAppService.CreateAsync(NewToDoText);
        ToDoItems.Add(result);
        NewToDoText = null;
    }

    private async Task Delete(ToDoItemDto toDoItem)
    {
        await ToDoAppService.DeleteAsync(toDoItem.Id);
        ToDoItems.Remove(toDoItem);
        await Notify.Info("ToDo Item deleted!");
    }
}
