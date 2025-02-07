using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityRegister.Data;
using ActivityRegister.Models;

namespace ActivityRegister.Pages.Registrations
{
    public class DetailsModel : PageModel
    {
        private readonly ActivityRegister.Data.ActivityRegisterContext _context;

        public DetailsModel(ActivityRegister.Data.ActivityRegisterContext context)
        {
            _context = context;
        }

        public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FirstOrDefaultAsync(m => m.Id == id);

            if (registration is not null)
            {
                Registration = registration;

                return Page();
            }

            return NotFound();
        }
    }
}
