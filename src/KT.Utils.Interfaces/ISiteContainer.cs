using System.Reflection;

namespace KT.Utils.Interfaces;

public interface ISiteContainer
{
    T Resolve<T>(bool throwIfNotFound = true) where T : class;

    object Resolve(Type type, bool throwIfNotFound = true);

    T ResolveByKeyed<T>(object keyed, bool defaultIfNotFound = true) where T : class;
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class RegisterDIAttribute : Attribute
{
    public readonly RegisterDIScope Scope;

    public RegisterDIInterface Interface { get; set; } = RegisterDIInterface.First;

    public RegisterDIAttribute(RegisterDIScope scope) => Scope = scope;

    public static IEnumerable<(Type Type, RegisterDIAttribute Attribute)> GetRegisters(Assembly assembly)
    {
        return assembly.GetTypes()
            .Select(type => (Type: type, Attribute: type.GetCustomAttribute<RegisterDIAttribute>()))
            .Where(a => a.Attribute != null);
    }
}

public enum RegisterDIScope
{
    Instance,

    PerRequest,

    Singleton
}

public enum RegisterDIInterface
{
    /// <summary>
    /// first interface of class
    /// </summary>
    First,

    /// <summary>
    /// each interface(s) of class will register instance
    /// </summary>
    PerInstance,
}