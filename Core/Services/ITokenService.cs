using Core.Models.Dto;
using Core.Models.Entities;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(AppUser user);
    }
}