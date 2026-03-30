using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace Jarmukolcsonzo.Shared.Models;

//[Index("felhasznalonev", Name = "felhasznalonev", IsUnique = true)]
//[Index("szerepkor_id", Name = "szerepkor_id")]
//[MySqlCharSet("utf8")]
//[MySqlCollation("utf8_general_ci")]
[Table("felhasznalok")]
public partial class Felhasznalo
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string felhasznalonev { get; set; } = null!;

    [StringLength(255)]
    public string jelszo { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int szerepkor_id { get; set; }

    [InverseProperty("felhasznalo")]
    public virtual ICollection<LoginToken> login_tokenek { get; set; } = new List<LoginToken>();

    [ForeignKey("szerepkor_id")]
    [InverseProperty("felhasznalok")]
    public virtual Szerepkor szerepkor { get; set; } = null!;
}
