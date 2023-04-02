using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public class UserService : IUserService
{
    private readonly AppContext _appContext;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContexAccessor;

    public UserService(AppContext appContext, IConfiguration configuration, IHttpContextAccessor httpContexAccessor)
    {
        _appContext = appContext;
        _configuration = configuration;
        _httpContexAccessor = httpContexAccessor;
    }

    public async Task<string> Login(UserDto userDto)
    {
        var user = await _appContext.Users.FirstOrDefaultAsync(x => x.Email == userDto.email && x.HashedPassword == userDto.hashed_password);
        if (user == null)
        {
            return "";
        }

        var token = CreateToken(user);

        return token;

    }

    public async Task<string> Register(UserDto userDto)
    {
        var userExists = await _appContext.Users.FirstOrDefaultAsync(x => x.Email == userDto.email);
        if (userExists != null)
        {
            return "User exists";
        }

        var user = new User()
        {
            Email = userDto.email,
            HashedPassword = userDto.hashed_password
        };

        await _appContext.Users.AddAsync(user);
        await _appContext.SaveChangesAsync();

        var token = CreateToken(user);

        return token;
    }

    public async Task GetMe()
    {
        var result = string.Empty;
        if (_httpContexAccessor.HttpContext != null)
        {
            result = _httpContexAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        Console.WriteLine(result);
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

        var apiToken = _configuration.GetSection("AppSettings:Token").Value;

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(apiToken));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}