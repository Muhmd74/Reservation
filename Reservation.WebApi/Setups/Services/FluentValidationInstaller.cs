//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FluentValidation;
//using FluentValidation.AspNetCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Reservation.WebApi.Setups.Factory.Services;

//namespace Reservation.WebApi.Setups.Services
//{
//    public class FluentValidationInstaller : IServiceSetup
//    {
//        public void InstallServices(IServiceCollection services, IConfiguration configuration)
//        {
//            services.AddMvc(options => options.Filters.Add<ValidatorActionFilter>())
//                .AddFluentValidation(options =>
//                    options.RegisterValidatorsFromAssemblyContaining<AddNewDefinitionRequestValidator>());
//        }

//        public class
//            AddNewDefinitionRequestValidator : AbstractValidator<
//                AddNewDefinitionRequestValidator.AddNewDefinitionRequest>
//        {
//            public AddNewDefinitionRequestValidator()
//            {
//                RuleFor(d => d.Definition)
//                    .NotNull()
//                    .NotEmpty();
//                RuleFor(d => d.Description)
//                    .NotEmpty()
//                    .NotNull();

//            }

//            public class AddNewDefinitionRequest
//            {
//                public string Definition { get; set; }
//                public string Description { get; set; }
//            }
//        }
//    }
//}
