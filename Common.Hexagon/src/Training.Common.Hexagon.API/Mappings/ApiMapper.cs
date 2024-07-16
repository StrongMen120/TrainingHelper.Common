using Mapster;
using MapsterMapper;

namespace Training.Common.Hexagon.API;

public class ApiMapper : Mapper, IApiMapper
{
    public ApiMapper(TypeAdapterConfig config)
        : base(config)
    { }
}
