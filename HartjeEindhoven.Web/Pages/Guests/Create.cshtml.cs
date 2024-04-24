using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HartjeEindhoven.Web.Data;
using HotelLibrary;

namespace HartjeEindhoven.Web.Pages.Guests
{
    public class CreateModel : PageModel
    {
        private readonly HartjeEindhoven.Web.Data.HartjeEindhovenWebContext _context;

        public CreateModel(HartjeEindhoven.Web.Data.HartjeEindhovenWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GuestModel GuestModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GuestModel.Add(GuestModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
