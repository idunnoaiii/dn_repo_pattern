using Repository.Domain;

namespace Repository.EfCore;

public interface IProjectRepository : IGenericRepository<Project> {
    
}

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationContext context) : base(context)
    {
    }
}
