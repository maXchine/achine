using System;

namespace Achine {


    [Serializable]
    public class ControlException : Exception {

        public ControlException()
            : base("系统错误") { }


        public ControlException(string msg)
            : base(msg) {
        }


        public ControlException(string msg, ILogger logger)
            : base(msg) {
            logger.Error(msg);
        }


        public ControlException(string msg, Exception innerException)
            : base(msg, innerException) {
        }


        public ControlException(string msgFormat, params object[] args) : base(string.Format(msgFormat, args)) { }

    }
}
