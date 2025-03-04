﻿using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Repositories
{
    public interface IContaRepository
    {
        int Insert(Conta conta);
        void Update(Conta conta);
        Conta? GetById(int id);
        Conta? GetByEmail(string email);
        void Delete(Conta conta);
    }
}
