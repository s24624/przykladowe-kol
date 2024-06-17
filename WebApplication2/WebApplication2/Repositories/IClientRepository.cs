using WebApplication2.Models;
using WebApplication2.ResponseModels;

namespace WebApplication2.Repository;

public interface IClientRepository
{
    public Task<ClientWithReservationsResponse> GetClientWithReservations(int clientId);
    public Task<ICollection<Reservation>> GetReservations( Client client);
    public Task SaveChanges();
}