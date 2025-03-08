using SocialMedia.Core.Entities;
using System.Collections.Generic;

namespace SocialMedia.Core.Repositories
{
    public interface IPerfilRepository
    {
        int Insert(Perfil perfil);
        void Update(Perfil perfil);
        Perfil? GetById(int id);
        List<Perfil>? GetAll(int idConta);
        void Delete(Perfil perfil);
    }
}
