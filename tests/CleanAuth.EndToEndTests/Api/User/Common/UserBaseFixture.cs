using CleanAuth.e2eTests.Api.Authentication.Common;
using CleanAuth.e2eTests.Base;
using CleanAuth.e2eTests.Contracts;
using DomainEntity = CleanAuth.Domain.Entities;

namespace CleanAuth.e2eTests.Api.User.Common;

public class UserBaseFixture : BaseFixture<IUserApiClient>
{
    public readonly AuthenticationPersistence Persistence;

    protected UserBaseFixture()
    {
        Persistence = new AuthenticationPersistence(CreateDbContext());
    }

    public string GetValidUserPassword()
    {
        return Faker.Internet.Password(8);
    }

    protected string GetValidUserName()
    {
        var userName = Faker.Person.FullName;
        if (userName.Length > 100)
        {
            userName = userName[..100];
        }

        return userName;
    }

    protected string GetValidUserEmail()
    {
        return Faker.Person.Email;
    }

    public DomainEntity.User GetValidUserFromCommand(string name, string email, string password) =>
        new(name, email, password, GetBCryptPasswordHasher());
}
