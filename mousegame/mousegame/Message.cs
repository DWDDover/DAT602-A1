using System;
using System.Collections.Generic;
using System.Text;

namespace mousegame
{
    public class Message
    {
        public string? Username { get; set; }
        public string? Timestamp { get; set; }
        public string? Content { get; set; }

        public override string ToString()
        {
            var time = DateTime.TryParse(Timestamp, out var parsedTimestamp)
                ? parsedTimestamp.ToString("HH:mm")
                : Timestamp;

            return $"{time} - {Username}: {Content}";
        }
    }
}
