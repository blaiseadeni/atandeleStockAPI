using ATD_API.Data;
using ATD_API.Dtos;
using jwtLogin.Models;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using ATD_API.Entities;

namespace ATD_API.Controllers.Parametres
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly MyDbContext _context;
        private readonly ILogin _repository;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration configuration, MyDbContext context, ILogin repository, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            var result = await _context.logins.FirstOrDefaultAsync(u => u.utilisateur == user.userName);
            if (result != null && result.utilisateur == user.userName && BC.Verify(user.password, result.pwd) && result.state == true)
            {
                var item = await (from log in _context.logins
                                  join u in _context.utilisateurs on log.utilisateurId equals u.id
                                  join lo in _context.locations on u.locationId equals lo.id
                                  join r in _context.roles on u.roleId equals r.id
                                  where log.id == result.id
                                  select new
                                  {
                                      location = lo.designation,
                                      locationId = u.locationId,
                                      role = r.libelle,
                                      utilisateur = log.utilisateur,
                                      utilisateurId = u.id,
                                      state = log.state
                                  }).FirstOrDefaultAsync();


                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("location", item.location),
                        new Claim("locationId", item.locationId.ToString()),
                        new Claim("name", user.userName),
                        new Claim("role", item.role),
                        new Claim("utilisateurId", item.utilisateurId.ToString()),
                        new Claim(ClaimTypes.Name, user.userName),
                        new Claim(ClaimTypes.Role, item.role)
                   };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                                    jwt.Issuer,
                                    jwt.Audience,
                                    claims,
                                    expires: DateTime.Now.AddMinutes(1),
                                    signingCredentials: signing
                                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpPut("login/{id}")]
        public async Task<ActionResult<Login>> UpdateLogin(Guid id, [FromBody] UpdateLogin request)
        {
            var query = await _context.logins.FirstOrDefaultAsync(x => x.utilisateurId == id);

            query.utilisateur = request.userName;
            query.pwd = BC.HashPassword(request.password);
            query.state = true;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpPut("active/{id}")]
        public async Task<ActionResult<Utilisateur>> UpdateLogin(Guid id, [FromBody] ActiveRequest request)
        {
            var query = await _context.logins.FirstOrDefaultAsync(x => x.utilisateurId == id);
            query.state = request.state;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Find(Guid id)
        {
            var result = await _context.logins.FirstOrDefaultAsync(x => x.utilisateurId == id);
            return Ok(result);
        }
    }
}
