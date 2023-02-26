using AutoMapper;
using StudentWebApi.Models;
using StudentWebApi.TokenOperations;
using StudentWebApi.TokenOperations.Models;

namespace StudentWebApi.Application.UserOperations.Commands.CreateTokenCommand
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(StudentDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        // An Handler to create new token
        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
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
                throw new InvalidOperationException("Kullanıcı adı - şifre hatalı.");
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
