using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
        
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientById(int clientId)
    {
        var client = await _clientService.GetClientById(clientId);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }
}