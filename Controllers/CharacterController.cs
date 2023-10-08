using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Container;
using catalog.Models;
using catalog.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        public CharacterController(ICharacterServices characterServices)
        {
            this._characterService = characterServices;
        }

        ICharacterServices _characterService;
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {

            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingleCharacter(int id)
        {

            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character character)
        {

            return Ok(await _characterService.AddCharacter(character));
        }
    }
}