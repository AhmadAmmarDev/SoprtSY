using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportSY.Client.Web.Models;
using SportSY.Client.Web.ViewModels;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportSY.Client.Web.Controllers
{

    public class MembershipController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private ITeamRepository _teamRepository { get; set; }

        private IRequestRepository _requestRepository;
        private IActivityRepository _activityRepository;
        private IPlaceRepository _placesRepository;

        public MembershipController(
            ITeamRepository teamRepository,
            IRequestRepository requestRepository,
            IActivityRepository activityRepository,
            IPlaceRepository placeRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _teamRepository = teamRepository;
            _requestRepository = requestRepository;
            _activityRepository = activityRepository;
            _placesRepository = placeRepository;
        }
        public ActionResult Index()
        {
            List<Team> teamsRequestList = new List<Team>();
            var loggedInUser = _userManager.GetUserAsync(HttpContext.User).Result;
            List<Guid> pendingRequests = _teamRepository.GetPendingMembershipByPersonID(loggedInUser.PersonId);
            var teamsLit = _teamRepository.GetItems().ToList();
            foreach (var team in teamsLit)
            {
                if (pendingRequests.Contains(team.ID))
                {
                    teamsRequestList.Add(team);
                }
            }
            ViewBag.TeamRequstsList = teamsRequestList;

            var requests = _requestRepository.GetItems();
            var places = _placesRepository.GetItems();
            var activities = _activityRepository.GetItems();

            MatchViewModel vm = new MatchViewModel();
            List<MatchViewModel> matchesRequest = new List<MatchViewModel>();
            foreach (var request in requests)
            {
                vm.AcitivityName = activities.FirstOrDefault(e => e.ID == request.ActivityId).ArabicName;
                vm.PlaceName = places.FirstOrDefault(e => e.ID == request.PlaceId).ArabicName;
                vm.MatchDate = request.MatchDate;
                vm.FromTeam = teamsLit.FirstOrDefault(e => e.ID == request.FromTeam).ArabicName;
                vm.ToTeam = teamsLit.FirstOrDefault(e => e.ID == request.ToTeam).ArabicName;
                matchesRequest.Add(vm);
            }
            ViewBag.MatchesRequests = matchesRequest;
            return View(ViewBag);
        }

        [HttpPost]
        public ActionResult Submit(int status, string teamId)
        {
            var loggedInUser = _userManager.GetUserAsync(HttpContext.User).Result;
            if (status == 1)
            {
                Guid teamID = Guid.Parse(teamId);
                _teamRepository.AcceptTeamMember(teamID, loggedInUser.PersonId);
            }
            else if (status == 0)
            {
                Guid teamID = Guid.Parse(teamId);
                _teamRepository.RejectTeamMember(teamID, loggedInUser.PersonId);

            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult SubmitMatch(int status, string teamId)
        {
            return RedirectToAction("Index");
        }
    }
}
