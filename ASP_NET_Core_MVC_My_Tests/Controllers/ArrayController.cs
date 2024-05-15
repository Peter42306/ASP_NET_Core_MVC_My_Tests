using ASP_NET_Core_MVC_My_Tests.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Core_MVC_My_Tests.Controllers
{
	public class ArrayController : Controller
	{
		//public IActionResult Index()
		//{
		//	// Создаём массив чисел от 100 до 999
		//	List<int> numbers = new List<int>();
		//	for (int i = 100; i <= 999; i++)
		//	{
		//		numbers.Add(i);
		//	}

		//          //// Преобразуем числа в строки и объединяем их
		//          //string numbersAsString =string.Join(",", numbers);

		//          //// Передаем строку с числами в представление
		//          //ViewBag.Numbers=numbersAsString;

		//          // Возвращаем представление с массивом чисел в качестве модели
		//          return View(numbers);
		//}


		// рабочий вариант без создания списка
		public IActionResult Index()
		{
			int start = 1;
			int end = 9999;
			int size = 200;

			// Создаём массив случайных чисел            
			int[] numbersArray = new int[size];

			// генерируем случайные числа в заданном диапазоне
			Random random = new Random();
			for (int i = 0; i < size; i++)
			{
				numbersArray[i] = random.Next(start, end + 1);
			}

			List<int> allNumbersList = new List<int>(numbersArray);
			List<int> evenNumbersList = new List<int>();
			List<int> oddNumbersList = new List<int>();

			var viewModel = new ArrayModel
			{
				AllNumbers = allNumbersList,
				EvenNumbers = evenNumbersList,
				OddNumbers = oddNumbersList
			};

			int quantityEven = 0;
			int quantityOdd = 0;
			int maxNumber = numbersArray[0];
			int minNumber = numbersArray[0];
            int maxEvenNumber = numbersArray[0];
            int minEvenNumber = numbersArray[0];
            int maxOddNumber = numbersArray[0];
            int minOddNumber = numbersArray[0];


            foreach (var number in allNumbersList)
            {
                if (number % 2 == 0)
                {
                    evenNumbersList.Add(number);
                    quantityEven++;
                }
                else
                {
                    oddNumbersList.Add(number);
                    quantityOdd++;
                }
				
				if (number>maxNumber)
				{
					maxNumber=number;	
				}

				if (number < minNumber)
				{
					minNumber=number;
				}
            }
			
			foreach (var number in evenNumbersList)
			{
				if(number>maxEvenNumber)
				{
					maxEvenNumber = number;
				}
				if(number<minEvenNumber)
				{
					minEvenNumber = number;
				}
			}

            foreach (var number in oddNumbersList)
            {
                if (number > maxOddNumber)
                {
                    maxOddNumber = number;
                }
                if (number < minOddNumber)
                {
                    minOddNumber = number;
                }
            }

            ViewBag.Start = start;
			ViewBag.End = end;
			ViewBag.Size = size;
			ViewBag.QuantityEven = quantityEven;
			ViewBag.QuantityOdd = quantityOdd;
			ViewBag.MaxNumber = maxNumber;
			ViewBag.MinNumber = minNumber;
            ViewBag.MaxEvenNumber = maxEvenNumber;
            ViewBag.MinEvenNumber = minEvenNumber; 
			ViewBag.MaxOddNumber = maxOddNumber;
            ViewBag.MinOddNumber = minOddNumber;

            return View(viewModel);
		}


		//// рабочий вариант без создания списка
		//public IActionResult Index()
		//{
		//    int start = 1000;
		//    int end = 9999;
		//    int size = 1000;

		//    // Создаём массив случайных чисел            
		//    int[] numbers=new int[size];

		//    // генерируем случайные числа в заданном диапазоне
		//    Random random = new Random();
		//    for (int i = 0; i < size; i++)
		//    {
		//        numbers[i] = random.Next(start, end + 1);
		//    }

		//    ViewBag.Start = start;
		//    ViewBag.End = end;

		//    return View(numbers);
		//}

		//public IActionResult Index(int? start,int? end)
		//{
		//    start ??= 1000;
		//    end ??= 9999;

		//    // Создаём массив чисел от 100 до 999
		//    List<int> numbers = new List<int>();
		//    for (int i = start.Value; i <= end.Value; i++)
		//    {
		//        numbers.Add(i);
		//    }

		//    ViewBag.Start=start;
		//    ViewBag.End=end;

		//    return View(numbers);
		//}
	}
}
