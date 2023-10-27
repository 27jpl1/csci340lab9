using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LyonCollege.Models;
using LyonCollege.Data;

namespace LyonCollege.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly LyonCollege.Data.SchoolContext _context;

        public CreateModel(LyonCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.Age, s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
           {
               _context.Students.Add(emptyStudent);
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
           }

            return Page();
        }
    }
}
