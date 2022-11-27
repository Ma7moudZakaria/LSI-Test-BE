using MediatR;

namespace LSIDomain.Features.CQRS.Commands
{
    public class DatabaseEnsureCreatedCommand : IRequest<bool>
    {
    }
}
