using System;
using Bogus;
using SocialMedia.App.Models.Contas;

namespace SocialMedia.Tests.Fakes.Contas
{
    public class UpdateContaInputModelFake : Faker<UpdateContaInputModel>
    {
        public UpdateContaInputModelFake()
        {
            CustomInstantiator(faker =>
            new UpdateContaInputModel(
                faker.Name.FullName(),
                DateTime.Now.AddYears(-20)
                )
            );
        }
    }
}
