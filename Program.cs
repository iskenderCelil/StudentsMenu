using System.Runtime.InteropServices.ComTypes;
using ConsoleDb2;
using Microsoft.EntityFrameworkCore;

/*var todoList = new List<Todo>();
todoList.AddRange(
    new Todo {Task = "task 1"},
    new Todo{ Task = "task 2 "},
    new Todo{ Task = "task 3 "}
    );
var comletedTodos=todoList.Where(x => x.IsComplete).ToArray();*/

using var db=new AppDbContext();
/*foreach (var todo in db.Todos.ToList())
{
    Console.WriteLine(todo.Task);
}*/
var total = db.Todos.Count();
// biz linq method yapısı ile sorgumuzu kod tarafında otomatik oluşturuyoruz.
// eğer sonunda tolist first find count gibi sonucu üreten metotlar eklersek
// ef otomatik olarak oluşturduğu sorguyu veritabanına gönderir ve bize sonuç döndürür
Console.WriteLine($"Total done: {total}");

Console.Write("Eklemen istediğin iş : ");
var inputTask= Console.ReadLine();
var newTodo=new Todo
{
    Task = inputTask,
};
db.Todos.Add(newTodo); // contexte e ekler ama kayıt etmez
db.SaveChanges(); // bu komut ile contectdeki yapılan değişiklikleri veritabanına kaydedilir.

var todos= db.Todos.ToList();
foreach (var todo in todos)
{
    Console.WriteLine($"{todo.Id}-{todo.Task} - {(todo.IsComplete ? "tamamlandı" : "tamamlanmadı")}");
}
Console.WriteLine("------------");
Console.Write($"Hangi kaydı düzenlemek istiyorsun (id) : ");
var todoId= int.Parse(Console.ReadLine());
// find doğrudan id girdiğimizde ilgili kayıt varsa kaydı döner yoksa null döner 
// firstordefault girdiğimis koşulla ilk bulduğu kaydı getirir
// singleofdefault girdiğimiz koşula uyan kayıtlar içinde sadece 1 tane getirir.

/*var todoToUpdate = db.Todos.Find(todoId);
if (todoToUpdate == null)
{
    Console.WriteLine("Bu todo yok");
    return;
}

Console.Write("Güncellenecek iş tanımı : ");
var inputTodoTask = Console.ReadLine();
if (!string.IsNullOrEmpty(inputTask))
{
    todoToUpdate.Task = inputTodoTask;
}

Console.Write("Tamamlandı mı? (e)/ (h) : ");

var inputTodoCompleted=Console.ReadLine();
if (!string.IsNullOrEmpty(inputTodoCompleted))
{
    todoToUpdate.IsComplete = (inputTodoCompleted == "e");
}*/
// bir bulma işlemi yaptığımızda bulduğumuz veri totomatik olarak contexte eklenir
//dolayısıyla değişiklik yaparsak sadece yaptıklarımızı veritabanına göndermemiz yeterli
// bunun için de contexti kaydetmmiz gerekiyor 
db.SaveChanges();
/*foreach (var todo in todos)
{
    Console.WriteLine($"{todo.Id}-{todo.Task} - {(todo.IsComplete ? "tamamlandı" : "tamamlanmadı")}");
}*/
Console.WriteLine("------------");
Console.Write("Silmek istidiğin id : ");
var todoIdDelete= int.Parse(Console.ReadLine());
var todoToDelete= db.Todos.Find((todoIdDelete));
if (todoToDelete != null)
{
    db.Todos.Remove(todoToDelete);
    db.SaveChanges();
}
Console.WriteLine("------------");

foreach (var todo in db.Todos.ToList())
{
    Console.WriteLine($"{todo.Id}-{todo.Task} - {(todo.IsComplete ? "tamamlandı" : "tamamlanmadı")}");
}