namespace KT.Common;

public class MultipleTasks<T>
{
    public T Owner { get; }

    private readonly Type _ownerType;
    private readonly MultipleTasks _tasks;

    public MultipleTasks(T owner)
    {
        Owner = owner;

        _ownerType = typeof(T);
        _tasks = new MultipleTasks();
    }

    public void Add(string mappingPropName, Task execute) => _tasks.Add(execute, async val =>
    {
        var prop = _ownerType.GetProperty(mappingPropName);
        prop?.SetValue(Owner, val);
        await Task.CompletedTask;
    });

    public void Add(Task execute, Func<object, Task> done = null) => _tasks.Add(execute, done);

    public async Task WhenAll(bool clearTasks = true) => await _tasks.WhenAll(clearTasks);

    public bool HasTasks => _tasks.HasTasks;
}

public class MultipleTasks
{
    private readonly List<(string Key, Task Execute, Func<object, Task> Done)> _tasks = new();

    public bool HasTasks => _tasks.Count > 0;

    public void Add(Task execute, Func<object, Task> done = null, string key = null) => _tasks.Add((key ?? Guid.NewGuid().ToString("N"), execute, done));

    public void AddRange(params (string Key, Task Execute, Func<object, Task> Done)[] tasks) => _tasks.AddRange(tasks);

    public async Task WhenAll(bool clearTasks = true)
    {
        if (_tasks.Count == 0)
        {
            return;
        }

        await Task.WhenAll(_tasks.Select(processItemAsync));

        if (clearTasks)
        {
            _tasks.Clear();
        }

        async Task processItemAsync((string Key, Task Execute, Func<object, Task> Done) item)
        {
            await item.Execute;
            if (item.Done != null)
            {
                var value = item.Execute.Value();
                await item.Done(value);
            }
        }
    }

    public async Task<(string Key, object Value)[]> WhenAllValues()
    {
        if (_tasks.Count == 0)
        {
            return null;
        }

        await Task.WhenAll(_tasks.Select(a => a.Execute));

        return _tasks.Select(item => (item.Key, item.Execute.Value())).ToArray();
    }
}

public static class MultipleTasksExtension
{
    public static object Value(this Task task) => task.IsCompleted ? task.GetType().GetProperty("Result")?.GetValue(task) : null;
}
