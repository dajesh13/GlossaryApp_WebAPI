using System.ComponentModel.DataAnnotations;

namespace Glossary_API;

public class GlossaryRequestDTO
{
    [Required]
    [MaxLength(50, ErrorMessage = "The Term shouldn't have more than 50 characters.")]
    public string GlossaryTerm { get; set; }

    [MaxLength(150, ErrorMessage = "The Definition shouldn't have more than 150 characters.")]
    public string GlossaryDefinition { get; set; }
}