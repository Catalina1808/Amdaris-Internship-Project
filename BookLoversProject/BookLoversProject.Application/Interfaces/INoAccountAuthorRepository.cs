using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface INoAccountAuthorRepository
    {
        NoAccountAuthor AddNoAccountAuthor(NoAccountAuthor noAccountAuthor);

        NoAccountAuthor GetNoAccountAuthorById(int id);

        List<NoAccountAuthor> GetAllNoAccountAuthors();

        void DeleteNoAccountAuthor(NoAccountAuthor noAccountAuthor);

        public void AddFollowerToAuthor(User follower, NoAccountAuthor noAccountAuthor);

        public void DeleteFollowerFromAuthor(User follower, NoAccountAuthor noAccountAuthor);
    }
}
