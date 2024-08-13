using Kyzmav2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kyzmav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentTeachersController : ControllerBase
    {
        private readonly ourmoodlecontext _context;

        public CommentTeachersController(ourmoodlecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<comment_teacher>>> GetNotes()
        {
            return await _context.comment_teachers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<comment_teacher>> PostCommentTeacher(InsertCommentTeacherModel insertCommentTeacherModel)
        {
            var commentTeacher = new comment_teacher
            {
                TeacherComment = insertCommentTeacherModel.TeacherComment,
                HomeworkId = insertCommentTeacherModel.HomeworkId
            };

            _context.comment_teachers.Add(commentTeacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentTeacher", new { id = commentTeacher.CommentTId }, commentTeacher);
        }
    }
}

