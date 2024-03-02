// Controllers/AnswersController.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace licenciyaAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public AnswersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Answer>> GetAnswers()
    {
        return _dbContext.Answers.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Answer> GetAnswerById(int id)
    {
        var Answer = _dbContext.Answers.Find(id);
        if (Answer == null)
        {
            return NotFound();
        }
        return Answer;
    }

    [HttpPost]
    public ActionResult<Answer> CreateAnswer([FromBody] Answer Answer)
    {
        _dbContext.Answers.Add(Answer);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetAnswerById), new { id = Answer.Id }, Answer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnswer(int id, [FromBody] Answer updatedAnswer)
    {
        var Answer = _dbContext.Answers.Find(id);
        if (Answer == null)
        {
            return NotFound();
        }

        Answer.Body = updatedAnswer.Body;
        Answer.IsCorrect = updatedAnswer.IsCorrect;
        Answer.QuestionId = updatedAnswer.QuestionId;
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnswer(int id)
    {
        var Answer = _dbContext.Answers.Find(id);
        if (Answer == null)
        {
            return NotFound();
        }

        _dbContext.Answers.Remove(Answer);
        _dbContext.SaveChanges();
        return NoContent();
    }
}