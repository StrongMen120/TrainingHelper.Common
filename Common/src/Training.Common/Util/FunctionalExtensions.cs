using System;

namespace Training.Common.Util;

public static class FunctionalExtensions
{
    [Obsolete("Changed namespace to `System`")]
    public static T Apply<T>(this T target, System.Action<T> action)
    {
        action?.Invoke(target);
        return target;
    }
    [Obsolete("Changed namespace to `System`")]
    public static TOut Run<TTarget, TOut>(this TTarget target, System.Func<TTarget, TOut> transform)
    {
        string errorMessage = $"Cannot invoke {nameof(Run)} without transform function!";
        if (transform == default) throw new ArgumentNullException(nameof(transform), errorMessage);
        return transform.Invoke(target);
    }
}
