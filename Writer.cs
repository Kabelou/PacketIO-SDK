using System;
using System.Collections.Generic;
using System.Text;

namespace SDKPacketIO
{
    /// <summary>
    /// Provides methods to sequentially write typed values to a byte buffer in BigEndian format.
    /// </summary>
    public class Writer
    {
        private readonly List<byte> _buffer = new List<byte>();

        public void SetShort(short value)
        {
            byte[] temp = new byte[2];
            EndianUtils.WriteInt16(temp, 0, value);
            _buffer.AddRange(temp);
        }

        public void SetUShort(ushort value)
        {
            byte[] temp = new byte[2];
            EndianUtils.WriteUInt16(temp, 0, value);
            _buffer.AddRange(temp);
        }

        public void SetInt(int value)
        {
            byte[] temp = new byte[4];
            EndianUtils.WriteInt32(temp, 0, value);
            _buffer.AddRange(temp);
        }

        public void SetLong(long value)
        {
            byte[] temp = new byte[8];
            EndianUtils.WriteInt64(temp, 0, value);
            _buffer.AddRange(temp);
        }

        public void SetBool(bool value)
        {
            _buffer.Add((byte)(value ? 1 : 0));
        }

        public void SetString(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            SetInt(bytes.Length);
            _buffer.AddRange(bytes);
        }

        public void SetBytes(byte[] data)
        {
            _buffer.AddRange(data);
        }

        public byte[] GetBytes() => _buffer.ToArray();
    }
}
