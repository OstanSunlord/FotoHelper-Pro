using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoHelper_Pro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MinimumSize = new Size(this.Width, this.Height);
            MaximumSize = new Size(this.Width, this.Height*2);
        }

        private void btn_OrganizeMyPhotos_Click(object sender, EventArgs e)
        {
            new OrganizeMyPhotosCommand().Execute();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_TagFilesAndFolder_Click(object sender, EventArgs e)
        {
            new TagFilesandFolderCommand().Execute();
        }

        private Button CreateButton(string text, EventHandler onClickHandler)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = false,
              //  Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Width = 100,
                Margin = new Padding(5),
                Height = 100,
                Left = 0,
                FlatStyle = FlatStyle.System,
                Dock = DockStyle.Top,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size + 2)
            };
            button.Click += onClickHandler;
            return button;
        }
    }
}
