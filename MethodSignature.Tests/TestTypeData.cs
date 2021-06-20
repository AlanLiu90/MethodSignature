using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MethodSignature.Tests
{
    enum TestEnum
    {
        One,
        Two,
    }

    delegate void ClickHandler(int x, int y);

    class TestTypeData
    {
        public static void TestNoArg()
        {

        }

        public static void TestBoolArg(bool arg)
        {

        }

        public static void TestByteArg(byte arg)
        {

        }

        public static void TestSByteArg(sbyte arg)
        {

        }

        public static void TestCharArg(char arg)
        {

        }

        public static void TestShortArg(short arg)
        {

        }

        public static void TestUShortArg(ushort arg)
        {

        }

        public static void TestIntArg(int arg)
        {

        }

        public static void TestUIntArg(uint arg)
        {

        }

        public static void TestLongArg(long arg)
        {

        }
        public static void TestULongArg(ulong arg)
        {

        }

        public static void TestFloatArg(float arg)
        {

        }

        public static void TestDoubleArg(double arg)
        {

        }

        public static void TestDecimalArg(decimal arg)
        {

        }

        public static void TestStringArg(string arg)
        {

        }

        public static void TestObjectArg(object arg)
        {

        }

        public static float? TestNullable(int? arg0)
        {
            return null;
        }

        public static void TestGenericArg(List<int> arg)
        {

        }

        public static void TestGenericArgWithMultiArgs(Dictionary<int, string> arg)
        {

        }

        public static Dictionary<int, List<string>> TestNestedGenericArg(Dictionary<int, List<string>> arg)
        {
            return arg;
        }

        public static void TestGeneric<T>(T arg)
        {

        }

        public static void TestGenericNullable<T>(T? arg) where T : struct
        {

        }

        public static Task TestTaskReturn()
        {
            return Task.CompletedTask;
        }

        public static Task<int> TestGenericTaskReturn()
        {
            return Task.FromResult(0);
        }

        public static void TestArray(byte[] arg)
        {

        }

        public static void Test2dArray(int[][] arg)
        {

        }

        public static IEnumerator TestIEnumerator(int[] arg)
        {
            foreach (int v in arg)
                yield return v;
        }

        public static IEnumerator<int> TestIEnumeratorInt(int[] arg)
        {
            foreach (int v in arg)
                yield return v;
        }

        public static void TestParams(string format, params object[] args)
        {

        }

        public static void TestEnum(TestEnum arg)
        {

        }

        public static void TestGenericTypeArray(List<int>[] arg)
        {

        }

        public static void TestAction(Action arg)
        {

        }

        public static void TestActionString(Action<string> arg)
        {

        }

        public static void TestFunc(Func<double> arg)
        {

        }

        public static void TestFuncStringBool(Func<string, bool> arg)
        {

        }

        public static void TestDelegate(ClickHandler arg)
        {

        }

        public static unsafe void TestPointer(byte* arg)
        {

        }
    }
}
