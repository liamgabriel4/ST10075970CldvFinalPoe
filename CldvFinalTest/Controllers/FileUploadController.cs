using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CldvFinalTest.Models;
using CldvFinalTest.Data;

namespace CldvFinalTest.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject ApplicationDbContext to save files in the database
        public FileUploadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET and POST action for file upload and display
        [HttpGet]
        public IActionResult Upload()
        {
            // Fetch the list of files from the database and pass it to the view
            var files = _context.Files.ToList();
            return View(files);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileModel = new FileModel
                {
                    Name = file.FileName,
                    Size = file.Length,
                    LastModified = DateTimeOffset.Now
                };

                // Optionally save the file to disk (in wwwroot/uploads)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Save the file metadata to the database
                _context.Files.Add(fileModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = "File uploaded successfully!";
            }
            else
            {
                TempData["Message"] = "Please select a valid file.";
            }

            // Redirect to the Upload action to refresh the list of files
            return RedirectToAction("Upload");
        }
    }
    //Digital TechJoint (2022). ASP.NET Identity - User Registration, Login and Log-out. [online] YouTube. Available at: https://www.youtube.com/watch?v=ghzvSROMo_M [Accessed 5 Nov. 2024].
    //Digital TechJoint (2022). ASP.NET MVC - How To Implement Role Based Authorization. YouTube. Available at: https://www.youtube.com/watch?v=qvsWwwq2ynE [Accessed 5 Nov. 2024].
    //Mrzygłód, K., 2022. Azure for Developers. 2nd ed. August: [Meeta Rajani]
}
