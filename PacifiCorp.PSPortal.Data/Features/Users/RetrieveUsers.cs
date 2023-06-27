namespace PacifiCorp.PSPortal.Data.Features.Users;

public static class RetrieveUsers
{
    public class Command : IRequest<List<User>>
    {
        public bool IncludeDeleted { get; set; } = false;
    }

    public class Handler : IRequestHandler<Command, List<User>>
    {
        readonly PSPortalDbContext context;

        public Handler(PSPortalDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> Handle(Command command, CancellationToken cancellationToken)
        {
            var model = await context.Users.Where(a => (!a.Deleted || command.IncludeDeleted) == true).ToListAsync(CancellationToken.None);
            return model;
        }
    }
}