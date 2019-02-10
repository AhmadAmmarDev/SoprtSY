using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportSY.Client.Web.Models;
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

        public MembershipController(
            ITeamRepository teamRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _teamRepository = teamRepository;
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
            return View(ViewBag);
        }
    }
}
