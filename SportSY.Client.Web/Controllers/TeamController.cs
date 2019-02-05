using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using SportSY.Client.Web.Models;
using SportSY.Core.Interfaces;

namespace SportSY.Client.Web.Controllers
{
    public class TeamController : Controller
    {
        private IPersonRepository _personRepository { get; set; }

        private ITeamRepository _teamRepository { get; set; }

        public TeamController(
            IPersonRepository personRepository )
        {
            _personRepository = personRepository;
        }
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
        public IActionResult Create(object playersList)
        {
            var persons = _personRepository.GetItems();
            ViewBag.Persons = persons;
            // team name , team members l
            //_teamRepository.AddItem()
            return RedirectToAction("Team","Create");
        }
    }
}
