using SocialMedia.App.Models;
using SocialMedia.App.Models.Contas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Messages.ContaMessages;
using SocialMedia.Core.Repositories;

namespace SocialMedia.App.Services.Contas
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public ResultViewModel<int> Insert(CreateContaInputModel model)
        {
            var conta = new Conta(
                model.NomeCompleto,
                model.Senha,
                model.Email,
                model.Telefone,
                model.DataNascimento
                );

            _contaRepository.Insert(conta);

            return ResultViewModel<int>.Success(conta.Id);
        }
        public ResultViewModel Update(int id, UpdateContaInputModel model)
        {
            var conta = _contaRepository.GetById(id);

            if(conta is null)
            {
                return ResultViewModel.Error(ContaMsgs.GetContaNotExist());
            }

            conta.Update(model.NomeCompleto, model.DataNascimento);

            conta.SetAsUpdated();

            _contaRepository.Update(conta);

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var conta = _contaRepository.GetById(id);

            if (conta is null)
            {
                return ResultViewModel.Error(ContaMsgs.GetContaNotExist());
            }

            conta.SetAsDeleted();

            _contaRepository.Delete(conta);

            return ResultViewModel.Success();
        }
        public ResultViewModel<ContaViewModel?> GetById(int id)
        {
            var conta = _contaRepository.GetById(id);

            return conta is null ?
                ResultViewModel<ContaViewModel?>.Error(ContaMsgs.GetContaNotExist()) :
                ResultViewModel<ContaViewModel?>.Success(ContaViewModel.FromEntity(conta));
        }
        public ResultViewModel<ContaViewModel?> GetByEmail(string email)
        {
            var conta = _contaRepository.GetByEmail(email);

            return conta is null ?
                ResultViewModel<ContaViewModel?>.Error(ContaMsgs.GetContaNotExist()) :
                ResultViewModel<ContaViewModel?>.Success(ContaViewModel.FromEntity(conta));

        }
        public ResultViewModel MudarSenha(string email, UpdateSenhaContaInputModel model)
        {
            var conta = _contaRepository.GetByEmail(email);

            if (conta is null)
            {
                return ResultViewModel.Error(ContaMsgs.GetContaNotExist());
            }

            if (conta.Senha != model.SenhaAtual)
            {
                return ResultViewModel.Error(ContaMsgs.GetSenhaInvalid());
            }

            conta.MudarSenha(model.NovaSenha);

            _contaRepository.Update(conta);

            return ResultViewModel.Success();
        }
        public ResultViewModel Login(string email, string senha)
        {
            var conta = _contaRepository.GetByEmail(email);

            if (conta is null)
            {
                return ResultViewModel.Error(ContaMsgs.GetContaNotExist());
            }

            if (conta.Senha != senha)
            {
                return ResultViewModel.Error(ContaMsgs.GetSenhaInvalid());
            }

            return ResultViewModel.Success();
        }
    }
}
