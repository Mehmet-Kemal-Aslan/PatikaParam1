using AutoMapper;
using StudentWebApi.Models;
using StudentWebApi.TokenOperations;
using StudentWebApi.TokenOperations.Models;

namespace StudentWebApi.Application.UserOperations.Commands.RefreshTokenCommand
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(StudentDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // An Handler to create new token
        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user != null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Geçerli Refresh Token bulunamadı.");
        }
    }
}
