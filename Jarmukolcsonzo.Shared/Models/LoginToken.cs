using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace Jarmukolcsonzo.API.Models;

//[Index("felhasznalo_id", Name = "felhasznalo_id")]
//[MySqlCharSet("utf8")]
//[MySqlCollation("utf8_general_ci")]
[Table("login_tokenek")]
public partial class LoginToken
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string token { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime lejarat_datum { get; set; }

    [Column(TypeName = "int(11)")]
    public int felhasznalo_id { get; set; }

    [ForeignKey("felhasznalo_id")]
    [InverseProperty("login_tokenek")]
    public virtual Felhasznalo felhasznalo { get; set; } = null!;
}
