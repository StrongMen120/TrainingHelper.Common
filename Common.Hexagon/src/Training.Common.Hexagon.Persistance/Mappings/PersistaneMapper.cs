using Mapster;
using MapsterMapper;

namespace Training.Common.Hexagon.Persistance;

public class PersistanceMapper : Mapper, IPersistanceMapper
{
    public PersistanceMapper(TypeAdapterConfig config)
        : base(config)
    { }
}
