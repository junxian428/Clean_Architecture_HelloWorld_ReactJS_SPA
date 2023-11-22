using Microsoft.Extensions.Logging;
using Project3.Domain.Events;

namespace Project3.Application.TodoItems.EventHandlers
{
    public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;

        public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Project3 Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}