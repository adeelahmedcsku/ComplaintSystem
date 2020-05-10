using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompliantSystem.Dtos;
using CompliantSystem.Dtos.ComplaintDto;
using CompliantSystem.Helpers;
using CompliantSystem.Models;
using CompliantSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CompliantSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompliantController : ControllerBase
    {
        private IComplaintService _complaintService;
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CompliantController(
            IComplaintService complaintService,
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _complaintService = complaintService;
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]ComplaintDto complaintDto)
        {
            // map dto to entity
            var complaint = _mapper.Map<Complaint>(complaintDto);
            complaint.UserId = complaintDto.userDto.Id;

            try
            {
                // save 
                _complaintService.Create(complaint);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var compalaints = _complaintService.GetAll();
            var listComplaintDtos = new List<ComplaintDto>();
            foreach(var comp in compalaints)
            {
                User user = new User();
                user = _userService.GetById(comp.UserId);
                UserDto userdto = _mapper.Map<UserDto>(user);
                var complaintsDto = _mapper.Map<ComplaintDto>(comp);
                complaintsDto.userDto = userdto;
                listComplaintDtos.Add(complaintsDto);

            }
           
            
            return Ok(listComplaintDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var complaint = _complaintService.GetById(id);
            var complaintDto = _mapper.Map<ComplaintDto>(complaint);
            return Ok(complaintDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]ComplaintDto complaintDto)
        {
            // map dto to entity and set id
            var complaint = _mapper.Map<Complaint>(complaintDto);
            try
            {
                // save 
                _complaintService.Update(complaint);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _complaintService.Delete(id);
            return Ok();
        }

        [HttpGet("getByUser/{userId}")]
        public IActionResult getByUserId(int userId)
        {
            var complaint = _complaintService.GetComplaintsByUser(userId);
           // var complaintDto = _mapper.Map<ComplaintDto>(complaint);
            return Ok(complaint);
        }

    }
}