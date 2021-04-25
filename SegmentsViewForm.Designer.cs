
namespace InterSeg
{
    partial class SegmentsViewForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSegmentCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.segmentsBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.segmentsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSegmentCount
            // 
            this.textBoxSegmentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSegmentCount.Location = new System.Drawing.Point(149, 14);
            this.textBoxSegmentCount.Name = "textBoxSegmentCount";
            this.textBoxSegmentCount.Size = new System.Drawing.Size(87, 20);
            this.textBoxSegmentCount.TabIndex = 1;
            this.textBoxSegmentCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество отрезков";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // segmentsBox
            // 
            this.segmentsBox.Location = new System.Drawing.Point(15, 67);
            this.segmentsBox.Name = "segmentsBox";
            this.segmentsBox.Size = new System.Drawing.Size(530, 473);
            this.segmentsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.segmentsBox.TabIndex = 9;
            this.segmentsBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Генерировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SegmentsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSegmentCount);
            this.Controls.Add(this.segmentsBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "SegmentsViewForm";
            this.Text = "Пересечение отрезков";
            this.Load += new System.EventHandler(this.SegmentsViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.segmentsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxSegmentCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox segmentsBox;
        private System.Windows.Forms.Button button1;
    }
}

