namespace WebApplication2.Models;

public class Client
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public int IdClientCategory { get; set; }

    public ClientCategory ClientCategory { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}