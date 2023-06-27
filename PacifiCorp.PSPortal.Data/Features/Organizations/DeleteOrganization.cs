﻿namespace PacifiCorp.PSPortal.Data.Features.Organizations;

public static class DeleteOrganization
{
    public class Command : IRequest<Organization>
    {
        public int Id { get; set; }
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
            var model = context.Organizations.Find(request.Id);
            Guard.IsNotNull(model);
            model.Deleted = true;
            _ = await context.SaveChangesAsync(CancellationToken.None);
            return model;
        }
    }
}