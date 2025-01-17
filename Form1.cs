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

        public RedboxMobileCommandCenter() {
            InitializeComponent();

            AllocConsole();

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
            }

            // initialize buttons

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
            client = new TCPClient();
            await client.ConnectAsync("216.169.82.236", 11500);

            await client.SendMessageAsync("get-all-kiosks");

            string response = await client.ReceiveMessageAsync();
            Console.WriteLine($"Server replied: {response}");

            List<KioskRow> kiosksTable = JsonConvert.DeserializeObject<List<KioskRow>>(response);

            foreach (KioskRow kiosk in kiosksTable) {
                CreateKioskButton(TabletBox, KioskList, kiosk.KioskID.ToString(), () => { });
            }
        }

        private void Battery_Btn_Click(object sender, EventArgs e) {
            Console.WriteLine("Hi!");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }

    public class KioskRow {
        public int KioskID { get; set; }
    }
}
