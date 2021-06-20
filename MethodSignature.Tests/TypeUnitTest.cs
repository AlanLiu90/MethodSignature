using System.Reflection;
using NUnit.Framework;

namespace MethodSignature.Tests
{
    public class TypeUnitTests
    {
        private static readonly BindingFlags bindingFlags = 
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestNoArg", bindingFlags);
            Assert.AreEqual("void TestNoArg()", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestBoolArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestBoolArg", bindingFlags);
            Assert.AreEqual("void TestBoolArg(bool arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestByteArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestByteArg", bindingFlags);
            Assert.AreEqual("void TestByteArg(byte arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestSByteArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestSByteArg", bindingFlags);
            Assert.AreEqual("void TestSByteArg(sbyte arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestCharArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestCharArg", bindingFlags);
            Assert.AreEqual("void TestCharArg(char arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestShortArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestShortArg", bindingFlags);
            Assert.AreEqual("void TestShortArg(short arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestUShortArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestUShortArg", bindingFlags);
            Assert.AreEqual("void TestUShortArg(ushort arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestIntArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestIntArg", bindingFlags);
            Assert.AreEqual("void TestIntArg(int arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestUIntArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestUIntArg", bindingFlags);
            Assert.AreEqual("void TestUIntArg(uint arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestLongArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestLongArg", bindingFlags);
            Assert.AreEqual("void TestLongArg(long arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestULongArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestULongArg", bindingFlags);
            Assert.AreEqual("void TestULongArg(ulong arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestFloatArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestFloatArg", bindingFlags);
            Assert.AreEqual("void TestFloatArg(float arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestDoubleArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestDoubleArg", bindingFlags);
            Assert.AreEqual("void TestDoubleArg(double arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestDecimalArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestDecimalArg", bindingFlags);
            Assert.AreEqual("void TestDecimalArg(decimal arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestStringArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestStringArg", bindingFlags);
            Assert.AreEqual("void TestStringArg(string arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestObjectArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestObjectArg", bindingFlags);
            Assert.AreEqual("void TestObjectArg(object arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestNullable()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestNullable", bindingFlags);
            Assert.AreEqual("float? TestNullable(int? arg0)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGenericArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestGenericArg", bindingFlags);
            Assert.AreEqual("void TestGenericArg(List<int> arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGenericArgWithMultiArgs()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestGenericArgWithMultiArgs", bindingFlags);
            Assert.AreEqual("void TestGenericArgWithMultiArgs(Dictionary<int, string> arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestNestedGenericArg()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestNestedGenericArg", bindingFlags);
            Assert.AreEqual("Dictionary<int, List<string>> TestNestedGenericArg(Dictionary<int, List<string>> arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGeneric()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestGeneric", bindingFlags);
            Assert.AreEqual("void TestGeneric<T>(T arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGenericNullable()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestGenericNullable", bindingFlags);
            Assert.AreEqual("void TestGenericNullable<T>(T? arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestTaskReturn()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestTaskReturn", bindingFlags);
            Assert.AreEqual("Task TestTaskReturn()", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGenericTaskReturn()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestGenericTaskReturn", bindingFlags);
            Assert.AreEqual("Task<int> TestGenericTaskReturn()", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestArray()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestArray", bindingFlags);
            Assert.AreEqual("void TestArray(byte[] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void Test2dArray()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("Test2dArray", bindingFlags);
            Assert.AreEqual("void Test2dArray(int[][] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestIEnumerator()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestIEnumerator", bindingFlags);
            Assert.AreEqual("IEnumerator TestIEnumerator(int[] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestIEnumeratorInt()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestIEnumeratorInt", bindingFlags);
            Assert.AreEqual("IEnumerator<int> TestIEnumeratorInt(int[] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestParams()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestParams", bindingFlags);
            Assert.AreEqual("void TestParams(string format, params object[] args)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestEnum()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestEnum", bindingFlags);
            Assert.AreEqual("void TestEnum(TestEnum arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGenericTypeArray()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestGenericTypeArray", bindingFlags);
            Assert.AreEqual("void TestGenericTypeArray(List<int>[] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestAction()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestAction", bindingFlags);
            Assert.AreEqual("void TestAction(Action arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestActionString()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestActionString", bindingFlags);
            Assert.AreEqual("void TestActionString(Action<string> arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestFunc()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestFunc", bindingFlags);
            Assert.AreEqual("void TestFunc(Func<double> arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestFuncStringBool()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestFuncStringBool", bindingFlags);
            Assert.AreEqual("void TestFuncStringBool(Func<string, bool> arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestDelegate()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestDelegate", bindingFlags);
            Assert.AreEqual("void TestDelegate(ClickHandler arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestPointer()
        {
            MethodInfo method = typeof(TestTypeData).GetMethod("TestPointer", bindingFlags);
            Assert.AreEqual("unsafe void TestPointer(byte* arg)", SignatureHelper.FromMethod(method));
        }
    }
}