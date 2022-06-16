using MediatR;

namespace ChiffresLettres.Application.Lettres
{
    public record CreateRandomDrawCommand(int VowelsNumber) : IRequest<char[]>;
}
