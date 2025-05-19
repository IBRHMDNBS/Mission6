using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DTOs;

public class UpdateStudentDto
{
    [Required(ErrorMessage = "Id alanı zorunludur.")]
    [Range(1, int.MaxValue, ErrorMessage = "Id 1'den büyük olmalıdır.")]
    public int Id { get; set; }
    //
    [Required(ErrorMessage = "İsim alanı zorunludur.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "İsim 3-50 karakter arasında olmalıdır.")]
    public string FirstName { get; set; }
    //
    [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Soyisim 3-50 karakter arasında olmalıdır.")]
    public string LastName { get; set; }
    //
    [Required(ErrorMessage = "Öğrenci numarası alanı zorunludur.")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Öğrenci numarası 3-10 karakter arasında olmalıdır.")]
    public string StudentNumber { get; set; }
    //
    [Required(ErrorMessage = "Sınıf alanı zorunludur.")]
    [RegularExpression("A|B|C|D", ErrorMessage = "Sınıf A, B, C veya D olmalıdır.")]
    public string Class { get; set; }
}
