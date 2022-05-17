using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbsenceAppData
{
    public partial class Absence
    {
        [Key]
        public Guid Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TypeName { get; set; }
        public double Percentage { get; set; }
    }
}
