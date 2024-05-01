using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Telepulesek.Models.Entities;

[Table("hivatal_kodok")]
public partial class HivatalKod
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int kod { get; set; }

    [StringLength(100)]
    public string jelentes { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("hivatal_kod")]
    public virtual ICollection<Telepules>? telepulesek { get; set; } = new List<Telepules>();
}
