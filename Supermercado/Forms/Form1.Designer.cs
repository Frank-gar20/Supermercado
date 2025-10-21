namespace Supermercado
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            this.LabHora = new System.Windows.Forms.Label();
            this.Timhora = new System.Windows.Forms.Timer(this.components);
            this.BtnEmpleados = new System.Windows.Forms.Button();
            this.BtnProductos = new System.Windows.Forms.Button();
            this.BtnProveedores = new System.Windows.Forms.Button();
            this.BtnClientes = new System.Windows.Forms.Button();
            this.BtnVentas = new System.Windows.Forms.Button();
            this.BtnFacturas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabHora
            // 
            this.LabHora.AutoSize = true;
            this.LabHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabHora.Location = new System.Drawing.Point(434, 9);
            this.LabHora.Name = "LabHora";
            this.LabHora.Size = new System.Drawing.Size(62, 25);
            this.LabHora.TabIndex = 0;
            this.LabHora.Text = "Hora";
            // 
            // Timhora
            // 
            this.Timhora.Enabled = true;
            this.Timhora.Tick += new System.EventHandler(this.Timhora_Tick);
            // 
            // BtnEmpleados
            // 
            this.BtnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmpleados.Location = new System.Drawing.Point(22, 75);
            this.BtnEmpleados.Name = "BtnEmpleados";
            this.BtnEmpleados.Size = new System.Drawing.Size(133, 35);
            this.BtnEmpleados.TabIndex = 1;
            this.BtnEmpleados.Text = "Empleados";
            this.BtnEmpleados.UseVisualStyleBackColor = true;
            this.BtnEmpleados.Click += new System.EventHandler(this.BtnEmpleados_Click);
            // 
            // BtnProductos
            // 
            this.BtnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductos.Location = new System.Drawing.Point(22, 133);
            this.BtnProductos.Name = "BtnProductos";
            this.BtnProductos.Size = new System.Drawing.Size(133, 35);
            this.BtnProductos.TabIndex = 2;
            this.BtnProductos.Text = "Productos";
            this.BtnProductos.UseVisualStyleBackColor = true;
            this.BtnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProveedores.Location = new System.Drawing.Point(22, 188);
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(133, 35);
            this.BtnProveedores.TabIndex = 3;
            this.BtnProveedores.Text = "Proveedores";
            this.BtnProveedores.UseVisualStyleBackColor = true;
            this.BtnProveedores.Click += new System.EventHandler(this.BtnProveedores_Click);
            // 
            // BtnClientes
            // 
            this.BtnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClientes.Location = new System.Drawing.Point(22, 242);
            this.BtnClientes.Name = "BtnClientes";
            this.BtnClientes.Size = new System.Drawing.Size(133, 35);
            this.BtnClientes.TabIndex = 4;
            this.BtnClientes.Text = "Clientes";
            this.BtnClientes.UseVisualStyleBackColor = true;
            this.BtnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // BtnVentas
            // 
            this.BtnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVentas.Location = new System.Drawing.Point(215, 129);
            this.BtnVentas.Name = "BtnVentas";
            this.BtnVentas.Size = new System.Drawing.Size(133, 39);
            this.BtnVentas.TabIndex = 8;
            this.BtnVentas.Text = "Ventas";
            this.BtnVentas.UseVisualStyleBackColor = true;
            this.BtnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // BtnFacturas
            // 
            this.BtnFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFacturas.Location = new System.Drawing.Point(215, 194);
            this.BtnFacturas.Name = "BtnFacturas";
            this.BtnFacturas.Size = new System.Drawing.Size(133, 39);
            this.BtnFacturas.TabIndex = 7;
            this.BtnFacturas.Text = "Facturas";
            this.BtnFacturas.UseVisualStyleBackColor = true;
            this.BtnFacturas.Click += new System.EventHandler(this.BtnFacturas_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 363);
            this.Controls.Add(this.BtnVentas);
            this.Controls.Add(this.BtnFacturas);
            this.Controls.Add(this.BtnClientes);
            this.Controls.Add(this.BtnProveedores);
            this.Controls.Add(this.BtnProductos);
            this.Controls.Add(this.BtnEmpleados);
            this.Controls.Add(this.LabHora);
            this.Name = "frmMenu";
            this.Text = "Supermercado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabHora;
        private System.Windows.Forms.Timer Timhora;
        private System.Windows.Forms.Button BtnEmpleados;
        private System.Windows.Forms.Button BtnProductos;
        private System.Windows.Forms.Button BtnProveedores;
        private System.Windows.Forms.Button BtnClientes;
        private System.Windows.Forms.Button BtnVentas;
        private System.Windows.Forms.Button BtnFacturas;
    }
}

