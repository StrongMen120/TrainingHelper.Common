using System;

namespace Training.Common.Utils
{
    public static class FunctionalExtensions
    {
        public static TOut Apply<TIn, TOut>(this TIn input, Func<TIn, TOut> functional) => functional(input);
        public static TIn With<TIn>(this TIn input, Action<TIn> functional)
        {
            functional(input);
            return input;
        }
    }
}