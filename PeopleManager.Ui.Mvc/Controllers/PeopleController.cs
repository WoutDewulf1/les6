using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Contracts;
using PeopleManager.Ui.Mvc.Domain;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController(IPersonService personService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var people = personService.Find();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Person person)
        {
            personService.Create(person);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id)
        {
            var person = personService.Get(id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, [FromForm]Person person)
        {

            personService.Update(id, person);

            return RedirectToAction("Index");
        }
    }
}
