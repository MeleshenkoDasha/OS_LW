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

        static string path_directory_logs = "server_logs"; // название паки с серверными логами
        static int port = 7777; // номер порта
        private TcpListener server; // прослушка TCP клиентов
        private StreamWriter logs; // поток для записи логов
        private List<TcpClient> clients = new List<TcpClient>(); // лист клиентов на случай подклюбчени более 1 клиента
        private string selectedColor = "0"; // Базовый цвет у нас белый
        public Server()
        {
            InitializeComponent();
        }

        // Обработка события загрузки формы
        private void Server_Load(object sender, EventArgs e)
        {
            // вызываем функцию запуска сервера
            StartServer();
        }

        // функция запуска сервера
        private void StartServer()
        {
            // проверка существования директории с логами
            if (!Directory.Exists(path_directory_logs))
            {
                Directory.CreateDirectory(path_directory_logs);
            }

            //создаем файл с логами
            var time_now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            logs = new StreamWriter($"{path_directory_logs}/log_{time_now}.txt", true);
            logs.AutoFlush = true;

            try
            {
                // определяем прослушку всех адресов на 7777 порту
                server = new TcpListener(IPAddress.Any, port);
                // запустили сервер
                server.Start();
                // сообщение в лог о начале работы сервера
                WriteLog($"Сервер запущен на порту {port}.");
                // подтверждаем подключение клиента к серверу
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
                // принимаем запрос на подключение клиента к серверу
                var client = await server.AcceptTcpClientAsync();
                // запись в лог о подключении клиента
                WriteLog($"Клиент {client.Client.RemoteEndPoint} подключился.");
                // добавляем нового клиента в список клиентов
                clients.Add(client);
            }
        }

        // функция изменения цыета
        private void ChangeColor()
        {
            // записьв лог о смене цвета
            WriteLog($"Цвет был сменён на {selectedColor}");
            // в цикле обходим всех клиентов
            foreach (TcpClient client in clients)
            {
                //если клиент подключен
                if (client.Connected)
                {
                    // отправляем сообщение о смене цвета
                    SendMessage(client, selectedColor);
                }
            }
        }

        // посылка сообщенния
        private void SendMessage(TcpClient client, string message)
        {
            try
            {
                // получаем клиентский поток
                NetworkStream stream = client.GetStream();
                // кодируем сообщение об изменении цвета
                byte[] data = Encoding.UTF8.GetBytes(message);
                // записываем в поток (отправляем сообщение на клиенты)
                stream.Write(data, 0, data.Length);
                // запись в лог
                WriteLog($"Клиенту {client.Client.RemoteEndPoint} отправлен цвет {message}.");
            }
            // обработка ошибок
            catch (Exception ex)
            {
                // если что-то пошло не так выведем сообщение об ошибке
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // запись в лог
        private void WriteLog(string message)
        {
            // запись в лог осуществляем одновременно и в лог и в "консоль вывода" в окне пользователя
            // определяем время свершения операции
            var time_event = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //создаем сообщение в формате дата время - сообщение
            var log_message = $"{time_event} - {message}";
            // записываем в файл
            logs.WriteLine(log_message);
            // записали в textbox для отображения пользователю в консоли
            Invoke((Action)(() => tbLogs.AppendText(log_message + Environment.NewLine)));
        }

        // обработчики нажатия кнопок на смену цвета
        private void btnColor1_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor1.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor2.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor3_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor3.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor4_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor4.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor5_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor5.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor6_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor6.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor7_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor7.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor8_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor8.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }

        private void btnColor0_Click(object sender, EventArgs e)
        {
            // записываем изменный цвет
            selectedColor = btnColor0.BackColor.Name;
            // производим смену цвеиа на клиенте
            ChangeColor();
        }
    }
}
