using Microsoft.Extensions.Logging;
using Project3.Domain.Events;

namespace Project3.Application.TodoItems.EventHandlers
{
    public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
    {
        private readonly ILogger<TodoItemCreatedEventHandler> _logger;

        public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Project3 Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}