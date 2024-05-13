using Microsoft.EntityFrameworkCore;
using Serilog;
namespace Glossary_API;

public class GlossaryService : IGlossaryService
{
    private readonly GlossaryDbContext _context;

    public GlossaryService(GlossaryDbContext context)
    {
        _context = context;

    }
    // Create Glossary
    public string CreateGlossary(GlossaryRequestDTO glossaryRequestDTO)
    {
        Log.Debug("Create Glossary ServiceCall");

        var glossaryTerm = _context.Terms.FirstOrDefault(p => p.GlossaryTerm == glossaryRequestDTO.GlossaryTerm);
        if (glossaryTerm == null)
        {
            var definition = new Definition
            {
                GlossaryDefinition = glossaryRequestDTO.GlossaryDefinition
            };

            var term = new Term()
            {
                GlossaryTerm = glossaryRequestDTO.GlossaryTerm,
                Definition = definition
            };

            _context.Definitions.Add(definition);
            _context.Terms.Add(term);
            _context.SaveChanges();
            return AppConstants.GLOSSARY_SUCCESS_MESSAGE;
        }
        else
        {
            return AppConstants.GLOSSARY_TERM_EXISTS_MESSAGE;
        }


    }

    public string DeleteGlossary(Guid id)
    {
        Log.Debug("Delete Glossary ServiceCall");
        var term = _context.Terms.Include(p => p.Definition).FirstOrDefault(p => p.TermId == id);
        if (term != null)
        {
            term.TermId = id;
            _context.Terms.Remove(term);
            _context.SaveChanges();
            return AppConstants.GLOSSARY_DELETE_MESSAGE;
        }
        else
        {
            return AppConstants.GLOSSARY_TERM_DOESNOT_EXISTS_MESSAGE;
        }
    }

    // List Glossary
    public List<Term> GetGlossaryList()
    {
        Log.Debug("Get Glossary ServiceCall");  
        var terms = _context.Terms.Include(p => p.Definition).OrderBy(p => p.GlossaryTerm).ToList();
        return terms;     
    }

    // Update a Glossary
    public string UpdateGlossary(Guid id, GlossaryRequestDTO glossaryRequestDTO)
    {
        Log.Debug("Update Glossary ServiceCall");
        var term = _context.Terms.Include(p => p.Definition).FirstOrDefault(p => p.TermId == id);
        if (term != null)
        {
            term.GlossaryTerm = glossaryRequestDTO.GlossaryTerm;
            term.Definition.GlossaryDefinition = glossaryRequestDTO.GlossaryDefinition;
            _context.Terms.Update(term);
            _context.SaveChanges();
            return AppConstants.GLOSSARY_UPDATE_MESSAGE;
        }
        else
        {
            return AppConstants.GLOSSARY_TERM_DOESNOT_EXISTS_MESSAGE;
        }
    }
    public Term GetGlossaryById(Guid id)
    {
        Log.Debug("Get Glossary ServiceCall");
        var term = _context.Terms.Include(p => p.Definition).OrderBy(p => p.GlossaryTerm).FirstOrDefault(p => p.TermId == id);
        return term;
    }
}
