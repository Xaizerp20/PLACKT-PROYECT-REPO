namespace manageRegistersApp.Services
{
    public interface IEventService
    {
        event Action<string> NewEvent;

        void NotifyEvent(string msg);
    }
}