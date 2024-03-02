using System.ComponentModel.DataAnnotations;

public class Question
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public string? Image { get; set; }

}
