using System;

namespace Achine {
    public interface ILogger {

        void Info(string message);

        void Info(string format, params object[] args);

        void Info(Exception exception);

        void Info(Exception exception, string message);

        void Info(Exception exception, string format, params object[] args);

        void Error(string message);

        void Error(string format, params object[] args);

        void Error(Exception exception);

        void Error(Exception exception, string message);

        void Error(Exception exception, string format, params object[] args);

        void Debug(string message);

        void Debug(string format, params object[] args);

        void Debug(Exception exception);

        void Debug(Exception exception, string message);

        void Debug(Exception exception, string format, params object[] args);

        void Warning(string message);

        void Warning(string format, params object[] args);

        void Warning(Exception exception);

        void Warning(Exception exception, string message);

        void Warning(Exception exception, string format, params object[] args);

    }
}
