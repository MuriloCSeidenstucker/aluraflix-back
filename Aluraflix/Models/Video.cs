using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Models;

public class Video
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de título é obrigatório")]
    [StringLength(60)]
    public string Title { get; set; }

    [StringLength(270)]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo de URL é obrigatório")]
    [StringLength(50)]
    public string URL { get; set; }
}
