namespace EnumGeneratorLibrary
{
    public static class MathExtensions 
    {
        public static short Max (this short sender, short other) => sender > other ? sender : other;
        public static int Max (this int sender, int other) => sender > other ? sender : other;
        public static long Max (this long sender, long other) => sender > other ? sender : other;
        public static ushort Max (this ushort sender, ushort other) => sender > other ? sender : other;
        public static uint Max (this uint sender, uint other) => sender > other ? sender : other;
        public static ulong Max (this ulong sender, ulong other) => sender > other ? sender : other;
    }
}