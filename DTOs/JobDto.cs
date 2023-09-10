namespace Tp.Integrador.Softtek.Entities
{
    public class JobDTO
    {
        public DateTime JobDate { get; set; }
        public int ProjectId { get; set; }
        public int ServiceId { get; set; }
        public int NumberOfHours { get; set; }
        public double HourValue { get; set; }
        public double Cost { get; set; }
    }
}
