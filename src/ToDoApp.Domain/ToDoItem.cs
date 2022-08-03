using System;
using Volo.Abp.Domain.Entities;

namespace ToDoApp;

public class ToDoItem : BasicAggregateRoot<Guid>
{
    public string Text { get; set; }
}
