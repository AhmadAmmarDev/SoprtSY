using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportSY.Client.Web.Models;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;

namespace SportSY.Client.Web.Controllers
{
    public class TeamController : Controller
    {


        public TeamController(
            IPersonRepository personRepository,
            ITeamRepository teamRepository,
                UserManager<ApplicationUser> userManager)
        {
            _personRepository = personRepository;
            _teamRepository = teamRepository;
            _personsList = _personRepository.GetItems().ToList();
            _userManager = userManager;

        }
        private List<Person> _personsList { get; set; }


        private IPersonRepository _personRepository { get; set; }

        private ITeamRepository _teamRepository { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var persons = _personRepository.GetItems();
            ViewBag.Persons = persons;
            return View();
        }

        [HttpPost]
        public IActionResult Create(string[] playersList, string teamArabicName,string teamEnglishName)
        {
            
            var filteredList = playersList.Distinct();

            var validPersonsIds = new List<Guid>();

            foreach (var personId in filteredList)
            {

                var gudiPersonId = Guid.Parse(personId);
                var pserson = _personsList.FirstOrDefault(e => e.ID == gudiPersonId);
                if (pserson != null)
                {
                    validPersonsIds.Add(gudiPersonId);
                }
               
            }
            var team = new Team()
            {
                ArabicName = teamArabicName,
                EnglishName = teamEnglishName
            };
            var captinPersonId = _userManager.GetUserAsync(User).Result.PersonId;
            _teamRepository.AddItem(team, validPersonsIds, captinPersonId);
            ViewBag.Persons = _personsList;
            return RedirectToAction("Create", "Team");
        }
    }
}
