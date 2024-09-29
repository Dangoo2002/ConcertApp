using Microsoft.AspNetCore.Mvc;
using ConcertApp.Models;

public class ConcertsController : Controller
{
    private readonly Manager _manager;

    public ConcertsController(ApplicationDbContext context)
    {
        _manager = new Manager(context);  // Pass DbContext to Manager
    }

    // Index action to display all concerts
    public IActionResult Index()
    {
        var concerts = _manager.GetAll();
        return View("~/Views/Home/Index.cshtml", concerts);  // Explicit path to Home/Index.cshtml
    }

    // Details action to display a specific concert
    public IActionResult Details(int id)
    {
        var concert = _manager.GetOne(id);
        if (concert == null) return NotFound();
        return View("~/Views/Home/Details.cshtml", concert);  // Explicit path to Home/Details.cshtml
    }

    // GET: Concerts/Create
    public IActionResult Create()
    {
        return View("~/Views/Home/Create.cshtml");  // Explicit path to Home/Create.cshtml
    }

    // POST: Concerts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ConcertAddViewModel model)
    {
        if (ModelState.IsValid)
        {
            _manager.AddNew(model);
            return RedirectToAction("Index");  // After creation, redirects to Index
        }
        return View("~/Views/Home/Create.cshtml", model);  // Return to form if invalid
    }

    // GET: Concerts/Edit/5
    public IActionResult Edit(int id)
    {
        var concert = _manager.GetOne(id);
        if (concert == null) return NotFound();
        return View("~/Views/Home/Edit.cshtml", concert);  // Explicit path to Home/Edit.cshtml
    }

    // POST: Concerts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ConcertBaseViewModel model)
    {
        if (id != model.ConcertId)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            var updated = _manager.UpdateExisting(model);
            if (!updated) return NotFound();  // Handle failure to update (e.g., concert not found)
            return RedirectToAction("Index");  // Redirect after successful update
        }
        return View("~/Views/Home/Edit.cshtml", model);  // Return to form if invalid
    }

    // GET: Concerts/Delete/5
    public IActionResult Delete(int id)
    {
        var concert = _manager.GetOne(id);
        if (concert == null) return NotFound();
        return View("~/Views/Home/Delete.cshtml", concert);  // Explicit path to Home/Delete.cshtml
    }

    // POST: Concerts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _manager.DeleteExisting(id);  // Calls manager to delete the concert
        return RedirectToAction("Index");  // Redirect to index after deletion
    }
}
