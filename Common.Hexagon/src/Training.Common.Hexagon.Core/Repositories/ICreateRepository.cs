namespace Training.Common.Hexagon.Core.Repositories;

/// <summary>
/// Describes repository that can create domain models.
/// </summary>
/// <typeparam name="TCreationModel"> Creation model type. </typeparam>
/// <typeparam name="TDomainModel"> Domain model type. </typeparam>
public interface ICreateRepository<in TCreationModel, TDomainModel>
{
    /// <summary>
    /// Creates domain model.
    /// </summary>
    /// <param name="creationModel"> Creation model instance. </param>
    /// <returns> Created model. </returns>
    Task<TDomainModel> CreateAsync(TCreationModel creationModel);

    /// <summary>
    /// Creates domain model.
    /// </summary>
    /// <param name="creationModel"> Creation model instance. </param>
    /// <returns> Created model. </returns>
    TDomainModel Create(TCreationModel creationModel) => CreateAsync(creationModel).Result;
}

/// <inheritdoc/>
public interface ICreateRepository<TModel> : ICreateRepository<TModel, TModel>
{ }