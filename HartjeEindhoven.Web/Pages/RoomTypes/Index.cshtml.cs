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
    public class IndexModel : PageModel
    {
        private readonly HartjeEindhovenWebContext _context;

        public IndexModel(HartjeEindhovenWebContext context)
        {
            _context = context;
        }

        public IList<RoomTypeModel> RoomTypeModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RoomTypeModel = await _context.RoomTypes.ToListAsync();
        }
    }
}
