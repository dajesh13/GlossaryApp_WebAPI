using System.Data.Common;
using Glossary_API;
using Moq;

namespace Glossary_Test;

public class GlossaryUnitTest 
{
     private readonly Mock<IGlossaryService> _service;

     public GlossaryUnitTest()
     {
        _service = new Mock<IGlossaryService>();
     }

    [Fact]
    public void CreateGlossary_Should_Create_A_Glossary()
    {
        //Arrange
        var reqdata = new GlossaryRequestDTO()
        {
            GlossaryTerm = "NEW Term",
            GlossaryDefinition = "New DEFINITION"
        };
        _service.Setup(pr => pr.CreateGlossary(reqdata))
        .Returns(AppConstants.GLOSSARY_SUCCESS_MESSAGE);

         var actual = _service.Object.CreateGlossary(reqdata);

        Assert.Equal("Glossary Created Successfully",actual);
    }
    [Fact]
    public void GetGlossary_Should_Return_GlossaryList()
    {
        //Arrange
        _service.Setup(pr => pr.GetGlossaryList())
        .Returns(GetGlossary());

         var actual = _service.Object.GetGlossaryList();

        Assert.NotNull(actual);
        Assert.Equal(3, actual.Count);
    }

    [Fact]
    public void UpdateGlossary_Should_Update_a_Glossary()
    {
        //Arrange
        var reqdata = new GlossaryRequestDTO()
        {
            GlossaryTerm = "TERM1",
            GlossaryDefinition = "UPDATED DEFINITION"
        };
        var id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C696");
       
        _service.Setup(pr => pr.UpdateGlossary(id,reqdata)).Returns(AppConstants.GLOSSARY_UPDATE_MESSAGE);
        
        var result = _service.Object.UpdateGlossary(id,reqdata);
        Assert.Equal("Glossary Updated Successfully",result);

    }
    [Fact]
    public void UpdateGlossary_With_Invalid_Id_Should_Return_Invalid_Message()
    {
        //Arrange
        var reqdata = new GlossaryRequestDTO()
        {
            GlossaryTerm = "TERM1",
            GlossaryDefinition = "UPDATED DEFINITION"
        };
        var id = new Guid("7760F693-BEF5-E011-A485-80EE7300C696");
        
        _service.Setup(pr => pr.UpdateGlossary(id,reqdata)).Returns(AppConstants.GLOSSARY_TERM_DOESNOT_EXISTS_MESSAGE);
        
        var result = _service.Object.UpdateGlossary(id,reqdata);
        Assert.Equal("Glossary Doesn't Exists!",result);
    }

    [Fact]
    public void DeleteGlossary_Should_Delete_Glossary()
    {
        var id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C696");
        //Arrange
        _service.Setup(pr => pr.DeleteGlossary(id)).Returns(AppConstants.GLOSSARY_DELETE_MESSAGE);
        
        var result = _service.Object.DeleteGlossary(id);
        Assert.Equal("Glossary Deleted Successfully",result);
    }

    [Fact]
    public void DeleteGlossary_With_Invalid_Id_Should_Return_Invalid_Message()
    {
        var id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C690");
        //Arrange
        _service.Setup(pr => pr.DeleteGlossary(id)).Returns(AppConstants.GLOSSARY_TERM_DOESNOT_EXISTS_MESSAGE);
        
        var result = _service.Object.DeleteGlossary(id);
        Assert.Equal("Glossary Doesn't Exists!",result);
    }
    public List<Term> GetGlossary()
    {
          List<Term> productsData = new List<Term>
        {
            new Term
            {
                TermId = new Guid("5C60F693-BEF5-E011-A485-80EE7300C696"),
                GlossaryTerm = "testterm1",
                CreatedDate =  "2024-05-11T00:00:00",
                ModifiedDate = "2024-05-11T00:00:00"
                
            },
            new Term
            {
                TermId = new Guid("6C60F693-BEF5-E011-A485-80EE7300C696"),
                GlossaryTerm = "testterm2",
                CreatedDate =  "2024-05-11T00:00:00",
                ModifiedDate = "2024-05-11T00:00:00"
            },
             new Term
            {
                TermId = new Guid("7C60F693-BEF5-E011-A485-80EE7300C696"),
                GlossaryTerm = "testterm3",
                CreatedDate =  "2024-05-11T00:00:00",
                ModifiedDate = "2024-05-11T00:00:00"
                
            },
        };
            return productsData;
        }
}
