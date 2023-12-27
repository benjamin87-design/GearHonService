using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Models
{
    [Table("Expense")]
    public class ExpenseModel : BaseModel
    {
        [PrimaryKey("id")]
		public int ID { get; set; }

        [Column("ContractorName")]
        public string ContractorName { get; set; }

        [Column("UID")]
        public string UID { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("ExpenseType")]
        public string ExpenseType { get; set; }

        [Column("ExpenseAmount")]
        public decimal ExpenseAmount { get; set; }

        [Column("ExpenseCurrency")]
        public string ExpenseCurrency { get; set; }
    }
}
