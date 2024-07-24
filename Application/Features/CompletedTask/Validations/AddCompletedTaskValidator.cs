using FluentValidation;

namespace Application.Features
{
	public class AddCompletedTaskValidator : AbstractValidator<AddCompletedTaskCommand>
	{
        public AddCompletedTaskValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.TaskId).NotEmpty();
        }
    }
}
