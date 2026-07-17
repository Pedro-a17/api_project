namespace PokeShop.Application.Interfaces
{
    public interface ITokenService
    {
      string jwtTokenGenerator(string userId);
    }
}



