using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6_server
{
    public partial class Server : Form
    {

        static string path_directory_logs = "server_logs"; // �������� ���� � ���������� ������
        static int port = 7777; // ����� �����
        private TcpListener server; // ��������� TCP ��������
        private StreamWriter logs; // ����� ��� ������ �����
        private List<TcpClient> clients = new List<TcpClient>(); // ���� �������� �� ������ ����������� ����� 1 �������
        private string selectedColor = "0"; // ������� ���� � ��� �����
        public Server()
        {
            InitializeComponent();
        }

        // ��������� ������� �������� �����
        private void Server_Load(object sender, EventArgs e)
        {
            // �������� ������� ������� �������
            StartServer();
        }

        // ������� ������� �������
        private void StartServer()
        {
            // �������� ������������� ���������� � ������
            if (!Directory.Exists(path_directory_logs))
            {
                Directory.CreateDirectory(path_directory_logs);
            }

            //������� ���� � ������
            var time_now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            logs = new StreamWriter($"{path_directory_logs}/log_{time_now}.txt", true);
            logs.AutoFlush = true;

            try
            {
                // ���������� ��������� ���� ������� �� 7777 �����
                server = new TcpListener(IPAddress.Any, port);
                // ��������� ������
                server.Start();
                // ��������� � ��� � ������ ������ �������
                WriteLog($"������ ������� �� ����� {port}.");
                // ������������ ����������� ������� � �������
                Task.Run(() => AcceptClientsAsync());
            }
            catch (Exception ex)
            {
                WriteLog($"Error: {ex.Message}");
            }
        }
        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                // ��������� ������ �� ����������� ������� � �������
                var client = await server.AcceptTcpClientAsync();
                // ������ � ��� � ����������� �������
                WriteLog($"������ {client.Client.RemoteEndPoint} �����������.");
                // ��������� ������ ������� � ������ ��������
                clients.Add(client);
            }
        }

        // ������� ��������� �����
        private void ChangeColor()
        {
            // ������� ��� � ����� �����
            WriteLog($"���� ��� ����� �� {selectedColor}");
            // � ����� ������� ���� ��������
            foreach (TcpClient client in clients)
            {
                //���� ������ ���������
                if (client.Connected)
                {
                    // ���������� ��������� � ����� �����
                    SendMessage(client, selectedColor);
                }
            }
        }

        // ������� ����������
        private void SendMessage(TcpClient client, string message)
        {
            try
            {
                // �������� ���������� �����
                NetworkStream stream = client.GetStream();
                // �������� ��������� �� ��������� �����
                byte[] data = Encoding.UTF8.GetBytes(message);
                // ���������� � ����� (���������� ��������� �� �������)
                stream.Write(data, 0, data.Length);
                // ������ � ���
                WriteLog($"������� {client.Client.RemoteEndPoint} ��������� ���� {message}.");
            }
            // ��������� ������
            catch (Exception ex)
            {
                // ���� ���-�� ����� �� ��� ������� ��������� �� ������
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ������ � ���
        private void WriteLog(string message)
        {
            // ������ � ��� ������������ ������������ � � ��� � � "������� ������" � ���� ������������
            // ���������� ����� ��������� ��������
            var time_event = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //������� ��������� � ������� ���� ����� - ���������
            var log_message = $"{time_event} - {message}";
            // ���������� � ����
            logs.WriteLine(log_message);
            // �������� � textbox ��� ����������� ������������ � �������
            Invoke((Action)(() => tbLogs.AppendText(log_message + Environment.NewLine)));
        }

        // ����������� ������� ������ �� ����� �����
        private void btnColor1_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor1.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor2.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor3_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor3.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor4_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor4.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor5_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor5.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor6_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor6.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor7_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor7.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor8_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor8.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }

        private void btnColor0_Click(object sender, EventArgs e)
        {
            // ���������� �������� ����
            selectedColor = btnColor0.BackColor.Name;
            // ���������� ����� ����� �� �������
            ChangeColor();
        }
    }
}
