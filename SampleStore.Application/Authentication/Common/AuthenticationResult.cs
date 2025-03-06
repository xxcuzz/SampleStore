using SampleStore.Application.Models.DTO;

namespace SampleStore.Application.Authentication.Common;

public record AuthenticationResult(UserDto UserDto, string Token);