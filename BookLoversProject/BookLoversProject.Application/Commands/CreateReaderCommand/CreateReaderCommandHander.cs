using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateReaderCommand
{
    internal class CreateReaderCommandHander : IRequestHandler<CreateReaderCommand, int>
    {
        private readonly IReaderRepository _readerRepository;

        public CreateReaderCommandHander(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;   
        }

        public Task<int> Handle(CreateReaderCommand request, CancellationToken cancellationToken)
        {
            var reader = new Reader
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath
            };
            _readerRepository.AddReader(reader);
            return Task.FromResult(reader.Id);
        }
    }
}
