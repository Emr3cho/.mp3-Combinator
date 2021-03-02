
namespace mp3Uniter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Btn_render = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Add
            // 
            this.Btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Add.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Add.Location = new System.Drawing.Point(12, 12);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(729, 145);
            this.Btn_Add.TabIndex = 0;
            this.Btn_Add.Text = " Добави";
            this.Btn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Btn_render
            // 
            this.Btn_render.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_render.Enabled = false;
            this.Btn_render.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_render.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_render.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_render.Location = new System.Drawing.Point(12, 188);
            this.Btn_render.Name = "Btn_render";
            this.Btn_render.Size = new System.Drawing.Size(729, 69);
            this.Btn_render.TabIndex = 1;
            this.Btn_render.Text = "Експортирай";
            this.Btn_render.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_render.UseVisualStyleBackColor = false;
            this.Btn_render.Click += new System.EventHandler(this.Btn_render_Click);
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info.Location = new System.Drawing.Point(12, 160);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(729, 27);
            this.info.TabIndex = 2;
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 270);
            this.Controls.Add(this.info);
            this.Controls.Add(this.Btn_render);
            this.Controls.Add(this.Btn_Add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = ".mp3 Combinator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Button Btn_render;
        private System.Windows.Forms.Label info;
    }
}

