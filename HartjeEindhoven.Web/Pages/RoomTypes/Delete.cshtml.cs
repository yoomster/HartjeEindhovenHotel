using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HartjeEindhoven.Web.Data;
using HotelLibrary;

namespace HartjeEindhoven.Web.Pages.RoomTypes
{
    public class DeleteModel : PageModel
    {
        private readonly HartjeEindhovenWebContext _context;

        public DeleteModel(HartjeEindhovenWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomType RoomTypeModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomtypemodel = await _context.RoomTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (roomtypemodel == null)
            {
                return NotFound();
            }
            else
            {
                RoomTypeModel = roomtypemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomtypemodel = await _context.RoomTypes.FindAsync(id);
            if (roomtypemodel != null)
            {
                RoomTypeModel = roomtypemodel;
                _context.RoomTypes.Remove(RoomTypeModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
