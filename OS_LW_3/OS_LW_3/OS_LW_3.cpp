#include <iostream>
#include <fstream>
#include <string>
#include <sys/types.h>
#include <unistd.h>
#include <cstring>
#include <cmath>
#include <iomanip>

using namespace std;

//Неименованные каналы связи in и out, массивы, хранящие файловые дискрипторы, 0-дескриптор для чтение, 1-дескриптор для запись
int pipe_in[2];//от родителя к потомку
int pipe_out[2];//от потомка к роидетлю

pid_t pid;

void help() {
    cout << "Справка: " << endl; //пользователь получает сообщение о справке 
    cout << "Чтобы посчитать произведение двух матриц, запустите программу без ключей" << endl; //пользователь получает сообщение о подсчете произведения двух матри, при запуске программы без ключей
    cout << "Вводите поочередно размеры матриц и значения матриц" << endl; // пользователь получает сообщение о вводе поочередно размер и значений матрий
    cout << "Колличество строк во второй матрице должно равняться колличеству столбцов в первой матрице"; //пользователь получает сообщение о том что колличество строк во второй матрице должно равняться колличеству столбцов в первой матрице
}


//Перемножение матриц
double** calculation_multy(double** left_matrix, double** right_matrix, int count_row_1, int count_column_1, int count_row_2, int count_column_2) {
    double** res = new double* [count_row_1];
    for (int i = 0; i < count_row_1; i++) {
        res[i] = new double[count_column_2];
        for (int j = 0; j < count_column_2; j++) {
            for (int k = 0; k < count_column_1; k++) {
                res[i][j] += left_matrix[i][k] * right_matrix[k][j];
            }
        }
    }

    return res;
}


bool skipLine() { // функция пропуска строки до символа переноса строки
    char c;
    bool isClear = true;
    do {
        std::cin.get(c); // получаем символы строки
        if (!iswspace(c)) {
            isClear = false;
        }
    } while (c != '\n'); // пока строка не закончится
    return isClear;
}

bool readDouble(double& target) { // функця чтения числе с плаваюшей точкой 
    std::cout << '>'; // выводим символ >
    std::cin >> target; // считываем проверяемое значение
    if (!std::cin) { // если введенное значение не удовлетворяет типу double то результат проверки false
        std::cin.clear(); // очистка потока
        skipLine(); // пропуск строки
        return false; // возврат false
    }
    if (!iswspace(std::cin.peek())) { //фукнция проверки пробелов
        skipLine();// пропуск строки
        return false;// возврат false
    }
    return true; // возврат true
}

bool readInt(int& target) {
    std::cout << '>'; // выводим символ >
    std::cin >> target;// считываем проверяемое значение
    if (!std::cin) { // если введенное значение не удовлетворяет типу int то результат проверки false
        std::cin.clear();// очистка потока
        skipLine(); // пропуск строки
        return false;
    }
    if (!iswspace(std::cin.peek())) {//фукнция проверки пробелов
        skipLine(); // пропуск строки
        return false;// возврат false
    }
    return true;// возврат true
}


/*
//Клиентская часть программы

//Принимает данные: рамзеры первой матрицы, первую матрицу и размеры второй матрицы, вторую матрицу

//Записывает и читает в/из неименованных каналов
//Выводит результат вычислений
*/


