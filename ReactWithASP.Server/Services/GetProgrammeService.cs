using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models.Data;
using ReactWithASP.Server.Models.DTOs;
using ReactWithASP.Server.Models.Entities;

namespace ReactWithASP.Server.Services
{
    public class GetProgrammeService(AppDbContext context) : IGetProgrammeService
    {
        public async Task<List<ProgrammeDto>> GetAll()
        {
            await context.Programmes.Include(i => i.Subjects).ToListAsync();

            var programmes = await context.Programmes.ToListAsync();
            List<ProgrammeDto> results = [];

            foreach (var programme in programmes)
            {
                results.Add(MapDto(programme));
            }
            return results;
        }
        public async Task<ProgrammeDto> Get(int id)
        {
            var programme = await context.Programmes.FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(programme);
        }
        private ProgrammeDto MapDto(Programme programme)
        {
            return new ProgrammeDto(programme.Id, programme.Title, programme.Subjects.Select(i => new SubjectDto(i.Id, i.Title)).ToList());
        }

        public async Task Store(ProgrammeDto dto)
        {
            var programme = new Programme(dto.Title);
            context.Programmes.Add(programme);
            await context.SaveChangesAsync();
        }

    }
}
