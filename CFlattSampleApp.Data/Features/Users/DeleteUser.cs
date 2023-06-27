namespace PacifiCorp.PSPortal.Data.Features.Users;

public static class DeleteUser
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
            var model = context.Users.Find(request.Id);
            Guard.IsNotNull(model);
            model.Deleted = true;
            _ = await context.SaveChangesAsync(CancellationToken.None);
            return model;
        }
    }
}
