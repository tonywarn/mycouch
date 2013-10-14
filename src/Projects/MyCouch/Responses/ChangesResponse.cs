﻿using System;
using MyCouch.Serialization.Converters;
using Newtonsoft.Json;

namespace MyCouch.Responses
{
#if !NETFX_CORE
    [Serializable]
#endif
    public class ChangesResponse : ChangesResponse<string> { }

#if !NETFX_CORE
    [Serializable]
#endif
    public class ChangesResponse<TIncludedDoc> : Response
    {
        [JsonProperty(JsonScheme.LastSeq)]
        public long LastSeq { get; set; }
        public Row[] Results { get; set; }

#if !NETFX_CORE
        [Serializable]
#endif
        public class Change
        {
            public string Rev { get; set; }
        }

#if !NETFX_CORE
        [Serializable]
#endif
        public class Row
        {
            public virtual string Id { get; set; }
            public virtual long Seq { get; set; }
            public virtual Change[] Changes { get; set; }
            public virtual bool Deleted { get; set; }
            [JsonProperty(JsonScheme.IncludedDoc)]
            [JsonConverter(typeof(MultiTypeDeserializationJsonConverter))]
            public virtual TIncludedDoc IncludedDoc { get; set; }
        }
    }
}