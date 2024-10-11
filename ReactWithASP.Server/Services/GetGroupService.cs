using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models.Data;
using ReactWithASP.Server.Models.DTOs;
using ReactWithASP.Server.Models.Entities;

namespace ReactWithASP.Server.Services
{
    public class GetGroupService(AppDbContext context) : IGetGroupService
    {
        public async Task<List<GroupDto>> GetAll()
        {
            var groups = await context.Groups.ToListAsync();
            List<GroupDto> results = [];

            foreach (var group in groups)
            {
                results.Add(MapDto(group));
            }
            return results;
        }
        public async Task<GroupDto> Get(int id)
        {
            var group = await context.Groups.FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(group);
        }
        private GroupDto MapDto(Group group)
            => new GroupDto(group.Id, group.Title);
    }
}

