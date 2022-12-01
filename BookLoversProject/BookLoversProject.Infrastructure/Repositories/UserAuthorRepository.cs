using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class UserAuthorRepository : IUserAuthorRepository
    {
        private readonly ICollection<UserAuthor> _userAuthors;

        public UserAuthorRepository(ICollection<UserAuthor> userAuthors)
        {
            _userAuthors = userAuthors;
        }

        public UserAuthor AddUserAuthor(UserAuthor userAuthor)
        {
            _userAuthors.Add(userAuthor);
            return userAuthor;
        }

        public void DeleteUserAuthor(UserAuthor userAuthor)
        {
            if(!_userAuthors.Remove(userAuthor))
            {
                throw new Exception("The object could not be deleted!");
            }
        }

        public ICollection<UserAuthor> GetAllUserAuthors()
        {
            return _userAuthors;
        }

        public ICollection<UserAuthor> GetUserAuthorsByAuthorId(int authorId)
        {
            var userAuthors = _userAuthors.Where(x => x.AuthorId == authorId).ToList();
            if(userAuthors.Count() > 0)
            {
                return userAuthors;
            }
            throw new Exception("There are no objects with with the given Id");
        }

        public ICollection<UserAuthor> GetUserAuthorsByUserId(int userId)
        {

            var userAuthors = _userAuthors.Where(x => x.UserId == userId).ToList();
            if (userAuthors.Count() > 0)
            {
                return userAuthors;
            }
            throw new Exception("There are no objects with with the given Id");
        }
    }
}
