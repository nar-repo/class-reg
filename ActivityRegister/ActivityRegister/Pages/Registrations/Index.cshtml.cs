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
    public class IndexModel : PageModel
    {
        private readonly ActivityRegister.Data.ActivityRegisterContext _context;

        public IndexModel(ActivityRegister.Data.ActivityRegisterContext context)
        {
            _context = context;
        }

        public IList<Registration> Registration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Registration = await _context.Registration.ToListAsync();
        }
    }
}
