namespace KT.Utils.Mapper;

public static class MapHelper
{
    internal static AutoMapper.Mapper AutoMapper;

    public static void RegisterAutoMapper(Action<IMapperConfigurationExpression> configure)
    {
        AutoMapper = new AutoMapper.Mapper(new MapperConfiguration(configure));
    }
}
