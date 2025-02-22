using System.Linq;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Repositories;

namespace SocialMedia.Infra.Persistence.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly SocialMediaDbContext _context;

        public ContaRepository(SocialMediaDbContext context)
        {
            _context = context;
        }

        public int Insert(Conta conta)
        {
            _context.Contas.Add(conta);
            _context.SaveChanges();

            return conta.Id;
        }
        public void Update(Conta conta)
        {
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }
        public Conta? GetById(int id)
        {
            var conta = _context.Contas.SingleOrDefault(c => c.Id == id && c.DeletedAt == null);

            return conta;
        }
        public Conta? GetByEmail(string email)
        {
            var conta = _context.Contas.SingleOrDefault(c => c.Email == email && c.DeletedAt == null);

            return conta;
        }
        public void Delete(Conta conta)
        {
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }
    }
}
