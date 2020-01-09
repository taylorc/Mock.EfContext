using Mock.EfContext.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Mock.EfContext.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
