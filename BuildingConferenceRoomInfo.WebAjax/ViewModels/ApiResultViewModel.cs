using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BuildingConferenceRoomInfo.WebAjax.ViewModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BootstrapContext
    {
        [EnumMember(Value = "success")]
        success = 0,

        [EnumMember(Value = "info")]
        info = 1,

        [EnumMember(Value = "warning")]
        warning = 2,

        [EnumMember(Value = "danger")]
        danger = 3,
    }

    public class ApiResultViewModel
    {
        public BootstrapContext Context { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
