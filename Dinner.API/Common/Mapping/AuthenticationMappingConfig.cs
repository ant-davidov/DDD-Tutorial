using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;
using static BuberDinner.Domain.Common.Errors.Errors;

namespace DDD_Tutorial.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();   
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                 .Map(dest => dest.Id, src => src.User.Id.Value)
                 .Map(dest => dest, src => src.User);
           
        }
    }
}
