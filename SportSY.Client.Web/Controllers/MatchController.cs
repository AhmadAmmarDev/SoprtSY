using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSY.Core.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportSY.Client.Web.Controllers
{
    public class MatchController : Controller
    {
        private ITeamRepository _teamRepository;

        public MatchController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var teams = _teamRepository.GetItems();
            ViewBag.Teams = teams;
            return View();
        }
    }
}
