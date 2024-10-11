using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models.Data;
using ReactWithASP.Server.Models.DTOs;
using ReactWithASP.Server.Models.Entities;

namespace ReactWithASP.Server.Services
{
    public class GetSubjectService(AppDbContext context) : IGetSubjectService
    {
        public async Task<List<SubjectDto>> GetAll()
        {
            var subjects = await context.Subjects.ToListAsync();
            List<SubjectDto> results = [];

            foreach (var subject in subjects)
            {
                results.Add(MapDto(subject));
            }
            return results;
        }

        public async Task<SubjectDto> Get(int id)
        {
            var subject = await context.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(subject);
        }
        private SubjectDto MapDto(Subject subject)
            => new SubjectDto(subject.Id, subject.Title, subject.Select(i => new SubjectDto(i.Id, i.Title)).ToList());

        public async Task Store(SubjectDto dto)
        {
            var subject = new Subject(dto.Title);
            context.Subjects.Add(subject);
            await context.SaveChangesAsync();
        }
    }
}
