using Contact.DAL.DataModels;
using Contact.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Contact.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly DbContext _dbContext;
        public UserController(IUserRepository userRepository, DbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = _userRepository.GetAll().ToList();
            var org = users[0].Organisation.Name;
            return Ok(users);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IHttpActionResult> AddUser()
        {

            var user = new User()
            {
                Name = "lola",
                PositionId = 1,
                OrganisationId = 3,
                ContactId = 3,
                Email = "james@gmal.com"


            };

            _userRepository.Save(user);
            return Ok(200);
        }
    }
}
