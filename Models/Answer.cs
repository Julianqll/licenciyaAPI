using System.ComponentModel.DataAnnotations;

public class Answer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Body { get; set; }

    [Required]
    public bool IsCorrect { get; set; }
    
}
