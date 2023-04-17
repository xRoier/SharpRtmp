﻿using System;
using SharpRtmp.Networking.Rtmp.Data;
using SharpRtmp.Networking.Rtmp.Serialization;
using SharpRtmp.Networking.Utils;

namespace SharpRtmp.Networking.Rtmp.Messages;

[RtmpMessage(MessageType.Acknowledgement)]
public class AcknowledgementMessage : ControlMessage
{
    public uint BytesReceived { get; set; }

    public override void Deserialize(SerializationContext context)
    {
        BytesReceived = NetworkBitConverter.ToUInt32(context.ReadBuffer.Span);
    }

    public override void Serialize(SerializationContext context)
    {
        var buffer = ArrayPool.Rent(sizeof(uint));
        try
        {
            NetworkBitConverter.TryGetBytes(BytesReceived, buffer);
            context.WriteBuffer.WriteToBuffer(buffer.AsSpan(0, sizeof(uint)));
        }
        finally
        {
            ArrayPool.Return(buffer);
        }
    }
}