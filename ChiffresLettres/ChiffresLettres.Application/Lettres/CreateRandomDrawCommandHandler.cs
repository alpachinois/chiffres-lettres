using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ChiffresLettres.Application.Lettres
{
    public class CreateRandomDrawCommandHandler : IRequestHandler<CreateRandomDrawCommand, char[]>
    {
        private static readonly Random Random = new();
        private const string Pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Task<char[]> Handle(CreateRandomDrawCommand request, CancellationToken cancellationToken)
        {
            var chars = Enumerable.Range(0, 9)
                .Select(x => Pool[Random.Next(0, Pool.Length)]).ToArray();
            return Task.FromResult(chars);
        }
    }
}
