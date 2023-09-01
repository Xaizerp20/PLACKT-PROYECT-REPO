namespace manageRegistersApp.Services
{
    public class EventService: IEventService
    {
        public event Action<string> NewEvent;

        public void NotifyEvent(string msg)
        {
            NewEvent?.Invoke(msg);
        }
    }
}
