using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace MethodSignature.Tests
{
    class GenricUnitTest
    {
        private static readonly BindingFlags bindingFlags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGeneric1()
        {
            MethodInfo method = typeof(TestGenericData1<>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData1<T>.NestedTestType arg)", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric2()
        {
            MethodInfo method = typeof(TestGenericData1<int>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData1<int>.NestedTestType arg)", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric3()
        {
            MethodInfo method = typeof(TestGenericData2<,>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData2<T, U>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric4()
        {
            MethodInfo method = typeof(TestGenericData2<bool, string>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData2<bool, string>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric5()
        {
            MethodInfo method = typeof(TestGenericData3<>.TestGenericData4).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData3<T>.TestGenericData4.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric6()
        {
            MethodInfo method = typeof(TestGenericData3<bool>.TestGenericData4).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData3<bool>.TestGenericData4.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric7()
        {
            MethodInfo method = typeof(TestGenericData4<>.TestGenericData5<>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData4<T>.TestGenericData5<U>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric8()
        {
            MethodInfo method = typeof(TestGenericData4<int>.TestGenericData5<float>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData4<int>.TestGenericData5<float>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric9()
        {
            MethodInfo method = typeof(TestGenericData5.TestGenericData6<>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData5.TestGenericData6<U>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric10()
        {
            MethodInfo method = typeof(TestGenericData5.TestGenericData6<byte>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData5.TestGenericData6<byte>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric11()
        {
            MethodInfo method = typeof(TestGenericData6.TestGenericData7<,>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData6.TestGenericData7<T, U>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric12()
        {
            MethodInfo method = typeof(TestGenericData6.TestGenericData7<char, string>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData6.TestGenericData7<char, string>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric13()
        {
            MethodInfo method = typeof(TestGenericData5.TestGenericData6<TestGenericData.NestedTestType>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData5.TestGenericData6<TestGenericData.NestedTestType>.NestedTestType arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric14()
        {
            MethodInfo method = typeof(TestGenericData1<int>).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(NestedTestType arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGeneric15()
        {
            MethodInfo method = typeof(TestGenericData7<int>.TestGenericData8).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestGenericData7<int>.TestGenericData8.NestedTestType<bool> arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestGeneric16()
        {
            MethodInfo method = typeof(TestGenericData7<int>.TestGenericData8).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(NestedTestType<bool> arg)",
                SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestGeneric17()
        {
            MethodInfo method = typeof(TestGenericData7<int>.TestGenericData8).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(MethodSignature.Tests.TestGenericData7<int>.TestGenericData8.NestedTestType<bool> arg)",
                SignatureHelper.FromMethod(method, new SignatureOption { WithNonSystemNamespace = true }));
        }
    }
}
