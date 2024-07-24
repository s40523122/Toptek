using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class equipStateIndicator : UserControl
    {
        public event EventHandler ButtonClick;

        public equipStateIndicator()
        {
            InitializeComponent();
        }

        public string palletNo
        {
            get
            {
                return lbPalletNo.Text;
            }

            set
            {
                lbPalletNo.Text = value;
            }
        }

        public string mission
        {
            get
            {
                return lbMission.Text;
            }

            set
            {
                lbMission.Text = value;
            }
        }

        public string subid
        {
            get
            {
                return lbSubid.Text;
            }

            set
            {
                lbSubid.Text = value;
            }
        }

        public bool subidVisible
        {
            get
            {
                return lbSubid.Visible;
            }

            set
            {
                lbSubid.Visible = value;
                lbSubidtitle.Visible = value;
            }
        }

        public string moid
        {
            get
            {
                return lbMoid.Text;
            }

            set
            {
                lbMoid.Text = value;
            }
        }

        public bool moidVisible
        {
            get
            {
                return lbMoid.Visible;
            }

            set
            {
                lbMoid.Visible = value;
                lbMOIDtitle.Visible = value;
            }
        }

        public string opid
        {
            get
            {
                return lbOPID.Text;
            }

            set
            {
                lbOPID.Text = value;
            }
        }

        public bool opidVisible
        {
            get
            {
                return lbOPID.Visible;
            }

            set
            {
                lbOPID.Visible = value;
                lbOPIDtitle.Visible = value;
            }
        }

        public System.Drawing.Image icon
        {
            get
            {
                return pbIcon.Image;
            }

            set
            {
                pbIcon.Image = value;
            }
        }

        public string title
        {
            get
            {
                return lbTitle.Text;
            }

            set
            {
                lbTitle.Text = value;
            }
        }

        public string linkStatus
        {
            get
            {
                return btLinkstatus.Text;
            }

            set
            {
                btLinkstatus.Text = value;
            }
        }

        public System.Drawing.Color linkStatusColor
        {
            get
            {
                return btLinkstatus.BackColor;
            }

            set
            {
                btLinkstatus.BackColor = value;
            }
        }

        public string status
        {
            get
            {
                return btStatus.Text;
            }

            set
            {
                btStatus.Text = value;
            }
        }

        public System.Drawing.Color statusColor
        {
            get
            {
                return btStatus.BackColor;
            }

            set
            {
                btStatus.BackColor = value;
            }
        }

        public string mode
        {
            get
            {
                return btMode.Text;
            }

            set
            {
                btMode.Text = value;
            }
        }

        public System.Drawing.Color modeColor
        {
            get
            {
                return btMode.BackColor;
            }

            set
            {
                btMode.BackColor = value;
            }
        }

        private void icon_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
    }
}
