using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Net.Sockets;

namespace TCP
{
    public class ClienteTCP
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
        /// <param name="state"></param>
        public delegate void ClienteTCPConnectionStateHandler(bool state);
        /// <summary>
        /// Evento que se dispara cuando la conexion cambia de estado
        /// </summary>
        public event ClienteTCPConnectionStateHandler Connected;
    
        TcpClient m_Client;
        NetworkStream m_netStream;
        StreamReader m_redStream;
        StreamWriter m_writStream;
        Thread m_threadRecibir;
        ManualResetEvent m_eventdesconectar;
        string m_hostname;
        int m_port;

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
            m_Client = new TcpClient();          
            m_Client.Connect(m_hostname, m_port);
            m_netStream = m_Client.GetStream();
            m_redStream = new StreamReader(m_netStream);
            m_writStream = new StreamWriter(m_netStream);
            m_eventdesconectar = new ManualResetEvent(false);

            m_threadRecibir = new Thread(_Recibir);
            m_threadRecibir.Name = "Thread Data Receive";
            m_threadRecibir.Start();          
            ChangeState(true);
            return true;
        }
        private void _Recibir()
        {
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
        /// Conectarse
        /// </summary>
        /// <param name="hostname">IP destino</param>
        /// <param name="port">Puerto destino</param>
        /// <returns></returns>
        public bool Conectar(string hostname, int port)
        {
            try
            {
                this.m_hostname = hostname;
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
        /// Desconectarse
        /// </summary>
        /// <returns></returns>
        public bool Desconectar()
        {           
            try
            {
                ChangeState(false);    
                m_threadRecibir.Abort();
                m_threadRecibir = null;
                m_eventdesconectar.Set();                
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
        /// <param name="mensaje">Mensaje a enviar</param>
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