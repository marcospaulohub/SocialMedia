using System;
using Bogus;
using SocialMedia.App.Models.Contas;

namespace SocialMedia.Tests.Fakes.Contas
{
    public class CreateContaInputModelFake : Faker<CreateContaInputModel>
    {
        public CreateContaInputModelFake()
        {
            CustomInstantiator(faker =>
            new CreateContaInputModel(
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
