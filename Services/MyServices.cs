namespace First.Services
{
    public class MyServices :IMyService
    {
        public List<string> Names { get; set; }
        public void AddName(string name)
        {
            Names.Add(name);    
        }

        public MyServices()
        {
            AddName("Steve");
            AddName("Ivy");
            AddName("Igor");
        }

    }



    public interface IMyService
    {
        List<string> Names { get; set; }
        void AddName(string name);
    }
}
