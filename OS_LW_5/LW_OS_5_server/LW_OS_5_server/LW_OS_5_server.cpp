#pragma comment(lib, "WS2_32")

#include <iostream>
#include <set>
#include <string>
#include "windows.h"

using namespace std;

SOCKET* socket_connection;

void ClientHandler(int size_of_array)
{
	int number = size_of_array + 1;
	send(socket_connection[size_of_array], (char*)&number, sizeof(int), NULL);
	while (true)
	{
		string text_message_welcome = "Введите строку в следующем формате: (число пробел число пробел число пробел и т.д.), чтобы удалить повторяющиеся числа, или «quit», чтобы отключиться.";
		int lenght_of_message;
		lenght_of_message = text_message_welcome.size();
		char* buffer = new char[lenght_of_message + 1]; //выделяем кол-во памяти для записи 
		buffer[lenght_of_message] = 0;
		if (send(socket_connection[size_of_array], (char*)&lenght_of_message, sizeof(int), NULL) == SOCKET_ERROR) {
			cout << "Клиент #" << size_of_array + 1 << " отключен!" << endl;
			return;
		}//отправляем на клиент длину сообщения
		if (send(socket_connection[size_of_array], text_message_welcome.c_str(), lenght_of_message, NULL) == SOCKET_ERROR) {
			cout << "Клиент #" << size_of_array + 1 << " отключен!" << endl;
			return;
		}//отправляем само сообщение
		if (recv(socket_connection[size_of_array], (char*)&lenght_of_message, sizeof(int), NULL) == SOCKET_ERROR) {
			cout << "Клиент #" << size_of_array + 1 << " отключен!" << endl;
			return;
		}// принимаем длину сообщения (ответ от клиента)
		if (recv(socket_connection[size_of_array], buffer, lenght_of_message, NULL) == SOCKET_ERROR) {
			cout << "Клиент #" << size_of_array + 1 << " отключен!" << endl;
			return;
		}// принимаем ответ 
		cout << "Клиент #" << size_of_array + 1 << " отправил: ";
		string message_recive_from_client = "";
		for (int i = 0; i < lenght_of_message; ++i) {
			message_recive_from_client += buffer[i];
			cout << buffer[i];
		}
		cout << endl;
		delete[] buffer;
		cout << message_recive_from_client << endl;
		if (message_recive_from_client == "quit") // если сообщение было quit, то завершаем программу
		{
			break;
		}
		double d;
		set<double> uniqueNumbers;
		size_t read;
		string result = "Unique numbers are: [ ";
		try
		{
			do
			{
				d = stod(message_recive_from_client, &read);
				uniqueNumbers.insert(d);
				message_recive_from_client = message_recive_from_client.substr(read);
			} while (message_recive_from_client != "");

		}
		catch (const invalid_argument&)
		{
			result = "Аргумент некорректен\n";
		}
		catch (const out_of_range&)
		{
			result = "Аргумент выходит за пределы диапазона double.\n";
		}
		for (auto& el : uniqueNumbers)
		{
			result += to_string(el);
			result += ", ";
		}
		result.pop_back();
		result.pop_back();
		result += " ]";
		lenght_of_message = result.size();
		cout << result << endl;
		if (send(socket_connection[size_of_array], (char*)&lenght_of_message, sizeof(int), NULL) == SOCKET_ERROR) {
			cout << "Клиент #" << size_of_array + 1 << " отключился!" << endl;
			return;
		}// отправляем на клиент длину сообещния
		if (send(socket_connection[size_of_array], result.c_str(), lenght_of_message * sizeof(char), NULL) == SOCKET_ERROR) {
			cout << "Клиент #" << size_of_array + 1 << " отключился!" << endl;
			return;
		}// отправляем на клиент само сообщение
	}
}


// проверки вводимых значений с консоли
bool skipLine() { // функция пропуска строки до символа переноса строки
	char c;
	bool isClear = true;
	do {
		cin.get(c); // получаем символы строки
		if (!iswspace(c)) {
			isClear = false;
		}
	} while (c != '\n'); // пока строка не закончится
	return isClear;
}

bool readInt(int& target) {
	cout << '>'; // выводим символ >
	cin >> target;// считываем проверяемое значение
	if (!cin) { // если введенное значение не удовлетворяет типу int то результат проверки false
		cin.clear();// очистка потока
		skipLine(); // пропуск строки
		return false;
	}
	if (!iswspace(cin.peek())) {//фукнция проверки пробелов
		skipLine(); // пропуск строки
		return false;// возврат false
	}
	return true;// возврат true
}



