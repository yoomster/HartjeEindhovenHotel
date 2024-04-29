using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HartjeEindhoven.Web.Data;
using HotelLibrary;

namespace HartjeEindhoven.Web.Pages.Rooms
{
    public class DeleteModel : PageModel
    {
        private readonly HartjeEindhoven.Web.Data.HartjeEindhovenWebContext _context;

        public DeleteModel(HartjeEindhoven.Web.Data.HartjeEindhovenWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Room = await _context.Rooms.FirstOrDefaultAsync(m => m.Id == id);

            if (Room == null)
            {
                return NotFound();
            }
            else
            {
                Room = Room;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Room = await _context.Rooms.FindAsync(id);
            if (Room != null)
            {
                Room = Room;
                _context.Rooms.Remove(Room);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
