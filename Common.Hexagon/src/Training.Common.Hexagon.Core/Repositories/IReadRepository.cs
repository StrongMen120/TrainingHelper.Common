using Training.Common.Hexagon.Core.Exceptions;

namespace Training.Common.Hexagon.Core.Repositories;

/// <summary>
/// Describes repository that can resolve domain model by its identifier.
/// </summary>
/// <typeparam name="TDomainModelId"> Domain model identifier type. </typeparam>
/// <typeparam name="TDomainModel"> Domain model type. </typeparam>
public interface IReadRepository<in TDomainModelId, TDomainModel>
{
    /// <summary>
    /// Gets domain model with given id. Throws if not found in domain.
    /// </summary>
    /// <exception cref="NotFoundException"> If not found in domain. </exception>
    /// <param name="id"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    Task<TDomainModel> GetByIdAsync(TDomainModelId id);

    /// <summary>
    /// Gets domain model with given id. Throws if not found in domain.
    /// </summary>
    /// <exception cref="NotFoundException"> If not found in domain. </exception>
    /// <param name="id"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    TDomainModel GetById(TDomainModelId id) => GetByIdAsync(id).Result;

    /// <summary>
    /// Gets domain model with given id or null if not found in domain.
    /// </summary>
    /// <param name="id"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    Task<TDomainModel?> FindByIdAsync(TDomainModelId id);

    /// <summary>
    /// Gets domain model with given id or null if not found in domain.
    /// </summary>
    /// <param name="id"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    TDomainModel? FindById(TDomainModelId id) => FindByIdAsync(id).Result;
}