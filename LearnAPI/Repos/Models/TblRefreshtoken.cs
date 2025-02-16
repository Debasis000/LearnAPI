using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Repos.Models;

[Table("tbl_refreshtoken")]
public partial class TblRefreshtoken
{
    [Key]
    [Column("userid")]
    [MaxLength(50)]
    public byte[] Userid { get; set; } = null!;

    [Column("tokenid")]
    [MaxLength(50)]
    public byte[]? Tokenid { get; set; }

    [Column("refreshtoken")]
    [Unicode(false)]
    public string? Refreshtoken { get; set; }
}
