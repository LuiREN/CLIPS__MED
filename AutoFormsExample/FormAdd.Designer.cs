
namespace AutoFormsExample
{
    partial class FormAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAddQueryRules = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAddQueryRules = new System.Windows.Forms.Button();
            this.buttonAddRepairRules = new System.Windows.Forms.Button();
            this.buttonMakeRepair = new System.Windows.Forms.Button();
            this.textBoxAddRepairRules = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Plum;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 130);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите через пробел:\r\n- название правила\r\n- предыдущий вопрос\r\n- yes/no,\r\n- след" +
    "ующий вопрос и название текста в auto_en.clp";
            // 
            // textBoxAddQueryRules
            // 
            this.textBoxAddQueryRules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.textBoxAddQueryRules.Location = new System.Drawing.Point(7, 166);
            this.textBoxAddQueryRules.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAddQueryRules.Multiline = true;
            this.textBoxAddQueryRules.Name = "textBoxAddQueryRules";
            this.textBoxAddQueryRules.Size = new System.Drawing.Size(484, 118);
            this.textBoxAddQueryRules.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(11, 292);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAddQueryRules
            // 
            this.buttonAddQueryRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonAddQueryRules.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddQueryRules.ForeColor = System.Drawing.Color.Black;
            this.buttonAddQueryRules.Location = new System.Drawing.Point(346, 292);
            this.buttonAddQueryRules.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddQueryRules.Name = "buttonAddQueryRules";
            this.buttonAddQueryRules.Size = new System.Drawing.Size(145, 48);
            this.buttonAddQueryRules.TabIndex = 3;
            this.buttonAddQueryRules.Text = "Добавить";
            this.buttonAddQueryRules.UseVisualStyleBackColor = false;
            this.buttonAddQueryRules.Click += new System.EventHandler(this.buttonAddQueryRules_Click);
            // 
            // buttonAddRepairRules
            // 
            this.buttonAddRepairRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonAddRepairRules.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddRepairRules.ForeColor = System.Drawing.Color.Black;
            this.buttonAddRepairRules.Location = new System.Drawing.Point(382, 292);
            this.buttonAddRepairRules.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddRepairRules.Name = "buttonAddRepairRules";
            this.buttonAddRepairRules.Size = new System.Drawing.Size(132, 48);
            this.buttonAddRepairRules.TabIndex = 7;
            this.buttonAddRepairRules.Text = "Добавить";
            this.buttonAddRepairRules.UseVisualStyleBackColor = false;
            this.buttonAddRepairRules.Click += new System.EventHandler(this.buttonAddRepairRules_Click);
            // 
            // buttonMakeRepair
            // 
            this.buttonMakeRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonMakeRepair.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMakeRepair.ForeColor = System.Drawing.Color.Black;
            this.buttonMakeRepair.Location = new System.Drawing.Point(11, 292);
            this.buttonMakeRepair.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMakeRepair.Name = "buttonMakeRepair";
            this.buttonMakeRepair.Size = new System.Drawing.Size(136, 48);
            this.buttonMakeRepair.TabIndex = 6;
            this.buttonMakeRepair.Text = "Создать";
            this.buttonMakeRepair.UseVisualStyleBackColor = false;
            this.buttonMakeRepair.Click += new System.EventHandler(this.buttonMakeRepair_Click);
            // 
            // textBoxAddRepairRules
            // 
            this.textBoxAddRepairRules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.textBoxAddRepairRules.Location = new System.Drawing.Point(11, 166);
            this.textBoxAddRepairRules.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAddRepairRules.Multiline = true;
            this.textBoxAddRepairRules.Name = "textBoxAddRepairRules";
            this.textBoxAddRepairRules.Size = new System.Drawing.Size(497, 118);
            this.textBoxAddRepairRules.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(269, 130);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите через пробел:\r\n- название правила\r\n- важность правила\r\n- последний вопрос" +
    "\r\n- название текста в auto_en.clp\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Plum;
            this.groupBox1.Controls.Add(this.textBoxAddQueryRules);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonAddQueryRules);
            this.groupBox1.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 347);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запросы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxAddRepairRules);
            this.groupBox2.Controls.Add(this.buttonMakeRepair);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonAddRepairRules);
            this.groupBox2.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.groupBox2.Location = new System.Drawing.Point(516, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 347);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Правила диагностики";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(337, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(344, 65);
            this.button2.TabIndex = 10;
            this.button2.Text = "Перейти к главной форме";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(1049, 452);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAddQueryRules;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAddQueryRules;
        private System.Windows.Forms.Button buttonAddRepairRules;
        private System.Windows.Forms.Button buttonMakeRepair;
        private System.Windows.Forms.TextBox textBoxAddRepairRules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
    }
}