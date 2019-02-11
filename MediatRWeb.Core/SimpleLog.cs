using System;
using System.Collections.Generic;

namespace MediatRWeb.Core
{
    public interface IReadFromSimpleLog
    {
        string GetLogEntries();
    }

    public interface IWriteToSimpleLog
    {
        void AddLogEntry(string value);
    }

    public class SimpleLog : IReadFromSimpleLog, IWriteToSimpleLog
    {
        private IList<string> Log { get; }

        public SimpleLog() => Log = new List<string>();

        public string GetLogEntries() => string.Join("; ", Log);

        public void AddLogEntry(string value) => Log.Add(value);
    }
}
