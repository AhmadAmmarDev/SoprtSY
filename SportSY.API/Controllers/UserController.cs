using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportSY.API.Models;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using System.Collections.Generic;

namespace SportSY.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UserController : Controller

    {
        private IUserRepository _userRepository;
        private IMapper _mapepr;

        public UserController(IUserRepository userRepeository, IMapper mapper)
        {
            _userRepository = userRepeository;
            _mapepr = mapper;

        }
        [HttpGet(Name = "GetUsersModel")]
        public ActionResult GetUsersModel()
        {
            var test  = _userRepository.GetItems();
            return Ok(_mapepr.Map<IEnumerable<UserModel>>(_userRepository.GetItems()));
        }
        [HttpPost]
        public IActionResult Create([FromBody]Person person)
        {

            var newUri = Url.Link("GetUsers", person);
            return Created(newUri, person);
        }

    }
}