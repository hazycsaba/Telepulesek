using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Telepulesek.Models.Entities;

[Table("telepulesek")]
[Index("hivatal_kod_id", Name = "hivatal_kod")]
[Index("hivatal_szekhely_id", Name = "hivatal_szekhely")]
[Index("jaras_id", Name = "jaras")]
[Index("jogallas_id", Name = "jogallas")]
[Index("megye_id", Name = "megye")]
public partial class Telepules
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(100)]
    public string megnevezes { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int IRSZ { get; set; }

    [StringLength(100)]
    public string? telepulesresz { get; set; }

    [Column(TypeName = "int(11)")]
    public int ksh_kod { get; set; }

    [Column(TypeName = "int(11)")]
    public int jogallas_id { get; set; }

    [Column(TypeName = "int(11)")]
    public int megye_id { get; set; }

    [StringLength(11)]
    public string jaras_id { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int hivatal_kod_id { get; set; }

    [Column(TypeName = "int(11)")]
    public int? hivatal_szekhely_id { get; set; }

    [Column(TypeName = "int(11)")]
    public int terulet { get; set; }

    [Column(TypeName = "int(11)")]
    public int nepesseg { get; set; }

    [Column(TypeName = "int(11)")]
    public int lakasok { get; set; }

    [JsonIgnore]
    [InverseProperty("hivatal_szekhely")]
    public virtual ICollection<Telepules>? Inversehivatal_szekhely { get; set; } = new List<Telepules>();

    [ForeignKey("hivatal_kod_id")]
    [InverseProperty("telepulesek")]
    public virtual HivatalKod? hivatal_kod { get; set; } = null!;

    [ForeignKey("hivatal_szekhely_id")]
    [InverseProperty("Inversehivatal_szekhely")]
    public virtual Telepules? hivatal_szekhely { get; set; }

    [ForeignKey("jaras_id")]
    [InverseProperty("telepulesek")]
    public virtual Jaras? jaras { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("szekhely")]
    public virtual ICollection<Jaras>? jarasok { get; set; } = new List<Jaras>();

    [ForeignKey("jogallas_id")]
    [InverseProperty("telepulesek")]
    public virtual TelepulesJogallas? jogallas { get; set; } = null!;

    [ForeignKey("megye_id")]
    [InverseProperty("telepulesek")]
    public virtual Megye? megye { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("szekhely")]
    public virtual ICollection<Megye>? megyek { get; set; } = new List<Megye>();
}
