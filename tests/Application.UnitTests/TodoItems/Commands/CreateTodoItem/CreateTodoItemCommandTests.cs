using Mock.EfContext.Application.Common.Interfaces;
using Mock.EfContext.Application.TodoItems.Commands.CreateTodoItem;
using Mock.EfContext.Application.UnitTests.Common;
using Mock.EfContext.Domain.Entities;
using MockQueryable.Moq;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mock.EfContext.Application.UnitTests.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandTests
    {
        [Fact]
        public async Task Handle_ShouldPersistTodoItem()
        {

            //arrange
            var todoItemEntities = new List<TodoItem>();
            
            var mockedDbContext = new Mock<IApplicationDbContext>();
            mockedDbContext.Setup(db=>db.TodoItems.Add(It.IsAny<TodoItem>())).Callback((TodoItem entity) => todoItemEntities.Add(entity));

            //act
            var command = new CreateTodoItemCommand
            {
                Title = "Do yet another thing."
            };

            var handler = new CreateTodoItemCommand.CreateTodoItemCommandHandler(mockedDbContext.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            //assert
            todoItemEntities.Count().ShouldBe(1);
            todoItemEntities[0].Title.ShouldBe(command.Title);
        }
    }
}
