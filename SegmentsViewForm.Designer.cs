
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
            this.intersectionColor = new System.Windows.Forms.Button();
            this.segmentColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridSegment = new System.Windows.Forms.DataGridView();
            this.dataGridIntersection = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.segmentsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIntersection)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSegmentCount
            // 
            this.textBoxSegmentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSegmentCount.Location = new System.Drawing.Point(149, 14);
            this.textBoxSegmentCount.Name = "textBoxSegmentCount";
            this.textBoxSegmentCount.Size = new System.Drawing.Size(87, 20);
            this.textBoxSegmentCount.TabIndex = 1;
            this.textBoxSegmentCount.Text = "5";
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
            this.segmentsBox.Location = new System.Drawing.Point(12, 168);
            this.segmentsBox.Name = "segmentsBox";
            this.segmentsBox.Size = new System.Drawing.Size(766, 522);
            this.segmentsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.segmentsBox.TabIndex = 9;
            this.segmentsBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Генерировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // intersectionColor
            // 
            this.intersectionColor.BackColor = System.Drawing.SystemColors.Highlight;
            this.intersectionColor.Location = new System.Drawing.Point(149, 40);
            this.intersectionColor.Name = "intersectionColor";
            this.intersectionColor.Size = new System.Drawing.Size(89, 23);
            this.intersectionColor.TabIndex = 11;
            this.intersectionColor.UseVisualStyleBackColor = false;
            this.intersectionColor.Click += new System.EventHandler(this.intersection_Click);
            // 
            // segmentColor
            // 
            this.segmentColor.BackColor = System.Drawing.SystemColors.GrayText;
            this.segmentColor.Location = new System.Drawing.Point(149, 69);
            this.segmentColor.Name = "segmentColor";
            this.segmentColor.Size = new System.Drawing.Size(89, 23);
            this.segmentColor.TabIndex = 12;
            this.segmentColor.UseVisualStyleBackColor = false;
            this.segmentColor.Click += new System.EventHandler(this.segmentColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Цвет пересечений";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Цвет отрезков";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridSegment
            // 
            this.dataGridSegment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSegment.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridSegment.Location = new System.Drawing.Point(244, 12);
            this.dataGridSegment.Name = "dataGridSegment";
            this.dataGridSegment.Size = new System.Drawing.Size(264, 150);
            this.dataGridSegment.TabIndex = 15;
            // 
            // dataGridIntersection
            // 
            this.dataGridIntersection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIntersection.Location = new System.Drawing.Point(514, 12);
            this.dataGridIntersection.Name = "dataGridIntersection";
            this.dataGridIntersection.Size = new System.Drawing.Size(264, 150);
            this.dataGridIntersection.TabIndex = 16;
            // 
            // SegmentsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 702);
            this.Controls.Add(this.dataGridIntersection);
            this.Controls.Add(this.dataGridSegment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.segmentColor);
            this.Controls.Add(this.intersectionColor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSegmentCount);
            this.Controls.Add(this.segmentsBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(6000, 6000);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "SegmentsViewForm";
            this.Text = "Пересечение отрезков";
            this.Load += new System.EventHandler(this.SegmentsViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.segmentsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIntersection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxSegmentCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox segmentsBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button intersectionColor;
        private System.Windows.Forms.Button segmentColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridSegment;
        private System.Windows.Forms.DataGridView dataGridIntersection;
    }
}

