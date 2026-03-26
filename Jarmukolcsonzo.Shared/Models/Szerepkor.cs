using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace Jarmukolcsonzo.API.Models;

//[Index("nev", Name = "nev", IsUnique = true)]
//[MySqlCharSet("utf8")]
//[MySqlCollation("utf8_general_ci")]
[Table("szerepkorok")]
public partial class Szerepkor
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string nev { get; set; } = null!;

    [InverseProperty("szerepkor")]
    public virtual ICollection<Felhasznalo> felhasznalok { get; set; } = new List<Felhasznalo>();
}
