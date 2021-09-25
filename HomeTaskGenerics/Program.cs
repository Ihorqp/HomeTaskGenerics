using HomeTaskGenerics.UserCollection;
using System;
using System.Text;

namespace HomeTaskGenerics
{
    class Program
    {
		static void Main()
		{
			//var сollection = new UserCollection<Element>();

			//сollection.Add(new Element(1, 2));
			//сollection.Add(new Element(3, 4));
			//сollection.Add(new Element(5, 6));
			//сollection.Add(new Element(7, 8));

			//foreach (var element in сollection)
			//{
			//	Console.WriteLine($",{element.FieldA} , {element.FieldB}");
			//}

			//Console.WriteLine(new string('-', 5));

			//foreach (var element in сollection)
			//{
			//	Console.WriteLine($",{element.FieldA} , {element.FieldB}");
			//}
		//	Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
			
			var сollection = new UserCollection<string>();

			сollection.Add("some");
			сollection.Add("tmp");
			сollection.Add("text");
			сollection.Add("for");

			foreach (var element in сollection)
			{
				Console.WriteLine($",{element}");
			}

            Console.WriteLine(new string('-', 5));

            foreach (var element in сollection)
            {
                Console.WriteLine($",{element}");
            }
            Console.WriteLine($"Кількість елементів у списку: {сollection.Count,6}");
            Console.WriteLine($"Наявність значення text у списку: {сollection.Contains("text"),5}");
            Console.WriteLine($"Видалення значення text iз списку: {сollection.Remove("text"),-1}");
            Console.WriteLine($"Кількість елементів у списку: {сollection.Count,6}");
            Console.WriteLine($"Наявність значення text у списку: {сollection.Contains("text"),5}");
			Console.WriteLine($"Копіювання елементів у масив");

			string[] arr = new string[сollection.Count];
			сollection.CopyTo(arr, 0);

			Console.WriteLine($"Видалення усіх елементів зi списку: {сollection.GetType()}");
			сollection.Clear();

			Console.WriteLine($"Кількість елементів у списку: {сollection.Count,6}");

			Console.WriteLine($"відображення елементів з масива:");

			foreach (var element in arr)
			{
				Console.WriteLine($",{element}");
			}

			Console.ReadKey();
		}
	}
}
