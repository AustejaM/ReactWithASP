namespace ReactWithASP.Server.Models.DTOs
{
    public record ProgrammeDto(int Id, string Title, List<SubjectDto> SubjectDtos);
}
