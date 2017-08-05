using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Retrofit.Net
{
    class InterfaceMethods
    {
        private readonly Dictionary<MethodInfo, RestMethodInfo> methods;

        public InterfaceMethods(Type t)
        {
            var smethods = t.GetMethods();
            methods = //t.GetMethods(BindingFlags.Instance)
                smethods.ToDictionary(m => m, m => new RestMethodInfo(m));
        }

        public RestMethodInfo Get(MethodInfo mi)
        {
            return methods[mi];
        }
    }
}