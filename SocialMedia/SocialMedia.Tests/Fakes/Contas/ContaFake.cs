using Bogus;
using SocialMedia.Core.Entities;
using System;

namespace SocialMedia.Tests.Fakes.Contas
{
    public class ContaFake : Faker<Conta>
    {
        public ContaFake()
        {
            CustomInstantiator(faker =>
            new Conta(
                faker.Name.FullName(),
                faker.Internet.Password(10),
                faker.Internet.Email(),
                faker.Phone.PhoneNumber(),
                DateTime.Now.AddYears(-20)
                )
            );
        }
    }
}
