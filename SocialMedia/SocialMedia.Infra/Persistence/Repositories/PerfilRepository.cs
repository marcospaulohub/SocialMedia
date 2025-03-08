using SocialMedia.Core.Entities;
using SocialMedia.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Infra.Persistence.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly SocialMediaDbContext _context;

        public PerfilRepository(SocialMediaDbContext context)
        {
            _context = context;
        }

        public int Insert(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            _context.SaveChanges();

            return perfil.Id;
        }
        public void Update(Perfil perfil)
        {
            _context.Perfis.Update(perfil);
            _context.SaveChanges();
        }
        public Perfil? GetById(int id)
        {
            var perfil = _context.Perfis.SingleOrDefault(p => p.Id == id && p.DeletedAt == null);

            return perfil;
        }
        public List<Perfil>? GetAll(int idConta)
        {
            var listPerfil = _context
                .Perfis
                .Where(p => p.Id == idConta)
                .ToList();
            
            return listPerfil;
        }
        public void Delete(Perfil perfil)
        {
            _context.Perfis.Update(perfil);
            _context.SaveChanges();
        }
    }
}
