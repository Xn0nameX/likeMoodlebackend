using Kyzmav2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Kyzmav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly ourmoodlecontext _context;

        public HomeworkController(ourmoodlecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<homework>>> GetHomework()
        {
            return await _context.homeworks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<homework>> GetHomework(int id)
        {
            var homework = await _context.homeworks.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            return homework;
        }

        [HttpPost]
        public async Task<ActionResult<homework>> PostHomework(InsertHomeworkModel insertHomeworkModel)
        {
            var homework = new homework
            {
                DeadlineDate = insertHomeworkModel.DeadlineDate,
                HomeworkDescription = insertHomeworkModel.HomeworkDescription,
                PlanId = insertHomeworkModel.PlanId,
                WayHomework = insertHomeworkModel.WayHomework,
                StatusHomework = insertHomeworkModel.StatusHomework
            };

            _context.homeworks.Add(homework);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomework", new { id = homework.HomeworkId }, homework);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomework(int id, InsertHomeworkModel insertHomeworkModel)
        {
            var homework = await _context.homeworks.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }

            homework.DeadlineDate = insertHomeworkModel.DeadlineDate;
            homework.HomeworkDescription = insertHomeworkModel.HomeworkDescription;
            homework.PlanId = insertHomeworkModel.PlanId;
            homework.WayHomework = insertHomeworkModel.WayHomework;
            homework.StatusHomework = insertHomeworkModel.StatusHomework;
            _context.Entry(homework).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomework(int id)
        {
            var homework = await _context.homeworks.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }

            _context.homeworks.Remove(homework);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
