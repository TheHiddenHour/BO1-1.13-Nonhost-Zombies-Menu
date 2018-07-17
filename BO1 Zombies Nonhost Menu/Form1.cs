using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using PS3Lib;

namespace BO1_Zombies_Nonhost_Menu
{
    public partial class mainform : Form
    {
        public static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        public static Thread MenuLoop_Thread = new Thread(BO1_Zombies_Nonhost_Menu.Menu.MenuLoop);


        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            
        }

        private void ccapi_radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void tmapi_radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            if(PS3.ConnectTarget())
            {
                MessageBox.Show("Target connected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connect_button.Text = "Connected";
                connect_button.ForeColor = Color.HotPink;

                attach_button.Enabled = true;
            }
            else
                MessageBox.Show("Could not connect to target", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void attach_button_Click(object sender, EventArgs e)
        {
            if (PS3.AttachProcess())
            {
                MessageBox.Show("Process attached!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                attach_button.Text = "Attached";
                attach_button.ForeColor = Color.HotPink;

                startmenu_button.Enabled = true;
            }
            else
                MessageBox.Show("Could not attach to process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void startmenu_button_Click(object sender, EventArgs e)
        {
            try
            {
                startmenu_button.Text = "Menu Started";
                startmenu_button.ForeColor = Color.HotPink;

                BO1_Zombies_Nonhost_Menu.Menu.FPS.Text = "Hold RIGHT to open";
                BO1_Zombies_Nonhost_Menu.Menu.FPS.EnableFPS();

                MenuLoop_Thread.Start();
            }
            catch
            {
                MessageBox.Show("RPC could not be initiated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            PS3.SetMemory(0x00407554, new byte[] { 0x40, 0x9A });//turn off the fps just for consistency
            MenuLoop_Thread.Abort();
        }
    }
}