int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "");
	// создадим семафор, который будет контролировать до 3 клиентов
	HANDLE hSemaphore = CreateSemaphore(NULL, 3, 3, L"SEMAPHORE");
	// если создание семафора потерпело неудачу, "корректно" завершим работу программы с ошибкой.
	if (!hSemaphore)
	{
		cout << "Произошла ошибка при создании семафора!" << endl;
		return 1;
	}

	// произведем загрузку библиотеки 
	// определим структуру для загрузки
	WSAData structData;
	// определеим версию библиотеки winsock
	// winsock - это техническая спецификация, которая определяет, как сетевое программное обеспечение Windows будет получать доступ к сетевым ресурсам
	WORD DLLVersion MAKEWORD(2, 1);
	// если подключение библиотеки потерпело неудачу, то "корректно" завершим работу программы с ошибкой.
	if (WSAStartup(DLLVersion, &structData) != 0)
	{
		cout << "Ошибка загрузки библиотеки сокетов!" << endl;
		return 1;
	}


	// заполним информацию об адресе сокета
	SOCKADDR_IN socket_adres;
	int lenght_of_adres_socket = sizeof(socket_adres); // размер
	socket_adres.sin_addr.s_addr = inet_addr("127.0.0.1"); // адрес
	socket_adres.sin_port = htons(1111); // порт
	socket_adres.sin_family = AF_INET; // семейство протоколов

	// определеим сокет для прослушки порта
	SOCKET listening_socket = socket(AF_INET, SOCK_STREAM, NULL);
	// произведем привязку адреса к сокету
	// если привязка потерпела неудачу, то "корректно" завершим работу программы с ошибкой.
	if (bind(listening_socket, (SOCKADDR*)&socket_adres, lenght_of_adres_socket) != 0)
	{
		cout << "Ошибка!" << endl;
		return 1;
	}

	// произведем подкючение для прослушивания с максимальной очередью
	listen(listening_socket, SOMAXCONN);

	// определим количество клиентов для подключения 
	// (запросим с консоли количество клиентов для подключения у пользователя сервера)
	int client_counts = 0;
	cout << "Пожалуйста введите колчиество клиентов: ";
	while (!readInt(client_counts) || client_counts <= 0) //проверка
	{
		cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользоваталь получает сообщение об ошибке и просит повторить ввод
	}

	// создадим массив подключений сокетов
	socket_connection = new SOCKET[client_counts];
	// определим промежуточный сокет
	SOCKET current_socket_connection;
	// создадим массив для потоков
	HANDLE* list_of_threads = new HANDLE[client_counts];
	// запустим необходимое число клиентов
	for (int i = 0; i < client_counts; ++i)
		system("start C:\\Users\\Ivan\\source\\repos\\LW_OS_5_client\\x64\\Debug\\LW_OS_5_client.exe");

	// в цикле проходим по каждому клиенту
	for (int i = 0; i < client_counts; ++i)
	{
		// разрешим установку соединения с клиентом 
		current_socket_connection = accept(listening_socket, (SOCKADDR*)&socket_adres, &lenght_of_adres_socket);
		// если разрешение не пройдет то отправим сообщение пользователю об ошибке
		if (current_socket_connection == 0)
		{
			cout << "Ошибка при подключении!" << endl;
		}
		else
		{
			// если подучлюени было раз решено то 
			// пользоваталь получает сообщение о номере подключенного клиента
			cout << "Клиент #" << i + 1 << " подключен!" << endl;
			socket_connection[i] = current_socket_connection;
			// создаем поток
			list_of_threads[i] = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)ClientHandler, (LPVOID)i, NULL, NULL);
			// если создание потока потерпело неудачу, то "корректно" завершим работу программы с ошибкой.
			if (list_of_threads[i] == NULL)
			{
				cout << "Ошибка создания потока" << endl;//пользоваталь получает сообщение об ошибке
				return 1;
			}
		}
	}

	// Произведем постановку сокетов на ожидание, до тех пор пока не будут в состоянии сигнала или не истечет интервал времени ожидания.
	WaitForMultipleObjects(client_counts, list_of_threads, TRUE, INFINITE);
	// Произведем закрытие потоков
	for (int i = 0; i < client_counts; ++i)
	{
		CloseHandle(list_of_threads[i]);
	}

	// высвободим память из под массива с потоками
	delete[] list_of_threads;
	//пользоваталь получает сообщение о завершении работы сервера
	cout << "Сервер завершил работу!" << endl;
	// высвободим память из под массива с сокетами
	delete[] socket_connection;
	// Прекратим использование библиотеки
	WSACleanup();
	// Произвдем закрытие сокетов
	closesocket(current_socket_connection);
	closesocket(listening_socket);
	system("pause");
	return 0;
}
