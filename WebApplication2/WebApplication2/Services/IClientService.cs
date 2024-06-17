using WebApplication2.Models;
using WebApplication2.ResponseModels;

namespace WebApplication2.Services;

public interface IClientService
{
    public Task<ClientWithReservationsResponse> GetClientById(int clientId);
}