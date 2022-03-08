using System;
using System.Net;
using System.Net.Sockets;

namespace WWBK
{
    public class TcpSocketClient
    {
        public delegate void ProcessBytesFunc(byte[] bytes);

        public delegate void StateChanged(State state);

        public delegate void ErrorFunc(string v);

        public enum State
        {
            DisConnect,
            Connected,
            Connecting,
        }

        private TcpClient _client;

        private NetworkStream _networkStream;

        public string ip;

        public int port;

        private State _state;

        public State state
        {
            set
            {
                if(_state != value)
                {
                    _state = value;
                    stateChanged(_state);
                }
            }
            get
            {
                return _state;
            }
        }

        public ProcessBytesFunc processBytesHandler;

        public StateChanged stateChanged;

        public ErrorFunc errorFunc;

        private byte[] _receiveBuffer;

        public TcpSocketClient(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            _receiveBuffer = new byte[1024];
            _state = State.DisConnect;
            processBytesHandler = ProcessBytesHandler;
            stateChanged = StateChangedHandler;
            errorFunc = ErrorHandler;
        }

        public void Connect()
        {
            state = State.Connecting;

            try
            {
                _client = new TcpClient();
                _client.SendTimeout = 5000;
                _client.ReceiveTimeout = 5000;
                AsyncCallback callBack = new AsyncCallback(BeginConnectCompleteConnet);
                IPAddress ipa = null;

                if (IPAddress.TryParse(ip, out ipa) == true)
                {
                    _client.BeginConnect(ipa, port, callBack,null);
                }
                else
                {
                    _client.BeginConnect(ip, port, callBack, null);
                }
                
            }
            catch (Exception e)
            {
                state = State.DisConnect;
                ProcessError(e);
            }
        }

        private void BeginConnectCompleteConnet(IAsyncResult result)
        {
            try
            {
                _client.EndConnect(result);
            }
            catch(Exception e)
            {
                state = State.DisConnect;
                ProcessError(e);
                return;
            }
            
            _networkStream = _client.GetStream();
            state = State.Connected;

            try
            {
                _networkStream.BeginRead(_receiveBuffer, 0, _receiveBuffer.Length, new AsyncCallback(ReadComplete), null);
            }
            catch (Exception e)
            {
                ProcessError(e);
                return;
            }
        }

        private void ReadComplete(IAsyncResult result)
        {
            if (_networkStream == null)
                return;

            int bytesRead = 0;

            try
            {

                bytesRead = _networkStream.EndRead(result);
            }
            catch (Exception e)
            {
                ProcessError(e);
                return;
            }

            //服务器关闭不会抛异常，只会返回零字节
            if (bytesRead == 0)
            {
                Close();
                return;
            }

            ProcessBytes(_receiveBuffer, 0, bytesRead);

            try
            {
                _networkStream.BeginRead(_receiveBuffer, 0, _receiveBuffer.Length, new AsyncCallback(ReadComplete), null);
            }
            catch (Exception e)
            {
                ProcessError(e);
                return;
            }
        }

        protected virtual void ProcessBytes(byte[] bytes, int offset, int limit)
        {
            byte[] data = new byte[limit];
            Array.Copy(bytes, data, limit);
            processBytesHandler(data);
        }

        private void ProcessBytesHandler(byte[] bytes)
        {
        }

        private void StateChangedHandler(State state)
        {
        }

        private void ErrorHandler(string v)
        {
        }

        public void ProcessError(Exception e)
        {
            errorFunc(e.ToString());
        }

        public void Send(byte[] buffer)
        {
            if (state != State.Connected)
                return;
            try
            {
                _networkStream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(SendComplete), null);
            }
            catch (Exception e)
            {
                ProcessError(e);
                return;
            }
        }

        void SendComplete(IAsyncResult result)
        {
            try
            {
                _networkStream.EndWrite(result);
            }
            catch (Exception e)
            {
                ProcessError(e);
                return;
            }
        }

        public void Close()
        {
            if (_networkStream != null)
            {
                _networkStream.Close();
                _networkStream = null;
            }

            if (_client != null)
            {
                _client.Close();
                _client = null;
            }
            state = State.DisConnect;
        }
    }
}