using Domain.Entities;

public interface IGithubRepository : IAsyncRepository<Github>, IRepository<Github>
{
    //tamamen brand'e özel operasyonlarımız olursa buraya yazacağız.

}

