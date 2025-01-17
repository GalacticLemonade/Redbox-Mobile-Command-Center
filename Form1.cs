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

namespace Redbox_Mobile_Command_Center {
    public partial class RedboxMobileCommandCenter : Form {

        static TCPClient client;

        public RedboxMobileCommandCenter() {
            InitializeComponent();

            AllocConsole();

            // initialize variables
            InitializeVariables();

            // initialize blanks
            IP_Text.Text = "Connecting...";

            // setup window
            //this.FormBorderStyle = FormBorderStyle.None;  // removes the border
            //this.WindowState = FormWindowState.Maximized;  // maximizes the window
            //this.TopMost = true;  // makes the form always on top

            // get local ip
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);
            var ipv4Address = ip.AddressList.FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            if (ipv4Address != null) {
                Console.WriteLine(ipv4Address.ToString());
                IP_Text.Text = ipv4Address.ToString();

            }
            else {
                Console.WriteLine("No IPv4 address found.");
            }

            // initialize buttons

        }

        private static async void InitializeVariables() {
            client = new TCPClient();
            await client.ConnectAsync("216.169.82.236", 11500);

            await client.SendMessageAsync("get-all-kiosks");

            string response = await client.ReceiveMessageAsync();
            Console.WriteLine($"Server replied: {response}");

            client.Disconnect();
        }

        private void Kiosk35618_Btn_Click(object sender, EventArgs e) {
            // TODO:
            // make sure you dynamically load
            // all kiosks from a server
            // instead of hard-coding
        }

        private void Battery_Btn_Click(object sender, EventArgs e) {
            Console.WriteLine("Hi!");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
