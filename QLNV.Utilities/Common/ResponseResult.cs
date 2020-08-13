using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Utilities.Common
{
    public class ResponseResult<Data>
    {

        /// <summary>
        /// Code error or not error
        /// If success code is success, else error
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Message of code content
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Data is result of action, if has error then data null
        /// </summary>
        [JsonProperty("result")]
        public Data Result { get; set; }

    }
}
