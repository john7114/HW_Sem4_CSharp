// Задача 3: **(Дополнительное, не обязательно)
// Назовём число «интересным» если его произведение цифр делится на их сумму. 
// Напишите программу, которая заполняет массив на 10 «интересных» случайных целых чисел от 10 до 1000. 
// (каждый эл-т массива – сгенерирован случайно)
//[591, 532, 189, 523, 333, 546, 527, 275, 456, 264]

// 1. Создать метод нахождения количества символов в рандомном числе.
// 2. Создать метод для нахождение "интересных" чисел из числа случайных от 10 до 1000
// 3. Создать массив на 10 элементов и заполнить его с помощью ранее созданого метода
// 4. Вывести на экран массив из "интересных" чисел

// 1.
int FindLengthOfNumber(int val)
{
    int count = 0;
    while (val > 0)
    {
        val = val / 10;
        count++;
    }
    return count;
}

// 2.
void GenRandomNumbers(int[] arr)
{
    int size = arr.Length;
    int i = 0;
    while (i < size)
    {
        int random_num = new Random().Next(10, 1000); // переменная для текущего сгенерированного числа 
        int sizeRandomNum = FindLengthOfNumber(random_num); // кол-во цифр рандомного числа

        int[] arr_Random = new int[sizeRandomNum];                //массив из цифр рандомного числа 
        int random_numForArray = random_num;  // промежуточная переменная для текущего рандомного числа, для создания массива 
        for (int count = sizeRandomNum - 1; count >= 0; count--)  //
        {                                                         //  
            arr_Random[count] = random_numForArray % 10;          //
            random_numForArray = random_numForArray / 10;         //
        }

        int product_random = 1;                              // произведение цифр рандомного числа
        for (int j = 0; j < sizeRandomNum; j++)              //
        {                                                    //                             
            product_random = product_random * arr_Random[j]; //
        }                                                    //

        int sum = 0;                               // сумма цифр рандомного числа
        for (int j = 0; j < sizeRandomNum; j++)    //
        {                                          //
            sum = sum + arr_Random[j];             //
        }                                          //   

        if (sum != 0)                              // Проверка, является ли рандомное число "интересным"   
        {                                          // Только при таком виде исполнения исключений
            if (product_random != 0)               // программа работает правильно.
            {                                      // Если расположить все исключения if в одной строке,         
                if (product_random / sum == 0)     // программа начинает выдавать числа с нолями, 
                {                                  // что противоречит исключению product_randon != 0
                    arr[i] = random_num;
                    i++;
                }
            }
        }
    }
}

// 3.
int[] InterestingNumbers = new int[10];
GenRandomNumbers(InterestingNumbers);

// 4.
int len = InterestingNumbers.Length;
for (int i = 0; i < len; i++)
{
    if (i == 0) Console.WriteLine("Массив из интересных чисел: ");
    Console.Write(InterestingNumbers[i] + ", ");
}