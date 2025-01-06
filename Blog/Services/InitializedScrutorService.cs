using Blog.Repositories;

namespace Blog.Services
{
    public class InitializedScrutorService : IInitializedScrutorService
    {
        private readonly IInitializedScrutorRepository _initializedScrutorRepository;
        public InitializedScrutorService(IInitializedScrutorRepository initializedScrutorRepository)
        {
            _initializedScrutorRepository = initializedScrutorRepository;
        }

        public string GetScrutorName()
        {
            return _initializedScrutorRepository.GetScrutorName();
        }
    }
}