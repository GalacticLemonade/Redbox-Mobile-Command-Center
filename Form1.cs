using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Redbox_Mobile_Command_Center {

    public partial class RedboxMobileCommandCenter : Form {

        static TCPClient client;
        static int NumKiosks = 0;
        static Timer kioskListTimer;
        private List<Button> kioskButtons = new List<Button>();
        int activeKiosk = 0;
        Random random;

        public RedboxMobileCommandCenter() {
            InitializeComponent();

            //AllocConsole();

            try {
                // initialize variables
                InitializeVariables();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            // initialize blanks
            IP_Text.Text = "Connecting...";

            // setup window
            //this.FormBorderStyle = FormBorderStyle.None;  // removes the border
            //this.WindowState = FormWindowState.Maximized;  // maximizes the window
            //this.TopMost = true;  // makes the form always on top

            // get local ip
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);
            IPAddress ipv4Address = ip.AddressList.FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            if (ipv4Address != null) {
                Console.WriteLine(ipv4Address.ToString());
                IP_Text.Text = ipv4Address.ToString();

            }
            else {
                Console.WriteLine("No IPv4 address found.");
                return;
            }

            // initialize buttons
            /*
            kioskListTimer = new Timer {
                Interval = 5000
            };

            kioskListTimer.Tick += KioskListTimer_Tick;
            kioskListTimer.Start();
            */
        }

        private void SwitchToKioskPanel(string KioskID) {
            GenericKioskPanel.Visible = true;
            GenericKioskPanel.Enabled = true;

            MainMenuPanel.Visible = false;

            GKPTitle.Text = "Kiosk " + KioskID;
        }

        private async void GenericKioskButton(string KioskID) {

            if (activeKiosk == Int32.Parse(KioskID)) {
                SwitchToKioskPanel(KioskID);
                return;
            }

            await client.SendMessageAsync("switch-to-kiosk " + KioskID);

            string response = await client.ReceiveMessageAsync();
            if (response != "200") {
                Console.WriteLine("Error!");
            } else {
                Console.WriteLine("Switched to kiosk " + KioskID);
                activeKiosk = Int32.Parse(KioskID);

                SwitchToKioskPanel(KioskID);
                //await client.SendMessageAsync("execute-kiosk-command move-to-slot 52 8");
            }
        }

        private void RunDOSCommand(string command) {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;
            process.Start();
        }

        /*
        private async void KioskListTimer_Tick(object sender, EventArgs e) {
            try {
                //remove all kiosk buttons
                foreach (Button btn in kioskButtons) {
                    //btn.Visible = false;
                    //btn.Enabled = false;
                    btn.Name = "UNACTIVE_" + DateTime.Now + "_" + random.Next(0, 10000000);

                    //please delete them
                    foreach (Control control in this.Controls) {
                        if (control.Name == btn.Name) {
                            this.Controls.Remove(control);
                            break;
                        }
                    }

                    NumKiosks -= 1;

                    ShrinkBoxByOne(TabletBox, KioskList, btn);
                }

                kioskButtons.RemoveRange(0, kioskButtons.Count);

                //add all kiosks
                await client.SendMessageAsync("get-all-kiosks");

                string response = await client.ReceiveMessageAsync();
                Console.WriteLine($"Server replied: {response}");

                List<KioskRow> kiosksTable = JsonConvert.DeserializeObject<List<KioskRow>>(response);

                foreach (KioskRow kiosk in kiosksTable) {
                    AddKiosk(kiosk.KioskID.ToString());
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        */

        private void ShrinkBoxByOne(GroupBox tabletBox, GroupBox groupBox, Button newButton) {
            int padding = 10;

            //calculate the center position before resizing
            Point originalCenter = new Point(
                groupBox.Location.X + groupBox.Width / 2,
                groupBox.Location.Y + groupBox.Height / 2
            );

            //adjust group box height and recenter it (removing height instead of adding)
            int previousHeight = groupBox.Height;
            groupBox.Height -= newButton.Size.Height + padding;

            //calculate the new location to keep it centered
            groupBox.Location = new Point(
                originalCenter.X - groupBox.Width / 2,
                originalCenter.Y - groupBox.Height / 2
            );

            //re-center tablet box so it looks better
            tabletBox.Location = new Point(tabletBox.Location.X, groupBox.Location.Y);
        }

        private void AddKiosk(string KioskID) {
            Button button = CreateKioskButton(TabletBox, KioskList, KioskID, () => {
                GenericKioskButton(KioskID);
            });

            kioskButtons.Add(button);
        }

        private static Button CreateKioskButton(GroupBox tabletBox, GroupBox groupBox, string KioskID, Action clicked) {
            int padding = 10;

            //check if the button already exists
            var existingButton = groupBox.Controls.OfType<Button>()
                .FirstOrDefault(b => b.Name == KioskID + "_Btn");

            if (existingButton != null) {
                MessageBox.Show($"Button for {KioskID} already exists!");
                return existingButton;
            }

            //calculate the center position before resizing
            Point originalCenter = new Point(
                groupBox.Location.X + groupBox.Width / 2,
                groupBox.Location.Y + groupBox.Height / 2
            );

            Button newButton = new Button();

            //set properties
            newButton.Text = "Kiosk " + KioskID;
            newButton.Size = new Size(326, 55);
            newButton.Location = new Point(6, 31 + ((55 + padding) * NumKiosks));
            newButton.Font = new Font("Target Alt Regular", 15.75f);
            newButton.Name = KioskID + "_Btn";

            newButton.Click += (Object sender, EventArgs e) => clicked?.Invoke();

            groupBox.Controls.Add(newButton);

            //adjust GroupBox height and recenter it
            int previousHeight = groupBox.Height;
            groupBox.Height += newButton.Size.Height + padding;

            //calculate the new location to keep it centered
            groupBox.Location = new Point(
                originalCenter.X - groupBox.Width / 2,
                originalCenter.Y - groupBox.Height / 2
            );

            //re-center tablet box so it looks better
            tabletBox.Location = new Point(tabletBox.Location.X, groupBox.Location.Y);

            NumKiosks += 1;

            return newButton;
        }


        private async void InitializeVariables() {
            random = new Random();

            client = new TCPClient();
            await client.ConnectAsync("216.169.82.236", 11500);

            await client.SendMessageAsync("get-all-kiosks");

            string response = await client.ReceiveMessageAsync();
            Console.WriteLine($"Server replied: {response}");

            List<KioskRow> kiosksTable = JsonConvert.DeserializeObject<List<KioskRow>>(response);

            foreach (KioskRow kiosk in kiosksTable) {
                AddKiosk(kiosk.KioskID.ToString());
            }
        }

        private void Battery_Btn_Click(object sender, EventArgs e) {
            Console.WriteLine("Hi!");
        }

        /*
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        */

        private void RegeditBtn_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("Regedit.exe");
        }

        private void button1_Click(object sender, EventArgs e) {
            GenericKioskPanel.Visible = false;
            MainMenuPanel.Visible = true;

            client.SendMessageAsync("select-no-kiosk");
        }
    }

    public class KioskRow {
        public int KioskID { get; set; }
    }
}
