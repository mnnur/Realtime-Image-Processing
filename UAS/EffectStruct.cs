namespace UAS
{
    internal struct EffectStruct
    {
        public ImageOperation ImageOperation { get; set; }

        public int BrightnessVal { get; set; }
        public int ThresholdVal { get; set; }
        public int BlurVal {  get; set; }
        public int SharpenVal { get; set; }
        public int TranslateVal { get; set; }
        public double RotationAngle {  get; set; }
        public double ScaleVal {  get; set; }
        public Bitmap? FrameTarget { get; set; }
        public double CrossFadeWeigth { get; set; }

        public EffectStruct(ImageOperation imageOperation)
        {
            ImageOperation = imageOperation;
            BrightnessVal = 0;
            ThresholdVal = 0;
            BlurVal = 0;
            SharpenVal = 0;
            TranslateVal = 0;
            RotationAngle = 0;
            ScaleVal = 0;
            FrameTarget = null;
            CrossFadeWeigth = 0;
        }
    }
}
