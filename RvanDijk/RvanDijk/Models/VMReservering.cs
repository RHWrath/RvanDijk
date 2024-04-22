namespace RvanDijk.Models
{
    public class VMReservering
    {
        public int ReservationID { get; set; }
        public string KlantNaam { get; set; }
        public DateTime Tijd_Datum { get; set; }

        public List<string> Klanten {  get; set; }
    }
}
