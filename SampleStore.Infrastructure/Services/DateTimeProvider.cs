using SampleStore.Application.Common.Interfaces.Services;

namespace SampleStore.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}