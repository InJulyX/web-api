using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web.Common
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private string DateTimeFormat { get; } = "yyyy-MM-dd HH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.TryParse(reader.GetString(), out var dateTime) ? dateTime : default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateTimeFormat));
        }
    }
}