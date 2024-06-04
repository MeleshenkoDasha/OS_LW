using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace LR6_client
{
    public partial class Client : Form
    {
        // ������� ����������� ���� ��� ������
        static string path_directory_logs = "client_logs"; // �������� ����� ��� �������� ����� �������
        static int port_connect = 7777; // ���� � �������� ����� ������������
        private TcpClient client; // ���������� ����������� �� ��������� TCP
        private NetworkStream stream; // ������� �����
        private StreamWriter logs; // ��� ������ ����� � ����������� ���������

        // �����������
        public Client()
        {
            InitializeComponent();
            // ��������� ������������� ���������� � ������
            if (!Directory.Exists(path_directory_logs))
            {
                // ������� � ������ ���� ����� � ������ ����������
                Directory.CreateDirectory(path_directory_logs);
            }
            // �������� ���� � �����
            // ��������� ���������� ����� �������� ����� (����+�����)
            var time_now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            logs = new StreamWriter($"{path_directory_logs}/log_{time_now}.txt", true);
            logs.AutoFlush = true;
        }

        // ���������� ������� ������ "������������ � �������"
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // ��������, ��� ������������ ������ ����� ��� �����������
            if (cb_listAdress.SelectedItem != null)
            {
                if (client != null)
                {
                    client.Close();
                }
                
                // ������� ����� �����������
                client = new TcpClient(cb_listAdress.Text, port_connect);
                // �������� �����
                stream = client.GetStream();
                // ������ ������ � ��� � ����������� � �������
                WriteLog($"��������� ����������� � ������� �� ������: {cb_listAdress.Text}:{port_connect}.");
                // ��������� � ����� �������� ������ �� �������
                Task.Run(() => ReceiveMessagesAsync());
            }
            else
            {
                MessageBox.Show("�� �� ������� ����� ��� ����������� � �������!\n��������� �������� ����� � ��������� �����������.", "��������!", MessageBoxButtons.OK);
            }
        }

        // ��������� ��������� �� �������
        private async Task ReceiveMessagesAsync()
        {
            // �������� ���������� �����
            NetworkStream stream = client.GetStream();
            // �������� ����� ��� �������������� ���������� ������
            byte[] buffer = new byte[1024];
            while (true)
            {
                // ��������� ��������� ������
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                // ���� ������ ���������� ������ ������ 0 ���������� ������
                if (bytesRead > 0)
                {
                    // ���������� ����������� ������
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // ������� ������ � ���
                    WriteLog($"������� ���� {message}.");
                    // ���������� ����� ����� ����
                    lbl_change_color.BackColor = Color.FromName(message);
                }
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
    }
}
