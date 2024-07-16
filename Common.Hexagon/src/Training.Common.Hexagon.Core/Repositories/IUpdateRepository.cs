namespace Training.Common.Hexagon.Core.Repositories;

/// <summary>
/// Describes repository that can update domain models.
/// </summary>
/// <typeparam name="TUpdateModel"> Update model type. </typeparam>
/// <typeparam name="TDomainModel"> Domain model type. </typeparam>
public interface IUpdateRepository<in TUpdateModel, TDomainModel>
{
    /// <summary>
    /// Updates domain model.
    /// </summary>
    /// <param name="updateModel"> Creation model instance. </param>
    /// <returns> Domain model. </returns>
    Task<TDomainModel> UpdateAsync(TUpdateModel updateModel);

    /// <summary>
    /// Updates domain model.
    /// </summary>
    /// <param name="updateModel"> Creation model instance. </param>
    /// <returns> Domain model. </returns>
    TDomainModel Update(TUpdateModel updateModel) => UpdateAsync(updateModel).Result;
}

/// <inheritdoc/>
public interface IUpdateRepository<TModel> : IUpdateRepository<TModel, TModel>
{ }