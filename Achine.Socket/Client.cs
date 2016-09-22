using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Achine.Socket {

    public class Client {

        public string Ip { get; private set; }


        public string Name { get; set; }

        public Client() { }

        public Client(string ipString) {


        }


        private IPEndPoint _server;

        private ushort _basePort = 19879;

        private bool _findOutServer;

        private Thread _searchThread;

        public void SearchServer() {

            if (_searchThread == null)
                _searchThread = new Thread(StartSearchServer);

            if (_searchThread.IsAlive)
                return;

            _searchThread.Start();
        }


        private void StartSearchServer() {

            UdpClient searchClient = null;
            while (searchClient == null) {
                try {
                    searchClient = new UdpClient(NetworkUnity.GetLocalBroadcastIp().ConvertToIpEndPoint(_basePort));
                }
                catch {
                    _basePort += 9;
                }
            }

            var data = new TransDgram {
                Type = DgramCommand.Connect
            }.GetDgramData();
            while (_findOutServer) {
                searchClient.Send(data, data.Length);
                Thread.Sleep(1000);
            }
        }

        private bool _stop;
        private bool _pause;

        private void ListenRequest() {

            while (true) {

                Thread.Sleep(5000);
                if (_stop)
                    break;

                if (_pause) 
                    continue;
                

            }
        }

    }
}
