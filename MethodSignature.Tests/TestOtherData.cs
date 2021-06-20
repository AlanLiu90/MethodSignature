using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MethodSignature.Tests
{
#pragma warning disable 0649
    class TestType
    {
        public string Name;
    }
#pragma warning restore 0649

    class TestOtherData
    {
#pragma warning disable 0649
        public class NestedTestType
        {
            public string Name;
        }
#pragma warning restore 0649

        public static void TestRefArg(ref int arg)
        {

        }

        public static void TestInArg(in double arg)
        {

        }

        public static void TestOutArg(out bool arg)
        {
            arg = true;
        }

        public static async Task<string> TestAsync(string path)
        {
            using var sw = new StreamReader(path);
            string content = await sw.ReadToEndAsync();
            return content;
        }

        public static void TestPublicStatic()
        {

        }

        internal static void TestInternalStatic()
        {

        }

        private static void TestPrivateStatic()
        {

        }

        public void TestPublicInstance()
        {

        }

        internal void TestInternalInstance()
        {

        }

        private void TestPrivateInstance()
        {

        }

        public static ref int TestRefReturn(int[] arg)
        {
            return ref arg[0];
        }

        public static ref readonly int TestRefReadOnlyReturn(int[] arg)
        {
            return ref arg[0];
        }

        public static void TestUserDefinedType(TestType arg)
        {

        }

        public static void TestUserDefinedNestedType(NestedTestType arg)
        {

        }

        public static void TestSystemNamespace(List<int> arg)
        {

        }

        public static void TestMultipleArgs(int arg0, float arg1, string arg2)
        {

        }

        public static void TestValueTupleArg((int, string) arg)
        {

        }

        public static (int, string) TestValueTupleReturn()
        {
            return (0, "test");
        }
    }
}
