using CFlattSampleApp.Domain.Services;

namespace CFlattSampleApp.WebApi.Controllers;

[ApiController]
public class OrganizationsController : ControllerBase
{
    private readonly ILogger<OrganizationsController> logger;
    private readonly IOrganizationService organizationService;

    public OrganizationsController(ILogger<OrganizationsController> logger, IOrganizationService organizationService)
    {
        this.logger = logger;
        this.organizationService = organizationService;
    }

    [HttpGet("organizations/{id}")]
    public async Task<ActionResult<Organization>> Get(int id)
    {
        try
        {
            var organization = await organizationService.RetrieveOrganization(id);
            if (organization == null)
                throw new KeyNotFoundException();
            return Ok(organization);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogError(ex, "Organization not found");
            return NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to get organization");
            return BadRequest();
        }
    }

    [HttpGet("organizations")]
    public async Task<ActionResult<List<Organization>>> Get(bool includeDeleted)
    {
        var organizations = await organizationService.RetrieveOrganizations(includeDeleted);
        return Ok(organizations);
    }

    [HttpPut("organizations")]
    public async Task<ActionResult<Organization>> Put(Organization model)
    {
        try
        {
            var organization = await organizationService.CreateOrganization(model);
            return Ok(organization);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to add organization");
            return BadRequest();
        }
    }

    [HttpPost("organizations")]
    public async Task<ActionResult<Organization>> Post(Organization model)
    {
        try
        {
            var organization = await organizationService.UpdateOrganization(model);
            if (organization == null)
                throw new KeyNotFoundException();
            return Ok(organization);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogError(ex, "Organization not found");
            return NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to update organization");
            return BadRequest();
        }
    }

    [HttpDelete("organizations/{id}")]
    public async Task<ActionResult<Organization>> Delete(int id)
    {
        try
        {
            var organization = await organizationService.DeleteOrganization(id);
            if (organization == null)
                throw new KeyNotFoundException();
            return Ok(organization);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogError(ex, "Organization not found");
            return NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to delete organization");
            return BadRequest();
        }
    }
}