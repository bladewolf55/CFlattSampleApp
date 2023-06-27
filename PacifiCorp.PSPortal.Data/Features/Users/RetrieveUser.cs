namespace PacifiCorp.PSPortal.Data.Features.Users;

public static class RetrieveUser
{
    public class Command : IRequest<User>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, User>
    {
        readonly PSPortalDbContext context;

        public Handler(PSPortalDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Handle(Command request, CancellationToken cancellationToken)
        {
            var model = await context.Users.FindAsync(request.Id);
            Guard.IsNotNull(model);
            return model;
        }
    }
}
