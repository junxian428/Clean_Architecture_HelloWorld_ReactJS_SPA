using Project3.Application.TodoItems.Commands.CreateTodoItem;
using Project3.Application.TodoItems.Commands.DeleteTodoItem;
using Project3.Application.TodoLists.Commands.CreateTodoList;
using Project3.Domain.Entities;
using static Testing;

namespace Project3.Application.FunctionalTests.TodoItems.Commands
{
    public class DeleteTodoItemTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand(99);

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand(itemId));

            var item = await FindAsync<TodoItem>(itemId);

            item.Should().BeNull();
        }
    }
}