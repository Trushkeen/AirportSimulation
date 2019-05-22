using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    class Airport
    {
        private enum AirportType { Military, MilitaryAndCivilian }; //тип аэропорта: онли военный, или военный и гражданский
        public string AirportName { get; set; }
        public string Status { get; set; }
        public int[] Coordinates { get; set; } = new int[2]; //координаты
        public int HangarsTotal { get; set; } //стояночных мест всего
        public int HangarsAvailable { get; set; } //доступных стоянок
        public int HangarsTaken { get; set; } //занятых стоянок
        public Airplane PlaneTookRunway { get; set; } //самолет на ВПП
        public List<Airplane> RunwayQueueFlight { get; set; } //очередь на взлет с ВПП
        public List<Airplane> RunwayQueueLanding { get; set; } //очередь на посадку на ВПП

        public Airport(int seed = -1)
        {
            if (seed == -1) seed = DateTime.Now.Millisecond;
            Random rnd = new Random(seed);
            string[] names = {"Платов", "Гагарин", "им. Карамзина", "им. Алексея Леонова", "Шарль-де-Голль",
                    "им. Джона Кеннеди", "им. Федерико Феллини", "Сент-Экзюпери", "Никола Тесла" };
            AirportName = names[rnd.Next(names.Length)];
            Coordinates[0] = rnd.Next(360);
            Coordinates[1] = rnd.Next(360);
            HangarsTotal = rnd.Next(5) + 1;
            HangarsTaken = 0;
            HangarsAvailable = HangarsTotal;
            RunwayQueueFlight = new List<Airplane>();
            RunwayQueueLanding = new List<Airplane>();
            Status = "ВПП свободна";
        }

        public override string ToString()
        {
            return AirportName;
        }
    }
}