void frontend()
{
    int count_row_1, count_column_1;
    cout << "Введите колличество строк первой матрицы: " << endl; //пользователь получает сообщение о вводе колличества строк первой матрицы
    while (!readInt(count_row_1)) //проверка
    {
        cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользоваталь получает сообщение об ошибке и просит повторить ввод
    }

    cout << "Введите колличествово столбцов первой матрицы: " << endl;//пользователь получает сообщение о вводе колличества строк первой матрицы
    while (!readInt(count_column_1))//проверка
    {
        cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользоваталь получает сообщение об ошибке и просит повторить ввод
    }

    write(pipe_in[1], &count_row_1, sizeof(int));
    write(pipe_in[1], &count_column_1, sizeof(int));

    //если при перемножении колличество строк и столбцов <= 25, то пользователь сам заполняет таблицу
    if (count_column_1 * count_column_1 <= 25)
    {
        cout << "Заполните первую матрицу: " << endl; //пользовать получает сообщение о заполнении первой матрице
        for (int i = 0; i < count_row_1 * count_column_1; i++) {
            double a;
            while (!readDouble(a))
            {
                cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользоваталь получает сообщение об ошибке и просит повторить ввод
            }
            write(pipe_in[1], &a, sizeof(double));
        }
    }
    else //иначе, рандом
    {
        for (int i = 0; i < count_row_1 * count_column_1; i++) {
            double a;
            a = -100 + (rand() - rand()) % 201;
            write(pipe_in[1], &a, sizeof(double));
        }
    }

    int count_row_2, count_column_2;

    cout << "Введите колличество строк второй матрицы: " << endl; //пользователь получает сообщение о вводе колличества строк второй матрицы
    while (!readInt(count_row_2)) //проверка
    {
        cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользоваталь получает сообщение об ошибке и просит повторить ввод
    }
    cout << "Введите колличество столбцов второй матрицы: " << endl; //пользователь получает сообщение о вводе колличества столбцов второй матрицы
    while (!readInt(count_column_2)) //проверка
    {
        cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользователь получает сообщение об ошибке и просит повторить ввод
    }

    while (count_column_1 != count_row_2) {
        cout << "Колличество строк во второй матрице должно равняться колличеству столбцов в первой матрице! Повторите ввод!" << endl;
        cout << "Введите колличество строк второй матрицы: " << endl; //пользователь получает сообщение о вводе колличества строк второй матрицы
        while (!readInt(count_row_2)) // проверка
        {
            cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользователь получает сообщение об ошибке и просит повторить ввод
        }
        cout << "Введите колличество столбцов второй матрицы: " << endl; //пользователь получает сообщение о вводе колличества строк второй матрицы
        while (!readInt(count_column_2)) //проверка
        {
            cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользователь получает сообщение об ошибке и просит повторить ввод
        }
    }
    write(pipe_in[1], &count_row_2, sizeof(int));
    write(pipe_in[1], &count_column_2, sizeof(int));

    if (count_column_1 * count_column_1 <= 25) //если при перемножении колличество строк и столбцов <= 25, то пользователь сам заполняет таблицу
    {
        cout << "Заполните вторую матрицу: " << endl; //пользовать получает сообщение о заполнении второй матрице
        for (int i = 0; i < count_row_2 * count_column_2; i++) {
            double a;
            while (!readDouble(a))
            {
                cout << "Ой! Что-то пошло не так, пожалуйста повторите ввод." << endl; //пользоваталь получает сообщение об ошибке и просит повторить ввод
            }
            write(pipe_in[1], &a, sizeof(double));
        }
    }
    else //иначе, рандом
    {
        for (int i = 0; i < count_row_2 * count_column_2; i++) {
            double a;
            a = -100 + (rand() - rand()) % 201;
            write(pipe_in[1], &a, sizeof(double));
        }
    }

    cout << "Результат:" << endl; //пользователь получает сообщение с результатом

    //ввывод матрицы
    for (int i = 0; i < count_row_1; i++) {
        for (int j = 0; j < count_column_2; j++) {
            double a;
            read(pipe_out[0], &a, sizeof(double));
            cout << "c[" << i << "," << j << "]=" << setw(4) << a << "   ";
        }
        cout << endl;
    }


    exit(0); //выход
}


/*
//Серверная часть программы

//Производит вычисления по данным, переданным клиентской частью по не-
именованному каналу

//Записывает результат вычисления в неименованный канал
*/


void backend()
{
    //Считывание размеров и значений первой матрицы
    int count_row_1, count_column_1;
    read(pipe_in[0], &count_row_1, sizeof(int));
    read(pipe_in[0], &count_column_1, sizeof(int));
    double** left_matrix = new double* [count_row_1];
    for (int i = 0; i < count_row_1; i++) {
        left_matrix[i] = new double[count_column_1];
        for (int j = 0; j < count_column_1; j++) {
            read(pipe_in[0], &left_matrix[i][j], sizeof(double));
        }
    }

    //Считывание размеров и значенйи второй матрицы
    int count_row_2, count_column_2;
    read(pipe_in[0], &count_row_2, sizeof(int));
    read(pipe_in[0], &count_column_2, sizeof(int));
    double** right_matrix = new double* [count_row_2];
    for (int i = 0; i < count_row_2; i++) {
        right_matrix[i] = new double[count_column_2];
        for (int j = 0; j < count_column_2; j++) {
            read(pipe_in[0], &right_matrix[i][j], sizeof(double));
        }
    }

    //Подсчет произведения матриц и запись вычислений в канал
    double** result = new double* [count_row_1];
    for (int i = 0; i < count_row_1; i++) {
        result[i] = new double[count_column_2];
    }

    result = calculation_multy(left_matrix, right_matrix, count_row_1, count_column_1, count_row_2, count_column_2);
    for (int i = 0; i < count_row_1; i++) {
        for (int j = 0; j < count_column_2; j++) {
            double b = result[i][j];
            write(pipe_out[1], &b, sizeof(double));
        }

    }
    for (int i = 0; i < count_row_1; i++) {
        delete[] left_matrix[i];
    }
    delete[] left_matrix;

    for (int i = 0; i < count_row_2; i++) {
        delete[] right_matrix[i];
    }
    delete[] right_matrix;

    for (int i = 0; i < count_row_1; i++) {
        delete[] result[i];
    }
    delete[] result;


}


int main(int argc, char const* argv[]) {

    if (argc == 2 && !strcmp(argv[1], "--help"))
    {
        help();
        exit(0);
    }
    else if (argc != 2)
    {
        cout << "Запустите программу с ключом --help для получения справки" << endl;
        exit(1);
    }
    else
    {
        if (!strcmp(argv[1], "cons")) {
            cout << "Программа для умножения двух матриц\n";

            pipe(pipe_in);
            pipe(pipe_out);
            pid = fork();
            if (pid < 0)//если -1
            {
                cerr << "Критическая ошибка! Форк не создан" << endl;
                exit(1);
            }
            else if (pid > 0)//родительский процесс
            {
                frontend();
            }
            else//дочерний процесс
            {
                backend();
            }
            for (int i = 0; i < 2; ++i)
            {
                close(pipe_in[i]);
                close(pipe_out[i]);
            }
        }
    }
    return 0;
}