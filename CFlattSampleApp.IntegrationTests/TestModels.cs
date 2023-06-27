using PacifiCorp.PSPortal.Data.Models;

namespace PacifiCorp.PSPortal.IntegrationTests.TestModels;

public static class UserData
{

    public static User Maddie =>
        new()
        {
            Id = 0,
            Name = "Maddie",
            Email = "m@example.com",
        };
}

public static class OrganizationData
{
    public static Organization USForestry =>
        new()
        {
            Id = 0,
            OrganizationType = Global.OrganizationType.Partner,
            Name = "US Forestry"
        };
}
