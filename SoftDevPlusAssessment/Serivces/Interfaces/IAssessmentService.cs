using SoftDevPlusAssessment.Dtos;
using SoftDevPlusAssessment.Responses;

namespace SoftDevPlusAssessment.Serivces.Interfaces
{
    public interface IAssessmentService
    {
        Task<GenericResponse<List<string>>> SearchContentFromFile(FileSearchDto dto);
        Task<GenericResponse<List<string>>> CheckDuplicate(DuplicateCheckDto<int> dto);
    }
}
