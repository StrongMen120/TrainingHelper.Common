namespace Training.Common.Hexagon.Core.Repositories;

/// <summary>
/// Describes repository that can search domain models.
/// </summary>
/// <typeparam name="TSearchModel"> Search model type. </typeparam>
/// <typeparam name="TDomainModel"> Domain model type. </typeparam>
public interface ISearchRepository<in TSearchModel, TDomainModel>
{
    /// <summary>
    /// Searches for domain models matching given criteria.
    /// </summary>
    /// <param name="searchModel"> Searche model instance. </param>
    /// <returns> Domain models found. </returns>
    Task<IEnumerable<TDomainModel>> SearchAsync(TSearchModel searchModel);

    /// <summary>
    /// Searches for domain models matching given criteria.
    /// </summary>
    /// <param name="searchModel"> Searche model instance. </param>
    /// <returns> Domain models found. </returns>
    IEnumerable<TDomainModel> Search(TSearchModel searchModel) => SearchAsync(searchModel).Result;
}