using System.ComponentModel.DataAnnotations;


namespace Glossary_API;

public class Definition
{
    [Key]
    public Guid DefinitionId { get; set; }
    [MaxLength(150)]
    public string GlossaryDefinition { get; set; }
    public Definition()
    {
        DefinitionId = Guid.NewGuid();     
    }

}
