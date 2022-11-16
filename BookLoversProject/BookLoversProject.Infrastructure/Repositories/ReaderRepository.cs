using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private List<Reader> readers;

        public ReaderRepository(List<Reader> readers)
        {
            this.readers = readers;
        }

        public Reader AddReader(Reader reader)
        {
            readers.Add(reader);
            return reader;
        }

        public void AddShelfToReader(Shelf shelf, Reader reader)
        {
            reader.BookShelves.Add(shelf);
        }

        public void DeleteReader(Reader reader)
        {
            if (!readers.Remove(reader))
            {
                throw new Exception("Exception occured, reader not found!");
            }
        }

        public void DeleteShelfFromReader(Shelf shelf, Reader reader)
        {
            if (!reader.BookShelves.Remove(shelf))
            {
                throw new ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public List<Reader> GetAllReaders()
        {
            return readers;
        }

        public Reader GetReaderById(int id)
        {
            var reader = readers.FirstOrDefault(x => x.Id == id);
            if (reader == null)
            {
                throw new Exception("Exception occured, reader not found!");
            }
            return reader;
        }
    }
}
