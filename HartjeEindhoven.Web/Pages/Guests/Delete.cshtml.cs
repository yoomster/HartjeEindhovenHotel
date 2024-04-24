using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HartjeEindhoven.Web.Data;
using HotelLibrary;

namespace HartjeEindhoven.Web.Pages.Guests
{
    public class DeleteModel : PageModel
    {
        private readonly HartjeEindhoven.Web.Data.HartjeEindhovenWebContext _context;

        public DeleteModel(HartjeEindhoven.Web.Data.HartjeEindhovenWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GuestModel GuestModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestmodel = await _context.GuestModel.FirstOrDefaultAsync(m => m.Id == id);

            if (guestmodel == null)
            {
                return NotFound();
            }
            else
            {
                GuestModel = guestmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestmodel = await _context.GuestModel.FindAsync(id);
            if (guestmodel != null)
            {
                GuestModel = guestmodel;
                _context.GuestModel.Remove(GuestModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
