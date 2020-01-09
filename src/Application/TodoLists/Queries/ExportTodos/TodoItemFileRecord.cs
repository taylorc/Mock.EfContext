using Mock.EfContext.Application.Common.Mappings;
using Mock.EfContext.Domain.Entities;

namespace Mock.EfContext.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
