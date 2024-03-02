// Controllers/QuestionsController.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace licenciyaAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public QuestionsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Question>> GetQuestions()
    {
        return _dbContext.Questions.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Question> GetQuestionById(int id)
    {
        var Question = _dbContext.Questions.Find(id);
        if (Question == null)
        {
            return NotFound();
        }
        return Question;
    }

    [HttpPost]
    public ActionResult<Question> CreateQuestion([FromBody] Question Question)
    {
        _dbContext.Questions.Add(Question);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetQuestionById), new { id = Question.Id }, Question);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateQuestion(int id, [FromBody] Question updatedQuestion)
    {
        var Question = _dbContext.Questions.Find(id);
        if (Question == null)
        {
            return NotFound();
        }

        Question.Title = updatedQuestion.Title;
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteQuestion(int id)
    {
        var Question = _dbContext.Questions.Find(id);
        if (Question == null)
        {
            return NotFound();
        }

        _dbContext.Questions.Remove(Question);
        _dbContext.SaveChanges();
        return NoContent();
    }
}