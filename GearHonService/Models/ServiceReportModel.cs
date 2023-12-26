using Postgrest.Attributes;
using Postgrest.Models;

namespace GearHonService.Models
{
    [Table("ServiceReport")]
    public class ServiceReportModel : BaseModel
    {
        [PrimaryKey("id")]
        public int ID { get; set; }

        [Column("UID")]
        public string UID { get; set; }

        [Column("Contractor")]
        public string Contractor { get; set; }

        [Column("CustomerName")]
        public string CustomerName { get; set; }

        [Column("Month")]
        public string Month { get; set; }

        [Column("Year")]
        public string Year { get; set; }

        [Column("TotalHour")]
        public string TotalHour { get; set; }
    }
}
