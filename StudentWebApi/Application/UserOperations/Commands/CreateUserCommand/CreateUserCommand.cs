using AutoMapper;
using StudentWebApi.Models;

namespace StudentWebApi.Application.UserOperations.Commands.CreateUserCommand
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateUserCommand(StudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // An Handler to create new user
        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user != null)
                throw new InvalidOperationException("Aynı kullanıcı ikinci kez kaydedilemez!");
            user = _mapper.Map<User>(Model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
