using System;

namespace SDKPacketIO
{
    /// <summary>
    /// Exception thrown when a read operation exceeds the buffer's length.
    /// </summary>
    public class PacketIOException : Exception
    {
        public PacketIOException(string message) : base(message) { }
    }
}
