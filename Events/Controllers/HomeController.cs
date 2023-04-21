using Events.Core.Models;
using Events.Models;
using Events.Providers.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Events.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventProvider _eventProvider;
        public HomeController(IEventProvider eventProvider)
        {
            _eventProvider = eventProvider;
        }

        public IActionResult Events()
        {
            var events = _eventProvider.GetEvents() ?? Enumerable.Empty<Event>();
            var eventsTable = new EventsTable(events);
            return View("Events", eventsTable);
        }

        public IActionResult Event(int id)
        {
            var existingEvent = _eventProvider.GetEventById(id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            return View(existingEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Event(Event updatedEvent)
        {
            if (ModelState.IsValid)
            {
                _eventProvider.Update(updatedEvent);
                return RedirectToAction("Events");
            }

            return View(updatedEvent);
        }

        public IActionResult NewEvent()
        {
            return View("Event");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _eventProvider.Create(newEvent);
                return RedirectToAction("Events");
            }

            return View("Event");
        }

        public IActionResult Delete(int id)
        {
            var @event = _eventProvider.GetEventById(id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event.Id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _eventProvider.Delete(id);

            return RedirectToAction("Events");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}