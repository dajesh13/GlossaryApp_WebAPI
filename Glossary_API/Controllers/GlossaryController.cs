using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace Glossary_API;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class GlossaryController : ControllerBase
{
    private readonly IGlossaryService _glossaryService;


    public GlossaryController(IGlossaryService glossaryService)
    {
        _glossaryService = glossaryService;
    }

    [HttpPost]
    public ActionResult CreateGlossary([FromBody] GlossaryRequestDTO requestDTO)
    {
        try
        {       
            if (ModelState.IsValid)
            {
                var result = _glossaryService.CreateGlossary(requestDTO);
                return Ok(result);
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }

    }

    [HttpGet]
    [Route("getGlossary")]
    public ActionResult GetGlossary()
    {
        try
        {       
          var list = _glossaryService.GetGlossaryList();
          return Ok(list);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getGlossary/{id}")]
    public ActionResult GetGlossaryById(Guid id)
    {
        try
        {       
          var term = _glossaryService.GetGlossaryById(id);
          return Ok(term);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("updateGlossary/{Id:Guid}")]
    public ActionResult UpdateGlossary([FromRoute] Guid Id, [FromBody] GlossaryRequestDTO requestDTO)
    {
        try
        {       
            if (ModelState.IsValid)
            {
                var result = _glossaryService.UpdateGlossary(Id,requestDTO);
                return Ok(result);
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }

    }


    [HttpDelete]
    [Route("deleteGlossary/{Id:Guid}")]
    public ActionResult DeleteGlossary([FromRoute] Guid Id)
    {
        try
        {       
            if (ModelState.IsValid)
            {
               var result = _glossaryService.DeleteGlossary(Id);
                return Ok(result);
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }

    }

}
