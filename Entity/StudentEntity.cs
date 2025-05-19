using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Entity;

public class StudentEntity
{
    public int Id { get; set; }

 
    public string FirstName { get; set; }


    public string LastName { get; set; }


    public string StudentNumber { get; set; }

    public string Class { get; set; }
}
