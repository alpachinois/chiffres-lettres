using System.Threading;
using System.Threading.Tasks;
using ChiffresLettres.Domain.Lettres;
using MediatR;

namespace ChiffresLettres.Application.Lettres
{
    public class CreateRandomDrawCommandHandler : IRequestHandler<CreateRandomDrawCommand, char[]>
    {
        private readonly IWordsService _wordsService;

        public CreateRandomDrawCommandHandler(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        public Task<char[]> Handle(CreateRandomDrawCommand request, CancellationToken cancellationToken)
        {
            var chars = _wordsService.CreateRandomDraw(request.VowelsNumber);
            return Task.FromResult(chars);
        }
    }
}
