using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.ResponseModels;

namespace WebApplication2.Repository
{
    public class ClientRepostiory : IClientRepository
    {
        private readonly SailboatDbContext _sailboatDbContext;

        public ClientRepostiory(SailboatDbContext sailboatDbContext)
        {
            _sailboatDbContext = sailboatDbContext;
        }

        // Pobierz rezerwacje dla danego klienta
        public async Task<ICollection<Reservation>> GetReservations(Client client)
        {
            var reservations = await _sailboatDbContext.Reservations
                .Where(e => e.IdClient == client.IdClient)
                .OrderByDescending(e => e.DateTo)
                .ToListAsync();
            return reservations;
        }

        // Pobierz dane klienta wraz z rezerwacjami
        public async Task<ClientWithReservationsResponse> GetClientWithReservations(int clientId)
        {
            var client = await _sailboatDbContext.Clients.FirstOrDefaultAsync(e => e.IdClient == clientId);
            if (client == null)
            {
                return null; // lub można rzucić wyjątek jeśli klient nie istnieje
            }

            var reservations = await GetReservations(client);

            var clientResponse = new ClientWithReservationsResponse()
            {
                IdClient = client.IdClient,
                IdClientCategory = client.IdClientCategory,
                Name = client.Name,
                Reservations = reservations.Select(r => new ReservationResponse
                {
                    IdReservation = r.IdReservation,
                    IdClient = r.IdClient,
                    DateFrom = r.DateFrom,
                    DateTo = r.DateTo,
                }).ToList()
            };

            return clientResponse;
        }

        // Zapisz zmiany do bazy danych
        public async Task SaveChanges()
        {
            await _sailboatDbContext.SaveChangesAsync();
        }
    }
}