using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.DTOs;

namespace TaskTrackerSE.Infrastructure.Validators
{
    public class TaskItemValidator : AbstractValidator<TaskItemDto>
    {
        public TaskItemValidator()
        {
            RuleFor(taskItem => taskItem.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(taskItem => taskItem.Description)
                .Length(10, 500)
                .WithMessage("La longitud del la descripcion debe estar entre 10 y 500 caracteres");

            RuleFor(taskItem => taskItem.Date)
                .NotNull()
                .LessThan(DateTime.Now)
                .WithMessage("La fecha no puede ser nula");

        }
    }
}
