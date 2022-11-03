using CRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebApp.Controllers
{
    public class PersonController : Controller
    {
        public static List<Person> people = new List<Person>()
        {
            new Person(){Id = 0,Name="Adam",Surename="Pawlikowski",Birth = new DateTime(2001,9,2) },
            new Person(){Id = 1,Name="Marcin",Surename="Strama",Birth = new DateTime(2001,5,21) },
            new Person(){Id = 2,Name="Sebastian",Surename="Bator",Birth = new DateTime(2001,3,15) },
            new Person(){Id = 3,Name="Marek",Surename="Pingwin",Birth = new DateTime(2001,4,13) }
        };
        public static int count = 4;
        public IActionResult Index()
        {
            return View(people);
        }
        public IActionResult Edit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return View("PersonForm");
            Person person = people.FirstOrDefault(e => e.Id == id);
            if (person != null)
                return View("PersonForm", person);
            else
                return View("Index", people);
        }
        public IActionResult Add()
        {
            return View("PersonForm");
        }
        [HttpPost]
        public IActionResult Add([FromForm] Person person)
        {
            if(!ModelState.IsValid)
                return View("PersonForm");
            if (person.Id != null)
            {

                people[people.FindIndex(e => e.Id == person.Id)] = person;

                return View("Index", people);
            }
            person.Id = count++;
            people.Add(person);
            return View("PersonForm");
        }
        public IActionResult Delete([FromRoute] int id)
        {
            Person person = people.FirstOrDefault(e => e.Id == id);
            if (person != null)
                people.Remove(person);


            return View("Index", people);
        }
    }
}
