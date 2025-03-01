﻿using System.Buffers;
using SharpRtmp.Networking.Rtmp.Serialization;

namespace SharpRtmp.Networking.Rtmp.Data;

public abstract class Message
{
    protected readonly ArrayPool<byte> ArrayPool = ArrayPool<byte>.Shared;
    public MessageHeader MessageHeader { get; internal set; } = new();
    internal Message()
    {
    }

    public abstract void Deserialize(SerializationContext context);
    public abstract void Serialize(SerializationContext context);

}