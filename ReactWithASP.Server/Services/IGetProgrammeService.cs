using ReactWithASP.Server.Models.DTOs;

namespace ReactWithASP.Server.Services
{
    public interface IGetProgrammeService
    {
        Task<List<ProgrammeDto>> GetAll();
        Task<ProgrammeDto> Get(int id);
    }
}
