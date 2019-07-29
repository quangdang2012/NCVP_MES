using System;

namespace Com.Nidec.Mes.Framework
{

    public class TextBoxCommon:System.Windows.Forms.TextBox
    {

        /// <summary>
        /// enum for inputtype
        /// </summary>
        public enum InputTypeList
        {
            Numeric,
            All
        }

        /// <summary>
        /// set the inputtype as All
        /// </summary>
        private InputTypeList inputType = InputTypeList.All;

        /// <summary>
        /// constructor
        /// </summary>
        public TextBoxCommon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// initialize the control
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextBoxCommon
            // 
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(187, 21);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }

        /// <summary>
        /// get and set the inputtype
        /// </summary>
        public InputTypeList InputType
        {
            get
            { return inputType; }
            set
            { inputType = value; }
        }

         /// <summary>
         /// overrides ongotfocus event
         /// </summary>
         /// <param name="e"></param>
         protected override void OnGotFocus(EventArgs e)
        {
            if (inputType == InputTypeList.Numeric)
            {

                this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                if (this.Text.Length > 0)
                {
                    this.Select(this.Text.Length, 0);
                }
            }
        }
        /// <summary>
        /// overrides onkeydown event for avoid Ctrl + V
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (inputType == InputTypeList.Numeric)
            {
                // if (e.KeyCode == System.Windows.Forms.Keys.V && e.Modifiers == System.Windows.Forms.Keys.Control)
                if (e.Control && e.KeyCode == System.Windows.Forms.Keys.V)
                 {
                    e.SuppressKeyPress = true;
                }
            }
            base.OnKeyDown(e);

        }

        /// <summary>
        /// overrides onkeypress for accepting numeric values
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e) 
        {
            if (inputType == InputTypeList.Numeric)
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;

                }
                if (e.KeyChar == '.')
                { e.Handled = true; }

                base.OnKeyPress(e);
            }
        }
    }
}
