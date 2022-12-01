using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserAuthorRepository
    {
        UserAuthor AddUserAuthor(UserAuthor userAuthor);

        ICollection<UserAuthor> GetAllUserAuthors();

        ICollection<UserAuthor> GetUserAuthorsByUserId(int userId);

        ICollection<UserAuthor> GetUserAuthorsByAuthorId(int authorId);

        void DeleteUserAuthor(UserAuthor userAuthor);
    }
}