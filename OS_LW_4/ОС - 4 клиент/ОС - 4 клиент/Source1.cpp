
#include <iostream>     
#include <windows.h>

using namespace std;

int main() {
	HANDLE channel;								// создаем дескриптор
	DWORD wr, rd;
	char inputcharacter[100];						// создаем буфер, в который будет записываться значение 
	channel = CreateFile(							// открываем канал
		L"\\\\.\\pipe\\MyPipe",					// имя канала
		GENERIC_READ | GENERIC_WRITE,			// режим доступа 
		FILE_SHARE_READ | FILE_SHARE_WRITE,		// совместный доступ
		(LPSECURITY_ATTRIBUTES)NULL,			// дескриптор защиты
		OPEN_EXISTING,							// открытие файла
		0,										// атрибуты файла
		(HANDLE)NULL							// дескриптор шаблона файла
	);

	// проверка на соединение с сервером 
	if (channel == INVALID_HANDLE_VALUE) {
		cerr << "Error! Failed to connect client.\n";
		return 0;
	}


	do {
		if (ReadFile(								// считывание из канала
			channel,									// дескриптор канала
			inputcharacter,							// массив считывания
			200,									// число байтов для чтения
			&rd,									// число прочитанных байтов
			(LPOVERLAPPED)NULL)) {					// асинхронный буфер

			switch (inputcharacter[0]) {				// оператор выбора цвета
			case '0':
				system("color 07");					// функция изменения цвета 
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
			case 'Q':
				CloseHandle(channel);			// выход из программы
				return 0;
			default:
				cout << "Error! Incorrect key.\n";
				break;
			}

			cout << "Done.\n";
		}
	} while (inputcharacter[0] != 'R');

	CloseHandle(channel);					// закрываем канал

	system("pause");
	return 0;
}