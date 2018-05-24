using System;
using System.Net;
using System.Threading;
using System.IO;
using System.Net.Sockets;

namespace STT.TCP
{
    public class ServidorTCP
    {
        /// <summary>
        /// Data Recived Event Handler
        /// </summary>
        /// <param name="e">Mensaje recibido</param>
        public delegate void DataReceivedEventHandler(string e);
        /// <summary>
        /// Evento que se dispara al recibir datos
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        /// <summary>
        /// State Event Handler
        /// </summary>
        /// <param name="state">state</param>
        public delegate void ServidorTCPConnectionStateHandler(bool state);
        /// <summary>
        /// Evento que se dispara cuando la conexion cambia de estado
        /// </summary>
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
            DataReceived?.Invoke(e);
        }
        private void ChangeState(bool state)
        {
            if (state != m_connected)
            {
                m_connected = state;
                Connected?.Invoke(state);
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
        /// <summary>
        /// Inicia la escucha de un puerto
        /// </summary>
        /// <param name="port">Puerto a escuchar</param>
        /// <returns></returns>
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
        /// <summary>
        /// Desconecta el socket
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Envia un mensaje
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        /// <returns></returns>
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
        /// <summary>
        /// Esta conectado?
        /// </summary>
        /// <returns></returns>
        public bool IsConnected() { return m_connected; }

    }
}

