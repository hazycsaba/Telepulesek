using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telepulesek.Models.Entities;

[Table("telepules_jogallasok")]
public partial class TelepulesJogallas
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string jogallas { get; set; } = null!;

    [InverseProperty("jogallas")]
    public virtual ICollection<Telepules> telepulesek { get; set; } = new List<Telepules>();
}
