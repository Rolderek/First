namespace First.Services
{
    public class StateService
    {
        private List<string> messages = new List<string>();
        public event Action OnChange;
        public IEnumerable<string> GetMessage() => messages;
        public void AddMessage(string message)
        {
            messages.Add(message);
            NotifyStateChanged();
        }

        //változott, ideje frissíteni
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
