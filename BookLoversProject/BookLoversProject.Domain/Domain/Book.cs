namespace BookLoversProject.Domain.Domain
{
    public class Book : Entity, ICloneable
    {
  
        public string Title { get; set; }

        public string Description { get; set; }

        public List<IAuthor> AuthorList { get; set; }

        public List<User> ReviewList { get; }

        public List<Genre> GenreList { get; set; }

        public object Clone()
        {
            Book clone = new Book
            {
                Id = Id,
                Title = Title,
                Description = Description,
                AuthorList = AuthorList,
                GenreList = GenreList
            };
            return clone;
        }
    }
}
