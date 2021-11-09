using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            typePattern();
            constantPattern();
            varPattern();
            recursivePattern(15);
            
            object[] data = { null, 39, DateTime.Now, null, new Person("Ercan", "Yesil", new DateTime(1996, 6, 3)), 78, new Person("Ahmet", "Yılmaz", new DateTime(2020, 2, 27)) };
            foreach (var item in data)
            {
                recursivePattern(item);
            }

            typevar();

        }







        // C# 7.0 Pattern Matching



        #region Type Pattern
        // Object içerisindeki bir tipin belirlenmesinde kullanılan is operatörünün desenleştirilmiş halidir.
        // is ile belirlenen türün direkt dönüşümünü sağlar.
        
        static void typePattern()
        {                  
            object x = 125;
            //x = Console.ReadLine();
            if (x is string _k)
            {
                Console.WriteLine("x değişkeni string tipindedir.");
            }
            else if (x is int k)
            {
                Console.WriteLine("x değişkeni int tipindedir.");
            }
        }
        
        #endregion


        #region Constant Pattern
        // Elimizdeki veriyi sabit bir değer ile karşılaştırabilmemizi sağlar.
        
        static void constantPattern()
        {
            int a = 5;
            Console.WriteLine(a is int); //true     //is operatörü işlemidir.
            Console.WriteLine(a is 5);  // true     //Bir değikenin değeri "==" gibi check edilirse constant pattern 
            object x = "Ercan Yeşil";
            if (x is "Ercan Yeşil")
            {
                Console.WriteLine("Ercan");
            }
            else if (x is null)
            {
                Console.WriteLine("null");
            }
        }
        
        #endregion


        #region Var Pattern
        // Eldeki veriyi 'var' değişkeni ile elde etmemizi sağlamaktadır.
        // Verilen değerin türüne bürünen bir keyword..  runtime'da bürünme işlemini gerçekleştirmektedir.
        // var keyword'ü ile var pattern'deki var yapılanması arasında davranış farkı vardır.
        // var keyword'ü : Derleme zamanında türünü belirlerken,
        // var pattern'da ki var keyword'ü ise : Runtime'da türünü belirleyecektir.
        
        static void varPattern()
        {
            object x = "Türkiye";
            if (x is var a)
            {
                Console.WriteLine(a);
            }
        }
        
        #endregion


        #region Recursive Pattern
        // Bu desen switch-case yapılanması üzerinde birçok yenilik getirmektedir.
        // Switch bloğunda referans türlü değişkenlerde kontrol edilebilmektedir.
        // Ayrıca switch bloğuna when komutu ile çeşitli şart/koşul niteliği kazandırılmıştır.
        // Recursive pattern, case null komutu ile ilgili türün/referansın null olup olmamasını kontrol edebilmesinden dolayı Constant pattern'i kapsamaktadır.
        // Recursive pattern, tür kontrolü yaptığı için Type Pattern'i kapsamaktadır.

        
        static void recursivePattern(object o)
        {                     
            switch (o) // Parantez içinde referans türlü değişken olan object ile kontrol sağlayabilmiş olduk bu örnekle.
            {
                case null:
                    Console.WriteLine("Gelen null bir değerdir.");
                    break;
                case int i:
                    Console.WriteLine("Integer tipinde bir sayıdır.");
                    break;
                case Person p when p.Name.StartsWith("Bo"):
                    Console.WriteLine($"Bo bir person {p.Name} dır.");
                    break;
                case Person p:
                    Console.WriteLine($"Başka bir person {p.Name} dır.");
                    break;
                case var x:
                    Console.WriteLine($"Sıradaki objenin [{x}] türü {x?.GetType().Name} dir ");
                    break;
                default:
                    
            }
        }

        static int counter = 0;
        public static void IsPattern(object o)
        {
            counter++;
            if (o is var x) Console.WriteLine($"{counter}. nesnenin türü {x?.GetType()?.Name}'dır.");
        }

        public class Person
        {
            public Person(string name, string surname, DateTime birthDate)
            {
                this.Name = name;
                this.Surname = surname;
                this.Birthdate = birthDate;
            }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthdate { get; set; }
        }
        
        #endregion


        #region Type&Var Pattern Fark
        
        static void typevar()
        {
            object x = "Ercan Yeşil";
            if (x is string a)
            {
                Console.WriteLine(a); // if sorgusuna soktuğumuz için a değişkeni if blokları içerisinde çağırabilirim. Dışında çağırırsam hata verecektir.
            } 
            
            bool result = x is string o1; // type pattern'da x değişkenin değerinin string olmama ihtimalinde
            //Console.WriteLine(o1);      // o1'in null olma ihtimali söz konusu olduğu için o1 kullanırken hata vermektedir. 
            Console.WriteLine(result);

            bool result2 = x is var o2; // var pattern'da ise x değişkenin değeri ne olursa olsun var ile o2'ye atanacağından dolayı
                                        // o2'nin null olma ihtimali yoktur. o2'yi rahatça kullanabiliriz.
            Console.WriteLine(o2);
            Console.WriteLine(result2);
        }
        
        #endregion
    }
}
