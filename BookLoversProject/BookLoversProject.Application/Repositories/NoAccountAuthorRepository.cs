using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Repositories
{
    public class NoAccountAuthorRepository : INoAccountAuthorRepository
    {
        private List<NoAccountAuthor> authors;

        public NoAccountAuthorRepository(List<NoAccountAuthor> authors)
        {
            this.authors = authors;
        }

        public NoAccountAuthor AddNoAccountAuthor(NoAccountAuthor noAccountAuthor)
        {
            authors.Add(noAccountAuthor);
            return noAccountAuthor;
        }

        public void AddFollowerToAuthor(User follower, NoAccountAuthor noAccountAuthor)
        {
            noAccountAuthor.Followers.Add(follower);
        }

        public void DeleteNoAccountAuthor(NoAccountAuthor noAccountAuthor)
        {
            authors.Remove(noAccountAuthor);
        }

        public void DeleteFollowerFromAuthor(User follower, NoAccountAuthor noAccountAuthor)
        {
            if (!noAccountAuthor.Followers.Remove(follower))
            {
                throw new Exception("Follower not found!");
            }
        }

        public NoAccountAuthor GetNoAccountAuthorById(int id)
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public List<NoAccountAuthor> GetAllNoAccountAuthors()
        {
            return authors;
        }
    }
}
