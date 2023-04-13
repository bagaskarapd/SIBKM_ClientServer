using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tr_universities")]
public class Universitie
{
    [Key, Column("id", TypeName = "int")]
    public int Id { get; set; }
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; }

    // Cardinality
    public ICollection<Education> Educations { get; set; }
}
