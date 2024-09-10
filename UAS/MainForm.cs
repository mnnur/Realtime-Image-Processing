using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace UAS
{
    public partial class MainForm : Form
    {
        private FilterInfoCollection? webCams;
        private VideoCaptureDevice? camera;
        private Bitmap? frame;
        private List<EffectStruct> effects;
        private Graphics graphics;
        List<Size> captureResoultions = new List<Size>();
        int newWidth;
        int newHeight;
        int captureWidth;
        int captureHeight;
        double imageAspectRatio;
        int newStartLocX;
        int newStartLocY;
        Rectangle frameRect;
        Font watermarkFont = new Font("Arial", 12);
        SolidBrush watermarkBrush = new SolidBrush(Color.Black);

        public MainForm()
        {
            InitializeComponent();
            InitCamera();
            cb_select_effect.DataSource = Enum.GetValues(typeof(ImageOperation));
            cb_select_effect.SelectedIndex = 0;
            effects = [];
            graphics = pictureBox.CreateGraphics();
            newWidth = pictureBox.Width;
            newHeight = pictureBox.Height;
        }

        private void InitCamera()
        {
            webCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo camera in webCams)
            {
                cb_select_camera.Items.Add(camera.Name);
            }
            cb_select_camera.SelectedIndex = 0;
        }

        void Camera_ProcessFrame(object sender, NewFrameEventArgs eventArgs)
        {
            frame = (Bitmap)eventArgs.Frame.Clone();
            ApplyEffects(ref frame);

            graphics.DrawImage(frame, frameRect);
            graphics.DrawString("mnnur", watermarkFont, watermarkBrush, newStartLocX, newStartLocY);
        }

        void ApplyEffects(ref Bitmap img)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                EffectStruct effect = effects[i];
                Bitmap? targetBitmap = effect.FrameTarget;
                switch (effect.ImageOperation)
                {
                    case ImageOperation.Brightness:
                        PointOperation.Brightness(ref img, effect.BrightnessVal);
                        break;
                    case ImageOperation.Invert:
                        PointOperation.Invert(ref img);
                        break;
                    case ImageOperation.Grayscale:
                        PointOperation.Grayscale(ref img);
                        break;
                    case ImageOperation.Threshold:
                        PointOperation.Thresholding(ref img, effect.ThresholdVal);
                        break;
                    case ImageOperation.Blurring:
                        AreaOperation.Blurring(ref img, effect.BlurVal);
                        break;
                    case ImageOperation.Sharpening:
                        AreaOperation.Sharpen(ref img, effect.SharpenVal);
                        break;
                    case ImageOperation.Embossing:
                        AreaOperation.Emboss(ref img);
                        break;
                    case ImageOperation.Edging:
                        AreaOperation.Edge(ref img);
                        break;
                    case ImageOperation.Add:
                        FrameOperation.AddFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Subtract:
                        FrameOperation.SubtractFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Difference:
                        FrameOperation.DifferenceFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Multiply:
                        FrameOperation.MultiplyFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Average:
                        FrameOperation.AverageFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.CrossFading:
                        FrameOperation.CrossFadingFrame(ref img, ref targetBitmap, effect.CrossFadeWeigth);
                        break;
                    case ImageOperation.Min:
                        FrameOperation.MinFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Max:
                        FrameOperation.MaxFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Amplitude:
                        FrameOperation.AmplitudeFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.And:
                        FrameOperation.ANDFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Or:
                        FrameOperation.ORFrame(ref img, ref targetBitmap);
                        break;
                    case ImageOperation.Xor:
                        FrameOperation.XORFrame(ref img, ref targetBitmap);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Btn_Camera_Start(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            if (cb_select_camera.SelectedIndex >= 0 && webCams != null)
            {
                StopCamera();
                RecalculateEffects();
                camera = new VideoCaptureDevice(webCams[cb_select_camera.SelectedIndex].MonikerString)
                {
                    VideoResolution = new VideoCaptureDevice(webCams[cb_select_camera.SelectedIndex].MonikerString).VideoCapabilities[cb_select_resolution.SelectedIndex]
                };
                camera.NewFrame += new NewFrameEventHandler(Camera_ProcessFrame);
                // Maintain aspect ratio
                imageAspectRatio = (double)captureWidth / captureHeight;
                if (newWidth / (double)newHeight > imageAspectRatio)
                {
                    newWidth = (int)(newHeight * imageAspectRatio);
                }
                else
                {
                    newHeight = (int)(newWidth / imageAspectRatio);
                }
                newStartLocX = (pictureBox.Width - newWidth) / 2;
                newStartLocY = (pictureBox.Height - newHeight) / 2;
                frameRect = new Rectangle(newStartLocX, newStartLocY, newWidth, newHeight);
                camera.Start();
            }
        }

        private void RecalculateEffects()
        {
            if (effects.Count > 0)
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    EffectStruct effect = effects[i];
                    if (effect.FrameTarget != null)
                    {
                        effect.FrameTarget = new Bitmap(effect.FrameTarget, captureWidth, captureHeight);
                    }
                    effects[i] = effect;
                }
            }
        }

        private void Btn_Stop_Camera(object sender, EventArgs e)
        {
            StopCamera();
        }

        private void StopCamera()
        {
            if (camera != null)
            {
                camera.SignalToStop();
                camera.WaitForStop();
                camera.NewFrame -= new NewFrameEventHandler(Camera_ProcessFrame);
                camera.Stop();
                camera = null;
                pictureBox.Image = null;
                graphics.ResetTransform();
                graphics.Clear(Color.White);
                newWidth = pictureBox.Width;
                newHeight = pictureBox.Height;
            }
        }

        private void Btn_Add_Effect(object sender, EventArgs e)
        {
            int selectedIndex = cb_select_effect.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < Enum.GetValues(typeof(ImageOperation)).Length)
            {
                ImageOperation selectedEffect = (ImageOperation)Enum.ToObject(typeof(ImageOperation), selectedIndex);
                EffectStruct effectStruct = new EffectStruct();
                DialogForm? dialogForm;
                switch (selectedEffect)
                {
                    case ImageOperation.Brightness:
                        dialogForm = new DialogForm("Brightness Parameter", ["Brightness Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Brightness, val: {dialogForm.parameterList[0]}");
                            effectStruct.ImageOperation = ImageOperation.Brightness;
                            effectStruct.BrightnessVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Invert:
                        lb_effect.Items.Add($"Invert");
                        effectStruct.ImageOperation = ImageOperation.Invert;
                        effects.Add(effectStruct);
                        break;
                    case ImageOperation.Grayscale:
                        lb_effect.Items.Add($"Grayscale");
                        effectStruct.ImageOperation = ImageOperation.Grayscale;
                        effects.Add(effectStruct);
                        break;
                    case ImageOperation.Threshold:
                        dialogForm = new DialogForm("Threshold Parameter", ["Threshold Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Threshold, val: {dialogForm.parameterList[0]}");
                            effectStruct.ImageOperation = ImageOperation.Threshold;
                            effectStruct.ThresholdVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Blurring:
                        dialogForm = new DialogForm("Blur Parameter", ["Blur Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Blur, Val: {dialogForm.parameterList[0]}");
                            effectStruct.ImageOperation = ImageOperation.Blurring;
                            effectStruct.BlurVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Sharpening:
                        dialogForm = new DialogForm("Sharpening Parameter", ["Sharpening Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Sharpening, Val: {dialogForm.parameterList[0]}");
                            effectStruct.ImageOperation = ImageOperation.Sharpening;
                            effectStruct.SharpenVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Embossing:
                        lb_effect.Items.Add($"Embossing");
                        effectStruct.ImageOperation = ImageOperation.Embossing;
                        effects.Add(effectStruct);
                        break;
                    case ImageOperation.Edging:
                        lb_effect.Items.Add($"Edge");
                        effectStruct.ImageOperation = ImageOperation.Edging;
                        effects.Add(effectStruct);
                        break;
                    case ImageOperation.Add:
                        dialogForm = new DialogForm("Frame Add Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Add, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Add;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Subtract:
                        dialogForm = new DialogForm("Frame Subtract Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Subtract, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Subtract;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Difference:
                        dialogForm = new DialogForm("Frame Difference Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Difference, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Difference;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Multiply:
                        dialogForm = new DialogForm("Frame Multiply Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Multiply, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Multiply;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Average:
                        dialogForm = new DialogForm("Frame Average Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Average, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Average;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.CrossFading:
                        dialogForm = new DialogForm();
                        dialogForm.CreateCrossFadingDialog("Frame Cross Fading Parameter", "Weigth", captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"CrossFading, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.CrossFading;
                            effectStruct.FrameTarget = dialogForm.img;
                            effectStruct.CrossFadeWeigth = Convert.ToDouble(dialogForm.parameterList[0]);
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Min:
                        dialogForm = new DialogForm("Frame Min Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Min, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Min;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Max:
                        dialogForm = new DialogForm("Frame Max Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Max, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Max;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Amplitude:
                        dialogForm = new DialogForm("Frame Amplitude Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Amplitude, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Amplitude;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.And:
                        dialogForm = new DialogForm("Frame And Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"And, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.And;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Or:
                        dialogForm = new DialogForm("Frame Or Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Or, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Or;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    case ImageOperation.Xor:
                        dialogForm = new DialogForm("Frame Xor Parameter", ["Select image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items.Add($"Xor, path: {dialogForm.imagePath}");
                            effectStruct.ImageOperation = ImageOperation.Xor;
                            effectStruct.FrameTarget = dialogForm.img;
                            effects.Add(effectStruct);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void Btn_Remove_Effect(object sender, EventArgs e)
        {
            if (lb_effect.SelectedIndex >= 0)
            {
                effects.RemoveAt(lb_effect.SelectedIndex);
                lb_effect.Items.RemoveAt(lb_effect.SelectedIndex);
            }
        }

        private void lb_effect_DoubleClick(object sender, EventArgs e)
        {
            if (lb_effect.SelectedIndex >= 0)
            {
                EffectStruct effectStruct = effects[lb_effect.SelectedIndex];
                DialogForm? dialogForm;
                switch (effectStruct.ImageOperation)
                {
                    case ImageOperation.Brightness:
                        dialogForm = new DialogForm("Edit Brightness Parameter", ["Brightness Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Brightness, val: {dialogForm.parameterList[0]}";
                            effectStruct.BrightnessVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Threshold:
                        dialogForm = new DialogForm("Edit Threshold Parameter", ["Threshold Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Threshold, val: {dialogForm.parameterList[0]}";
                            effectStruct.ThresholdVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Blurring:
                        dialogForm = new DialogForm("Edit Blur Parameter", ["Blur Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Blur, Val: {dialogForm.parameterList[0]}";
                            effectStruct.BlurVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Sharpening:
                        dialogForm = new DialogForm("Edit Sharpening Parameter", ["Sharpening Value"]);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Sharpening, Val: {dialogForm.parameterList[0]}";
                            effectStruct.SharpenVal = Convert.ToInt32(dialogForm.parameterList[0]);
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Add:
                        dialogForm = new DialogForm("Edit Frame add Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Add, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Subtract:
                        dialogForm = new DialogForm("Edit Frame Subtract Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Subtract, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Difference:
                        dialogForm = new DialogForm("Edit Frame Difference Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Difference, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Multiply:
                        dialogForm = new DialogForm("Edit Frame Multiply Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Multiply, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Average:
                        dialogForm = new DialogForm("Edit Frame Average Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Average, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.CrossFading:
                        dialogForm = new DialogForm();
                        dialogForm.CreateCrossFadingDialog("Frame Cross Fading Parameter", "Weigth", captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"CrossFading, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effectStruct.CrossFadeWeigth = Convert.ToDouble(dialogForm.parameterList[0]);
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Min:
                        dialogForm = new DialogForm("Edit Frame Min Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Min, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Max:
                        dialogForm = new DialogForm("Edit Frame Max Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Max, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Amplitude:
                        dialogForm = new DialogForm("Edit Frame Amplitude Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Amplitude, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.And:
                        dialogForm = new DialogForm("Edit Frame And Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"And, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Or:
                        dialogForm = new DialogForm("Edit Frame Or Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Or, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    case ImageOperation.Xor:
                        dialogForm = new DialogForm("Edit Frame Xor Parameter", ["Open Image"], true, captureWidth, captureHeight);
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.OK)
                        {
                            lb_effect.Items[lb_effect.SelectedIndex] = $"Xor, Path: {dialogForm.imagePath}";
                            effectStruct.FrameTarget = dialogForm.img;
                            effects[lb_effect.SelectedIndex] = effectStruct;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void setInterpolationMode(int selection)
        {
            switch (selection)
            {
                case 0:
                    graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    break;
                case 1:
                    graphics.InterpolationMode = InterpolationMode.Bilinear;
                    break;
                case 2:
                    graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    break;
                case 3:
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    break;
                default:
                    break;
            }
        }

        private void btn_geometric_effetcs_Click(object sender, EventArgs e)
        {
            GeometricEffectsForm dialog = new GeometricEffectsForm();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                graphics.ResetTransform();
                graphics.Clear(Color.White);
                setInterpolationMode(dialog.interpolationMode);
                graphics.TranslateTransform(dialog.translateX, dialog.translateY);
                graphics.RotateTransform(dialog.rotationAngle);
                graphics.ScaleTransform(dialog.scaleX, dialog.scaleY);
                if (dialog.reflectX)
                {
                    Matrix matrix = new Matrix(1, 0, 0, -1, 0, 0);
                    graphics.MultiplyTransform(matrix);
                }
                if (dialog.reflectY)
                {
                    Matrix matrix = new Matrix(-1, 0, 0, 1, 0, 0);
                    graphics.MultiplyTransform(matrix);
                }
            }
        }

        private void cb_select_camera_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_select_camera.SelectedIndex >= 0 && webCams != null)
            {
                camera = new VideoCaptureDevice(webCams[cb_select_camera.SelectedIndex].MonikerString);
                captureResoultions.Clear();
                cb_select_resolution.Items.Clear();
                for (int i = 0; i < camera.VideoCapabilities.Length; i++)
                {
                    string resolution_size = camera.VideoCapabilities[i].FrameSize.ToString();
                    captureResoultions.Add(
                        new Size(
                            camera.VideoCapabilities[i].FrameSize.Width,
                            camera.VideoCapabilities[i].FrameSize.Height
                            )
                        );
                    cb_select_resolution.Items.Add(resolution_size);
                }
                cb_select_resolution.SelectedIndex = 0;
            }
        }

        private void cb_select_resolution_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_select_resolution.SelectedIndex >= 0 && camera != null)
            {
                captureWidth = captureResoultions[cb_select_resolution.SelectedIndex].Width;
                captureHeight = captureResoultions[cb_select_resolution.SelectedIndex].Height;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
    }
}
