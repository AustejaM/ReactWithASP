using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Models.Entities;

public class Group(string Title) : Entity<int>
{
    [MaxLength(30)] public string Title { get; private set; } = Title;

}