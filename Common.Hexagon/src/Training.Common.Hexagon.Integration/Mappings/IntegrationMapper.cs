using Mapster;
using MapsterMapper;

namespace Training.Common.Hexagon.Integration;

public class IntegrationMapper : Mapper, IIntegrationMapper
{
    public IntegrationMapper(TypeAdapterConfig config)
        : base(config)
    { }
}
