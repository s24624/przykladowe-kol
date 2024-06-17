namespace WebApplication2.Models;

public class SailboatReservation
{
    public int IdSailboat { get; set; }
    public int IdReservation { get; set; }

    public Reservation Reservation { get; set; }
    public Sailboat Sailboat { get; set; }
}