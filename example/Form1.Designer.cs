namespace Test_TCP.dll
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cliente_enviar = new System.Windows.Forms.Button();
            this.btn_cliente_conectar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cliente_puerto = new System.Windows.Forms.TextBox();
            this.txt_cliente_IP = new System.Windows.Forms.TextBox();
            this.txt_cliente_enviar = new System.Windows.Forms.TextBox();
            this.txt_cliente_recibido = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_servidor_enviar = new System.Windows.Forms.Button();
            this.btn_servidor_escuchar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_servidor_puerto = new System.Windows.Forms.TextBox();
            this.txt_servidor_enviar = new System.Windows.Forms.TextBox();
            this.txt_servidor_recibido = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_cliente_enviar);
            this.groupBox1.Controls.Add(this.btn_cliente_conectar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_cliente_puerto);
            this.groupBox1.Controls.Add(this.txt_cliente_IP);
            this.groupBox1.Controls.Add(this.txt_cliente_enviar);
            this.groupBox1.Controls.Add(this.txt_cliente_recibido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 469);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // btn_cliente_enviar
            // 
            this.btn_cliente_enviar.Enabled = false;
            this.btn_cliente_enviar.Location = new System.Drawing.Point(393, 395);
            this.btn_cliente_enviar.Name = "btn_cliente_enviar";
            this.btn_cliente_enviar.Size = new System.Drawing.Size(92, 47);
            this.btn_cliente_enviar.TabIndex = 7;
            this.btn_cliente_enviar.Text = "Enviar";
            this.btn_cliente_enviar.UseVisualStyleBackColor = true;
            this.btn_cliente_enviar.Click += new System.EventHandler(this.btn_cliente_enviar_Click);
            // 
            // btn_cliente_conectar
            // 
            this.btn_cliente_conectar.Location = new System.Drawing.Point(205, 419);
            this.btn_cliente_conectar.Name = "btn_cliente_conectar";
            this.btn_cliente_conectar.Size = new System.Drawing.Size(75, 23);
            this.btn_cliente_conectar.TabIndex = 6;
            this.btn_cliente_conectar.Text = "Conectar";
            this.btn_cliente_conectar.UseVisualStyleBackColor = true;
            this.btn_cliente_conectar.Click += new System.EventHandler(this.btn_cliente_conectar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "PORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "HOSTNAME";
            // 
            // txt_cliente_puerto
            // 
            this.txt_cliente_puerto.Location = new System.Drawing.Point(102, 421);
            this.txt_cliente_puerto.Name = "txt_cliente_puerto";
            this.txt_cliente_puerto.Size = new System.Drawing.Size(79, 20);
            this.txt_cliente_puerto.TabIndex = 3;
            this.txt_cliente_puerto.Text = "13000";
            // 
            // txt_cliente_IP
            // 
            this.txt_cliente_IP.Location = new System.Drawing.Point(102, 395);
            this.txt_cliente_IP.Name = "txt_cliente_IP";
            this.txt_cliente_IP.Size = new System.Drawing.Size(178, 20);
            this.txt_cliente_IP.TabIndex = 2;
            this.txt_cliente_IP.Text = "127.0.0.1";
            // 
            // txt_cliente_enviar
            // 
            this.txt_cliente_enviar.Enabled = false;
            this.txt_cliente_enviar.Location = new System.Drawing.Point(6, 306);
            this.txt_cliente_enviar.Multiline = true;
            this.txt_cliente_enviar.Name = "txt_cliente_enviar";
            this.txt_cliente_enviar.Size = new System.Drawing.Size(522, 59);
            this.txt_cliente_enviar.TabIndex = 1;
            // 
            // txt_cliente_recibido
            // 
            this.txt_cliente_recibido.Enabled = false;
            this.txt_cliente_recibido.Location = new System.Drawing.Point(6, 19);
            this.txt_cliente_recibido.Multiline = true;
            this.txt_cliente_recibido.Name = "txt_cliente_recibido";
            this.txt_cliente_recibido.ReadOnly = true;
            this.txt_cliente_recibido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_cliente_recibido.Size = new System.Drawing.Size(522, 268);
            this.txt_cliente_recibido.TabIndex = 0;
            this.txt_cliente_recibido.TextChanged += new System.EventHandler(this.txt_cliente_recibido_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_servidor_enviar);
            this.groupBox2.Controls.Add(this.txt_servidor_recibido);
            this.groupBox2.Controls.Add(this.btn_servidor_escuchar);
            this.groupBox2.Controls.Add(this.txt_servidor_enviar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_servidor_puerto);
            this.groupBox2.Location = new System.Drawing.Point(594, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 469);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servidor";
            // 
            // btn_servidor_enviar
            // 
            this.btn_servidor_enviar.Enabled = false;
            this.btn_servidor_enviar.Location = new System.Drawing.Point(399, 395);
            this.btn_servidor_enviar.Name = "btn_servidor_enviar";
            this.btn_servidor_enviar.Size = new System.Drawing.Size(92, 47);
            this.btn_servidor_enviar.TabIndex = 13;
            this.btn_servidor_enviar.Text = "Enviar";
            this.btn_servidor_enviar.UseVisualStyleBackColor = true;
            this.btn_servidor_enviar.Click += new System.EventHandler(this.btn_servidor_enviar_Click);
            // 
            // btn_servidor_escuchar
            // 
            this.btn_servidor_escuchar.Location = new System.Drawing.Point(211, 419);
            this.btn_servidor_escuchar.Name = "btn_servidor_escuchar";
            this.btn_servidor_escuchar.Size = new System.Drawing.Size(75, 23);
            this.btn_servidor_escuchar.TabIndex = 12;
            this.btn_servidor_escuchar.Text = "Escuchar";
            this.btn_servidor_escuchar.UseVisualStyleBackColor = true;
            this.btn_servidor_escuchar.Click += new System.EventHandler(this.btn_servidor_escuchar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "PORT";
            // 
            // txt_servidor_puerto
            // 
            this.txt_servidor_puerto.Location = new System.Drawing.Point(108, 421);
            this.txt_servidor_puerto.Name = "txt_servidor_puerto";
            this.txt_servidor_puerto.Size = new System.Drawing.Size(79, 20);
            this.txt_servidor_puerto.TabIndex = 10;
            this.txt_servidor_puerto.Text = "13000";
            // 
            // txt_servidor_enviar
            // 
            this.txt_servidor_enviar.Enabled = false;
            this.txt_servidor_enviar.Location = new System.Drawing.Point(12, 306);
            this.txt_servidor_enviar.Multiline = true;
            this.txt_servidor_enviar.Name = "txt_servidor_enviar";
            this.txt_servidor_enviar.Size = new System.Drawing.Size(522, 59);
            this.txt_servidor_enviar.TabIndex = 9;
            // 
            // txt_servidor_recibido
            // 
            this.txt_servidor_recibido.Enabled = false;
            this.txt_servidor_recibido.Location = new System.Drawing.Point(12, 19);
            this.txt_servidor_recibido.Multiline = true;
            this.txt_servidor_recibido.Name = "txt_servidor_recibido";
            this.txt_servidor_recibido.ReadOnly = true;
            this.txt_servidor_recibido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_servidor_recibido.Size = new System.Drawing.Size(522, 268);
            this.txt_servidor_recibido.TabIndex = 8;
            this.txt_servidor_recibido.TextChanged += new System.EventHandler(this.txt_servidor_recibido_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 493);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test TCP.dll";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cliente_enviar;
        private System.Windows.Forms.Button btn_cliente_conectar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_cliente_puerto;
        private System.Windows.Forms.TextBox txt_cliente_IP;
        private System.Windows.Forms.TextBox txt_cliente_enviar;
        private System.Windows.Forms.TextBox txt_cliente_recibido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_servidor_enviar;
        private System.Windows.Forms.TextBox txt_servidor_recibido;
        private System.Windows.Forms.Button btn_servidor_escuchar;
        private System.Windows.Forms.TextBox txt_servidor_enviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_servidor_puerto;
    }
}

