#include <iostream>
#include <fstream>
#include <fcntl.h>
#include <sys/stat.h>
#include <unistd.h>
#include <cstring>
#include <sstream>
#include <ctime>

using namespace std;


//-копирование файлов
void copyFile(string Startfile, string Finalfile)
{
    if (Startfile == Finalfile) // если название копируемого файла и название копии совпадают, то выдает ошитбку, и возвращаемся назад
    {
        cout << "Название копируемого файла и название копии не должны совпадать"; //сообщение пользователю о неправильно введеных данных
        return; //возвращение
    }

    ifstream fin;
    size_t bufsize = 4;
    char* buf = new char[bufsize];
    fin.open(Startfile, ios::binary); //Открытие 1 файлф
    if (fin.is_open()) //если файл открывается
    {
        ofstream fout; //Назовём объект – fout
        fout.open(Finalfile, ios::binary); //связываем объект с файлом

        while (!fin.eof()) // пока читается файл
        {
            fin.read(buf, bufsize);
            if (fin.gcount())
                fout.write(buf, fin.gcount());
        }

        cout << "Копирование прошло успешно" << endl;
        delete[] buf;
        fin.close();
        fout.close();
    }

    else // файл не откроится и вернется назад
    {
        cout << "Невозможно открыть файл" << endl; // сообщение пользователю о невозможности отрытия файла
        return; //возвращение
    }
}


//-перемещение файлов
void moveFile(const char* Startfile, const char* Finalfile) // указатель на объект, который нельзя менять
{

    if (rename(Startfile, Finalfile) == 0) //если файл пеерименовывайтся
    {
        cout << "Файл успешно перемещен"; // пользовватель получает сообщение о перемещении файла 
    }
    else //иначе
    {
        cout << "Ошибка при перемещении файла" << endl;// пользовватель получает сообщение об ошибке перемещении файла
    }
}


void mask(mode_t mask)
{
    cout << "Права доcтупа:"; //пользователь получает сообщение о правах доступа
    cout << ((mask & S_IRUSR) ? "r" : "-"); // S_IRUSR - пользователь может читать
    cout << ((mask & S_IWUSR) ? "w" : "-"); // S_IWUSR - пользователь можеть писать
    cout << ((mask & S_IXUSR) ? "x" : "-"); // S_IXUSR - пользователь может выполнять файл или искать в каталоге
    cout << " ";
    cout << ((mask & S_IRGRP) ? "r" : "-"); // S_IRGRP - группа-владелец может читать
    cout << ((mask & S_IWGRP) ? "w" : "-"); // S_IWGRP - группа-владелец может писать
    cout << ((mask & S_IXGRP) ? "x" : "-"); // S_IXGRP - группа-владелец может выполнять файл или искать в каталоге
    cout << " ";
    cout << ((mask & S_IROTH) ? "r" : "-"); // S_IROTH - все остальные могут читать
    cout << ((mask & S_IWOTH) ? "w" : "-"); // S_IWOTH - все остальные могут писать
    cout << ((mask & S_IXOTH) ? "x" : "-") << endl; // S_IXOTH - все остальные могут выполнять файл или искать в каталоге
}


//-получение информации о файле(права, размер, время изменения)
void infoFile(const char* Startfile)
{
    struct stat statbuf; // структура stat для всей необходимой информации о файле
    if (stat(Startfile, &statbuf) == 0)
    {
        cout << "Размер файла: " << statbuf.st_size << endl;
        mask(statbuf.st_mode);
        cout << "Время модификации: " << ctime(&statbuf.st_mtime) << endl;
    }
    else
    {
        cout << "Ошибка при получении информации о файле" << endl;
    }
}


//-изменение прав на выбранный файл
void modeFile(const char* Startfile, mode_t access) // проверка на существование файла 
{

    if (chmod(Startfile, access) == 0) // если такой файл существует, то права доступа на выбранный файл меняются 
    {
        cout << "Права доступа успешно изменены"; // пользователь получает сообщение, о изменнение прав доступа
    }
    else // иначе
    {
        cout << "Ошибка при изменении прав доступа" << endl; // пользователь получает сообщение, об невозможности изменения прав доступа
    }
}


int main(int argc, char* argv[]) // argc- кол-во аргументов ком.строки,
//*argv- массив строк, каждая из которых представляет отдельный аргумент ком.строки(argv[0]-имя исполняемого файла )
{
    setlocale(LC_ALL, "");
    if (argc > 1) // если количкество аргусетов больше 1
    {
        string type_comand = argv[1]; // желаемая команда
        if (type_comand == "--help")
        {
            cout << "Краткая справка:" << endl;
            cout << "- copy [Startfile] [Finalfile] - копирование стартового файла в конечный файл" << endl;
            cout << "- move [Startfile] [Finalfile] - переименовать или переместить стартовый файл в конечный файл" << endl;
            cout << "- info [Startfile] - получение информации о стартовом файле (права, размер, время изменения)" << endl;
            cout << "- mode [Startfile] [новые права доcтупа в формате цифр] - изменение прав на стратовый файл " << endl;

        }
        else if (type_comand == "copy" && argc == 4)
        {
            copyFile(argv[2], argv[3]);
        }
        else if (type_comand == "move" && argc == 4)
        {
            moveFile(argv[2], argv[3]);
        }
        else if (type_comand == "info" && argc == 3)
        {
            infoFile(argv[2]);
        }
        else if (type_comand == "mode" && argc == 4)
        {
            mode_t newPermissions = strtol(argv[3], NULL, 8); // преобразуем строку в восьмеричное число
            modeFile(argv[2], newPermissions);
        }
        else // иначе 
        {
            cout << "Некорректный ввод параметров." << endl; // пользователь получает сообщение о неверном вводе параметров
            return 1; // возвращается 1
        }
    }

    else // работа с консолью
    {
        cout << "Работа с консолью: " << endl;

        cout << "Краткая справка:" << endl;
        cout << "- copy [Startfile] [Finalfile] - копирование стартового файла в конечный файл" << endl;
        cout << "- move [Startfile] [Finalfile] - переименовать или переместить стартовый файл в конечный файл" << endl;
        cout << "- info [Startfile] - получение информации о стартовом файле (права, размер, время изменения)" << endl;
        cout << "- mode [Startfile] [новые права доcтупа в формате цифр] - изменение прав на стартовый файл " << endl;

        string type_comand;
        cout << "Введите команду, которую необходимо выполнить" << endl;
        cin >> type_comand;

        if (type_comand == "copy") {
            string Startfile, Finalfile;
            cout << "Введите название первого файлa: " << endl;
            cin >> Startfile;
            cout << "Введите название второго файлa: " << endl;
            cin >> Finalfile;
            copyFile(Startfile, Finalfile);
        }
        else if (type_comand == "move") {
            string Startfile, Finalfile;
            cout << "Введите название первого файлa: " << endl;
            cin >> Startfile;
            cout << "Введите название второго файлa: " << endl;
            cin >> Finalfile;
            moveFile(Startfile.c_str(), Finalfile.c_str());
        }
        else if (type_comand == "info") {
            string Startfile;
            cout << "Введите название первого файлa: " << endl;
            cin >> Startfile;
            infoFile(Startfile.c_str());
        }
        else if (type_comand == "mode") {
            string Startfile;
            mode_t access;
            cout << "Введите название первого файлa: " << endl;
            cin >> Startfile;
            cout << "Введите права доступа для первого файла: " << endl;
            cin >> oct >> access;
            modeFile(Startfile.c_str(), access);
        }
        else {
            cout << "Неверный формат ввода(:";
        }
    }
}
