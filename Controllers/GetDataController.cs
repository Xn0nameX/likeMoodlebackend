using Kyzmav2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kyzmav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ourmoodlecontext _context;

        public ScheduleController(ourmoodlecontext context)
        {
            _context = context;
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetDailySchedule(DateTime date)
        {
           
            var schedule = await _context.working_plans
                .Include(wp => wp.homeworks)
                .ThenInclude(hw => hw.dates_of_dzs)
                .Where(wp => wp.homeworks.Any(hw => hw.dates_of_dzs.Any(dz => dz.DzDate.Date == date.Date)))
                .Select(wp => new ScheduleDto
                {
                    PlanTitle = wp.PlanTitle,
                    Homeworks = wp.homeworks.Select(hw => new HomeworkDto
                    {
                        HomeworkDescription = hw.HomeworkDescription,
                        DeadlineDates = hw.dates_of_dzs.Where(dz => dz.DzDate.Date == date.Date)
                            .Select(dz => dz.DzDate).ToList()
                    }).ToList()
                }).ToListAsync();

            return Ok(schedule);
        }
    }


    public class ScheduleDto
    {
        public string PlanTitle { get; set; }
        public List<HomeworkDto> Homeworks { get; set; }
    }

    public class HomeworkDto
    {
        public string HomeworkDescription { get; set; }
        public List<DateTime> DeadlineDates { get; set; }
    }
}
