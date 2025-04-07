using Microsoft.AspNetCore.Mvc;
using MatthewEpSol.DataAccess;
using MatthewEpSol.domain;

namespace MatthewAzzopardiEpSolution.Controllers
{
    public class PollController : Controller
    {
       private readonly PollRepository _pollRepository;


        public PollController(PollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Poll poll) {
            if (ModelState.IsValid) {
                using var context = HttpContext.RequestServices.GetService<PollDbContext>();
                _pollRepository.CreatePoll(poll, context);

                return RedirectToAction("Create");
            }
            return View(poll);
        }
    }
}
