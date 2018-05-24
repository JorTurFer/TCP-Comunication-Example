using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STT.TCP;

namespace Test_TCP.dll
{
    public partial class Form1 : Form
    {
        //Cliente y servidor
        ClienteTCP m_cliente;
        ServidorTCP m_servidor;
        public Form1()
        {
            InitializeComponent();
        }

        #region  Metodos de Formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            m_cliente = new ClienteTCP();
            m_servidor = new ServidorTCP();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_cliente.Desconectar();
            m_servidor.Desconectar();
        }
        private void txt_cliente_recibido_TextChanged(object sender, EventArgs e)
        {
            txt_cliente_recibido.SelectionStart = txt_cliente_recibido.Text.Length;
            txt_cliente_recibido.ScrollToCaret();
        }
        private void txt_servidor_recibido_TextChanged(object sender, EventArgs e)
        {
            txt_servidor_recibido.SelectionStart = txt_servidor_recibido.Text.Length;
            txt_servidor_recibido.ScrollToCaret();
        }
        #endregion

        #region Metodos Cliente
        private void btn_cliente_conectar_Click(object sender, EventArgs e)
        {
            if (m_cliente.IsConnected())
            {
                m_cliente.Desconectar();
            }
            else
            {
                int port;
                if (int.TryParse(txt_cliente_puerto.Text, out port))
                {
                    m_cliente = new ClienteTCP();
                    m_cliente.DataReceived += OnDataReceivedCliente;
                    m_cliente.Connected += OnStateChangeCliente;
                    if (m_cliente.Conectar(txt_cliente_IP.Text, port))
                    {
                        string strRecibido = string.Format("{0} Cliente-> {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), "Conectado");
                        txt_cliente_recibido.BeginInvoke(new MethodInvoker(delegate { txt_cliente_recibido.Text += strRecibido; }));

                    }
                    else
                    {
                        MessageBox.Show("NO SE HA PODIDO CONECTAR");
                    }

                }
            }
        }
        private void btn_cliente_enviar_Click(object sender, EventArgs e)
        {
            if (!m_cliente.Enviar(txt_cliente_enviar.Text))
            {
                MessageBox.Show("NO SE HA ENVIADO EL MENSAJE");
            }
            else
            {
                string strRecibido = string.Format("{0} Cliente-> {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), txt_cliente_enviar.Text);
                txt_cliente_recibido.BeginInvoke(new MethodInvoker(delegate { txt_cliente_recibido.Text += strRecibido; }));
            }

        }
        private void OnDataReceivedCliente(string e)
        {
            string strRecibido = string.Format("{0} Servidor-> {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), e);
            txt_cliente_recibido.BeginInvoke(new MethodInvoker(delegate { txt_cliente_recibido.Text += strRecibido; }));
        }
        private void OnStateChangeCliente(bool state)
        {
            txt_cliente_enviar.BeginInvoke(new MethodInvoker(delegate { txt_cliente_enviar.Enabled = state; }));
            txt_cliente_recibido.BeginInvoke(new MethodInvoker(delegate { txt_cliente_recibido.Enabled = state; }));
            btn_cliente_enviar.BeginInvoke(new MethodInvoker(delegate { btn_cliente_enviar.Enabled = state; }));
            txt_cliente_puerto.BeginInvoke(new MethodInvoker(delegate { txt_cliente_puerto.Enabled = !state; }));
            txt_cliente_IP.BeginInvoke(new MethodInvoker(delegate { txt_cliente_IP.Enabled = !state; }));
            btn_cliente_conectar.BeginInvoke(new MethodInvoker(delegate { btn_cliente_conectar.Text = state ? "Desconectar" : "Conectar"; }));
            if(!state)
            {
                string strRecibido = string.Format("{0} Cliente-> DESCONECTADO\r\n", DateTime.Now.ToString("HH:mm:ss"));
                txt_cliente_recibido.BeginInvoke(new MethodInvoker(delegate { txt_cliente_recibido.Text += strRecibido; }));
            }
        }
        #endregion

        #region Metodos Servidor
        private void btn_servidor_escuchar_Click(object sender, EventArgs e)
        {
            if (m_servidor.IsConnected())
            {
                m_servidor.Desconectar();
            }
            else
            {
                int port;
                if (int.TryParse(txt_servidor_puerto.Text, out port))
                {
                    m_servidor = new ServidorTCP();
                    m_servidor.DataReceived += OnDataReceivedServidor;
                    m_servidor.Connected += OnStateChangeServidor;
                    if (m_servidor.Escuchar(port))
                    {
                        string strRecibido = string.Format("{0} Servidor-> {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), "Escuchando...");
                        txt_servidor_recibido.BeginInvoke(new MethodInvoker(delegate { txt_servidor_recibido.Text += strRecibido; }));
                    }

                }
            }
        }
        private void OnDataReceivedServidor(string e)
        {
            string strRecibido = string.Format("{0} Cliente-> {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), e);
            txt_servidor_recibido.BeginInvoke(new MethodInvoker(delegate { txt_servidor_recibido.Text += strRecibido; }));
        }
        private void OnStateChangeServidor(bool state)
        {
            txt_servidor_enviar.BeginInvoke(new MethodInvoker(delegate { txt_servidor_enviar.Enabled = state; }));
            txt_servidor_recibido.BeginInvoke(new MethodInvoker(delegate { txt_servidor_recibido.Enabled = state; }));
            btn_servidor_enviar.BeginInvoke(new MethodInvoker(delegate { btn_servidor_enviar.Enabled = state; }));
            txt_servidor_puerto.BeginInvoke(new MethodInvoker(delegate { txt_servidor_puerto.Enabled = !state; }));            
            btn_servidor_escuchar.BeginInvoke(new MethodInvoker(delegate { btn_servidor_escuchar.Text = state ? "Desconectar" : "Escuchar"; }));
            if(!state)
            {
                string strRecibido = string.Format("{0} Servidor-> DESCONECTADO\r\n", DateTime.Now.ToString("HH:mm:ss"));
                txt_servidor_recibido.BeginInvoke(new MethodInvoker(delegate { txt_servidor_recibido.Text += strRecibido; }));
            }
        }
        private void btn_servidor_enviar_Click(object sender, EventArgs e)
        {
            if (!m_servidor.Enviar(txt_servidor_enviar.Text))
            {
                MessageBox.Show("NO SE HA ENVIADO EL MENSAJE");
            }
            else
            {
                string strRecibido = string.Format("{0} Servidor-> {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), txt_servidor_enviar.Text);
                txt_servidor_recibido.BeginInvoke(new MethodInvoker(delegate { txt_servidor_recibido.Text += strRecibido; }));
            }
        }
        #endregion

       
    }
}
