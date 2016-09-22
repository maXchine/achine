using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

using BaseSocket = System.Net.Sockets.Socket;

namespace Achine.Socket {

    public class Server : IDisposable {

        public Server() {
            Ip = NetworkUnity.GetLocalBroadcastIp();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        ~Server() {
            Dispose(false);
        }

        private void Dispose(bool disposing) {
            if (_disposed)
                return;

            if (disposing) {
                if (_clientFinder != null)
                    _clientFinder.Dispose();

                if (_searchClientThread != null)
                    _searchClientThread.Abort();

                if (_receiveMsgThread != null)
                    _receiveMsgThread.Abort();

                ListenIp.Clear();
                ListenIp = null;
            }
            _disposed = true;
        }

        public string Ip { get; private set; }

        public ushort Port { get { return _startPort; } }

        private const int Backlog = 32;
        private ushort _startPort = 19879;

        public List<string> ListenIp { get; set; }
        private BaseSocket _clientFinder;
        private BaseSocket _receiveMessager;
        private Thread _searchClientThread;
        private Thread _receiveMsgThread;
        private bool _stop;
        private bool _pause;

        public void Pause() {
            _pause = true;
        }

        public void Resumed() {
            _pause = false;
        }

        public void Stop() {
            _stop = true;
        }

        private readonly object _searchLock = new object();
        private readonly object _receiveMsgLock = new object();

        public void SearchClient() {

            lock (_searchLock) {
                NetworkUnity.ActiveThread(ref _searchClientThread, FindClient);
            }

        }

        private void ReceiveMsg() {
            lock (_receiveMsgLock) {
                NetworkUnity.ActiveThread(ref _receiveMsgThread, ReciveMessage);
            }
        }

        private void ReciveMessage() {

            if (_receiveMessager == null)
                _receiveMessager = new BaseSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _receiveMessager.Blocking = false;
            _receiveMessager.Listen(10);

        }

        private void FindClient() {

            if (_clientFinder == null) {
                _clientFinder = new BaseSocket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            }

            _clientFinder.Blocking = false;
            _clientFinder.Listen(Backlog);

            NetworkUnity.BindPort(_clientFinder, Ip, ref _startPort);
            ReceiveClient();
        }

        private void ReceiveClient() {

            while (true) {

                Thread.Sleep(1000);
                if (_stop)
                    break;

                if (_pause)
                    continue;

                WaitingForClients();
            }

        }

        private void WaitingForClients() {

            var acceptClient = _clientFinder.Accept();
            var data = new TransDgram { Type = DgramCommand.IsServer }.GetDgramData();
            acceptClient.Send(data);

        }
    }
}
