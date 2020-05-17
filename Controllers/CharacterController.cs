using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Model;
using dotnet_rpg.Services.CharacterService;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.User;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_rpg.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService _characterService)
        {
            this._characterService = _characterService;

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingel(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newcharacter)
        {
            await _characterService.AddCharacter(newcharacter);
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            await _characterService.UpdateCharacter(updatedCharacter);
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            await _characterService.DeleteCharacter(id);


            return Ok(await _characterService.GetAllCharacters());
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepo;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepo = authRepository;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Registor(UserRegisterDtos request){
           ServiceResponse<int> response = await authRepo.Register(new User { Username = request.Username }, request.Password);
            if (!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserRegisterDtos request){
            ServiceResponse<string> response = await authRepo.Login(request.Username,request.Password);
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}