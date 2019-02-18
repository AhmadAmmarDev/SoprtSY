using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportSY.Client.Web.Controllers
{
    public class MatchController : Controller
    {
        private ITeamRepository _teamRepository;
        private IActivityRepository _activityRepository;
        private IPlaceRepository _placeRepsitory;
        private IRequestRepository _requestRepository;

        public MatchController(ITeamRepository teamRepository,
            IActivityRepository activityRepository,
            IPlaceRepository placeRepository,
            IRequestRepository requestRepository)
        {
            _teamRepository = teamRepository;
            _activityRepository = activityRepository;
            _placeRepsitory = placeRepository;
            _requestRepository = requestRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var teams = _teamRepository.GetItems();
            var places = _placeRepsitory.GetItems();
            var activities = _activityRepository.GetItems();
            ViewBag.Teams = teams;
            ViewBag.Activities = activities;
            ViewBag.Places = places;
            return View();
        }
        [HttpPost]
        public IActionResult Create(string[] selectedTeams,string matchDate, string activityId, string placeId, string note)
        {
            List<Guid> teams = new List<Guid>();
            foreach(var item in selectedTeams)
            {
                teams.Add(Guid.Parse(item));
            }
            CultureInfo provider = CultureInfo.InvariantCulture;
            var request = new Request()
            {
                ActivityId = Guid.Parse(activityId),
                PlaceId = Guid.Parse(placeId),
                MatchDate = DateTime.ParseExact(matchDate, "d", provider),
                FromTeam = teams[0],
                ToTeam = teams[1],
                ID = Guid.NewGuid(),
                RequestTypeId = 2
            };
            _requestRepository.AddItem(request);
            return RedirectToAction("Create");
        }
    }
}
