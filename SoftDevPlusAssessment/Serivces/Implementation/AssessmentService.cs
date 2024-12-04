using SoftDevPlusAssessment.Dtos;
using SoftDevPlusAssessment.Responses;
using SoftDevPlusAssessment.Serivces.Interfaces;

namespace SoftDevPlusAssessment.Serivces.Implementation
{
    public class AssessmentService : IAssessmentService
    {
        public AssessmentService() { }

        public Task<GenericResponse<List<string>>> SearchContentFromFile(FileSearchDto dto)
        {
            var results = new List<string>();
            GenericResponse<List<string>> response = new();
            try
            {
                var files = Directory.GetFiles(dto.FolderPath);

                foreach (var file in files)
                {
                    try
                    {
                        // Check if the file is a text file
                        var fileExtension = Path.GetExtension(file).ToLower();
                        if (fileExtension != ".txt")
                        {
                            results.Add($"Skipped: {Path.GetFileName(file)} (Not a text file)");
                            continue;
                        }

                        // Read and search content
                        var content = File.ReadAllText(file);
                        if (content.Contains(dto.SearchString))
                            results.Add($"Present: {Path.GetFileName(file)}");
                        else
                            results.Add($"Absent: {Path.GetFileName(file)}");
                    }
                    catch (Exception ex)
                    {
                        results.Add($"Error reading file {Path.GetFileName(file)}: {ex.Message}");
                    }
                }
                response = new GenericResponse<List<string>> { Data = results, IsSuccessful = true, ResponseCode = "00", ResponseDescription = "Success" };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                results.Add($"Internal error occurred. Error: {ex.Message}");
                response = new GenericResponse<List<string>> { Data = results, IsSuccessful = false, ResponseCode = "99", ResponseDescription = "Failed" };
                return Task.FromResult(response);
            }
        }

        public  Task<GenericResponse<List<string>>> CheckDuplicate(DuplicateCheckDto<int> dto)
        {
            GenericResponse<List<string>> response = new();
            var results = new List<string>();
            try
            {
                var setA = new HashSet<int>(dto.CollectionA);

                foreach (var item in dto.CollectionS)
                {
                    results.Add($"{item}:{setA.Contains(item).ToString().ToLower()}");
                }

                response = new GenericResponse<List<string>> { Data = results, IsSuccessful = true, ResponseCode = "00", ResponseDescription = "Success" };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                results.Add($"Internal error occurred. Error: {ex.Message}");
                response = new GenericResponse<List<string>> { Data = results, IsSuccessful = false, ResponseCode = "99", ResponseDescription = "Failed" };
                return Task.FromResult(response);
            }
        }

    }
}
