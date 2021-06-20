using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace MethodSignature
{
    public static class SignatureHelper
    {
        private static readonly Dictionary<Type, string> keywords = new Dictionary<Type, string>
        {
            [typeof(bool)] = "bool",
            [typeof(byte)] = "byte",
            [typeof(sbyte)] = "sbyte",
            [typeof(char)] = "char",
            [typeof(short)] = "short",
            [typeof(ushort)] = "ushort",
            [typeof(int)] = "int",
            [typeof(uint)] = "uint",
            [typeof(long)] = "long",
            [typeof(ulong)] = "ulong",
            [typeof(float)] = "float",
            [typeof(double)] = "double",
            [typeof(decimal)] = "decimal",
            [typeof(string)] = "string",
            [typeof(object)] = "object",
            [typeof(void)] = "void",
        };

        private static readonly string IsReadOnlyAttribute = "System.Runtime.CompilerServices.IsReadOnlyAttribute";
        private static readonly char GenericTypeCharacter = '`'; 

        private static readonly SignatureOption defaultOption = new SignatureOption();

        private static readonly Lazy<Type> isReadOnlyAttributeType 
            = new Lazy<Type>(() =>
            {
                foreach (var assemblyRef in Assembly.GetEntryAssembly().GetReferencedAssemblies())
                {
                    if (assemblyRef.Name == "System.Runtime")
                    {
                        var assembly = Assembly.Load(assemblyRef);
                        Type type = assembly.GetType(IsReadOnlyAttribute);
                        return type;
                    }
                }

                return null;
            });

        public static string FromMethod(MethodInfo method, SignatureOption option = null)
        {
            option = option ?? defaultOption;

            StringBuilder sb = new StringBuilder();

            WriteAccessModifier(method, option, sb);
            WriteStatic(method, option, sb);
            WriteAsync(method, sb);
            WriteUnsafe(method, sb);
            WriteReturnType(method, option, sb);
            WriteMethodName(method, sb);
            WriteParameters(method, option, sb);

            return sb.ToString();
        }

        private static void WriteAccessModifier(MethodInfo method, SignatureOption option, StringBuilder sb)
        {
            if (option.WithAccessModifier)
            {
                if (method.IsPublic)
                    sb.Append("public ");
                else if (method.IsAssembly)
                    sb.Append("internal ");
                else if (method.IsPrivate)
                    sb.Append("private ");
            }
        }

        private static void WriteStatic(MethodInfo method, SignatureOption option, StringBuilder sb)
        {
            if (option.WithStatic)
            {
                if (method.IsStatic)
                    sb.Append("static ");
            }
        }

        private static void WriteAsync(MethodInfo method, StringBuilder sb)
        {
            if (method.IsDefined(typeof(AsyncStateMachineAttribute)))
                sb.Append("async ");
        }

        private static void WriteUnsafe(MethodInfo method, StringBuilder sb)
        {
            if (method.GetParameters().Where(x => x.ParameterType.IsPointer).Any())
                sb.Append("unsafe ");
        }

        private static void WriteReturnType(MethodInfo method, SignatureOption option, StringBuilder sb)
        {
            Type type = method.ReturnType;
            if (type.IsByRef)
            {
                sb.Append("ref ");
                type = type.GetElementType();

                bool isReadOnly;
                if (isReadOnlyAttributeType.Value != null)
                {
                    isReadOnly = method.ReturnTypeCustomAttributes.IsDefined(isReadOnlyAttributeType.Value, false);
                }
                else
                {
                    object[] attributes = method.ReturnTypeCustomAttributes.GetCustomAttributes(false);
                    isReadOnly = attributes.Where(x => x.GetType().FullName == IsReadOnlyAttribute).Any();
                }

                if (isReadOnly)
                    sb.Append("readonly ");
            }

            WriteType(type, option, sb);

            sb.Append(" ");
        }

        private static void WriteMethodName(MethodInfo method, StringBuilder sb)
        {
            sb.Append(method.Name);

            if (method.IsGenericMethod)
            {
                sb.Append("<");

                Type[] typeArgs = method.GetGenericArguments();
                for (int i = 0; i < typeArgs.Length; ++i)
                {
                    if (i > 0)
                        sb.Append(", ");

                    sb.Append(typeArgs[i].Name);
                }

                sb.Append(">");
            }
        }

        private static void WriteParameters(MethodInfo method, SignatureOption option, StringBuilder sb)
        {
            sb.Append("(");

            var parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; ++i)
            {
                if (i > 0)
                    sb.Append(", ");

                WriteParameter(parameters[i], option, sb);
            }

            sb.Append(")");
        }

        private static void WriteParameter(ParameterInfo p, SignatureOption option, StringBuilder sb)
        {
            Type type = p.ParameterType;

            if (p.IsOut)
            {
                sb.Append("out ");
                type = type.GetElementType();
            }
            else if (p.IsIn)
            {
                sb.Append("in ");
                type = type.GetElementType();
            }
            else if (type.IsByRef)
            {
                sb.Append("ref ");
                type = type.GetElementType();
            }
            else if (p.IsDefined(typeof(ParamArrayAttribute)))
            {
                sb.Append("params ");
            }

            WriteType(type, option, sb);
            sb.AppendFormat(" {0}", p.Name);

            if (p.HasDefaultValue)
            {
                sb.Append(" = ");
                WriteDefaultValue(p.DefaultValue, p.ParameterType.IsGenericParameter, option, sb);
            }
        }

        private static void WriteType(Type type, SignatureOption option, StringBuilder sb)
        {
            if (type.IsGenericParameter)
            {
                sb.Append(type.Name);
                return;
            }

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                WriteType(underlyingType, option, sb);
                sb.Append("?");
                return;
            }

            if (type.IsArray)
            {
                WriteType(type.GetElementType(), option, sb);
                sb.Append("[]");
                return;
            }

            if (type.IsGenericType)
            {
                Type typeDef = type.GetGenericTypeDefinition();
                Type[] typeArgs = type.GetGenericArguments();
                WriteQualifiedTypeName(typeDef, typeArgs, option, sb);
                return;
            }

            if (type.IsPointer)
            {
                WriteType(type.GetElementType(), option, sb);
                sb.Append("*");
                return;
            }

            if (keywords.TryGetValue(type, out var name))
            {
                sb.Append(name);
                return;
            }

            WriteQualifiedTypeName(type, null, option, sb);
        }

        private static void WriteQualifiedTypeName(Type type, Type[] typeArgs, SignatureOption option, StringBuilder sb)
        {
            if (!string.IsNullOrEmpty(type.Namespace))
            {
                if (option.WithSystemNamespace)
                {
                    if (type.Namespace.StartsWith("System"))
                        sb.AppendFormat("{0}.", type.Namespace);
                }
                else if (option.WithNonSystemNamespace)
                {
                    if (!type.Namespace.StartsWith("System"))
                        sb.AppendFormat("{0}.", type.Namespace);
                }
            }

            int typeArgStart = 0;
            
            if (option.WithDeclaringType)
            {
                if (type.IsNested)
                    WriteDeclaringType(type.DeclaringType, typeArgs, ref typeArgStart, option, sb);
            }

            if (typeArgs != null && typeArgStart < typeArgs.Length)
                sb.Append(type.Name.Substring(0, type.Name.LastIndexOf(GenericTypeCharacter)));
            else
                sb.Append(type.Name);

            if (typeArgs != null && typeArgStart < typeArgs.Length)
            {
                sb.Append("<");

                for (int i = 0; i < typeArgs.Length - typeArgStart; ++i)
                {
                    if (i > 0)
                        sb.Append(", ");

                    WriteType(typeArgs[i + typeArgStart], option, sb);
                }

                sb.Append(">");
            }
        }

        private static void WriteDeclaringType(Type type, Type[] typeArgs, ref int typeArgStart, SignatureOption option, StringBuilder sb)
        {
            if (type.IsNested)
                WriteDeclaringType(type.DeclaringType, typeArgs, ref typeArgStart, option, sb);

            if (type.IsGenericType)
            {
                int typeArgCount = type.GetGenericArguments().Length - typeArgStart;

                if (typeArgCount > 0)
                {
                    sb.Append(type.Name.Substring(0, type.Name.LastIndexOf(GenericTypeCharacter)));

                    sb.Append("<");

                    for (int i = 0; i < typeArgCount; ++i)
                    {
                        if (i > 0)
                            sb.Append(", ");

                        WriteType(typeArgs[i + typeArgStart], option, sb);
                    }

                    sb.Append(">");

                    typeArgStart += typeArgCount;
                }
                else
                {
                    sb.Append(type.Name);
                }

                sb.Append(".");
            }
            else
            {
                sb.AppendFormat("{0}.", type.Name);
            }            
        }

        private static void WriteDefaultValue(object value, bool isGenericParameter, SignatureOption option, StringBuilder sb)
        {
            if (value != null)
            {
                Type type = value.GetType();

                if (type == typeof(bool))
                {
                    bool boolValue = (bool)value;
                    sb.Append(boolValue ? "true" : "false");
                    return;
                }
                else if (type == typeof(string))
                {
                    sb.AppendFormat("\"{0}\"", value);
                    return;
                }
                else if (type == typeof(char))
                {
                    sb.AppendFormat("\'{0}\'", value);
                    return;
                }
                else if (type == typeof(float))
                {
                    sb.AppendFormat("{0}f", value);
                }
                else if (type.IsEnum)
                {
                    WriteType(type, option, sb);
                    sb.AppendFormat(".{0}", value);
                }
                else
                {
                    sb.Append(value);
                }
            }
            else
            {
                if (isGenericParameter)
                    sb.Append("default");
                else
                    sb.Append("null");
            }
        }
    }
}
