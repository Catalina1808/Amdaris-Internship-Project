namespace BookLoversProject.Domain.Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        // public List<IAuthor> AuthorList { get; set; }
        // public List<Review> ReviewList { get; }
        // public List<Genre> GenreList { get; set; }
    }
}
