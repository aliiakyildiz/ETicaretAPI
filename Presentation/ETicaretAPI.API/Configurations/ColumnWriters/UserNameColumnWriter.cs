using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace ETicaretAPI.API.Configurations.ColumnWriters
{
    public class UserNameColumnWriter : ColumnWriterBase
    {
        public UserNameColumnWriter() : base(NpgsqlDbType.Varchar)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            var (UserNameColumnWriter, value) = logEvent.Properties.FirstOrDefault(p => p.Key == "user_name");
            return value?.ToString() ?? null;
        }
    }
}
