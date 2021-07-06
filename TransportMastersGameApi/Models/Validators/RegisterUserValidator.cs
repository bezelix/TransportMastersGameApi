using TransportMastersGameApi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi.Models.Validators
{
    //klasa odpowiadająca za walidację danych zamiast [atrybutów] w modelACH DANYCH     
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(TransportMastersGameDbContext dbContext) //wstrzykuje dbcontext aby uzyskać dostęp do bazy danych 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            
            //METODA custom pozwala na napisanie własnej walidacji dla pola 
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is teken");
                }
            });

        }
    }
}
