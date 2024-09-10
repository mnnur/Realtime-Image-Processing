namespace UAS
{
    partial class GeometricEffectsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            nud_translate_x = new NumericUpDown();
            nud_translate_y = new NumericUpDown();
            nud_rotate = new NumericUpDown();
            nud_scale_y = new NumericUpDown();
            chkb_reflect_x = new CheckBox();
            chkb_reflect_y = new CheckBox();
            btn_confirm = new Button();
            btn_cancel = new Button();
            label5 = new Label();
            nud_scale_x = new NumericUpDown();
            cb_interpolation = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_translate_x).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_translate_y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_rotate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_scale_y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_scale_x).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(nud_translate_x, 1, 0);
            tableLayoutPanel1.Controls.Add(nud_translate_y, 2, 0);
            tableLayoutPanel1.Controls.Add(nud_rotate, 2, 1);
            tableLayoutPanel1.Controls.Add(nud_scale_y, 2, 2);
            tableLayoutPanel1.Controls.Add(chkb_reflect_x, 1, 3);
            tableLayoutPanel1.Controls.Add(chkb_reflect_y, 2, 3);
            tableLayoutPanel1.Controls.Add(btn_confirm, 0, 5);
            tableLayoutPanel1.Controls.Add(btn_cancel, 2, 5);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(nud_scale_x, 1, 2);
            tableLayoutPanel1.Controls.Add(cb_interpolation, 1, 4);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(353, 182);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(32, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 30);
            label1.TabIndex = 0;
            label1.Text = "Translate";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(38, 30);
            label2.Name = "label2";
            label2.Size = new Size(41, 30);
            label2.TabIndex = 1;
            label2.Text = "Rotate";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(41, 60);
            label3.Name = "label3";
            label3.Size = new Size(34, 30);
            label3.TabIndex = 2;
            label3.Text = "Scale";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(37, 90);
            label4.Name = "label4";
            label4.Size = new Size(43, 30);
            label4.TabIndex = 3;
            label4.Text = "Reflect";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nud_translate_x
            // 
            nud_translate_x.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nud_translate_x.Location = new Point(120, 3);
            nud_translate_x.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nud_translate_x.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            nud_translate_x.Name = "nud_translate_x";
            nud_translate_x.Size = new Size(111, 23);
            nud_translate_x.TabIndex = 5;
            // 
            // nud_translate_y
            // 
            nud_translate_y.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nud_translate_y.Location = new Point(238, 3);
            nud_translate_y.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nud_translate_y.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            nud_translate_y.Name = "nud_translate_y";
            nud_translate_y.Size = new Size(111, 23);
            nud_translate_y.TabIndex = 6;
            // 
            // nud_rotate
            // 
            nud_rotate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nud_rotate.Location = new Point(237, 33);
            nud_rotate.Maximum = new decimal(new int[] { 359, 0, 0, 0 });
            nud_rotate.Minimum = new decimal(new int[] { 359, 0, 0, int.MinValue });
            nud_rotate.Name = "nud_rotate";
            nud_rotate.Size = new Size(113, 23);
            nud_rotate.TabIndex = 1;
            // 
            // nud_scale_y
            // 
            nud_scale_y.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nud_scale_y.DecimalPlaces = 1;
            nud_scale_y.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_scale_y.Location = new Point(237, 63);
            nud_scale_y.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            nud_scale_y.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_scale_y.Name = "nud_scale_y";
            nud_scale_y.Size = new Size(113, 23);
            nud_scale_y.TabIndex = 8;
            nud_scale_y.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkb_reflect_x
            // 
            chkb_reflect_x.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            chkb_reflect_x.AutoSize = true;
            chkb_reflect_x.Location = new Point(159, 93);
            chkb_reflect_x.Name = "chkb_reflect_x";
            chkb_reflect_x.Size = new Size(33, 24);
            chkb_reflect_x.TabIndex = 9;
            chkb_reflect_x.Text = "X";
            chkb_reflect_x.UseVisualStyleBackColor = true;
            // 
            // chkb_reflect_y
            // 
            chkb_reflect_y.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            chkb_reflect_y.AutoSize = true;
            chkb_reflect_y.Location = new Point(277, 93);
            chkb_reflect_y.Name = "chkb_reflect_y";
            chkb_reflect_y.Size = new Size(33, 24);
            chkb_reflect_y.TabIndex = 10;
            chkb_reflect_y.Text = "Y";
            chkb_reflect_y.UseVisualStyleBackColor = true;
            // 
            // btn_confirm
            // 
            btn_confirm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_confirm.Location = new Point(3, 153);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(111, 26);
            btn_confirm.TabIndex = 4;
            btn_confirm.Text = "Confirm";
            btn_confirm.UseVisualStyleBackColor = true;
            btn_confirm.Click += btn_confirm_click;
            // 
            // btn_cancel
            // 
            btn_cancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_cancel.Location = new Point(238, 153);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(111, 26);
            btn_cancel.TabIndex = 7;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Location = new Point(21, 120);
            label5.Name = "label5";
            label5.Size = new Size(75, 30);
            label5.TabIndex = 11;
            label5.Text = "Interpolation";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nud_scale_x
            // 
            nud_scale_x.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nud_scale_x.DecimalPlaces = 1;
            nud_scale_x.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_scale_x.Location = new Point(120, 63);
            nud_scale_x.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            nud_scale_x.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            nud_scale_x.Name = "nud_scale_x";
            nud_scale_x.Size = new Size(111, 23);
            nud_scale_x.TabIndex = 13;
            nud_scale_x.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cb_interpolation
            // 
            tableLayoutPanel1.SetColumnSpan(cb_interpolation, 2);
            cb_interpolation.FormattingEnabled = true;
            cb_interpolation.Items.AddRange(new object[] { "Nearest Neighbor", "Bilinear", "High Quality Bilinear", "High Quality Bicubic" });
            cb_interpolation.Location = new Point(120, 123);
            cb_interpolation.Name = "cb_interpolation";
            cb_interpolation.Size = new Size(229, 23);
            cb_interpolation.TabIndex = 12;
            // 
            // GeometricEffectsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(381, 205);
            Controls.Add(tableLayoutPanel1);
            Name = "GeometricEffectsForm";
            Text = "Geometric Effects";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_translate_x).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_translate_y).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_rotate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_scale_y).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_scale_x).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown nud_translate_x;
        private NumericUpDown nud_translate_y;
        private NumericUpDown nud_rotate;
        private NumericUpDown nud_scale_y;
        private CheckBox chkb_reflect_x;
        private CheckBox chkb_reflect_y;
        private Button btn_confirm;
        private Button btn_cancel;
        private Label label5;
        private ComboBox cb_interpolation;
        private NumericUpDown nud_scale_x;
    }
}