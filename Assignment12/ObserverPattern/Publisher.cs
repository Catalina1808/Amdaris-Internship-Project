namespace ObserverPattern
{
    public abstract class Publisher<T>
    {
        private List<IFollower<T>> followers;
        public Publisher()
        {
            this.followers = new List<IFollower<T>>();
        }
        public void AddFollower(IFollower<T> subscriber)
        {
            this.followers.Add(subscriber);
        }
        public void Publish(T item)
        {
            this.followers.ForEach(f => f.Notify(item));
        }
    }
}
