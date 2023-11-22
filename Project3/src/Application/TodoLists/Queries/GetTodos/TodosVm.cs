﻿using Project3.Application.Common.Models;

namespace Project3.Application.TodoLists.Queries.GetTodos
{
    public class TodosVm
    {
        public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = Array.Empty<LookupDto>();

        public IReadOnlyCollection<TodoListDto> Lists { get; init; } = Array.Empty<TodoListDto>();
    }
}