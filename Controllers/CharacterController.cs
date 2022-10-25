using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Dtos.Character;
using dotnet.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        public ICharacterService CharacterService { get; set;}
        public CharacterController(ICharacterService characterService){
            this.CharacterService = characterService;
            
        }        

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            
            return Ok(await this.CharacterService.GetAllCharacters());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id){
             
             var response = await this.CharacterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            
            return Ok(await this.CharacterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            
            return Ok(await this.CharacterService.AddCharacter(newCharacter));
        }
         [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter){
            
            var response = await this.CharacterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}