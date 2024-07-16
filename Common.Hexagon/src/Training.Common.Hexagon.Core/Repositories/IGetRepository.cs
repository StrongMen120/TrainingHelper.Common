using Training.Common.Hexagon.Core.Exceptions;

namespace Training.Common.Hexagon.Core.Repositories;

/// <summary>
/// Describes repository that can resolve domain model by its identifier.
/// </summary>
/// <typeparam name="TGetModel"> Domain model identifier type. </typeparam>
/// <typeparam name="TDomainModel"> Domain model type. </typeparam>
public interface IGetRepository<in TGetModel, TDomainModel>
{
    /// <summary>
    /// Gets domain model with matching given get model. Throws if not found in domain.
    /// </summary>
    /// <exception cref="NotFoundException"> If not found in domain. </exception>
    /// <param name="getModel"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    Task<TDomainModel> GetAsync(TGetModel getModel);

    /// <summary>
    /// Gets domain model with matching given get model. Throws if not found in domain.
    /// </summary>
    /// <exception cref="NotFoundException"> If not found in domain. </exception>
    /// <param name="getModel"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    TDomainModel Get(TGetModel getModel) => GetAsync(getModel).Result;

    /// <summary>
    /// Gets domain model with matching given get model or null if not found in domain.
    /// </summary>
    /// <param name="getModel"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    Task<TDomainModel?> FindAsync(TGetModel getModel);

    /// <summary>
    /// Gets domain model with matching given get model or null if not found in domain.
    /// </summary>
    /// <param name="getModel"> Domain model identifier. </param>
    /// <returns> Read model. </returns>
    TDomainModel? Find(TGetModel getModel) => FindAsync(getModel).Result;
}
