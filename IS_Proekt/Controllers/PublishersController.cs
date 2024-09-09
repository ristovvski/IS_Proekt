using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using IS_Proekt.Domain;

namespace IS_Proekt.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            return View(_publisherService.GetAllPublishers());
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.GetPublisherDetails(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Address,Id")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                publisher.Id = Guid.NewGuid();
                _publisherService.AddPublisher(publisher);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Publishers/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.GetPublisherDetails(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Address,Id")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _publisherService.UpdatePublisher(publisher);
                }
                catch (Exception)
                {

                }
                return RedirectToAction(nameof(Index));
            }

            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.GetPublisherDetails(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _publisherService.DeletePublisher(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
