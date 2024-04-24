using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HartjeEindhoven.Web.Data;
using HotelLibrary;

namespace HartjeEindhoven.Web.Pages.Guests
{
    public class EditModel : PageModel
    {
        private readonly HartjeEindhoven.Web.Data.HartjeEindhovenWebContext _context;

        public EditModel(HartjeEindhoven.Web.Data.HartjeEindhovenWebContext context)
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

            var guestmodel =  await _context.GuestModel.FirstOrDefaultAsync(m => m.Id == id);
            if (guestmodel == null)
            {
                return NotFound();
            }
            GuestModel = guestmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GuestModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestModelExists(GuestModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GuestModelExists(int id)
        {
            return _context.GuestModel.Any(e => e.Id == id);
        }
    }
}
