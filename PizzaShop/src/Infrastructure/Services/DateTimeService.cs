using PizzaShop.Application.Common.Interfaces;

namespace PizzaShop.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
