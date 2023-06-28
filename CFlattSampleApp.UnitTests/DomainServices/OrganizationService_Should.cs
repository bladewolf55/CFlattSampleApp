namespace CFlattSampleApp.UnitTests.DomainServices;

public class OrganizationFeatures_Should
{
    Data.Services.IOrganizationService organizationDataService;
    Domain.Services.OrganizationService organizationDomainService;

    public OrganizationFeatures_Should()
    {
        organizationDataService = Substitute.For<Data.Services.IOrganizationService>();
        organizationDomainService = new(organizationDataService);
    }

    [Fact]
    public async Task Create_a_new_organization()
    {
        // arrange
        Data.Models.Organization dataOrganization = OrganizationData.CAOrganization;        
        Domain.Models.Organization domainOrganization = dataOrganization.ToDomainModel();

        organizationDataService.CreateOrganization(Arg.Is<Data.Models.Organization>(a => a.Id == domainOrganization.Id))
            .Returns(dataOrganization);

        // act
        var result = await organizationDomainService.CreateOrganization(domainOrganization);

        // assert
        result.Should().BeEquivalentTo(domainOrganization);
    }

    [Fact]
    public async Task Delete_an_organization_by_id()
    {
        // arrange
        var dataOrganization = OrganizationData.CAOrganization;
        dataOrganization.Deleted = true;
        organizationDataService.DeleteOrganization(dataOrganization.Id).Returns(dataOrganization);

        // act
        var result = await organizationDomainService.DeleteOrganization(dataOrganization.Id);

        // assert
        result.Deleted.Should().BeTrue();
    }

    [Fact]
    public async Task Return_an_organization()
    {
        // arrange
        var dataOrganization = OrganizationData.CAOrganization;
        dataOrganization.Id = 1;
        var domainOrganization = dataOrganization.ToDomainModel();
        organizationDataService.RetrieveOrganization(domainOrganization.Id).Returns(dataOrganization);

        // act
        var result = await organizationDomainService.RetrieveOrganization(domainOrganization.Id);

        // assert
        result.Should().BeEquivalentTo(domainOrganization);
    }

    [Fact]
    public async Task Return_organizations()
    {
        // arrange
        List<Data.Models.Organization> organizations = new() { OrganizationData.CAOrganization, OrganizationData.CFlattOrganization };
        organizationDataService.RetrieveOrganizations(includeDeleted: false).Returns(organizations);

        // act
        var result = await organizationDomainService.RetrieveOrganizations(includeDeleted: false);

        // assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task Update_an_organization()
    {
        //arrange
        var dataOrganization = OrganizationData.CAOrganization;
        dataOrganization.Name = "newname";
        var submittedOrganization = dataOrganization.ToDomainModel();
        organizationDataService.UpdateOrganization(Arg.Is<Data.Models.Organization>(a => a.Id == dataOrganization.Id))
            .Returns(dataOrganization);


        //act
        var result = await organizationDomainService.UpdateOrganization(submittedOrganization);

        //assert
        result.Should().BeEquivalentTo(submittedOrganization);
    }
}

