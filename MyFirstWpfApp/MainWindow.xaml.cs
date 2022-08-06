using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        List<Car> list = new List<Car>(); // other chages
        Dictionary<string, object> Queries = new Dictionary<string, object>();

        public MainWindow()
        {
            InitializeComponent();
       
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            lstResult.ItemsSource = element?.Tag as IEnumerable;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            People MrFirst = new People() { Name = "Mr First" };
            People MrSecond = new People() { Name = "Mr Second" };
            //People Olga = new People() { Name = "Olga" };
            //People Diana = new People() { Name = "Diana" };
            //People Vadiks = new People() { Name = "Vadiks" };
            //People Ruslans = new People() { Name = "Ruslans" };
            //People Juris = new People() { Name = "Juris" };
            //People Valdis = new People() { Name = "Valdis" };
            //People Nikola = new People() { Name = "Nikola" };



            List<People> peoples = new List<People>() { MrSecond, MrFirst };

            List<Info> infos = new List<Info>();
            infos.Add(new Info() { Number = "AM6655", Information = "Broken!!!" });
            infos.Add(new Info() { Number = "SPEEDY", Information = "Broken!!!" });
            infos.Add(new Info() { Number = "RU1993", Information = "Broken!!!" });
            infos.Add(new Info() { Number = "OP2145", Information = "Good conditioning" });


            list.Add(new Car() { Marka = "Toyota Corolla", Number = "FN6755", Class = CarClass.Family, FuelType = FuelType.gasoline });
            list.Last().Owners.Add(DateTime.Now, MrSecond);

            list.Add(new Car() { Marka = "Toyota Corolla", Number = "FN6775", Class = CarClass.Family, FuelType = FuelType.gasoline });
            list.Add(new Car() { Marka = "Toyota Corolla", Number = "FM6855", Class = CarClass.Family, FuelType = FuelType.gasoline });
            list.Last().Owners.Add(new DateTime(1999, 12, 12), MrFirst);
            list.Last().Owners.Add(DateTime.Now, MrSecond);
            list.Add(new Car() { Marka = "Toyota Avensis", Number = "AM6655", Class = CarClass.Family });
            list.Add(new Car() { Marka = "Honda", Number = "GT6650", Class = CarClass.Lux });
            list.Add(new Car() { Marka = "Moscvich 412", Number = "AS1122", Class = CarClass.Lux });

            list.Add(new Car() { Marka = "Lexus", Number = "SE6775", Class = CarClass.Lux });
            list.Add(new Car() { Marka = "Kia Sportage", Number = "MO9999", Class = CarClass.Family });
            list.Last().Owners.Add(new DateTime(2021, 1, 4), MrFirst);
            list.Last().Owners.Add(new DateTime(2021, 3, 5), MrSecond);

            list.Add(new Car() { Marka = "Kia Sportage", Number = "ALEX", Class = CarClass.Family });
            list.Last().Owners.Add(new DateTime(2022, 1, 12), MrFirst);
            list.Last().Owners.Add(new DateTime(2022, 3, 3), MrSecond);

            list.Add(new Car() { Marka = "Nissan Note", Number = "VR1015", Class = CarClass.Family });
            list.Last().Owners.Add(new DateTime(2010, 2, 10), MrFirst);
            list.Last().Owners.Add(new DateTime(2012, 7, 15), MrSecond);

            list.Add(new Car() { Marka = "Porsche 911", Number = "SPEEDY", Class = CarClass.Sport });
            list.Last().Owners.Add(new DateTime(2022, 7, 21), MrSecond);
            list.Last().Owners.Add(new DateTime(2021, 4, 29), MrFirst);

            list.Add(new Car() { Marka = "Opel Astra", Number = "OP2145", Class = CarClass.Family });
            list.Last().Owners.Add(new DateTime(2021, 8, 16), MrFirst);
            list.Last().Owners.Add(new DateTime(2022, 1, 5), MrSecond);

            list.Add(new Car() { Marka = "Smart Fortwo", Number = "KX1125", Class = CarClass.Smart });
            list.Last().Owners.Add(new DateTime(2019, 6, 19), MrFirst);
            list.Last().Owners.Add(new DateTime(2020, 2, 17), MrSecond);

            list.Add(new Car() { Marka = "GAZ-53", Number = "RU1993", Class = CarClass.Truck });
            list.Last().Owners.Add(new DateTime(2000, 3, 22), MrFirst);
            list.Last().Owners.Add(new DateTime(2022, 6, 20), MrSecond);

            lstMyLst.ItemsSource = list;

            Queries.Add("Номер начинается с FN или FM",

                                                    //Izmaiņas
                                                    from item in list // Может быть несколько from (в SQL CROSS JOIN)
                                                    let CurrentOwner = item.Owners.OrderByDescending(x => x.Key).FirstOrDefault()
                                                    where item.Class == CarClass.Family
                                                    where item.Number?.StartsWith("FN") == true || item.Number?.StartsWith("FM") == true
                                                    select new
                                                    {
                                                        Valsts_Numurs = item.Number,
                                                        Class = item.Class,
                                                        CurrentOwner = CurrentOwner.Value == null ? People.Default : CurrentOwner.Value
                                                    });



            Queries.Add("Группировка по марке", from item in list
                                                group item by item.Marka);



            Queries.Add("Объединение двух коллекций", from car in list
                                                      from people in peoples
                                                      orderby car.Marka, people.Name descending
                                                      select new
                                                      {
                                                          Car = car,
                                                          People = people
                                                      });

            
                     

            

            
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            // разность последовательностей
            Queries.Add("Разность коллекций", soft.Except(hard));

            Queries.Add("Пересечение коллекций", soft.Intersect(hard));

            Queries.Add("Объединение коллекций", soft.Union(hard));

            Queries.Add("Сцепление коллекций", soft.Concat(hard));

            Queries.Add("Объединение по ключу", list.Join(  infos, 
                                                            x => x.Number, 
                                                            y => y.Number, 
                                                            (x,y) => new
                                                                        {
                                                                            Car = x,
                                                                            info = y.Information
                                                                        }));

            Queries.Add("Объединение (синтаксис)", 
                                          from a in list
                                          join b in infos on a.Number equals b.Number
                                          select new
                                          {
                                              Info = b.Information,
                                              CarNumber = a.Number
                                          });


            Queries.Add("В течении последнего года менялся владелец",
                                                from item in list
                                                where item.Owners.Any() && item.Owners.FirstOrDefault().Key.Value >= DateTime.Now.AddYears(-1)
                                                select new 
                                                {
                                                    Auto = item.Marka,
                                                    Valsts_numurs = item.Number
                                                }
                                                );



            Queries.Add("Сломанные машины",

                                                     from a in list
                                                     join b in infos on a.Number equals b.Number
                                                     where b.Information == "Broken!!!"
                                                     select new
                                                     {
                                                         Auto = a.Marka,
                                                         Info = b.Information

                                                     });

            Queries.Add("Группа (год посл. смены владельца)",
                                                from item in list
                                                where item.Owners.Any()
                                                let Datums = item.Owners.OrderByDescending(x=>x.Key).FirstOrDefault().Key.Value.Year.ToString()
                                                orderby Datums
                                                group item by Datums

                                                );

            Queries.Add("Сорт. (год послед. смены владельца)",

                                                   from item in list
                                                   let Datums = item.Owners.Any() ? item.Owners.OrderByDescending(x => x.Key).FirstOrDefault().Key.Value.Year.ToString() : null
                                                   orderby Datums, item.Marka descending                                                   
                                                   select new
                                                   {
                                                       Date = Datums,
                                                       Auto = item.Marka,
                                                   });


            //Agregate, Count, Sum, Max, Min, Average - агрегаторы
            //Skip, SkipLast, SkipWhile (пропуск пока условие), Take, TakeLast, TakeWhile (выбор пока условие)
            //All (все удовлетворяют условию), Any, Contains, First, FirstOrDefault, Last, LastOrDefault




            // Я напишу комментарий



            foreach (var item in Queries)
            {
                Button Item = new Button();
                Item.Width = 200;
                Item.Tag = item.Value;
                Item.Content = item.Key;
                Item.Click += button_Click;
                Menu.Items.Add(Item);
            }
        }
    }
}
