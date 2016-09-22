using System;
using System.IO;
using System.Threading;

namespace TheControlPanelTester {

    internal class Program {

        private static Thread _mainThread;

        private static void Main() {

            var v1 = File.Open(@"D:\Downloads\搏击俱乐部.mkv", FileMode.Open, FileAccess.Read);
            var v2 = File.Open(@"D:\Downloads\飞越疯人院.mkv", FileMode.Open, FileAccess.Read);
            var bs1 = new byte[1024];
            var bs2 = new byte[1024];
            v1.Read(bs1, 0, bs1.Length);
            v1.Read(bs2, 0, bs2.Length);
            Console.Read();

            ActiveThread(ref _mainThread, TestThreadStart);
            //SearchEngine.StartUp("http://huaban.com/");
            Console.Read();
        }

        private static void TestThreadStart() {
            while (true) {
                Thread.Sleep(1000 / 24);
            }
        }

        private static void ActiveThread(ref Thread thread, ThreadStart threadStart) {

            if (thread == null)
                thread = new Thread(threadStart);

            if (thread.IsAlive)
                return;

            thread.Start();
        }
    }
}
