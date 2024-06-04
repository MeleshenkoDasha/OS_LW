using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace LR6_client
{
    public partial class Client : Form
    {
        // объ€вим необходимые пол€ дл€ работы
        static string path_directory_logs = "client_logs"; // название папки дл€ хранени€ логов клиента
        static int port_connect = 7777; // порт к которому будем подключатьс€
        private TcpClient client; //  лиентское подключение по протоколу TCP
        private NetworkStream stream; // сетевой поток
        private StreamWriter logs; // дл€ записи логов в опредленной кодировке

        // конструктор
        public Client()
        {
            InitializeComponent();
            // провер€ем существование директории с логами
            if (!Directory.Exists(path_directory_logs))
            {
                // создаем в случае если папка с логами отсутсвует
                Directory.CreateDirectory(path_directory_logs);
            }
            // создадим файл с логом
            // определим уникальную часть названи€ файла (дата+врем€)
            var time_now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            logs = new StreamWriter($"{path_directory_logs}/log_{time_now}.txt", true);
            logs.AutoFlush = true;
        }

        // обработчик нажати€ кнопки "ѕодключитьс€ к серверу"
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // ѕроверим, что пользователь выбрал адрес дл€ подключени€
            if (cb_listAdress.SelectedItem != null)
            {
                if (client != null)
                {
                    client.Close();
                }
                
                // создаем новое подключение
                client = new TcpClient(cb_listAdress.Text, port_connect);
                // получаем поток
                stream = client.GetStream();
                // делаем запись в лог о подключении к серверу
                WriteLog($"¬ыполнено подключение к серверу по адресу: {cb_listAdress.Text}:{port_connect}.");
                // переходим в режим ожидани€ команд от сервера
                Task.Run(() => ReceiveMessagesAsync());
            }
            else
            {
                MessageBox.Show("¬ы не выбрали адрес дл€ подключени€ к серверу!\nѕожалуйса выберете адрес и повторите подключение.", "¬нимание!", MessageBoxButtons.OK);
            }
        }

        // получение сообщение от сервера
        private async Task ReceiveMessagesAsync()
        {
            // получили клиентский поток
            NetworkStream stream = client.GetStream();
            // выделили буфер дл€ преобразовани€ получаемых данных
            byte[] buffer = new byte[1024];
            while (true)
            {
                // считываем пришедшие данные
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                // если длинна полученных данных больше 0 производим разбор
                if (bytesRead > 0)
                {
                    // декодируем лполученную строку
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // сделаем запись в лог
                    WriteLog($"ѕолучен цвет {message}.");
                    // произведем смену цвета окна
                    lbl_change_color.BackColor = Color.FromName(message);
                }
            }
        }

        // запись в лог
        private void WriteLog(string message)
        {
            // запись в лог осуществл€ем одновременно и в лог и в "консоль вывода" в окне пользовател€
            // определ€ем врем€ свершени€ операции
            var time_event = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //создаем сообщение в формате дата врем€ - сообщение
            var log_message = $"{time_event} - {message}";
            // записываем в файл
            logs.WriteLine(log_message);
            // записали в textbox дл€ отображени€ пользователю в консоли
            Invoke((Action)(() => tbLogs.AppendText(log_message + Environment.NewLine)));
        }
    }
}
