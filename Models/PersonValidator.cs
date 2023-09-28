using FluentValidation;

namespace CustomerApi.Models;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("name canot be blank");
        RuleFor(x => x.Discount).Must(BeAValidA).When(x => x.Type == "A").WithMessage("Cat A Error");
        RuleFor(x => x.Discount).Must(BeAValidB).When(x => x.Type == "B").WithMessage("Cat B Error");
    }

    private bool BeAValidA(decimal discount)
    {
        if ((discount > 0 && discount < 10))
        {
            return true;
        }
        
        return false;
    }

    private bool BeAValidB(decimal discount)
    {
        if ((discount > 10 && discount < 20))
        {
            return true;
        }

        return false;
    }
}