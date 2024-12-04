using Microsoft.AspNetCore.Mvc;
using SoftDevPlusAssessment.Dtos;
using SoftDevPlusAssessment.Responses;
using SoftDevPlusAssessment.Serivces.Interfaces;

namespace SoftDevPlusAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssessmentController : ControllerBase
    {
       private readonly IAssessmentService _assessmentService;
        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [HttpPost("search-contents")]
        public async Task<IActionResult> SearchStringInFiles([FromBody] FileSearchDto dto)
        {
            GenericResponse<List<string>> response = new();
            try
            {
                if (!Directory.Exists(dto.FolderPath))
                {
                    response = new GenericResponse<List<string>> { IsSuccessful = false, ResponseCode = "99", ResponseDescription = "The specified folder does not exist." };
                    return BadRequest(response);
                }
                return Ok(await _assessmentService.SearchContentFromFile(dto));
            }
            catch (Exception ex)
            {
                response = new GenericResponse<List<string>> { IsSuccessful = false, ResponseCode = "99", ResponseDescription = $"Internal error occured. Error : {ex.Message}" };
                return StatusCode(500,response);
            }
        }

        [HttpPost("check-duplicates")]
        public async Task<IActionResult> CheckDuplicates([FromBody] DuplicateCheckDto<int> dto)
        {
            GenericResponse<List<string>> response = new();
            try
            {
                return Ok(await _assessmentService.CheckDuplicate(dto));
            }
            catch (Exception ex)
            {
                response = new GenericResponse<List<string>> { IsSuccessful = false, ResponseCode = "99", ResponseDescription = $"Internal error occured. Error : {ex.Message}" };
                return StatusCode(500, response);
            }
           
        }
    }

   
}


