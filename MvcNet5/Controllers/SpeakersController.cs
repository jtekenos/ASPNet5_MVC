using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Framework.Logging;
using MvcNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcNet5.Controllers
{
    public class SpeakersController : Controller
    {
        private SpeakerContext _context { get; set; }

        [FromServices]
        public ILogger<SpeakersController> Logger { get; set; }

        public SpeakersController(SpeakerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Speakers.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Items = GetSpeakersListItems();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _context.Speakers.Add(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        public ActionResult Details(int id)
        {
            Speaker speaker = _context.Speakers
                .Where(b => b.SpeakerId == id)
                .FirstOrDefault();
            if (speaker == null)
            {
                Logger.LogInformation("Details: Item not found {0}", id);
                return HttpNotFound();
            }
            return View(speaker);
        }

        private IEnumerable<SelectListItem> GetSpeakersListItems(int selected = -1)
        {
            var tmp = _context.Speakers.ToList();

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(s => s.LastName)
                .Select(s => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", s.FirstName, s.LastName),
                    Value = s.SpeakerId.ToString(),
                    Selected = s.SpeakerId == selected
                });
        }

        public async Task<ActionResult> Edit(int id)
        {
            Speaker speaker = await FindSpeakerAsync(id);
            if (speaker == null)
            {
                Logger.LogInformation("Edit: Item not found {0}", id);
                return HttpNotFound();
            }

            ViewBag.Items = GetSpeakersListItems(speaker.SpeakerId);
            return View(speaker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Speaker speaker)
        {
            try
            {
                speaker.SpeakerId = id;
                _context.Speakers.Attach(speaker);
                _context.Entry(speaker).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(speaker);
        }

        private Task<Speaker> FindSpeakerAsync(int id)
        {
            return _context.Speakers.SingleOrDefaultAsync(s => s.SpeakerId == id);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id, bool? retry)
        {
            Speaker speaker = await FindSpeakerAsync(id);
            if (speaker == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(speaker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Speaker speaker = await FindSpeakerAsync(id);
                _context.Speakers.Remove(speaker);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id = id, retry = true });
            }
            return RedirectToAction("Index");
        }
    }
}
