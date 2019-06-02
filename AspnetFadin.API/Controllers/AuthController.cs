namespace AspnetFadin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;            
        }
      [HttpPost("register")]
      public async Task<IActionResult> Register(string username, string password){
          username = username.ToLower();
          
      }

    }
}