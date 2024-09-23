using ReactWithASP.Server.Models.DTOs;

namespace ReactWithASP.Server.Services
{
    public interface ISaveStudentService
    {
        Task Store(StudentDto dto);
        Task Update(int id, StudentDto dto);
    }
}
