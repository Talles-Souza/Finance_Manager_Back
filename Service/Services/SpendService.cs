using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.DTOS.SpendDTO;
using Service.Exceptions;
using Service.Interfaces;
using System.Security.Principal;

namespace Service.Services
{
    public class SpendService : ISpendService
    {
        private readonly IMapper _mapper;
        private readonly ISpendRepository _repository;
        private readonly IAccountRepository _accountRepository;

        public SpendService(IMapper mapper, ISpendRepository repository, IAccountRepository accountRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<ExceptionManager<ICollection<SpendDTO>>> FindAll() => ExceptionManager.Ok(_mapper.Map<ICollection<SpendDTO>>( await _repository.FindAll()));


        public async Task<ExceptionManager<SpendDTO>> FindById(int id) => id <= 0 ? ExceptionManager.NotAcceptable<SpendDTO>("Id deve ser positivo")
                                                                                      : (await _repository.FindById(id)) == null ? ExceptionManager.NotFound<SpendDTO>("Gasto não encontrado") :
                                                                                         ExceptionManager.Ok<SpendDTO>(_mapper.Map<SpendDTO>(await _repository.FindById(id)));


        public async Task<ExceptionManager<SpendDTO>> Update(SpendDTO spend)
        {
            if (spend.Id == null) return ExceptionManager.BadRequest<SpendDTO>("Id deve ser positivo");
            var verify = await _repository.FindById((int)spend.Id);
            if (verify == null) return ExceptionManager.NotFound<SpendDTO>("Gasto não encontrado");
            var account = await _accountRepository.FindById(spend.AccountID);
            if(account == null) return ExceptionManager.NotFound<SpendDTO>("Conta não encontrado");
            var entitySpend = _mapper.Map<Spend>(spend);
            entitySpend.Account = account;
            return ExceptionManager.Ok<SpendDTO>(_mapper.Map<SpendDTO>(await _repository.Update(entitySpend)));

        }

        public async Task<ExceptionManager<SpendDTO>> Create(SpendDTO spend)
        {
            var account =  await _accountRepository.FindById(spend.AccountID);
            if (account == null) return ExceptionManager.NotFound<SpendDTO>("Conta não encontrado");
            var entitySpend = _mapper.Map<Spend>(spend);
            account.Spends.Add(entitySpend);
            await _accountRepository.Update(account);
            return ExceptionManager.Ok(_mapper.Map<SpendDTO>(entitySpend));

        }
        public async Task<ExceptionManager> Delete(int id) => id <= 0 ? ExceptionManager.NotAcceptable<SpendDTO>("Id deve ser positivo")
                                                                                      : (await _repository.FindById(id)) == null ? ExceptionManager.NotFound<SpendDTO>("Gasto não encontrado") :
                                                                                       ExceptionManager.Ok(await _repository.Delete(id));
    }
}
