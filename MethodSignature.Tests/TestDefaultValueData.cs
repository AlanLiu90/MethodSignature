using System;
using System.Collections.Generic;
using System.Text;

namespace MethodSignature.Tests
{
    class TestDefaultValueData
    {
        public static void TestBoolArgTrue(bool arg = true)
        {

        }

        public static void TestBoolArgFalse(bool arg = false)
        {

        }

        public static void TestIntArg(int arg = -3)
        {

        }

        public static void TestFloatArg(float arg = 6.5f)
        {

        }

        public static void TestDoubleArg(double arg = -2.4)
        {

        }

        public static void TestCharArg(char arg = 'a')
        {

        }

        public static void TestStringArg(string arg = "test")
        {

        }

        public static void TestObjectArg(object arg = null)
        {

        }

        public static void FuncEnumArg(TestEnum arg = TestEnum.Two)
        {

        }

        public static void FuncGenericArg<T>(T arg = default)
        {

        }
    }
}
