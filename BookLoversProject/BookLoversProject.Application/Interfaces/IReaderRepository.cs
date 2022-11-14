using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IReaderRepository
    {
        Reader AddReader(Reader reader);

        Reader GetReaderById(int id);

        List<Reader> GetAllReaders();

        void DeleteReader(Reader reader);

        void AddShelfToReader(Shelf shelf, Reader reader);

        void DeleteShelfFromReader(Shelf shelf, Reader reader);
    }
}
