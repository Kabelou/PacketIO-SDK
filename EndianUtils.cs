using System;
using System.Runtime.CompilerServices;

namespace SDKPacketIO
{
    /// <summary>
    /// Utility class for reading and writing numeric values in BigEndian format.
    /// </summary>
    internal static class EndianUtils
    {
        public static short ReadInt16(ReadOnlySpan<byte> data)
            => (short)((data[0] << 8) | data[1]);

        public static ushort ReadUInt16(ReadOnlySpan<byte> data)
            => (ushort)((data[0] << 8) | data[1]);

        public static int ReadInt32(ReadOnlySpan<byte> data)
            => (data[0] << 24) | (data[1] << 16) | (data[2] << 8) | data[3];

        public static long ReadInt64(ReadOnlySpan<byte> data)
            => ((long)data[0] << 56) | ((long)data[1] << 48) | ((long)data[2] << 40) |
               ((long)data[3] << 32) | ((long)data[4] << 24) | ((long)data[5] << 16) |
               ((long)data[6] << 8) | data[7];

        public static void WriteInt16(byte[] dest, int offset, short value)
        {
            dest[offset] = (byte)(value >> 8);
            dest[offset + 1] = (byte)value;
        }

        public static void WriteUInt16(byte[] dest, int offset, ushort value)
        {
            dest[offset] = (byte)(value >> 8);
            dest[offset + 1] = (byte)value;
        }

        public static void WriteInt32(byte[] dest, int offset, int value)
        {
            dest[offset] = (byte)(value >> 24);
            dest[offset + 1] = (byte)(value >> 16);
            dest[offset + 2] = (byte)(value >> 8);
            dest[offset + 3] = (byte)value;
        }

        public static void WriteInt64(byte[] dest, int offset, long value)
        {
            dest[offset] = (byte)(value >> 56);
            dest[offset + 1] = (byte)(value >> 48);
            dest[offset + 2] = (byte)(value >> 40);
            dest[offset + 3] = (byte)(value >> 32);
            dest[offset + 4] = (byte)(value >> 24);
            dest[offset + 5] = (byte)(value >> 16);
            dest[offset + 6] = (byte)(value >> 8);
            dest[offset + 7] = (byte)value;
        }
    }
}
