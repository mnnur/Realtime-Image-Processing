using System.Diagnostics;

namespace UAS
{
    public partial class DialogForm : Form
    {
        private int parameterNum;
        public List<Decimal> parameterList = new List<Decimal>();
        public Bitmap? img;
        public string imagePath;
        private List<NumericUpDown> numericUpDowns = new List<NumericUpDown>();
        private int frameWidth, frameHeight;
        bool fileInput = false;

        public DialogForm()
        {
            InitializeComponent();
        }

        public void CreateCrossFadingDialog(String name, String lbl, int imgWidth, int imgHeight)
        {
            this.Text = name;
            this.frameHeight = imgHeight;
            this.frameWidth = imgWidth;
            this.fileInput = true;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.ColumnCount = 2;
            Controls.Add(tableLayoutPanel);

            Label label = new Label();
            label.Text = lbl;
            label.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(label, 0, 1);
            tableLayoutPanel.SetColumnSpan(label, 2);

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Width = 100;
            numericUpDown.Dock = DockStyle.Fill;
            numericUpDown.Maximum = 1;
            numericUpDown.Minimum = 0;
            numericUpDown.Increment = 0.01M;
            numericUpDown.DecimalPlaces = 2;

            tableLayoutPanel.Controls.Add(numericUpDown, 0, 2);
            tableLayoutPanel.SetColumnSpan(numericUpDown, 2);
            numericUpDowns.Add(numericUpDown);

            Button button = new Button();
            button.Width = 100;
            button.Dock = DockStyle.Fill;
            button.Text = "Open Image";

            tableLayoutPanel.Controls.Add(button, 0, 3);
            tableLayoutPanel.SetColumnSpan(button, 2);
            button.Click += OpenImage;

            Button btnConfirm = new Button();
            btnConfirm.Text = "Confirm";
            btnConfirm.MaximumSize = new Size(int.MaxValue, 30);
            btnConfirm.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(btnConfirm, 0, 4);

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.MaximumSize = new Size(int.MaxValue, 30);
            btnCancel.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(btnCancel, 1, 4);

            // Set button click event handlers
            btnConfirm.Click += Btn_Confirm_Click;
            btnCancel.Click += Btn_Cancel_Click;


            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Padding = new Padding(10);
        }

        public DialogForm(String name, String[] input, bool fileInput = false, int imgWidth = 0, int imgHeight = 0)
        {
            InitializeComponent();
            this.Text = name;
            this.parameterNum = input.Length;
            this.frameHeight = imgHeight;
            this.frameWidth = imgWidth;
            this.fileInput = fileInput;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = (parameterNum * 2) + 1;
            tableLayoutPanel.ColumnCount = 2;
            Controls.Add(tableLayoutPanel);

            int row = 0;
            for (int i = 0; i < parameterNum; i++)
            {
                Label label = new Label();
                label.Text = input[i];
                label.Dock = DockStyle.Fill;
                tableLayoutPanel.Controls.Add(label, 0, row);
                tableLayoutPanel.SetColumnSpan(label, 2);
                row++;

                if (fileInput)
                {
                    Button button = new Button();
                    button.Width = 100;
                    button.Dock = DockStyle.Fill;
                    button.Text = "Open Image";

                    tableLayoutPanel.Controls.Add(button, 0, row);
                    tableLayoutPanel.SetColumnSpan(button, 2);
                    button.Click += OpenImage;
                }
                else
                {
                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Width = 100;
                    numericUpDown.Dock = DockStyle.Fill;
                    numericUpDown.Maximum = 255;

                    tableLayoutPanel.Controls.Add(numericUpDown, 0, row);
                    tableLayoutPanel.SetColumnSpan(numericUpDown, 2);
                    numericUpDowns.Add(numericUpDown);
                }

                row++;
            }

            Button btnConfirm = new Button();
            btnConfirm.Text = "Confirm";
            btnConfirm.MaximumSize = new Size(int.MaxValue, 30);
            btnConfirm.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(btnConfirm, 0, row);

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.MaximumSize = new Size(int.MaxValue, 30);
            btnCancel.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(btnCancel, 1, row);

            // Set button click event handlers
            btnConfirm.Click += Btn_Confirm_Click;
            btnCancel.Click += Btn_Cancel_Click;


            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Padding = new Padding(10);
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            foreach (NumericUpDown numericUpDown in numericUpDowns)
            {
                parameterList.Add(numericUpDown.Value);
            }

            if (fileInput)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OpenImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;

                Image image = Image.FromFile(imagePath);

                img = new Bitmap(image, frameWidth, frameHeight);

                foreach (NumericUpDown numericUpDown in numericUpDowns)
                {
                    parameterList.Add(numericUpDown.Value);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
