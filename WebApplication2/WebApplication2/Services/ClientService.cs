using System.Data;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.RequestModels;
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

    public async Task<int> AddReservation(ReservationRequestModel reservationRequestModel)
    {
        var reservations = await _clientRepostiory.GetClientWithoutReservation(reservationRequestModel.IdClient);
        if (reservations == null)
        {
            throw new DataException("Ten klient nie może złożyć rezerwacji");
        }

        var boatCount = await _clientRepostiory.GetNumOfBoats(reservationRequestModel.NumOfBoats);
        if (boatCount < reservationRequestModel.IdBoatStandard)
        {
            if (_clientRepostiory.GetBoatStandard(reservationRequestModel.IdBoatStandard + 1) != null)
            {
                reservationRequestModel.IdBoatStandard += 1;
            }
            else
            {
                throw new DataException("nie mozna dokonac rezerwacji");
                
            }
        }

        var reservationResult = new Reservation()
        {
            IdClient = reservationRequestModel.IdClient,
            CancelReaeson = " ",
            Fulfilled = true,
            DateFrom = reservationRequestModel.DateFrom,
            DateTo = reservationRequestModel.DateTo,
            IdBoatStandard = reservationRequestModel.IdBoatStandard,
            Capacity = 1,
            Price = reservationRequestModel.NumOfBoats * 12,
            NumOfBoats = reservationRequestModel.NumOfBoats
        };
        await _clientRepostiory.AddReservation(reservationResult);
        await _clientRepostiory.SaveChanges();
        return reservationResult.IdReservation;
    }
}