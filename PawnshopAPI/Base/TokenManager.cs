using Entities;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static System.Net.WebRequestMethods;

namespace HomeAPI.DI
{
  public class TokenManager
  {
    private const string _tokenSecret = "ReallySecretKeyToEncryptzaq1@WSX";

    public static string GenerateToken(UserVm user)
    {
      if (user != null)
      {
        var claims = new List<Claim>
        {
          new("Username", user.Username == null ? "unrecognized" : user.Username),
          new("Id", user.UserId.ToString()),
          new("LastLogin", user.LastLogin == null ? "" : user.LastLogin.ToString()),
          new(ClaimTypes.Role, "User"),
        };

        var creds = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSecret)), SecurityAlgorithms.HmacSha256
                    );

        var token = new JwtSecurityToken(
          issuer: "https://localhost:7175/",
          audience: "https://localhost:7175/",
          claims: claims,
          expires: DateTime.Now.AddHours(10),
          signingCredentials: creds
          );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
      }
      else
      {
        throw new Exception("no_user_for_token");
      }
    }
  }
}