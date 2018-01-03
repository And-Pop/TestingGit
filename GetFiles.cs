using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;

namespace GetFiles
{
    public partial class Recursion : Form
    {
        #region FIELDS
        private List<string> configurationFile = new List<string>
        {
            "[lastFilterLocation]",
            "[lastFileExtensionUsed]",
            "[lastSelectionColor]",
            "[lastSelectionHide]"
        };
        #endregion
        public Recursion()
        {
            InitializeComponent();

            BtnOpenFile.Enabled = false;
            BtnDeleteFile.Enabled = false;

            this.btnFilter.Click -= new System.EventHandler(this.BtnFilter_Click);
            this.btnFilter.Click += new EventHandler(this.CbColored_CheckedChanged);
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);

            // fill in the textbox Directory path and the last file extension used
            tbDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            tbFileType.Text = CfgLastUsed(configurationFile[1]);
            cbColored.Checked = Convert.ToBoolean(CfgLastUsed(configurationFile[2]));

            label3.Text = string.Empty;

            CfgInitiate();
        }
	}
}