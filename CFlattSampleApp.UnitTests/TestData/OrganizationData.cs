namespace CFlattSampleApp.UnitTests.TestData;

/// <summary>
/// Ids are unique
/// </summary>
public static class OrganizationData
{
    public static Data.Models.Organization PacifiCorpOrganization =>
        new()
        {
            Id = 1,
            OrganizationType = OrganizationType.PacifiCorp,
            Name = "PacifiCorp",
        };

    public static Data.Models.Organization CAPartnerOrganization =>
        new()
        {
            Id = 1,
            OrganizationType = OrganizationType.PacifiCorp,
            Name = "CA Partner",
        };
}
