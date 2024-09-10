namespace UAS
{
    public partial class GeometricEffectsForm : Form
    {
        public int translateX = 0;
        public int translateY = 0;
        public int rotationAngle = 0;
        public float scaleX = 1.0f;
        public float scaleY = 1.0f;
        public bool reflectX = false;
        public bool reflectY = false;
        public int interpolationMode = 0;

        public GeometricEffectsForm()
        {
            InitializeComponent();
            cb_interpolation.SelectedIndex = 0;
        }

        private void btn_confirm_click(object sender, EventArgs e)
        {
            translateX = Convert.ToInt32(nud_translate_x.Value);
            translateY = Convert.ToInt32(nud_translate_y.Value);
            rotationAngle = Convert.ToInt32(nud_rotate.Value);
            scaleX = (float)nud_scale_x.Value;
            scaleY = (float)nud_scale_y.Value;
            reflectX = chkb_reflect_x.Checked;
            reflectY = chkb_reflect_y.Checked;
            interpolationMode = cb_interpolation.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
