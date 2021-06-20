using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace MethodSignature.Tests
{
    public class OtherUnitTest
    {
        private static readonly BindingFlags bindingFlags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRefArg()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestRefArg", bindingFlags);
            Assert.AreEqual("void TestRefArg(ref int arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestInArg()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestInArg", bindingFlags);
            Assert.AreEqual("void TestInArg(in double arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestOutArg()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestOutArg", bindingFlags);
            Assert.AreEqual("void TestOutArg(out bool arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestAsync()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestAsync", bindingFlags);
            Assert.AreEqual("async Task<string> TestAsync(string path)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestPublicStatic()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestPublicStatic", bindingFlags);
            Assert.AreEqual("public static void TestPublicStatic()", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithAccessModifier = true, WithStatic = true }));
        }

        [Test]
        public void TestInternalStatic()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestInternalStatic", bindingFlags);
            Assert.AreEqual("internal static void TestInternalStatic()", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithAccessModifier = true, WithStatic = true }));
        }

        [Test]
        public void TestPrivateStatic()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestPrivateStatic", bindingFlags);
            Assert.AreEqual("private static void TestPrivateStatic()", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithAccessModifier = true, WithStatic = true }));
        }

        [Test]
        public void TestPublicInstance()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestPublicInstance", bindingFlags);
            Assert.AreEqual("public void TestPublicInstance()", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithAccessModifier = true, WithStatic = true }));
        }

        [Test]
        public void TestInternalInstance()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestInternalInstance", bindingFlags);
            Assert.AreEqual("internal void TestInternalInstance()", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithAccessModifier = true, WithStatic = true }));
        }

        [Test]
        public void TestPrivateInstance()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestPrivateInstance", bindingFlags);
            Assert.AreEqual("private void TestPrivateInstance()", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithAccessModifier = true, WithStatic = true }));
        }

        [Test]
        public void TestRefReturn()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestRefReturn", bindingFlags);
            Assert.AreEqual("ref int TestRefReturn(int[] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestRefReadOnlyReturn()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestRefReadOnlyReturn", bindingFlags);
            Assert.AreEqual("ref readonly int TestRefReadOnlyReturn(int[] arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestUserDefinedType()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestUserDefinedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedType(TestType arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestUserDefinedTypeWithNamespace()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestUserDefinedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedType(MethodSignature.Tests.TestType arg)", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithNonSystemNamespace = true }));
        }

        [Test]
        public void TestUserDefinedNestedType()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(NestedTestType arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestUserDefinedNestedTypeWithDeclaringType()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestUserDefinedNestedType", bindingFlags);
            Assert.AreEqual("void TestUserDefinedNestedType(TestOtherData.NestedTestType arg)", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithDeclaringType = true }));
        }

        [Test]
        public void TestSystemNamespace()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestSystemNamespace", bindingFlags);
            Assert.AreEqual("void TestSystemNamespace(System.Collections.Generic.List<int> arg)", 
                SignatureHelper.FromMethod(method, new SignatureOption { WithSystemNamespace = true }));
        }

        [Test]
        public void TestMultipleArgs()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestMultipleArgs", bindingFlags);
            Assert.AreEqual("void TestMultipleArgs(int arg0, float arg1, string arg2)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestValueTupleArg()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestValueTupleArg", bindingFlags);
            Assert.AreEqual("void TestValueTupleArg((int, string) arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestNamedValueTupleArg()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestNamedValueTupleArg", bindingFlags);
            Assert.AreEqual("void TestNamedValueTupleArg((int id, string name) arg)", SignatureHelper.FromMethod(method));
        }

        [Test]
        public void TestValueTupleReturn()
        {
            MethodInfo method = typeof(TestOtherData).GetMethod("TestValueTupleReturn", bindingFlags);
            Assert.AreEqual("(int, string) TestValueTupleReturn()", SignatureHelper.FromMethod(method));
        }
    }
}
