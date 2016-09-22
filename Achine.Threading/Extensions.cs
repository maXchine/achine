using System.Threading;

namespace Achine.Threading {

    public static class Extensions {


        public static void ActiveThread(ref Thread thread, ThreadStart threadStart, object param) {

            if (thread == null)
                thread = new Thread(threadStart);

            if (thread.IsAlive)
                return;

            if (param == null)
                thread.Start();
            else {
                thread.Start(param);
            }
        }

    }
}
