using ReactWithASP.Server.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class Lecturer(string firstName, string lastName) : Entity<int>
{
    [MaxLength(30)] public string FirstName { get; private set; } = firstName;

    [MaxLength(30)] public string LastName { get; private set; } = lastName;

    public void SetValues(string firstName, string lastName)
    => (FirstName, LastName) = (firstName, lastName);
}
