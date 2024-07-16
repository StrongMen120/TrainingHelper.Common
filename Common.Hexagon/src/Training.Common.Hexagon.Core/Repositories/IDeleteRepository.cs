namespace Training.Common.Hexagon.Core.Repositories;

/// <summary>
/// Describes repository that can delete domain models.
/// </summary>
/// <typeparam name="TDomainModelId"> Domain model identifier type. </typeparam>
/// <typeparam name="TDomainModel"> Domain model type. </typeparam>
public interface IDeleteRepository<in TDomainModelId, TDomainModel>
{
    /// <summary>
    /// Deletes domain model with given id.
    /// </summary>
    /// <param name="id"> Domain model identifier. </param>
    /// <returns> Deleted model. </returns>
    Task<TDomainModel> DeleteByIdAsync(TDomainModelId id);

    /// <summary>
    /// Deletes domain model with given id.
    /// </summary>
    /// <param name="id"> Domain model identifier. </param>
    /// <returns> Deleted model. </returns>
    TDomainModel DeleteById(TDomainModelId id) => DeleteByIdAsync(id).Result;

    /// <summary>
    /// Deletes given domain model.
    /// </summary>
    /// <param name="model"> Domain model. </param>
    /// <returns> Deleted model. </returns>
    Task<TDomainModel> DeleteAsync(TDomainModel model);

    /// <summary>
    /// Deletes given domain model.
    /// </summary>
    /// <param name="model"> Domain model. </param>
    /// <returns> Deleted model. </returns>
    TDomainModel Delete(TDomainModel model) => DeleteAsync(model).Result;
}
