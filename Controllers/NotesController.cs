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
    public class NotesController : ControllerBase
    {
        private readonly ourmoodlecontext _context;

        public NotesController(ourmoodlecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<notes>>> GetNotes()
        {
            return await _context.notes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<notes>> GetNote(int id)
        {
            var note = await _context.notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public async Task<ActionResult<notes>> PostNote(InsertNoteModel insertNoteModel)
        {
            var note = new notes
            {
                NoteText = insertNoteModel.NoteText,
                NoteDate = insertNoteModel.NoteDate,
                UserId = insertNoteModel.UserId,
                NotesTypeId = insertNoteModel.NotesTypeId
            };

            _context.notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.NoteId }, note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteExists(int id)
        {
            return _context.notes.Any(e => e.NoteId == id);
        }
    }
}
