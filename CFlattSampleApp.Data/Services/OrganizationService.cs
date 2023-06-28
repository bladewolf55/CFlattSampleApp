
namespace CFlattSampleApp.Data.Services;

public class OrganizationService : IOrganizationService
{
    CFlattSampleAppDbContext context;

    public OrganizationService(CFlattSampleAppDbContext context)
    {
        this.context = context;
    }

    public async Task<Organization> CreateOrganization(Organization organization)
    {
        var model = organization;
        Guard.IsNotNull(model);
        Guard.IsNull(context.Organizations.Find(model.Id));
        context.Organizations.Add(model);
        _ = await context.SaveChangesAsync(CancellationToken.None);
        return model;
    }

    public async Task<Organization> DeleteOrganization(int id)
    {
        var model = context.Organizations.Find(id);
        Guard.IsNotNull(model);
        model.Deleted = true;
        _ = await context.SaveChangesAsync(CancellationToken.None);
        return model;
    }

    public async Task<Organization> RetrieveOrganization(int id)
    {
        var model = await context.Organizations.FindAsync(id);
        Guard.IsNotNull(model);
        return model;
    }

    public async Task<IEnumerable<Organization>> RetrieveOrganizations(bool includeDeleted)
    {
        var model = await context.Organizations.Where(a => (!a.Deleted || includeDeleted) == true).ToListAsync(CancellationToken.None);
        return model;
    }

    public async Task<Organization> UpdateOrganization(Organization organization)
    {
        var submittedModel = organization;
        Guard.IsNotNull(submittedModel);
        context.Organizations.Update(submittedModel);
        var currentModel = context.Organizations.Find(organization.Id);
        Guard.IsNotNull(currentModel);
        currentModel = submittedModel;
        context.Organizations.Entry(submittedModel).State = EntityState.Modified;
        _ = await context.SaveChangesAsync(CancellationToken.None);
        return currentModel;
    }
}
