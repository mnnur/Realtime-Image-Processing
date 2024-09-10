namespace UAS
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            btn_start_camera = new Button();
            btn_stop_camera = new Button();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            cb_select_effect = new ComboBox();
            btn_add_effect = new Button();
            btn_remove_effect = new Button();
            btn_geometric_effetcs = new Button();
            lb_effect = new ListBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            cb_select_camera = new ComboBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label2 = new Label();
            cb_select_resolution = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(9, 15);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(480, 360);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btn_start_camera
            // 
            btn_start_camera.Location = new Point(3, 3);
            btn_start_camera.Name = "btn_start_camera";
            btn_start_camera.Size = new Size(162, 23);
            btn_start_camera.TabIndex = 1;
            btn_start_camera.Text = "Start Camera";
            btn_start_camera.UseVisualStyleBackColor = true;
            btn_start_camera.Click += Btn_Camera_Start;
            // 
            // btn_stop_camera
            // 
            btn_stop_camera.Location = new Point(3, 32);
            btn_stop_camera.Name = "btn_stop_camera";
            btn_stop_camera.Size = new Size(162, 23);
            btn_stop_camera.TabIndex = 2;
            btn_stop_camera.Text = "Stop Camera";
            btn_stop_camera.UseVisualStyleBackColor = true;
            btn_stop_camera.Click += Btn_Stop_Camera;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(flowLayoutPanel4);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(12, 378);
            panel1.Name = "panel1";
            panel1.Size = new Size(486, 238);
            panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(flowLayoutPanel3);
            groupBox1.Controls.Add(lb_effect);
            groupBox1.Location = new Point(6, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 165);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Effects";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(cb_select_effect);
            flowLayoutPanel3.Controls.Add(btn_add_effect);
            flowLayoutPanel3.Controls.Add(btn_remove_effect);
            flowLayoutPanel3.Controls.Add(btn_geometric_effetcs);
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(176, 19);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(124, 123);
            flowLayoutPanel3.TabIndex = 6;
            // 
            // cb_select_effect
            // 
            cb_select_effect.FormattingEnabled = true;
            cb_select_effect.Location = new Point(3, 3);
            cb_select_effect.Name = "cb_select_effect";
            cb_select_effect.Size = new Size(121, 23);
            cb_select_effect.TabIndex = 3;
            // 
            // btn_add_effect
            // 
            btn_add_effect.Location = new Point(3, 32);
            btn_add_effect.Name = "btn_add_effect";
            btn_add_effect.Size = new Size(121, 23);
            btn_add_effect.TabIndex = 1;
            btn_add_effect.Text = "Add Effect";
            btn_add_effect.UseVisualStyleBackColor = true;
            btn_add_effect.Click += Btn_Add_Effect;
            // 
            // btn_remove_effect
            // 
            btn_remove_effect.Location = new Point(3, 61);
            btn_remove_effect.Name = "btn_remove_effect";
            btn_remove_effect.Size = new Size(121, 23);
            btn_remove_effect.TabIndex = 2;
            btn_remove_effect.Text = "Remove Effect";
            btn_remove_effect.UseVisualStyleBackColor = true;
            btn_remove_effect.Click += Btn_Remove_Effect;
            // 
            // btn_geometric_effetcs
            // 
            btn_geometric_effetcs.Location = new Point(3, 90);
            btn_geometric_effetcs.Name = "btn_geometric_effetcs";
            btn_geometric_effetcs.Size = new Size(121, 23);
            btn_geometric_effetcs.TabIndex = 4;
            btn_geometric_effetcs.Text = "Geometric Effects";
            btn_geometric_effetcs.UseVisualStyleBackColor = true;
            btn_geometric_effetcs.Click += btn_geometric_effetcs_Click;
            // 
            // lb_effect
            // 
            lb_effect.FormattingEnabled = true;
            lb_effect.ItemHeight = 15;
            lb_effect.Location = new Point(3, 19);
            lb_effect.Name = "lb_effect";
            lb_effect.Size = new Size(167, 124);
            lb_effect.TabIndex = 6;
            lb_effect.DoubleClick += lb_effect_DoubleClick;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(cb_select_camera);
            flowLayoutPanel2.Location = new Point(6, 6);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(306, 30);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Margin = new Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 4;
            label1.Text = "Camera";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cb_select_camera
            // 
            cb_select_camera.FormattingEnabled = true;
            cb_select_camera.Location = new Point(57, 3);
            cb_select_camera.Name = "cb_select_camera";
            cb_select_camera.Size = new Size(243, 23);
            cb_select_camera.TabIndex = 3;
            cb_select_camera.SelectedValueChanged += cb_select_camera_SelectedValueChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(label2);
            flowLayoutPanel4.Controls.Add(cb_select_resolution);
            flowLayoutPanel4.Location = new Point(6, 38);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(306, 30);
            flowLayoutPanel4.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 6);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 4;
            label2.Text = "Resolution";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cb_select_resolution
            // 
            cb_select_resolution.FormattingEnabled = true;
            cb_select_resolution.Location = new Point(72, 3);
            cb_select_resolution.Name = "cb_select_resolution";
            cb_select_resolution.Size = new Size(228, 23);
            cb_select_resolution.TabIndex = 3;
            cb_select_resolution.SelectedValueChanged += cb_select_resolution_SelectedValueChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btn_start_camera);
            flowLayoutPanel1.Controls.Add(btn_stop_camera);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(312, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(171, 58);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 603);
            Controls.Add(panel1);
            Controls.Add(pictureBox);
            Name = "MainForm";
            Text = "140810210058 - Muhammad Naufal Nur Ramadhan";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button btn_start_camera;
        private Button btn_stop_camera;
        private Panel panel1;
        private GroupBox groupBox1;
        private ListBox lb_effect;
        private ComboBox cb_select_camera;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btn_add_effect;
        private Button btn_remove_effect;
        private ComboBox cb_select_effect;
        private Button btn_geometric_effetcs;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label2;
        private ComboBox cb_select_resolution;
    }
}
