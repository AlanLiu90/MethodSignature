using System;
using System.Collections.Generic;
using System.Text;

namespace MethodSignature.Tests
{
    class TestGenericData
    {
        public class NestedTestType
        {

        }
    }

    class TestGenericData1<T>
    {
        public class NestedTestType
        {

        }

        public static void TestUserDefinedNestedType(NestedTestType arg)
        {

        }
    }

    class TestGenericData2<T, U>
    {
        public class NestedTestType
        {

        }

        public static void TestUserDefinedNestedType(NestedTestType arg)
        {

        }
    }

    class TestGenericData3<T>
    {
        public class TestGenericData4
        {
            public class NestedTestType
            {

            }

            public static void TestUserDefinedNestedType(NestedTestType arg)
            {

            }
        }
    }

    class TestGenericData4<T>
    {
        public class TestGenericData5<U>
        {
            public class NestedTestType
            {

            }

            public static void TestUserDefinedNestedType(NestedTestType arg)
            {

            }
        }
    }

    class TestGenericData5
    {
        public class TestGenericData6<U>
        {
            public class NestedTestType
            {

            }

            public static void TestUserDefinedNestedType(NestedTestType arg)
            {

            }
        }
    }

    class TestGenericData6
    {
        public class TestGenericData7<T, U>
        {
            public class NestedTestType
            {

            }

            public static void TestUserDefinedNestedType(NestedTestType arg)
            {

            }
        }
    }
}
