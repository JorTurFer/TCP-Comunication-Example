using System;
using System.Net;
using System.Threading;
using System.IO;
using System.Net.Sockets;

namespace STT.TCP
{
    public class ServidorTCP
    {
        public delegate void DataReceivedEventHandler(string e);
        public event DataReceivedEventHandler DataReceived;

        public delegate void ServidorTCPConnectionStateHandler(bool state);
        public event ServidorTCPConnectionStateHandler Connected;

        TcpClient m_Client;
        TcpListener listener;
        NetworkStream m_netStream;
        StreamReader m_redStream;
        StreamWriter m_writStream;
        Thread m_threadRecibir;
        ManualResetEvent m_eventdesconectar;
        int m_port;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        bool m_connected = false;

        private void OnDataRecived(string e)
        {
            DataReceivedEventHandler handler = DataReceived;
            if (handler != null)
            {
                handler(e);
            }
        }
        private void ChangeState(bool state)
        {
            if (state != m_connected)
            {
                m_connected = state;
                ServidorTCPConnectionStateHandler handler = Connected;
                if (handler != null)
                {
                    handler(state);
                }
            }
        }
        private bool _Conectar()
        {
            m_threadRecibir = new Thread(_Recibir);
            m_threadRecibir.Name = "Thread Data Receive";
            m_threadRecibir.Start();
            return true;
        }
        private void _Recibir()
        {
            ChangeState(true);
            listener = new TcpListener(localAddr, m_port);
            listener.Start();
            try
            {
                m_Client = listener.AcceptTcpClient(); //Saltara al catch si se cierra el thread
            }
            catch
            {
                return;
            }
            m_connected = true;

            m_netStream = m_Client.GetStream();
            m_redStream = new StreamReader(m_netStream);
            m_writStream = new StreamWriter(m_netStream);
            m_eventdesconectar = new ManualResetEvent(false);
            OnDataRecived("Conectado");
            while (!m_eventdesconectar.WaitOne(0))
            {
                try
                {
                    string strRec = m_redStream.ReadLine();
                    if (strRec == null)
                    {
                        Desconectar();
                    }
                    else
                    {
                        OnDataRecived(strRec);
                    }
                }
                catch
                {
                    Desconectar();
                }
            }
        }
        public bool Escuchar(int port)
        {
            try
            {
                this.m_port = port;
                return _Conectar();
            }
            catch
            {
                Desconectar();
                return false;
            }
        }
        public bool Desconectar()
        {
            try
            {
                ChangeState(false);
                listener.Stop();
                m_eventdesconectar.Set();
                m_threadRecibir.Abort();
                m_threadRecibir = null;
                m_Client.Close();
                m_netStream.Close();
                m_redStream.Close();
                m_writStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Enviar(string mensaje)
        {
            try
            {
                if (!m_Client.Connected)
                {
                    Desconectar();
                    _Conectar();
                }
                m_writStream.WriteLine(mensaje);
                m_writStream.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsConnected() { return m_connected; }

    }
}

