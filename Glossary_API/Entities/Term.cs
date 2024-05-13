using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glossary_API;

public class Term
{
    [Key]
    public Guid TermId { get; set; }
    [Required]
    [MaxLength(50)]
    public string GlossaryTerm { get; set; }
    public string CreatedDate { get; set; } = DateTime.Now.ToShortDateString();
    public string? ModifiedDate { get; set; } = DateTime.Now.ToShortDateString();
    [ForeignKey("DefinitionId")]
    public Definition Definition{ get; set; }

    public Term()
    {
        TermId = Guid.NewGuid();
    }

    
}
