using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Telepulesek.Models.Entities;

[Table("telepules_jogallasok")]
public partial class TelepulesJogallas
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string jogallas { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("jogallas")]
    public virtual ICollection<Telepules>? telepulesek { get; set; } = new List<Telepules>();
}
