﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Harmonic.Networking.Rtmp.Data
{
    public class Chunk
    {
        public ChunkHeader ChunkHeader { get; set; }

        public byte[] ChunkData { get; set; }
    }
}