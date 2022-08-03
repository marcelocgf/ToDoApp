using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ToDoApp;

public class ToDoAppService : ApplicationService, IToDoAppService
{
    private readonly IRepository<ToDoItem, Guid> _toDoItemRepository;

    public ToDoAppService(IRepository<ToDoItem, Guid> toDoItemRepository)
    {
        _toDoItemRepository = toDoItemRepository;
    }

    public async Task<ToDoItemDto> CreateAsync(string text)
    {
        var toDoItem = await _toDoItemRepository.InsertAsync(new ToDoItem() {Text = text});
        return new ToDoItemDto() {Id = toDoItem.Id, Text = toDoItem.Text};
    }

    public async Task DeleteAsync(Guid id)
    {
        await _toDoItemRepository.DeleteAsync(id);
    }

    public async Task<List<ToDoItemDto>> GetListAsync()
    {
        var items = await _toDoItemRepository.GetListAsync();
        return items.Select(item => new ToDoItemDto() { Id = item.Id, Text = item.Text }).ToList();
    }
}
