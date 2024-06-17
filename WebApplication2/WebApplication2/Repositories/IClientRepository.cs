using WebApplication2.Models;
using WebApplication2.ResponseModels;

namespace WebApplication2.Repository;

public interface IClientRepository
{
    public Task<ClientWithReservationsResponse> GetClientWithReservations(int clientId);
    public Task<ICollection<Reservation>> GetReservations( Client client);
    public Task SaveChanges();
    public Task<Client> GetClientById(int id);
    public Task<Reservation> GetClientWithoutReservation(int clientId);
    public Task<int> GetNumOfBoats(int idBoatStandard);
    public  Task<BoatStandard> GetBoatStandard(int boatStandardId);
    public  Task AddReservation(Reservation reservation);
}