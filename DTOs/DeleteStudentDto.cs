using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DTOs;

public class DeleteStudentDto
{
    [Required(ErrorMessage = "Id alanı zorunludur.")]
    [Range(1, int.MaxValue, ErrorMessage = "Id 1'den büyük olmalıdır.")]
    public int Id { get; set; }
}



