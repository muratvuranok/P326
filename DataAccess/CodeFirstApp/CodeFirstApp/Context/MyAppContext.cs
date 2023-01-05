namespace CodeFirstApp.Context;
public class MyAppContext : DbContext
{
    public virtual DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=.;database=OzumuzDb;uid=sa;pwd=Pro247!!;Trust Server Certificate=true"); 
        // NOT : Bu benim conenction string'im lütfen kendi conenctionString'inizi yazınız :)
    }
}
