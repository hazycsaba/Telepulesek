using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telepulesek.Models.Entities;

[Table("telepules_kisebbsegi_kapcsolatok")]
[Keyless]
[Index("onkormanyzat_id", Name = "onkormanyzat_id")]
[Index("telepules_id", Name = "telepules_id")]
public partial class TelepulesKisebbsegiKapcsolat
{
    [Column(TypeName = "int(11)")]
    public int telepules_id { get; set; }

    [Column(TypeName = "int(11)")]
    public int onkormanyzat_id { get; set; }

    [ForeignKey("onkormanyzat_id")]
    public virtual KisebbsegiOnkormanyzat onkormanyzat { get; set; } = null!;

    [ForeignKey("telepules_id")]
    public virtual Telepules telepules { get; set; } = null!;
}
