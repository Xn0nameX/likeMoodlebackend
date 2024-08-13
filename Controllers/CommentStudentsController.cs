using Kyzmav2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kyzmav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStudentsController : ControllerBase
    {
        private readonly ourmoodlecontext _context;

        public CommentStudentsController(ourmoodlecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<commentstudent>>> GetNotes()
        {
            return await _context.commentstudents.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<commentstudent>> PostCommentStudent(InsertCommentStudentModel insertCommentStudentModel)
        {
            var commentStudent = new commentstudent
            {
                StudentComment = insertCommentStudentModel.StudentComment,
                HomeworkId = insertCommentStudentModel.HomeworkId
            };

            _context.commentstudents.Add(commentStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentStudent", new { id = commentStudent.CommentSId }, commentStudent);
        }
    }
}
