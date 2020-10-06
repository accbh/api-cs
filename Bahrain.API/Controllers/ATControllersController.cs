using System.Collections.Generic;
using Bahrain.API.Models;
using Bahrain.API.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Bahrain.API.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;

namespace Bahrain.API.Controllers
{
    [Route("controllers")]
    [ApiController]
    public class ATControllersController : ControllerBase
    {
        private readonly IATControllerRepo _repository;
        private readonly IMapper _mapper;

        //private readonly MockATControllerRepo _repository = new MockATControllerRepo();

        public ATControllersController(IATControllerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /////////////
        // GETTING //
        /////////////

        // TODO:
        // Add authorization - this will be a problem under GDPR.

        //GET api.bahrainvacc.com/controllers
        [HttpGet]
        public ActionResult <IEnumerable<ATControllerReadDTO>> GetAllControllers()
        {
            var controllerItems = _repository.GetAllControllers();

            return Ok(_mapper.Map<IEnumerable<ATControllerReadDTO>>(controllerItems));
        }

        //GET api.bahrainvacc.com/controllers/{id}
        [HttpGet("id/{id}", Name="GetControllerByID")]
        public ActionResult<ATControllerReadDTO> GetControllerById(int id)
        {

            var controllerItem = _repository.GetControllerById(id);

            if (controllerItem != null) {
                return Ok(_mapper.Map<ATControllerReadDTO>(controllerItem));
            } else {
                return NotFound();
            }

        }

        [HttpGet("cid/{cid}")]
        public ActionResult<ATControllerReadDTO> GetControllerByNetworkId(string cid)
        {
            
            //Console.WriteLine($"cid: {cid}");

            var controllerItem = _repository.GetControllerByNetworkId(cid);
            if (controllerItem != null) {
                return Ok(_mapper.Map<ATControllerReadDTO>(controllerItem));
            } else {
                return NotFound();
            }

        }

        [HttpGet("ratings/{rating}")]
        public ActionResult<IEnumerable<ATControllerReadDTO>> GetControllerByRating(string rating)
        {

            var controllerItems = _repository.GetControllerByRating(rating);

            return Ok(_mapper.Map<IEnumerable<ATControllerReadDTO>>(controllerItems));

        }

        //TODO: Fix this: Browser doesn't like commas.

        // [HttpGet("approved-positions/{positions}")]
        // public ActionResult<ATController> GetControllerByPosition(string position)
        // {

        //     var controllerItem = this.repository.GetControllerByNetworkID(position);

        //     return Ok(controllerItem);

        // }

        [HttpGet("on-solo")]
        public ActionResult<IEnumerable<ATControllerReadDTO>> GetControllerBySoloVal()
        {

            var controllerItems = _repository.GetSignedOffControllers();

            return Ok(_mapper.Map<IEnumerable<ATControllerReadDTO>>(controllerItems));

        }

        [HttpGet("signed-off")]
        public ActionResult<IEnumerable<ATControllerReadDTO>> GetControllerBySignOff()
        {

            var controllerItems = _repository.GetSignedOffControllers();

            return Ok(_mapper.Map<IEnumerable<ATControllerReadDTO>>(controllerItems));

        }

        //TODO add pages for listing visitors

        /////////////
        // POSTING //
        /////////////

        //TODO:
        // Add authorization. Don't want any random adding stuff.

        //POST api.bahrainvacc.com/controllers
        [HttpPost]
        public ActionResult <ATControllerReadDTO> AddATController(ATControllerCreateDTO controllerCreateDto)
        {
            var controllerModel = _mapper.Map<ATController>(controllerCreateDto);
            _repository.AddATController(controllerModel);
            _repository.SaveChanges();

            var controllerReadDto = _mapper.Map<ATControllerReadDTO>(controllerModel);

            return CreatedAtRoute(nameof(GetControllerById), new {ID = controllerReadDto.Id}, controllerReadDto);
        }

        /////////////
        // PUTTING //
        /////////////

        //TODO:
        //Add putting for other elements, such as name, rating etc.
        //Add authorization.

        //PUT api.bahrainvacc.com/controllers/id/{id}
        [HttpPut("id/{id}")]
        public ActionResult UpdateATController(int id, ATControllerUpdateDTO controllerUpdateDto)
        {
            var controllerFromRepo = _repository.GetControllerById(id);
            if (controllerFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(controllerUpdateDto, controllerFromRepo);
            _repository.UpdateATController(controllerFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }


        //////////////
        // PATCHING //
        //////////////

        //Example:
        // [
        //     {
        //         "op": "replace",
        //         "path": "/fullName",
        //         "value": "Steve Door"
        //     }
        // ]

        //TODO:
        //Add putting for other elements, such as name, rating etc.
        // Add authorization

        //PATCH api.bahrainvacc.com/controllers/id/{id}
        [HttpPatch("id/{id}")]
        public ActionResult PatchATController(int id, JsonPatchDocument<ATControllerUpdateDTO> patchDoc)
        {

            var controllerFromRepo = _repository.GetControllerById(id);
            if (controllerFromRepo == null) 
            {
                return NotFound();
            }

            var controllerToPatch = _mapper.Map<ATControllerUpdateDTO>(controllerFromRepo);
            patchDoc.ApplyTo(controllerToPatch, ModelState); //Modelstate checking if model validations are valid, nice

            if (!TryValidateModel(controllerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(controllerToPatch, controllerFromRepo);
            _repository.UpdateATController(controllerFromRepo); //I think these two lines do the same thing?

            _repository.SaveChanges();

            return NoContent();

        }

        //////////////
        // DELETING //
        //////////////

        //Deleting should only be called when a user leaves the vACC or requests that their data be deleted under GDPR.

        //TODO:
        // Add authorization!!!!
        // Add VATSIM ID as a way to find a user to delete.

        //DELETE api.bahrainvacc.com/controllers/id/{id}
        [HttpDelete("id/{id}")]
        public ActionResult DeleteATController(int id)
        {
            var controllerFromRepo = _repository.GetControllerById(id);
            if (controllerFromRepo == null) 
            {
                return NotFound();
            }

            _repository.DeleteController(controllerFromRepo);
            _repository.SaveChanges();

            //return NoContent();
            //We are going to return the deleted record just in case it was an accident, the user can copy it and put it back.
            //or in the system, we can add an undo button while the delete successful page is still active - it can keep the response until the user leaves the page.
            return Ok(_mapper.Map<ATControllerReadDTO>(controllerFromRepo));

        }

    }
}