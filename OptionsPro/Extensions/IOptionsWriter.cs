using Newtonsoft.Json.Linq;
using System;

namespace OptionsPro.Extensions
{
    internal interface IOptionsWriter
    {
        void UpdateOptions(Action<JObject> callback, bool reload = true);
    }
}