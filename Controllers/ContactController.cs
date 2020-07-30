using Microsoft.AspNetCore.Mvc;
using PRGSample.Models;

namespace PRGSample.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Message());
        }

        [HttpPost]
        public IActionResult Send(Message message)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), message);

            // Save the message...

            TempData[nameof(Message.Name)] = message.Name;
            TempData[nameof(Message.Email)] = message.Email;

            return RedirectToAction(nameof(Confirmation));
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            if (TempData[nameof(Message.Name)] == null || TempData[nameof(Message.Email)] == null)
                return RedirectToAction("Index", "Home");

            var confirmation = new MessageConfirmationViewModel
            {
                Name = TempData[nameof(Message.Name)].ToString(),
                Email = TempData[nameof(Message.Email)].ToString()
            };

            return View(confirmation);
        }
    }
}