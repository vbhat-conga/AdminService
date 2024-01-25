using System.Diagnostics;

namespace AdminService.Model
{
    public class Instrumentation : IDisposable
    {
        internal const string ActivitySourceName = "Admin-API";

        public Instrumentation()
        {
            string? version = typeof(Instrumentation).Assembly.GetName().Version?.ToString();
            this.ActivitySource = new ActivitySource(ActivitySourceName, version);

        }

        public ActivitySource ActivitySource { get; }


        public void Dispose()
        {
            this.ActivitySource.Dispose();
        }
    }
}
