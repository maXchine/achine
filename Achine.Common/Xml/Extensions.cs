using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Achine.Common.Xml {

    public static class Extensions {

        public static XmlDocument ToXml(this Stream stream)
        {

            CopyToStream(stream, out stream);
            var xml = new XmlDocument();
            xml.Load(stream);
            return xml;

        }

        public static void CopyToStream(this Stream fromStream, out Stream toStream)
        {
            toStream = fromStream.CopyToStream();
        }

        public static Stream CopyToStream(this Stream stream) {

            var memoryStream = new MemoryStream();

            if (stream.CanSeek)
                stream.CopyTo(memoryStream);
            else {
                var oneByte = stream.ReadByte();
                while (oneByte != -1) {
                    memoryStream.WriteByte((byte) oneByte);
                    oneByte = stream.ReadByte();
                }
            }
            return memoryStream;

        }

        public static byte[] GetBytes(this Stream stream) {

            if (stream.CanSeek)
            {
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }

            var bytes = new List<byte>();
            var b = stream.ReadByte();
            while (b != -1) {
                bytes.Add((byte) b);
                b = stream.ReadByte();
            }
            return bytes.ToArray();
        }


    }

}
