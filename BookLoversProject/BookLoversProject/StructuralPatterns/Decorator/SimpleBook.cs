namespace BookLoversProject.Presentation.StructuralPatterns.Decorator
{
    public class SimpleBook : IBook
    {
        public string Title { get; set; }

        public string GetDescription()
        {
            return "book";
        }
    }
}
