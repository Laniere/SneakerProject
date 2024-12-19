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

    //Get could be used like that. Find is MUCH better for performance porpuses
    public virtual T? GetById(int id)
    {
      return dbSet.Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
      return [.. dbSet];
    }

    public virtual IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
      IQueryable<T> query = dbSet;
      if (filter != null)
      {
        query = query.Where(filter);
      }
      if (orderBy != null)
      {
        orderBy(query);
      }
      return [.. query];
    }

    public virtual void Insert(T entity)
    {
      dbSet.Add(entity);
    }

    public virtual void Update(T entity)
    {
      dbSet.Attach(entity);
      context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Delete(int id)
    {
      T? entityToDelete = dbSet.Find(id);
      if (entityToDelete != null)
      {
        Delete(entityToDelete);
      }
    }

    public virtual void Delete(T entity)
    {
      if (context.Entry(entity).State == EntityState.Detached)
      {
        dbSet.Attach(entity);
      }
      dbSet.Remove(entity);
    }
  }
}
// RAW SQL
// public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
// {
//   return dbSet.SqlQuery(query, parameters).ToList();
// }