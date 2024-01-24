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
        private readonly IMapper _mapper;
        private UserUtils _validation;

        public UserService(IUserRepository repository, IMapper mapper, UserUtils validation)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }

        public async Task<ExceptionManager<ICollection<UserDTO>>> FindAll() => ExceptionManager.Ok(_mapper.Map<ICollection<UserDTO>>(await _repository.FindAll()));

        public async Task<ExceptionManager<UserDTO>> FindById(int id) => id <= 0 ? ExceptionManager.NotAcceptable<UserDTO>("Id deve ser positivo") :
            (await _repository.FindById(id)) == null ? ExceptionManager.NotFound<UserDTO>("Usuário não encontrado") :
             ExceptionManager.Ok<UserDTO>(_mapper.Map<UserDTO>(await _repository.FindById(id)));

        public async Task<ExceptionManager<UserDTO>> Create(UserCreateDTO user) =>
            _validation.ValidateAndFindExistingUser(user) ? await _validation.ReturnMessageError(user) :
                          ExceptionManager.Created<UserDTO>(_mapper.Map<UserDTO>(await _repository.Create(_mapper.Map<User>(user))));

        public async Task<ExceptionManager<UserDTO>> Update(UserDTO user) =>
            await _repository.FindById((int)user.Id) == null ? ExceptionManager.NotFound<UserDTO>("Usuário não encontrado") :
            ExceptionManager.Ok<UserDTO>(_mapper.Map<UserDTO>(await _repository.Update(_mapper.Map<User>(user))));

        public async Task<ExceptionManager> Delete(int id) =>
            await _repository.FindById(id) == null ? ExceptionManager.NotFound<UserDTO>("Usuário não encontrado") :
            ExceptionManager.Ok(await _repository.Delete(id));
    }
}
