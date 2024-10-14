using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace leson_07_dz_05_
{
    internal class Program
    {
        public static void Line() => Console.WriteLine("==========================================================================================================");
        public class Play /*Пьеса*/     /* Dz#3 -> */: IDisposable 
        {
            public string title      { get; set; }
            public string author     { get; set; }
            public string genre      { get; set; }
            public int year          { get; set; }
            public Play(string title, string author, string genre, int year)
            {
                this.title = title;
                this.author = author;
                this.genre = genre;
                this.year = year;
            }
            public void ShowPlay()
            {
                Console.WriteLine($"Название пьесы:{title}\n" +
                                  $"Ф.И.О. автора :{author}\n" +
                                  $"Жанр          :{genre}\n" +
                                  $"Год           :{year}");
            }
            public void Dispose() //<-Dz#3 
            {                
                Console.WriteLine("Освобождение ресурсов ");
            }
            ~Play() //Имя деструктора совпадает с именем класса, но перед ним ставится тильда ~.
            {                
                Console.WriteLine("Деструктор Dz№1 вызван");
                // Когда программа завершит выполнение, деструктор объекта будет вызван автоматически             
            }
        }
        public class Shop /*Магазин*/ : IDisposable
        {
            public string name_shop     { get; set; }
            public string address_shop  { get; set; }
            public string tupe_Shop     { get; set; }

            public Shop(string name_shop, string address_shop, string tupe_Shop)
            {
                this.name_shop = name_shop;
                this.address_shop = address_shop;
                this.tupe_Shop = tupe_Shop;
            } 
            public void ShowShop()
            {
                Console.WriteLine($"Магазин:{name_shop}\n" +
                                  $"Адрес  :{address_shop}\n" +
                                  $"Тип    :{tupe_Shop}");
            }
            public void Dispose()
            {
                Line();
                Console.WriteLine("Dz№2 Dispose вызван -> очищаем ресурсы в ручную ");
                Line();
            }
            ~Shop()//<-Dz#3 
            {
                Console.WriteLine("Деструктор Dz№2 вызван");
            }
        }
        static void Main(string[] args)
        {
            Line();
            Console.WriteLine("Dz_№1");
            var play = new Play("Ромео и Джульетта", "Уильям Шекспир", "Трагедия", 1595);
            play.ShowPlay();
            Line();
            //Деструктор будет вызван внутри класса 

            Console.WriteLine("Dz_№2");
            using (var магазин = new Shop("АТБ", "м.Одесса с.Котовка. ул.Мира.15", "Продовольственный"))
            {
                // Работаем с объектом
                магазин.ShowShop();
            } // Dispose вызывается автоматически после выхода из using
            // Деструктор будет вызван сборщиком мусора позже
           
            Console.WriteLine("Dz№3    \r\n//Dispose позволяет сразу освободить ресурсы вручную, когда они больше не нужны.\r\n//Деструктор используется для автоматической очистки, но его вызов может задержаться,\r\n//так как зависит от работы сборщика мусора.");
            Line();
            Console.WriteLine("Конец работы програмы  \n\n\n");
            //№3    
            //Dispose позволяет сразу освободить ресурсы вручную, когда они больше не нужны.
            //Деструктор используется для автоматической очистки, но его вызов может задержаться,
            //так как зависит от работы сборщика мусора.

        }
    }
}
