using WebApplication2.Models;

namespace WebApplication2.ResponseModels;

public class ClientWithReservationsResponse
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public int IdClientCategory { get; set; }
    public List<ReservationResponse> Reservations { get; set; }
}