
namespace thesis_3
{
    partial class TableValue
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpdateValue = new System.Windows.Forms.Timer(this.components);
            this.PrintValue_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1167, 581);
            this.dataGridView1.TabIndex = 0;
            // 
            // UpdateValue
            // 
            this.UpdateValue.Interval = 1000;
            this.UpdateValue.Tick += new System.EventHandler(this.UpdateValue_Tick);
            // 
            // PrintValue_btn
            // 
            this.PrintValue_btn.Location = new System.Drawing.Point(1202, 23);
            this.PrintValue_btn.Name = "PrintValue_btn";
            this.PrintValue_btn.Size = new System.Drawing.Size(75, 23);
            this.PrintValue_btn.TabIndex = 1;
            this.PrintValue_btn.Text = "Print";
            this.PrintValue_btn.UseVisualStyleBackColor = true;
            this.PrintValue_btn.Click += new System.EventHandler(this.PrintValue_btn_Click);
            // 
            // TableValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 606);
            this.Controls.Add(this.PrintValue_btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TableValue";
            this.Text = "TableValue";
            this.Load += new System.EventHandler(this.TableValue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer UpdateValue;
        private System.Windows.Forms.Button PrintValue_btn;
    }
}