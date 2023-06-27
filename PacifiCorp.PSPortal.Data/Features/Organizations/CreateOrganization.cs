namespace PacifiCorp.PSPortal.Data.Features.Organizations;

public class CreateOrganization
{
    public class Command : IRequest<Organization>
    {
        public Organization Organization { get; set; } = null!;
    }

    public class Handler : IRequestHandler<Command, Organization>
    {
        readonly PSPortalDbContext context;

        public Handler(PSPortalDbContext context)
        {
            this.context = context;
        }

        public async Task<Organization> Handle(Command request, CancellationToken cancellationToken)
        {
            var model = request.Organization;
            Guard.IsNotNull(model);
            Guard.IsNull(context.Organizations.Find(model.Id));
            context.Organizations.Add(model);
            _ = await context.SaveChangesAsync(CancellationToken.None);
            return model;
        }
    }
}
