
namespace CFlattSampleApp.Data.Services;

public interface IOrganizationService
{
    Task<Organization> CreateOrganization(Organization organization);
    Task<Organization> DeleteOrganization(int id);
    Task<Organization> RetrieveOrganization(int id);
    Task<IEnumerable<Organization>> RetrieveOrganizations(bool includeDeleted);
    Task<Organization> UpdateOrganization(Organization organization);

}
