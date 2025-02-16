using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Modal
{
    public class Customermodal
    {
        [Key]
        public int Code { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string? Email { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string? Phone { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? CreditLimit { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? TaxCode { get; set; }

        public string Statusname { get; set; }
    }
}
