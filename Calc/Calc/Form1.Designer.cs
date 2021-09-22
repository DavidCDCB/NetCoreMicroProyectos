namespace Calc
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.z = new System.Windows.Forms.TextBox();
            this.suma = new System.Windows.Forms.Button();
            this.resta = new System.Windows.Forms.Button();
            this.multi = new System.Windows.Forms.Button();
            this.divi = new System.Windows.Forms.Button();
            this.can = new System.Windows.Forms.Button();
            this.res = new System.Windows.Forms.Button();
            this.bt1 = new System.Windows.Forms.Button();
            this.bt4 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.bt5 = new System.Windows.Forms.Button();
            this.bt9 = new System.Windows.Forms.Button();
            this.bt8 = new System.Windows.Forms.Button();
            this.bt6 = new System.Windows.Forms.Button();
            this.bt7 = new System.Windows.Forms.Button();
            this.bt0 = new System.Windows.Forms.Button();
            this.punto = new System.Windows.Forms.Button();
            this.pot = new System.Windows.Forms.Button();
            this.neg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // z
            // 
            this.z.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.z.Font = new System.Drawing.Font("LCD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z.ForeColor = System.Drawing.Color.Black;
            this.z.Location = new System.Drawing.Point(12, 12);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(210, 28);
            this.z.TabIndex = 0;
            this.z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.z.TextChanged += new System.EventHandler(this.z_TextChanged);
            // 
            // suma
            // 
            this.suma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suma.ForeColor = System.Drawing.Color.Blue;
            this.suma.Location = new System.Drawing.Point(174, 51);
            this.suma.Name = "suma";
            this.suma.Size = new System.Drawing.Size(48, 32);
            this.suma.TabIndex = 2;
            this.suma.Text = "+";
            this.suma.UseVisualStyleBackColor = true;
            this.suma.Click += new System.EventHandler(this.suma_Click);
            // 
            // resta
            // 
            this.resta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resta.ForeColor = System.Drawing.Color.Blue;
            this.resta.Location = new System.Drawing.Point(174, 92);
            this.resta.Name = "resta";
            this.resta.Size = new System.Drawing.Size(48, 32);
            this.resta.TabIndex = 3;
            this.resta.Text = "-";
            this.resta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.resta.UseVisualStyleBackColor = true;
            this.resta.Click += new System.EventHandler(this.resta_Click);
            // 
            // multi
            // 
            this.multi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multi.ForeColor = System.Drawing.Color.Blue;
            this.multi.Location = new System.Drawing.Point(174, 130);
            this.multi.Name = "multi";
            this.multi.Size = new System.Drawing.Size(48, 32);
            this.multi.TabIndex = 4;
            this.multi.Text = "*";
            this.multi.UseVisualStyleBackColor = true;
            this.multi.Click += new System.EventHandler(this.multi_Click);
            // 
            // divi
            // 
            this.divi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divi.ForeColor = System.Drawing.Color.Blue;
            this.divi.Location = new System.Drawing.Point(119, 211);
            this.divi.Name = "divi";
            this.divi.Size = new System.Drawing.Size(49, 35);
            this.divi.TabIndex = 5;
            this.divi.Text = "/";
            this.divi.UseVisualStyleBackColor = true;
            this.divi.Click += new System.EventHandler(this.divi_Click);
            // 
            // can
            // 
            this.can.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.can.ForeColor = System.Drawing.Color.Blue;
            this.can.Location = new System.Drawing.Point(65, 210);
            this.can.Name = "can";
            this.can.Size = new System.Drawing.Size(48, 35);
            this.can.TabIndex = 7;
            this.can.Text = "C";
            this.can.UseVisualStyleBackColor = true;
            this.can.Click += new System.EventHandler(this.button6_Click);
            // 
            // res
            // 
            this.res.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.res.ForeColor = System.Drawing.Color.Blue;
            this.res.Location = new System.Drawing.Point(174, 170);
            this.res.Name = "res";
            this.res.Size = new System.Drawing.Size(48, 77);
            this.res.TabIndex = 10;
            this.res.Text = "=";
            this.res.UseVisualStyleBackColor = true;
            this.res.Click += new System.EventHandler(this.res_Click);
            // 
            // bt1
            // 
            this.bt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1.Location = new System.Drawing.Point(12, 51);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(48, 32);
            this.bt1.TabIndex = 11;
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // bt4
            // 
            this.bt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt4.Location = new System.Drawing.Point(12, 92);
            this.bt4.Name = "bt4";
            this.bt4.Size = new System.Drawing.Size(48, 32);
            this.bt4.TabIndex = 12;
            this.bt4.Text = "4";
            this.bt4.UseVisualStyleBackColor = true;
            this.bt4.Click += new System.EventHandler(this.bt4_Click);
            // 
            // bt2
            // 
            this.bt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2.Location = new System.Drawing.Point(66, 51);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(48, 32);
            this.bt2.TabIndex = 13;
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt3
            // 
            this.bt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3.Location = new System.Drawing.Point(120, 51);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(48, 32);
            this.bt3.TabIndex = 14;
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // bt5
            // 
            this.bt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt5.Location = new System.Drawing.Point(66, 92);
            this.bt5.Name = "bt5";
            this.bt5.Size = new System.Drawing.Size(48, 32);
            this.bt5.TabIndex = 15;
            this.bt5.Text = "5";
            this.bt5.UseVisualStyleBackColor = true;
            this.bt5.Click += new System.EventHandler(this.bt5_Click);
            // 
            // bt9
            // 
            this.bt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt9.Location = new System.Drawing.Point(120, 130);
            this.bt9.Name = "bt9";
            this.bt9.Size = new System.Drawing.Size(48, 32);
            this.bt9.TabIndex = 16;
            this.bt9.Text = "9";
            this.bt9.UseVisualStyleBackColor = true;
            this.bt9.Click += new System.EventHandler(this.bt9_Click);
            // 
            // bt8
            // 
            this.bt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt8.Location = new System.Drawing.Point(66, 130);
            this.bt8.Name = "bt8";
            this.bt8.Size = new System.Drawing.Size(48, 32);
            this.bt8.TabIndex = 17;
            this.bt8.Text = "8";
            this.bt8.UseVisualStyleBackColor = true;
            this.bt8.Click += new System.EventHandler(this.bt8_Click);
            // 
            // bt6
            // 
            this.bt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt6.Location = new System.Drawing.Point(120, 92);
            this.bt6.Name = "bt6";
            this.bt6.Size = new System.Drawing.Size(48, 32);
            this.bt6.TabIndex = 18;
            this.bt6.Text = "6";
            this.bt6.UseVisualStyleBackColor = true;
            this.bt6.Click += new System.EventHandler(this.bt6_Click);
            // 
            // bt7
            // 
            this.bt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt7.Location = new System.Drawing.Point(12, 130);
            this.bt7.Name = "bt7";
            this.bt7.Size = new System.Drawing.Size(48, 32);
            this.bt7.TabIndex = 19;
            this.bt7.Text = "7";
            this.bt7.UseVisualStyleBackColor = true;
            this.bt7.Click += new System.EventHandler(this.bt7_Click);
            // 
            // bt0
            // 
            this.bt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt0.Location = new System.Drawing.Point(65, 170);
            this.bt0.Name = "bt0";
            this.bt0.Size = new System.Drawing.Size(49, 35);
            this.bt0.TabIndex = 20;
            this.bt0.Text = "0";
            this.bt0.UseVisualStyleBackColor = true;
            this.bt0.Click += new System.EventHandler(this.bt0_Click);
            // 
            // punto
            // 
            this.punto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.punto.ForeColor = System.Drawing.Color.Blue;
            this.punto.Location = new System.Drawing.Point(13, 211);
            this.punto.Name = "punto";
            this.punto.Size = new System.Drawing.Size(47, 34);
            this.punto.TabIndex = 21;
            this.punto.Text = ".";
            this.punto.UseVisualStyleBackColor = true;
            this.punto.Click += new System.EventHandler(this.punto_Click);
            // 
            // pot
            // 
            this.pot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pot.ForeColor = System.Drawing.Color.Blue;
            this.pot.Location = new System.Drawing.Point(120, 170);
            this.pot.Name = "pot";
            this.pot.Size = new System.Drawing.Size(48, 35);
            this.pot.TabIndex = 22;
            this.pot.Text = "^";
            this.pot.UseVisualStyleBackColor = true;
            this.pot.Click += new System.EventHandler(this.pot_Click);
            // 
            // neg
            // 
            this.neg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.neg.ForeColor = System.Drawing.Color.Blue;
            this.neg.Location = new System.Drawing.Point(13, 170);
            this.neg.Name = "neg";
            this.neg.Size = new System.Drawing.Size(47, 35);
            this.neg.TabIndex = 23;
            this.neg.Text = "+ -";
            this.neg.UseVisualStyleBackColor = true;
            this.neg.Click += new System.EventHandler(this.neg_Click);
            // 
            // Form1
            // 
            this.AccessibleName = "Calculadora";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(234, 253);
            this.Controls.Add(this.neg);
            this.Controls.Add(this.pot);
            this.Controls.Add(this.punto);
            this.Controls.Add(this.bt0);
            this.Controls.Add(this.bt7);
            this.Controls.Add(this.bt6);
            this.Controls.Add(this.bt8);
            this.Controls.Add(this.bt9);
            this.Controls.Add(this.bt5);
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.bt4);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.res);
            this.Controls.Add(this.can);
            this.Controls.Add(this.divi);
            this.Controls.Add(this.multi);
            this.Controls.Add(this.resta);
            this.Controls.Add(this.suma);
            this.Controls.Add(this.z);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Calculadora  Basica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox z;
        private System.Windows.Forms.Button suma;
        private System.Windows.Forms.Button resta;
        private System.Windows.Forms.Button multi;
        private System.Windows.Forms.Button divi;
        private System.Windows.Forms.Button can;
        private System.Windows.Forms.Button res;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt4;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button bt5;
        private System.Windows.Forms.Button bt9;
        private System.Windows.Forms.Button bt8;
        private System.Windows.Forms.Button bt6;
        private System.Windows.Forms.Button bt7;
        private System.Windows.Forms.Button bt0;
        private System.Windows.Forms.Button punto;
        private System.Windows.Forms.Button pot;
        private System.Windows.Forms.Button neg;
    }
}

