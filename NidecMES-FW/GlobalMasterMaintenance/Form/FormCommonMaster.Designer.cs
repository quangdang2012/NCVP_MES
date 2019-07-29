namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class FormCommonMaster:  Framework.FormCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommonMaster));
            this.SuspendLayout();
            // 
            // FormCommonMaster
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "FormCommonMaster";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCommonMaster_FormClosed);
            this.Load += new System.EventHandler(this.FormCommonMaster_Load);
            this.ResumeLayout(false);

        }

        #endregion

    }
}