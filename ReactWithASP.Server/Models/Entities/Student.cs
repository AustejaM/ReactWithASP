using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Models.Entities;
public class Student(string firstName, string lastName, string email) : Entity<int>
{
    [MaxLength(30)] public string FirstName { get; protected set; } = firstName;

    [MaxLength(30)] public string LastName { get; protected set; } = lastName;

    [MaxLength(30)] public string Email { get; protected set; } = email;

}

