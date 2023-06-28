using CommunityToolkit.Diagnostics;

namespace CFlattSampleApp.Domain.Services;

public class OrganizationService : IOrganizationService
{
    Data.Services.IOrganizationService organizationDataService;

    public OrganizationService(Data.Services.IOrganizationService organizationDataService)
    {
        this.organizationDataService = organizationDataService;
    }

    public async Task<Organization> CreateOrganization(Organization organization)
    {
        var model = organization;
        Guard.IsNotNull(model);
        var dataModel = model.ToDataModel();
        dataModel = await organizationDataService.CreateOrganization(dataModel);
        return dataModel.ToDomainModel();
    }

    public async Task<Organization> DeleteOrganization(int id)
    {
        var dataModel = await organizationDataService.DeleteOrganization(id);
        return dataModel.ToDomainModel();
    }

    public async Task<Organization> RetrieveOrganization(int id)
    {
        var dataModel = await organizationDataService.RetrieveOrganization(id);
        Guard.IsNotNull(dataModel);
        return dataModel.ToDomainModel();
    }

    public async Task<List<Organization>> RetrieveOrganizations(bool includeDeleted)
    {
        var dataModel = await organizationDataService.RetrieveOrganizations(includeDeleted);
        return dataModel.ToDomainList();
    }

    public async Task<Organization> UpdateOrganization(Organization organization)
    {
        var submittedModel = organization;
        Guard.IsNotNull(submittedModel);
        var dataModel = await organizationDataService.UpdateOrganization(submittedModel.ToDataModel());
        return dataModel.ToDomainModel();
    }
}
