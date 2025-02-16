using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Repos.Models;

[Table("tbl_customer")]
[Index("Email", Name = "UQ__tbl_cust__A9D105347D6B8C19", IsUnique = true)]
public partial class TblCustomer
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
}
