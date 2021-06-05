namespace Api.Entities
{
    public class KursDeltagare
    {
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
        public int DeltagareId { get; set; }
        public Deltagare Deltagare { get; set; }
    }
}