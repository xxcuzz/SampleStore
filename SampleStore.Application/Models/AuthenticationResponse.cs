using SampleStore.Application.Models.DTO;

namespace SampleStore.Application.Models;

public record AuthenticationResponse(UserDto UserDto, string Token);