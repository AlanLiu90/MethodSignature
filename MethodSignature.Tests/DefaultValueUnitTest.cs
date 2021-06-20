using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace MethodSignature.Tests
{
    public class DefaultValueUnitTest
    {
        private static readonly BindingFlags bindingFlags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestBoolArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("TestBoolArg", bindingFlags);
            Assert.AreEqual("void TestBoolArg(bool arg = true)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestIntArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("TestIntArg", bindingFlags);
            Assert.AreEqual("void TestIntArg(int arg = -3)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestFloatArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("TestFloatArg", bindingFlags);
            Assert.AreEqual("void TestFloatArg(float arg = 6.5f)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestCharArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("TestCharArg", bindingFlags);
            Assert.AreEqual("void TestCharArg(char arg = 'a')", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestStringArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("TestStringArg", bindingFlags);
            Assert.AreEqual("void TestStringArg(string arg = \"test\")", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestObjectArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("TestObjectArg", bindingFlags);
            Assert.AreEqual("void TestObjectArg(object arg = null)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void FuncEnumArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("FuncEnumArg", bindingFlags);
            Assert.AreEqual("void FuncEnumArg(TestEnum arg = TestEnum.Two)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void FuncGenericArg()
        {
            MethodInfo method = typeof(TestDefaultValueData).GetMethod("FuncGenericArg", bindingFlags);
            Assert.AreEqual("void FuncGenericArg<T>(T arg = default)", SignatureHelper.FromMethod(method));
        }
    }
}
