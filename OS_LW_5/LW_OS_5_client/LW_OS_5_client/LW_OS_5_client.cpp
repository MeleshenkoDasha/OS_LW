#include <iostream>
//#include <winsock2.h> 
#include <string>
#include "windows.h"

#pragma comment(lib, "WS2_32")
using namespace std;

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "");
	// сообщение об ожидании
	cout << "Waiting..." << endl;
	// попытаемся открыть семафор
	HANDLE handleSemaphore = OpenSemaphore(SEMAPHORE_MODIFY_STATE | SYNCHRONIZE, FALSE, L"SEMAPHORE");
	// если создание семафора потерпело неудачу, "корректно" завершим работу программы с ошибкой.
	if (!handleSemaphore)
	{
		cout << "Произошла ошибка при открытии семафора!";
		return 1;
	}
	// Приостановим выполнение программы до тех пор пока семафор не изменит своего состояния
	WaitForSingleObject(handleSemaphore, INFINITE);

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
	socket_adres.sin_addr.s_addr = inet_addr("127.0.0.1"); //адрес
	socket_adres.sin_port = htons(1111); //порт
	socket_adres.sin_family = AF_INET; // семейство протоколов

	// определеим сокет для прослушки порта
	SOCKET listening_socket = socket(AF_INET, SOCK_STREAM, NULL);
	// выполним подключение к серверу
	// если подключение потерпело не удачу, то "корректно" завершаем работу программы с ошибкой
	if (connect(listening_socket, (SOCKADDR*)&socket_adres, lenght_of_adres_socket) != 0)
	{
		cout << "Ошибка: не удалось подключиться к серверу!" << endl;
		return 1;
	}

	// получим сообщение о подключении к серверу и оповестим об этом пользователя
	int number;
	recv(listening_socket, (char*)&number, sizeof(int), NULL);
	cout << "Подключено!" << "Ваш номер подключения: " << number << endl;

	// запустим "бесконечный цикл"
	while (true)
	{
		int lenght_of_message;
		// получаем размер сообщения
		// если при получении возникнет ошибка то просто завершим работу программы
		if (recv(listening_socket, (char*)&lenght_of_message, sizeof(int), NULL) == SOCKET_ERROR) {
			return 1;
		}
		// выделяем необходимое количество памяти для записи
		char* buffer = new char[lenght_of_message + 1];
		buffer[lenght_of_message] = 0;
		// получаем само сообщение 
		// если при получении возникнет ошибка то просто завершим работу программы
		if (recv(listening_socket, buffer, lenght_of_message * sizeof(buffer), NULL) == SOCKET_ERROR) {
			return 1;
		}
		// выводим полученное сообщение пользователю в консоль
		cout << buffer << endl;
		// произвдем очистку выдленной памяти
		delete[] buffer;

		// строка для получения данных от клиента
		string string_data;
		// получаем данные которые воодит клиент с консоли
		getline(cin, string_data);
		// определяем длину введенной строки
		lenght_of_message = string_data.size();
		// отправляем размер строки
		// если при отправке возникнет ошибка то просто завершим работу программы
		if (send(listening_socket, (char*)&lenght_of_message, sizeof(int), NULL) == SOCKET_ERROR) {
			return 1;
		}
		// отправляем саму строку
		// если при отправке возникнет ошибка то просто завершим работу программы
		if (send(listening_socket, string_data.c_str(), lenght_of_message, NULL) == SOCKET_ERROR) {
			return 1;
		}
		// если введенное сообщение quit, то прекращаем работы
		if (string_data == "quit")
		{
			break;
		}


		// получаем размер сообещния 
		// если при получении возникнет ошибка то просто завершим работу программы
		if (recv(listening_socket, (char*)&lenght_of_message, sizeof(int), NULL) == SOCKET_ERROR) {
			return 1;
		}
		// выделяем память
		buffer = new char[lenght_of_message + 1];
		buffer[lenght_of_message] = 0;
		// получаем само сообщение
		// если при получении возникнет ошибка то просто завершим работу программы
		if (recv(listening_socket, buffer, lenght_of_message, NULL) == SOCKET_ERROR) {
			return 1;
		}
		// выведем полученное сообщение
		cout << buffer << endl;
		//очищаем выделенную память
		delete[] buffer;
		system("pause");
	}
	// уменьшим счетчик семафоров после высвобождение очередного семафора
	ReleaseSemaphore(handleSemaphore, 1, NULL);
	// закроем семафор
	CloseHandle(handleSemaphore);
	// закроем соект
	closesocket(listening_socket);
	// Прекратим использование библиотеки
	WSACleanup();
	system("pause");
	return 0;
}

