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

namespace HartjeEindhoven.Web.Pages.RoomTypes
{
    public class EditModel : PageModel
    {
        private readonly HartjeEindhovenWebContext _context;

        public EditModel(HartjeEindhovenWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomTypeModel RoomTypeModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomtypemodel = await _context.RoomTypeModel.FirstOrDefaultAsync(m => m.Id == id);
            if (roomtypemodel == null)
            {
                return NotFound();
            }
            RoomTypeModel = roomtypemodel;
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

            _context.Attach(RoomTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeModelExists(RoomTypeModel.Id))
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

        private bool RoomTypeModelExists(int id)
        {
            return _context.RoomTypeModel.Any(e => e.Id == id);
        }
    }
}
