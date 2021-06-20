namespace MethodSignature
{
    public class SignatureOption
    {
        public bool WithAccessModifier { get; set; }
        public bool WithStatic { get; set; }
        public bool WithSystemNamespace { get; set; }
        public bool WithNonSystemNamespace { get; set; }
        public bool WithDeclaringType { get; set; }
    }
}
