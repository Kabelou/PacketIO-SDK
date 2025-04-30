using System;
using System.Text;

namespace SDKPacketIO
{
    /// <summary>
    /// Provides methods to sequentially read typed values from a byte buffer in BigEndian format.
    /// </summary>
    public class Reader
    {
        private readonly byte[] _buffer;
        private int _position;

        public Reader(byte[] buffer)
        {
            _buffer = buffer;
            _position = 0;
        }

        private void EnsureAvailable(int count)
        {
            if (_position + count > _buffer.Length)
                throw new PacketIOException("Not enough data in buffer.");
        }

        /// <summary>Reads a 2-byte signed integer (short).</summary>
        public short GetShort()
        {
            EnsureAvailable(2);
            var val = EndianUtils.ReadInt16(new ReadOnlySpan<byte>(_buffer, _position, 2));
            _position += 2;
            return val;
        }

        /// <summary>Reads a 2-byte unsigned integer (ushort).</summary>
        public ushort GetUShort()
        {
            EnsureAvailable(2);
            var val = EndianUtils.ReadUInt16(new ReadOnlySpan<byte>(_buffer, _position, 2));
            _position += 2;
            return val;
        }

        /// <summary>Reads a 4-byte signed integer (int).</summary>
        public int GetInt()
        {
            EnsureAvailable(4);
            var val = EndianUtils.ReadInt32(new ReadOnlySpan<byte>(_buffer, _position, 4));
            _position += 4;
            return val;
        }

        /// <summary>Reads an 8-byte signed integer (long).</summary>
        public long GetLong()
        {
            EnsureAvailable(8);
            var val = EndianUtils.ReadInt64(new ReadOnlySpan<byte>(_buffer, _position, 8));
            _position += 8;
            return val;
        }

        /// <summary>Reads a boolean value (1 byte).</summary>
        public bool GetBool()
        {
            EnsureAvailable(1);
            return _buffer[_position++] != 0;
        }

        /// <summary>Reads a UTF-8 encoded string prefixed by its length as a 4-byte int.</summary>
        public string GetString()
        {
            int length = GetInt();
            EnsureAvailable(length);
            string result = Encoding.UTF8.GetString(_buffer, _position, length);
            _position += length;
            return result;
        }

        /// <summary>Reads a sequence of bytes of the given length.</summary>
        public byte[] GetBytes(int length)
        {
            EnsureAvailable(length);
            var bytes = new byte[length];
            Array.Copy(_buffer, _position, bytes, 0, length);
            _position += length;
            return bytes;
        }
    }
}
