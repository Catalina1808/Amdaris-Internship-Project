namespace ObserverPattern
{
    public interface IFollower<T>
    {
        void Notify(T item);
    }
}
