using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.ResponseModels;

namespace WebApplication2.Services;

public class ClientService : IClientService
{
    private IClientRepository _clientRepostiory;

    public ClientService(IClientRepository sailboatDbContext)
    {
        _clientRepostiory = sailboatDbContext;
    }


    public async Task<ClientWithReservationsResponse> GetClientById(int clientId)
    {
        return await _clientRepostiory.GetClientWithReservations(clientId);
    }
}