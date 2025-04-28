using System.Net.Sockets;
using ClassHelperExamples;
using ClassHelperExamples.Helpers;

var me = new Student
{   
    Tckn = 71497022608,
    FirstName = "Orhan",
    LastName = "Ekici",
    BirthDate = new DateOnly(1989, 3, 17),
    Gender = "Erkek"
};

var students = new List<Student> {me};


while (true)
{
    Console.Clear();
    Console.WriteLine("Öğrenci Yönetim Sistemi\n".ToUpper());
    var inputSelection = Helper.AskOption("Yapmak istediğin işlemi seç", ["Listele", "Ekle", "Sil", "Çıkış"]);

    if (inputSelection == 1)
    {   
        if (students.Count >0)
        {
            StudentHelper.ListStudents(students);
            
        }
       
        else
        {   
            Console.Clear();
            Helper.ShowErrorMsg("Listede öğrenci yok.");
        }
        
    } 
    else if (inputSelection == 2)
    {   
        Console.Clear();
        Console.Write("TC kimlik numaranızı giriniz : ");
        long addTckn=long.Parse(Console.ReadLine());
        
        Console.Write("Adınızı giriniz : ");
        string addFirstName = Console.ReadLine();
        
        Console.Write("Soyadınızı giriniz : ");
        string addLastName = Console.ReadLine();
        
        Console.Write("Doğum tarihinizi giriniz (Örn:  1999-08-01 ): ");
        DateOnly addBirthDate = DateOnly.Parse(Console.ReadLine());

        Console.Write("Lütfen cinsiyet giriniz (Erkek/ Kadın) :");
        string? addGender = Console.ReadLine();
        
        var newStudents = new Student
        {
            Tckn = addTckn,
            FirstName = addFirstName,
            LastName = addLastName,
            BirthDate = addBirthDate,
            Gender = addGender,
        };
        students.Add(newStudents);
        
    }
    else if (inputSelection == 3)
    {   
        Console.Clear();
        
        Console.Write("Silmek istediğiniz öğrencinin TC kimlik numarasını giriniz : ");
        long removeTckn = long.Parse(Console.ReadLine());
        
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Tckn == removeTckn)
            {
                students.Remove(students[i]);
            }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Hoşçakalın...");
        Thread.Sleep(1000);
        break;
    }
    
    Console.WriteLine("\nMenüye dönmek için bir tuşa basın.");
    Console.ReadKey(true);
}



