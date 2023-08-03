namespace Biludlejningsfirma.Models
{
    public class Udlejning
    {
        public int Id { get; set; }
        public Biltype biltype { get; set; }
        public Bruger bruger { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Extra extra { get; set; }
    }
}
