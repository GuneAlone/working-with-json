using System;
using System.Net.Http;
using System.Threading.Tasks;

// скрипт в котором пользователь может ввести id пользователя из фейкового сервера jsonplaceholder.typicode.com и получить информацию о нем

Console.WriteLine("Введите id пользователя, информацию которого хотите просмотреть (от 1 до 10) ");

int userId;

userId = int.Parse(Console.ReadLine());

// здесь получаем информацию о желаемом пользователе 
string apiUrl = $"https://jsonplaceholder.typicode.com/users/{userId}";

// код для отправки HTTP запросов и получения ответов
using (HttpClient client = new HttpClient())
{
    // тут происходит GET-запрос к серверу для получения информации о желаемом пользователе
    HttpResponseMessage response = await client.GetAsync(apiUrl);

    // проверяем успешность ответа
    if (response.IsSuccessStatusCode)
    {
        // преобразование ответа в строку что бы пользователь мог прочитать ответ
        string responseBody = await response.Content.ReadAsStringAsync();

        // вывод информации о пользователе на консоль
        Console.WriteLine(responseBody);
    }
    else
    {
        // если на сервере не будет информации об пользователе или самого пользователя, то будет выводится ошибка 
        Console.WriteLine("Ошибка: " + response.StatusCode);
    }
}