using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telepulesek.Models.Entities;

[Table("kisebbsegi_onkormanyzatok")]
public partial class KisebbsegiOnkormanyzat
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int id { get; set; }

    [StringLength(50)]
    public string megnevezes { get; set; } = null!;
}
