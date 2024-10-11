using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Models.Entities;

public class Programme(string Title) : Entity<int>
{
    [MaxLength(30)] public string Title { get; private set; } = Title;
    public object Subjects { get; internal set; }
}
