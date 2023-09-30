using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    public class JobUpdateDto
    {
        public int JobId { get; set; }
        public DateTime JobDate { get; set; }
        public int NumberOfHours { get; set; }
        public double HourValue { get; set; }
        public double Cost { get; set; }
        public int ProjectId { get; set; }
        public int ServiceId { get; set; }
    }
}