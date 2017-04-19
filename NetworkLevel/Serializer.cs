using NetworkLevel.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NetworkLevel
{
    public class Serializer
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        public byte[] Serialize(Message message)
        {
            using (var memory = new MemoryStream())
            {
                binaryFormatter.Serialize(memory, message);
                return memory.ToArray();
            }
        }

        public Message Deserialize(byte[] data)
        {
            using (var memory = new MemoryStream(data))
            {
                var message = (Message)binaryFormatter.Deserialize(memory);
                return message;
            }
        }
    }
}
