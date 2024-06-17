namespace WebApplication2.ResponseModels;

public class ReservationResponse
{
        public int IdReservation { get; set; }
        public int IdClient { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
}