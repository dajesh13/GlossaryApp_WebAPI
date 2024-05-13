namespace Glossary_API;

public interface IGlossaryService
{
    string CreateGlossary(GlossaryRequestDTO glossaryRequestDTO);
    string UpdateGlossary(Guid id, GlossaryRequestDTO glossaryRequestDTO);
    string DeleteGlossary(Guid id);
    List<Term> GetGlossaryList();
    Term GetGlossaryById(Guid id);


}
