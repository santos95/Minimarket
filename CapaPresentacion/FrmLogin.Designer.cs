namespace CapaPresentacion
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.Encabezado = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnminimizar = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.PictureBox();
            this.Contraseña = new System.Windows.Forms.PictureBox();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.pnlContraseña = new System.Windows.Forms.Panel();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.data = new System.Windows.Forms.DataGridView();
            this.estado = new System.Windows.Forms.DataGridView();
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.Encabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estado)).BeginInit();
            this.SuspendLayout();
            // 
            // Encabezado
            // 
            this.Encabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Encabezado.Controls.Add(this.label6);
            this.Encabezado.Controls.Add(this.btnClose);
            this.Encabezado.Controls.Add(this.btnminimizar);
            this.Encabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.Encabezado.Location = new System.Drawing.Point(0, 0);
            this.Encabezado.Name = "Encabezado";
            this.Encabezado.Size = new System.Drawing.Size(617, 40);
            this.Encabezado.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(233, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 27);
            this.label6.TabIndex = 143;
            this.label6.Text = "Inicio de Sesión";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(584, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 148;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnminimizar
            // 
            this.btnminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnminimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnminimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnminimizar.Image")));
            this.btnminimizar.Location = new System.Drawing.Point(550, 3);
            this.btnminimizar.Name = "btnminimizar";
            this.btnminimizar.Size = new System.Drawing.Size(30, 30);
            this.btnminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnminimizar.TabIndex = 147;
            this.btnminimizar.TabStop = false;
            this.btnminimizar.Click += new System.EventHandler(this.btnminimizar_Click);
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(12, 46);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(149, 150);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 1;
            this.Logo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("IceCreamPartySolid", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.label2.Location = new System.Drawing.Point(26, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 52);
            this.label2.TabIndex = 138;
            this.label2.Text = "Minimarket \r\nLos Chombos";
            // 
            // Usuario
            // 
            this.Usuario.Image = ((System.Drawing.Image)(resources.GetObject("Usuario.Image")));
            this.Usuario.Location = new System.Drawing.Point(183, 79);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(40, 40);
            this.Usuario.TabIndex = 139;
            this.Usuario.TabStop = false;
            // 
            // Contraseña
            // 
            this.Contraseña.Image = ((System.Drawing.Image)(resources.GetObject("Contraseña.Image")));
            this.Contraseña.Location = new System.Drawing.Point(183, 138);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(40, 40);
            this.Contraseña.TabIndex = 140;
            this.Contraseña.TabStop = false;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.pnlUsuario.Location = new System.Drawing.Point(250, 118);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(350, 2);
            this.pnlUsuario.TabIndex = 141;
            // 
            // pnlContraseña
            // 
            this.pnlContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.pnlContraseña.Location = new System.Drawing.Point(250, 177);
            this.pnlContraseña.Name = "pnlContraseña";
            this.pnlContraseña.Size = new System.Drawing.Size(350, 2);
            this.pnlContraseña.TabIndex = 142;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(258, 96);
            this.TxtUsuario.MaxLength = 30;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(327, 22);
            this.TxtUsuario.TabIndex = 143;
            this.TxtUsuario.Text = "Usuario";
            this.TxtUsuario.Click += new System.EventHandler(this.TxtUsuario_Click);
            this.TxtUsuario.Enter += new System.EventHandler(this.TxtUsuario_Enter);
            this.TxtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUsuario_KeyDown);
            this.TxtUsuario.Leave += new System.EventHandler(this.TxtUsuario_Leave);
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtPassword.Location = new System.Drawing.Point(263, 153);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(322, 22);
            this.TxtPassword.TabIndex = 144;
            this.TxtPassword.Text = "Contraseña";
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.Click += new System.EventHandler(this.TxtPassword_Click);
            this.TxtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            this.TxtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave);
            // 
            // data
            // 
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Location = new System.Drawing.Point(34, 281);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(240, 131);
            this.data.TabIndex = 145;
            // 
            // estado
            // 
            this.estado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estado.Location = new System.Drawing.Point(367, 286);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(159, 47);
            this.estado.TabIndex = 146;
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.BtnIngresar.FlatAppearance.BorderSize = 2;
            this.BtnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngresar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.BtnIngresar.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnIngresar.Location = new System.Drawing.Point(295, 218);
            this.BtnIngresar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(230, 40);
            this.BtnIngresar.TabIndex = 149;
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.UseVisualStyleBackColor = false;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(617, 270);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.data);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.pnlContraseña);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.Encabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.Encabezado.ResumeLayout(false);
            this.Encabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Encabezado;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Usuario;
        private System.Windows.Forms.PictureBox Contraseña;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Panel pnlContraseña;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.DataGridView estado;
        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button BtnIngresar;
    }
}