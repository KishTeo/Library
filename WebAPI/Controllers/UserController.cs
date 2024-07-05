using LibLogic.service;
using LibLogic.DTOs;
using LibLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static NuGet.Packaging.PackagingConstants;
using Newtonsoft.Json;
using LibDB.models;

namespace WebAPI.Controllers
{
    [Route("/User/")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IBookRentalService _rentService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public UserController(IBookRentalService rentService, IBookService bookService, IUserService userService)
        {
            _rentService = rentService;
            _bookService = bookService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return users is not null ? Ok(users) : NoContent();
        }
        [HttpGet("WithRents")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersWithRents()
        {
            var users = await _userService.GetUsersWithRentsAsync();
            return users is not null ? Ok(users) : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user is not null ? new ObjectResult(user) : NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserDTO item)
        {
            if (item is null)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserByIdAsync(item.UserId);
            if (user is null)
            {
                return NotFound();
            }
            await _userService.UpdateUserAsync(item);
            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(UserDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _userService.AddUserAsync(item);
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var users = await _userService.GetAllUsersAsync();
            var user = users.FirstOrDefault(x => x.UserId == id);
            if (user is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return Ok(user);
        }
        [HttpGet("report")]
        public async Task<ActionResult<ReportDTO>> GenerateReport()
        {
            
            var users = await _userService.GetAllUsersAsync();
            if (users == null)
            {
                return NoContent();
            }
            var bookRentals = await _rentService.GetAll();

            var report = new ReportDTO
            {
                ReportName = "Report",
                ReportDate = DateTime.Today,
                Users = users.Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    MiddleName = u.MiddleName,
                    BirthYear = u.BirthYear,
                    Address = u.Address,
                    Email = u.Email,
                    Bookrental = bookRentals.Where(r => r.UserId == u.UserId).Select(r => new BookRentalDTO
                    {
                        dateCapture = r.dateCapture, 
                        dateReturn = r.dateReturn,
                        Book = new BookDTO
                        {
                            Title = r.Book.Title,
                            Author = r.Book.Author
                        }
                    }).ToList()
                }).ToList()
            };

            return Ok(report);
        }
    }
}