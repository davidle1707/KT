using System.Collections;
using IMapper = KT.Utils.Interfaces.IMapper;

namespace KT.Utils.Mapper;

public class AutoMapperImp : IMapper
{
    public TDest Map<TDest>(object source, Action<TDest> after = null)
    {
        Validate();

        if (source == null)
        {
            return default;
        }

        var dest = MapHelper.AutoMapper.Map<TDest>(source);
        after?.Invoke(dest);

        return dest;
    }

    public TDest Map<TSource, TDest>(TSource source, Action<TDest> after = null)
    {
        Validate();

        if (source == null)
        {
            return default;
        }

        var dest = MapHelper.AutoMapper.Map<TSource, TDest>(source);
        after?.Invoke(dest);

        return dest;
    }

    public IEnumerable<TDest> MapEnumerable<TDest>(IEnumerable sources, Action<IEnumerable<TDest>> after = null)
    {
        Validate();

        if (sources == null)
        {
            return null;
        }

        var dests = MapHelper.AutoMapper.Map<IEnumerable<TDest>>(sources);
        after?.Invoke(dests);

        return dests;
    }

    public List<TDest> MapList<TDest>(IList sources, Action<List<TDest>> after = null)
    {
        Validate();

        if (sources == null)
        {
            return null;
        }

        var dests = MapHelper.AutoMapper.Map<IList, List<TDest>>(sources);
        after?.Invoke(dests);

        return dests;
    }

    private void Validate()
    {
        if (MapHelper.AutoMapper == null)
        {
            throw new NotImplementedException("AutoMapper is not yet register");
        }
    }
}
