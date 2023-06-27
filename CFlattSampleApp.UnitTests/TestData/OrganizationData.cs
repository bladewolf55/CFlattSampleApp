namespace CFlattSampleApp.UnitTests.TestData;

/// <summary>
/// Ids are unique
/// </summary>
public static class OrganizationData
{
    public static Data.Models.Organization CFlattOrganization =>
        new()
        {
            Id = 1,
            OrganizationType = OrganizationType.CFlatt,
            Name = "CFlatt",
        };

    public static Data.Models.Organization CAPartnerOrganization =>
        new()
        {
            Id = 1,
            OrganizationType = OrganizationType.CFlatt,
            Name = "CA Partner",
        };
}
