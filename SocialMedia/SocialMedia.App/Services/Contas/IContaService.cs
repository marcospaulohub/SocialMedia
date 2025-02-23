using SocialMedia.App.Models;
using SocialMedia.App.Models.Contas;

namespace SocialMedia.App.Services.Contas
{
    public interface IContaService
    {
        ResultViewModel<int> Insert(CreateContaInputModel model);
        ResultViewModel Update(int id, UpdateContaInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<ContaViewModel?> GetById(int id);
        ResultViewModel<ContaViewModel?> GetByEmail(string email);
        ResultViewModel MudarSenha(string email, UpdateSenhaContaInputModel model);
        ResultViewModel Login(string email, string senha);
    }
}
