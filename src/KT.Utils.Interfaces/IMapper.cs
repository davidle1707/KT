using System.Collections;

namespace KT.Utils.Interfaces;

public interface IMapper
{
    TDest Map<TDest>(object source, Action<TDest> after = null);

    TDest Map<TSource, TDest>(TSource source, Action<TDest> after = null);

    List<TDest> MapList<TDest>(IList sources, Action<List<TDest>> after = null);

    IEnumerable<TDest> MapEnumerable<TDest>(IEnumerable sources, Action<IEnumerable<TDest>> after = null);
}
