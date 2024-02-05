using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.DTOS.UserDTO;
using Service.Exceptions;
using Service.Interfaces;
using Service.Utils;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private UserUtils _utils;

        public UserService(IUserRepository repository, IAccountRepository accountRepository, IMapper mapper, UserUtils validation)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _utils = validation ?? throw new ArgumentNullException(nameof(validation));
        }

        public async Task<ExceptionManager<ICollection<UserDTO>>> FindAll() => ExceptionManager.Ok(_mapper.Map<ICollection<UserDTO>>(await _repository.FindAll()));

        public async Task<ExceptionManager<UserDTO>> FindById(int id) => id <= 0 ? ExceptionManager.NotAcceptable<UserDTO>("Id deve ser positivo") :
            (await _repository.FindById(id)) == null ? ExceptionManager.NotFound<UserDTO>("Usuário não encontrado") :
             ExceptionManager.Ok<UserDTO>(_mapper.Map<UserDTO>(await _repository.FindById(id)));

        public async Task<ExceptionManager<UserDTO>> Create(UserCreateDTO user)
        {
           // VALIDANDO DTO
           var isTrue = _utils.ValidateAndFindExistingUser(user);
           if (isTrue) return await _utils.ReturnMessageError(user);

           // TRANSFORMANDO EM ENTIDADE
           var userEntity = _mapper.Map<User>(user);

           //SALVANDO NO BANCO
           await _repository.Create(userEntity);

            // CRIANDO CONTA AUTOMÁTICA
            var account = new Account()
            {
                Number = _utils.GenerateNumberAccount(),
                CreateAccount = DateTime.UtcNow,
                UpdateAccount = DateTime.UtcNow,
                Type = 0 ,
                User = userEntity,
                Spends = new List<Spend>()
            };
            await _accountRepository.Create(account);

            //ADICIONANDO AO USUARIO
            userEntity.Account.Add(account);

           return ExceptionManager.Ok<UserDTO>(_mapper.Map<UserDTO>(userEntity));
        }
           
                          

        public async Task<ExceptionManager<UserDTO>> Update(UserDTO user) =>
            await _repository.FindById((int)user.Id) == null ? ExceptionManager.NotFound<UserDTO>("Usuário não encontrado") :
            ExceptionManager.Ok<UserDTO>(_mapper.Map<UserDTO>(await _repository.Update(_mapper.Map<User>(user))));

        public async Task<ExceptionManager> Delete(int id) =>
            await _repository.FindById(id) == null ? ExceptionManager.NotFound<UserDTO>("Usuário não encontrado") :
            ExceptionManager.Ok(await _repository.Delete(id));
    }

}
