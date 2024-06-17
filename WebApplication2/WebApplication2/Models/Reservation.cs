namespace WebApplication2.Models;

public class Reservation
{
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public int Price { get; set; }
    public string CancelReaeson { get; set; }
    
    public BoatStandard BoatStandard { get; set; }
    public Client Client { get; set; }
    public ICollection<SailboatReservation> SailboatReservations { get; set; }
    
}   