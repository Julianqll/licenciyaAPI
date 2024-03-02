using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Answer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Body { get; set; }

    [Required]
    public bool IsCorrect { get; set; }

    [Required]
    public int QuestionId { get; set; }
}
