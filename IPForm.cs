using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dip
{
    public partial class IPForm : Form
    {
        public IPForm()
        {
            InitializeComponent();
        }
        string rd;
        byte[] b1;
        string v;
        int m;
        TcpListener list;

        Int32 port = 9000;
        Int32 port1 = 9000;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                TcpListener list = new TcpListener(localAddr,port1);
                
                list = new TcpListener(port1);
                list.Start();
                TcpClient client = list.AcceptTcpClient();
                Stream s = client.GetStream();
                b1 = new byte[m];
                s.Read(b1, 0, b1.Length);
                File.WriteAllBytes(textBox1.Text + "\\" + rd.Substring(0, rd.LastIndexOf('.')), b1);
                list.Stop();
                client.Close();
                label1.Text = "File Received......";
            }
        }

        private void IP_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            TcpListener list = new TcpListener(localAddr, 9000);
            //TcpListener list = new TcpListener(port);
            list.Start();

            TcpClient client = list.AcceptTcpClient();
            MessageBox.Show("Client trying to connect");
            StreamReader sr = new StreamReader(client.GetStream());
            rd = sr.ReadLine();
            v = rd.Substring(rd.LastIndexOf('.') + 1);
            m = int.Parse(v);
            list.Stop();
            client.Close();
        }
    }
}
