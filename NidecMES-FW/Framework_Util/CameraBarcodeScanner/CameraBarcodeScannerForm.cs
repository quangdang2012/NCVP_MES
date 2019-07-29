using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using Com.Nidec.Mes.Framework;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.Framework_Util
{
    public partial class CameraBarcodeScannerForm : Form
    {

        #region Variables

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CameraBarcodeScannerForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize backgroundworker
        /// </summary>
        private BackgroundWorker scanBackgroundWorker; // 別スレッドで扱う

        /// <summary>
        /// 
        /// </summary>
        private int WIDTH = 640;

        /// <summary>
        /// 
        /// </summary>
        private int HEIGHT = 480;

        /// <summary>
        /// 
        /// </summary>
        private Mat frame;

        /// <summary>
        /// 
        /// </summary>
        private VideoCapture capture;

        /// <summary>
        /// 
        /// </summary>
        private Bitmap bmp;

        /// <summary>
        /// 
        /// </summary>
        private Graphics graphic;

        #endregion

        public string BarcodeData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public delegate void DelegateBarcodeFormatText();

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public CameraBarcodeScannerForm()
        {
            InitializeComponent();
        }

        #endregion

        #region FormEvents

        /// <summary>
        /// load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraBarcodeScannerForm_Load(object sender, EventArgs e)
        {
            //
            scanBackgroundWorker = new BackgroundWorker(); // インスタンスの生成
            scanBackgroundWorker.WorkerReportsProgress = true; //進捗状況を表示するか？
            scanBackgroundWorker.WorkerSupportsCancellation = true;
            scanBackgroundWorker.DoWork += new DoWorkEventHandler(ScanBackgroundWorker_DoWork); // イベントハンドラにworker_DoWorkを指定
            scanBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ScanBackgroundWorker_ProgressChanged); // イベントハンドラの設定
            scanBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ScanBackgroundWorker_RunWorkerCompleted); // イベントハンドラの設定

            //カメラ画像取得用のVideoCapture作成 //InCamera(0),OutCamera(1)
            capture = new VideoCapture(0);
            capture.AutoFocus = true;

            if (!capture.IsOpened())
            {
                IsCameraIssue = true;
                this.Close();
                return;
            }

            capture.FrameWidth = WIDTH;
            capture.FrameHeight = HEIGHT;

            //取得先のMat作成
            frame = new Mat(HEIGHT, WIDTH, MatType.CV_8UC3);

            //表示用のBitmap作成
            bmp = new Bitmap(frame.Cols, frame.Rows, (int)frame.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, frame.Data);

            //image1を出力サイズに合わせる
            Camera_pbx.Width = frame.Cols;
            Camera_pbx.Height = frame.Rows;

            //描画用のGraphics作成
            graphic = Camera_pbx.CreateGraphics();

            //画像取得スレッド開始
            scanBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraBarcodeScannerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //スレッドの終了を待機
            if (scanBackgroundWorker.WorkerSupportsCancellation == true)
            {
                scanBackgroundWorker.CancelAsync();
                if (capture != null) capture.Dispose();
                if (frame != null) frame.Dispose();
                if (bmp != null) bmp.Dispose();
                if (graphic != null) graphic.Dispose();
                frame = null;
                capture = null;
                graphic = null;
                bmp = null;
            }

            while (scanBackgroundWorker.IsBusy)
                Application.DoEvents();
        }

        #endregion

        #region BackgroundworkerEvents

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            while (!scanBackgroundWorker.CancellationPending)
            {

                // バーコード読み取り
                ZXing.BarcodeReader reader = new ZXing.BarcodeReader();
                reader.AutoRotate = true;
                reader.Options.TryHarder = true;

                //画像取得
                capture.Grab();
                OpenCvSharp.NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(capture.CvPtr, frame.CvPtr);

                // Windows FormsではBitmapを渡す
                ZXing.Result result = reader.Decode(BitmapConverter.ToBitmap(frame.CvtColor(ColorConversionCodes.BGR2GRAY)));

                if (result != null)
                {
                    this.Invoke(new Action<ZXing.Result>(this.UpdateBarcodeFormatText), result);
                }

                bw.ReportProgress(0);
            }
        }

        /// <summary>
        /// This is on the main thread, so we can update a TextBox or anything.
        /// </summary>
        private void ScanBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (bmp == null || frame == null) { return; }
            //描画
            graphic.DrawImage(bmp, 0, 0, frame.Cols, frame.Rows);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public bool IsCameraIssue { get; internal set; }
        /// <summary>
        /// to get scanned barcode data
        /// </summary>
        /// <param name="result"></param>
        private void UpdateBarcodeFormatText(ZXing.Result result)
        {
            BarcodeData = result.Text;
        }


    }
}
