using MapsterMapper;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Training.Common.Strategy;

public abstract class StrategyBase
{
    protected StrategyBase(ILogger logger, IMapper mapper)
    {
        this.Logger = logger;
        this.Mapper = mapper;
    }

    protected ILogger Logger { get; }
    protected IMapper Mapper { get; }
}