using Project3.Application.Common.Interfaces;
using Project3.Application.Common.Security;
using Project3.Domain.Constants;

namespace Project3.Application.TodoLists.Commands.PurgeTodoLists
{
    [Authorize(Roles = Roles.Administrator)]
    [Authorize(Policy = Policies.CanPurge)]
    public record PurgeTodoListsCommand : IRequest;

    public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeTodoListsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.RemoveRange(_context.TodoLists);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}