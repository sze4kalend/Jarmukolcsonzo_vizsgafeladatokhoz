using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Jarmukolcsonzo.Shared.Models;

//[Index("rendszam", Name = "rendszam", IsUnique = true)]
//[Index("tipus_id", Name = "tipus_id")]
[Table("jarmuvek")]
public partial class Jarmu
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(8)]
    public string rendszam { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int tipus_id { get; set; }

    [Column(TypeName = "int(5)")]
    public int dij { get; set; }

    public bool elerheto { get; set; }

    public DateTime? szerviz_datum { get; set; }

    [InverseProperty("jarmu")]
    [JsonIgnore] // JSON adatot nem készít belőle
    public virtual ICollection<Rendeles> rendelesek { get; set; } = new List<Rendeles>();

    [ForeignKey("tipus_id")]
    [InverseProperty("jarmuvek")]
    // Frontend csak a tipus_id-t fogja küldeni, ezért nem kötelező a tipus objektum
    // public virtual JarmuTipus tipus { get; set; } = null!;
    public virtual JarmuTipus? tipus { get; set; }
}
