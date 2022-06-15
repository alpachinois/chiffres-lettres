using MediatR;

namespace ChiffresLettres.Application.Lettres
{
    public record CreateRandomDrawCommand : IRequest<char[]>;
}
