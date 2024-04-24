
#include <iostream>
#include <windows.h>

using namespace std;

int main()
{
	HANDLE channel;                        // создаем дескриптор
	char inputcharacter[2];
	DWORD rd, wr;

	channel = CreateNamedPipe(             // создаем канал
		L"\\\\.\\pipe\\MyPipe",         // имя канала
		PIPE_ACCESS_DUPLEX,             // режим работы канала
		PIPE_TYPE_MESSAGE |             // режимы
		PIPE_READMODE_MESSAGE |
		PIPE_WAIT,
		1,                              // число клиентов
		100,                            // входной буфер
		100,                            // выводной буфер
		INFINITE,                       // время ожидания
		(LPSECURITY_ATTRIBUTES)NULL);   // указатель на атрибуты безопасности

	// проверка создался ли канал
	if (channel == INVALID_HANDLE_VALUE) {
		cerr << "Error! Couldn't create pipe.\n";
		return 0;
	}

	cout << "Waiting for client...\n";

	// проверка подсоединился ли клиент
	if (!ConnectNamedPipe(channel, (LPOVERLAPPED)NULL)) {
		cerr << "Error! Failed to connect client.\n";
		CloseHandle(channel);
		return 0;
	}
	else {
		cout << "Client connected.\n\nWelcome!\n\n";
		cout << "To change console's background:\n";
		cout << "\t0 = Black \n\t1 = Blue \n\t2 = Green \n\t3 = Blue \n\t4 = Red \n\t5 = Purple \n\t6 = Yellow \n\t7 = White \n\t8 = Grey \n\tR = The restore default background color\n\tQ = Exit\n ";
	}

	do {
		cin.getline(inputcharacter, 100);              // считывание ввода

		switch (inputcharacter[0]) {				// оператор выбора цвета
		case '0':
			system("color 07");
			break;
		case '1':
			system("color 10");
			break;
		case '2':
			system("color 20");
			break;
		case '3':
			system("color 30");
			break;
		case '4':
			system("color 40");
			break;
		case '5':
			system("color 50");
			break;
		case '6':
			system("color 60");
			break;
		case '7':
			system("color 70");
			break;
		case '8':
			system("color 80");
			break;
		case '9':
			system("color 90");
			break;
		case 'R':
			system("color 0F");
			break;
		default:
			cout << "Error! Incorrect key.\n";
			break;
		}

		//передача данных по каналу
		if (WriteFile(channel, inputcharacter, strlen(inputcharacter) + 1, &wr, (LPOVERLAPPED)NULL)) {
			cout << "Done.\n";
		}

		cout << "Choose next color.\n";
	} while (inputcharacter[0] != 'R');

	DisconnectNamedPipe(channel);
	cout << "Disconnected successfully.\n";

	CloseHandle(channel);              // закрытие канала
	system("pause");
	return 0;
}


