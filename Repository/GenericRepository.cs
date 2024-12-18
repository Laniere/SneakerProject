namespace SneakerServer.Repository
{
  public class GenericRepository<T> where T : class
  {
    internal SneakerContext context = null!;
    internal DbSet<T> dbSet = null!;

    public GenericRepository(SneakerContext context)
    {
      this.context = context;
      this.dbSet = context.Set<T>();
    }

    public virtual T? GetById(int id)
    {
      return dbSet.Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
      return [.. dbSet];
    }
  }
}

