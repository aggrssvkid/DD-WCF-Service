using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.ServiceReference1;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please, enter just one input file");
                return;
            }

            string input = args[0];

            if (File.Exists(input) == false)
            {
                Console.WriteLine("Your file doesnt exist! :(");
                return;
            }
            //считываем файл
            var fContent = File.ReadAllLines(input);
            // создаем экземпляр класса, описанного в службе WCF и вызываем метод этого класса
            var client = new ServiceClient();
            var dict = client.ParallelParse(fContent);

            //сортирнуем словарь и записываем данные в файл
            var sort_words = dict.OrderByDescending(_ => _.Value);
            using (StreamWriter file = new StreamWriter("output.txt"))
            {
                foreach (var row in sort_words)
                {
                    file.WriteLine($"{row.Key} {row.Value}");
                }
            }
            Console.WriteLine("Complited!");
        }
    }
}

/*P.S
 * Да, мы увеличили размер буфера в файле конфига, но как ни крути, все на этом свете имеет начало и конец. (Кроме Санта-Барбары)
 * Тогда, возникает вопрос, а что же делать, если размер данных, которые мы хотим перебросить на сервак, больше, чем буфер?!
 * (Извечный вопрос, который тяготит душу каждого программиста!) Ну хорошо, подумал я, надо передавать информацию порциями. Но какими порциями,
 * если мы не знаем заранее размер буфера?! Если не знаем, значит его надо узнать! Инфа о нем должна быть указана в информации о подключении,
 * иначе быть не может, так как должна существовать область памяти для обмена данными (по закону природы).
 * Да, я подключение к серверу  осуществляю с помощью App.config, вместо прямого кода в проге, но информация о подрубке
 * должна же где-то храниться?! Все это натолкнуло меня на мысль, что надо поискать, как же найти метаданные в рантайме?! А вот как, с помощью
 * библитеки "System.Configuration"!
 * 
 *           // Сохраняем информацию, хранящуюся в файлк конфига
 *          System.Configuration.Configuration config =  System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(
            new System.Configuration.ExeConfigurationFileMap() { ExeConfigFilename = "..//..//App.config" },
            System.Configuration.ConfigurationUserLevel.None);

            // Достаем нужную инфу по нудному подключению! (Можно по всем коллекциям модключений пройтись, если потребуется)
            // Но нас интересует BasicHttpBinding

            var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);
            var httpBindings = serviceModel.Bindings.BasicHttpBinding;
            var bindingEl = httpBindings.ConfiguredBindings[0];
            var binding = (BasicHttpBinding)Activator.CreateInstance(httpBindings.BindingType);
            bindingEl.ApplyConfiguration(binding);
            var max = binding.MaxBufferSize;

   Далее, зная размер буфера, можно спокойно отправлять меньшее количество байт, в ответ получать частично заполненный словарь, суммировать
    значения в словаре, и так до бесконечности...(парадокс!)
        Методов наверняка много, а что делать, если мы не знаем, где располагается файл конфига?! Впрочем, это уже другая история, да и мне
        с мышами воевать надо, пойду я...
*/