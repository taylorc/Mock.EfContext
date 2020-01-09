using AutoMapper;
using Mock.EfContext.Application.Common.Interfaces;
using Mock.EfContext.Application.TodoLists.Queries.GetTodos;
using Mock.EfContext.Application.UnitTests.Common;
using Mock.EfContext.Domain.Entities;
using Mock.EfContext.Infrastructure.Persistence;
using MockQueryable.Moq;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mock.EfContext.Application.UnitTests.TodoLists.Queries.GetTodos
{
    [Collection("QueryTests")]
    public class GetTodosQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodosQueryTests(QueryTestFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            //arrange
            var query = new GetTodosQuery();
            var mockedDbContext = new Mock<IApplicationDbContext>();

            var todoListEntities = new List<TodoList>
            {
                new TodoList{Colour="Blue", Items = new List<TodoItem>{
                        new TodoItem{Title="Dynamics" },
                        new TodoItem{Title="Case" },
                        new TodoItem{Title="Management" },
                        new TodoItem{Title="Accelerator" },
                        new TodoItem{Title="HSD" }
                    } 
                }
            };

            var mockDbSet = todoListEntities.AsQueryable().BuildMockDbSet();

            mockedDbContext.Setup(db => db.TodoLists).Returns(mockDbSet.Object);

            //act
            var handler = new GetTodosQuery.GetTodosQueryHandler(mockedDbContext.Object, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<TodosVm>();
            result.Lists.Count.ShouldBe(1);

            var list = result.Lists.First();

            list.Items.Count.ShouldBe(5);
        }
    }
}
