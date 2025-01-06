namespace Blog.Repositories
{
    public class InitializedScrutorRepository : IInitializedScrutorRepository
    {
        public string GetScrutorName()
        {
            return "hi this is from scrutor Repository";
        }
    }
}
