using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telepulesek.Models.Entities;

[Table("megyek")]
[Index("szekhely_id", Name = "szekhely")]
public partial class Megye
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string megye { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int? szekhely_id { get; set; }

    [ForeignKey("szekhely_id")]
    [InverseProperty("megyek")]
    public virtual Telepules? szekhely { get; set; }

    [InverseProperty("megye")]
    public virtual ICollection<Telepules> telepulesek { get; set; } = new List<Telepules>();
}
