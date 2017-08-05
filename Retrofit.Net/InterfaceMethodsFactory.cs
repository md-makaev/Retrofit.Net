using System;
using System.Collections.Concurrent;

namespace Retrofit.Net
{
    class InterfaceMethodsFactory
    {
        private static readonly ConcurrentDictionary<Type, InterfaceMethods> Cache =
            new ConcurrentDictionary<Type, InterfaceMethods>();

        public static InterfaceMethods Create<T>()
        {
            return Cache.GetOrAdd(typeof(T), t => new InterfaceMethods(t));
        }
    }
}