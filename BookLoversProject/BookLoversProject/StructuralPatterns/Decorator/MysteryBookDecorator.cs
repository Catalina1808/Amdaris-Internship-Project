namespace BookLoversProject.Presentation.StructuralPatterns.Decorator
{
    public class MysteryBookDecorator : BaseBookDecorator
    {
        public MysteryBookDecorator(IBook book) : base(book)
        {
        }

        public override string GetDescription()
        {
            return "mystery " + _book.GetDescription();
        }
    }
}
