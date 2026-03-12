using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Jarmukolcsonzo.Shared.Models;

// POCO = Plain Old Class Object

[Table("jarmu_tipusok")]
public partial class JarmuTipus
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string megnevezes { get; set; } = null!;

    [Column(TypeName = "int(2)")]
    public int ferohely { get; set; }

    [InverseProperty("tipus")]
    [JsonIgnore]
    public virtual ICollection<Jarmu> jarmuvek { get; set; } = new List<Jarmu>();
}
