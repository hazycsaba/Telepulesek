using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telepulesek.Models.Entities;

[Table("jarasok")]
[Index("szekhely_id", Name = "szekhely")]
public partial class Jaras
{
    [Key]
    [StringLength(100)]
    public string kod { get; set; } = null!;

    [StringLength(11)]
    public string jaras { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int szekhely_id { get; set; }

    [ForeignKey("szekhely_id")]
    [InverseProperty("jarasok")]
    public virtual Telepules szekhely { get; set; } = null!;

    [InverseProperty("jaras")]
    public virtual ICollection<Telepules> telepulesek { get; set; } = new List<Telepules>();
}
