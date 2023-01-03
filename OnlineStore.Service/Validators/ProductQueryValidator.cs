using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OnlineStore.Repository;

namespace OnlineStore.Service.Validators
{
    public class ProductQueryValidator : AbstractValidator<ProductQuery>
    {
        public ProductQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 50);
        }
    }
}
