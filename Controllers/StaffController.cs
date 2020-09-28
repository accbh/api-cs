using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bahrain.API.Data;
using Bahrain.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bahrain.API.Controllers
{
    // TODO: Needs authentication.
    [Route("staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepo _repository;
        private readonly IMapper _mapper;

        public StaffController(IStaffRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GETTING
        [HttpGet]
        public ActionResult<List<StaffReadDto>> GetAllStaff()
        {
            var controllerItems = _repository.GetAllStaff().ToList();

            //Console.WriteLine(controllerItems.First().PermissionPower);

            return Ok(_mapper.Map<List<StaffReadDto>>(controllerItems));
        }
        
        // POSTING
        
        
        // PUTTING
        
        
        // PATCHING
        
        
        // DELETING
        
    }

    [Route("admin/staff")]
    [ApiController]
    public class StaffAdminController : ControllerBase
    {
        private readonly IStaffRepo _repository;
        private readonly IMapper _mapper;

        public StaffAdminController(IStaffRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GETTING
        [HttpGet]
        public ActionResult<List<StaffReadAdminDto>> GetAllStaff()
        {
            var controllerItems = _repository.GetAllStaff().ToList();

            //Console.WriteLine(controllerItems.First().PermissionPower);

            return Ok(_mapper.Map<List<StaffReadAdminDto>>(controllerItems));
        }
        
        // POSTING
        
        
        // PUTTING
        
        
        // PATCHING
        
        
        // DELETING
        
    }
}
