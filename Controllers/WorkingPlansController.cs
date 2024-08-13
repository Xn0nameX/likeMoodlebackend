using Kyzmav2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kyzmav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingPlansController : ControllerBase
    {
        private readonly ourmoodlecontext _context;

        public WorkingPlansController(ourmoodlecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<working_plan>>> GetWorkingPlans()
        {
            return await _context.working_plans.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<working_plan>> GetWorkingPlan(int id)
        {
            var workingPlan = await _context.working_plans.FindAsync(id);

            if (workingPlan == null)
            {
                return NotFound();
            }

            return workingPlan;
        }

        [HttpPost]
        public async Task<ActionResult<working_plan>> PostWorkingPlan(InsertWorkingPlanModel insertWorkingPlanModel)
        {
            var workingPlan = new working_plan
            {
                PlanTitle = insertWorkingPlanModel.PlanTitle,
                PlanDescription = insertWorkingPlanModel.PlanDescription,
                UserId = insertWorkingPlanModel.UserId,
                WayOfFile = insertWorkingPlanModel.WayOfFile
            };

            _context.working_plans.Add(workingPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkingPlan", new { id = workingPlan.PlanId }, workingPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingPlan(int id, InsertWorkingPlanModel insertWorkingPlanModel)
        {
            var workingPlan = await _context.working_plans.FindAsync(id);
            if (workingPlan == null)
            {
                return NotFound();
            }

            workingPlan.PlanTitle = insertWorkingPlanModel.PlanTitle;
            workingPlan.PlanDescription = insertWorkingPlanModel.PlanDescription;
            workingPlan.UserId = insertWorkingPlanModel.UserId;
            workingPlan.WayOfFile = insertWorkingPlanModel.WayOfFile;

            _context.Entry(workingPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkingPlan(int id)
        {
            var workingPlan = await _context.working_plans.FindAsync(id);
            if (workingPlan == null)
            {
                return NotFound();
            }

            _context.working_plans.Remove(workingPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkingPlanExists(int id)
        {
            return _context.working_plans.Any(e => e.PlanId == id);
        }
    }
}
