# MethodSignature

It's a tiny library to construct signature from MethodInfo for .NET.

# Examples

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using MethodSignature;

namespace Example
{
    class Example
    {
        public static double Method1(int arg0, string arg1, bool? arg2)
        {
            return 0;
        }

        public static void Method2(int arg0 = 2, string arg1 = "test")
        {
        }

        public static void Method3(ref int arg0, out int arg1, params object[] args)
        {
            arg1 = arg0;
        }

        public static (int, string) Method4((int, string) arg)
        {
            return arg;
        }

        public static void Method5(Dictionary<int, List<string>> arg)
        {
        }

        public static ref readonly int Method6(int[] arg)
        {
            return ref arg[0];
        }

        public static async Task<string> Method7(string path)
        {
            using (var sr = new StreamReader(path))
                return await sr.ReadToEndAsync();
        }

        public static unsafe void Method8(byte* arg)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(Example).GetMethods();
            foreach (MethodInfo method in methods)
            {
                if (!method.Name.StartsWith("Method"))
                    continue;

                string signature = SignatureHelper.FromMethod(method);
                Console.WriteLine("{0}: {1}", method.Name, signature);
            }
        }
    }
}

// Output:
// Method1: double Method1(int arg0, string arg1, bool? arg2)
// Method2: void Method2(int arg0 = 2, string arg1 = "test")
// Method3: void Method3(ref int arg0, out int arg1, params object[] args)
// Method4: (int, string) Method4((int, string) arg)
// Method5: void Method5(Dictionary<int, List<string>> arg)
// Method6: ref readonly int Method6(int[] arg)
// Method7: async Task<string> Method7(string path)
// Method8: unsafe void Method8(byte* arg)
```

```c#
using System;
using System.Reflection;
using MethodSignature;

namespace Example
{
    class ExampleType
    {

    }

    class Example<T>
    {
        public class NestedType
        {
        }

        public static void Method1()
        {
        }

        public static void Method2(Type arg0, ExampleType arg1)
        {
        }

        public static void Method3(NestedType arg)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo method;
            string signature;

            method = typeof(Example<int>).GetMethod("Method1");
            signature = SignatureHelper.FromMethod(method,
                new SignatureOption { WithAccessModifier = true, WithStatic = true });
            Console.WriteLine("{0}: {1}", method.Name, signature);

            method = typeof(Example<int>).GetMethod("Method2");
            signature = SignatureHelper.FromMethod(method,
                new SignatureOption { WithSystemNamespace = true});
            Console.WriteLine("{0}: {1}", method.Name, signature);

            method = typeof(Example<int>).GetMethod("Method2");
            signature = SignatureHelper.FromMethod(method,
                new SignatureOption { WithNonSystemNamespace = true });
            Console.WriteLine("{0}: {1}", method.Name, signature);

            method = typeof(Example<int>).GetMethod("Method3");
            signature = SignatureHelper.FromMethod(method);
            Console.WriteLine("{0}: {1}", method.Name, signature);

            method = typeof(Example<int>).GetMethod("Method3");
            signature = SignatureHelper.FromMethod(method,
                new SignatureOption { WithDeclaringType = true });
            Console.WriteLine("{0}: {1}", method.Name, signature);
        }
    }
}

// Output:
// Method1: public static void Method1()
// Method2: void Method2(System.Type arg0, ExampleType arg1)
// Method2: void Method2(Type arg0, Example.ExampleType arg1)
// Method3: void Method3(NestedType arg)
// Method3: void Method3(Example<int>.NestedType arg)
```

