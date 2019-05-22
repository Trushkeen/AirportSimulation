using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    class Airplane
    {
        public enum Cargo { WeightPeoples, WeightValuable, Military } //тип груза: пассажирский, транспортный, без груза
        public Cargo PlaneCargo { get; set; }
        public string PlaneName { get; set; }
        public string Status { get; set; }
        public Airport CurrentPort { get; set; } //текущий или последний аэропорт
        public Airport Destination { get; set; } //следующий аэропорт назначения
        public double Distance { get; set; } //расстояние до пункта назначения
        public double ElapsedDistance { get; set; } //пройденное расстояние
        public double FilledPlaneWeight { get; set; } //вес заправленного самолета
        public int MaxFlyingMinutes { get; set; } //макс. время полета в минутах
        public int RemainingFlyingMinutes
        {
            get
            {
                if (FlightTime != null) return MaxFlyingMinutes - FlightTime.Elapsed.Seconds;
                else return 0;
            }
        }
        public int ServiceBeforeFlightMinutes { get; set; } //время обслуживания перед взлетом
        public bool ReadyToFlight { get; set; } = false;
        public bool IsOnFlight { get; set; } = false;
        public bool FlightFinished { get; set; } = false;
        public bool NewAirportSet { get; set; } = false;
        public bool Crashed { get; set; } = false;
        public int? Seats { get; set; } //кол-во мест у пасс. самолета, знак ? у int? значит что переменная может быть null
        public int? OccupiedSeats { get; set; } //занятых мест
        public double? MaxCargoWeight { get; set; } //макс. вес груза для транс. самолета, может быть null аналогично верхней
        public double? CargoWeight { get; set; } //вес груза
        public string CargoStatus
        {
            get { if (Seats != null) return "Людей " + OccupiedSeats; else return "Груз " + CargoWeight; }
        }

        private Stopwatch ServiceMinutesRemaining; //время обслуживания
        private Stopwatch FlightTime; //время полета

        public Airplane(int seed = -1)
        {
            if (seed == -1) seed = DateTime.Now.Millisecond;
            Random rnd = new Random(seed);
            string[] PlaneNames = { "Boeing", "Sukhoi", "Airbus", "Embraer", "Cessna", "Airspace" };
            PlaneName = PlaneNames[rnd.Next(PlaneNames.Length)] + "-" + rnd.Next(100, 1000);
            FilledPlaneWeight = rnd.Next();
            MaxFlyingMinutes = rnd.Next(100, 360);
            ServiceBeforeFlightMinutes = rnd.Next(5, 10);
            Status = "Ожидает";
            switch (rnd.Next(3))
            {
                case 0: PlaneCargo = Cargo.Military; PlaneName += " военный"; break;
                case 1: PlaneCargo = Cargo.WeightPeoples; Seats = rnd.Next(100, 400); PlaneName += " пассажирский"; break;
                case 2: PlaneCargo = Cargo.WeightValuable; MaxCargoWeight = rnd.Next(500, 1000); PlaneName += " транспортный"; break;
            }
        }

        public bool PrepareToFlight()
        {
            FlightFinished = false;
            NewAirportSet = false;
            if (ReadyToFlight) return ReadyToFlight;
            if (ServiceMinutesRemaining == null && !ReadyToFlight)
            {
                ServiceMinutesRemaining = new Stopwatch();
                ServiceMinutesRemaining.Restart();
            }
            if (ServiceMinutesRemaining.Elapsed.Seconds >= ServiceBeforeFlightMinutes)
            {
                ServiceMinutesRemaining.Reset();
                ServiceMinutesRemaining = null;
                Status = "Ожидает свободной ВПП";
                ReadyToFlight = true;
                return ReadyToFlight;
            }
            else
            {
                Status = "Обслуживание " + ServiceMinutesRemaining.Elapsed.Seconds
                    + "/" + ServiceBeforeFlightMinutes;
                return ReadyToFlight;
            }
        }

        public void FlyFromRunway()
        {
            if (ReadyToFlight && !IsOnFlight && CurrentPort.PlaneTookRunway == null)
            {
                if (FlightTime == null)
                {
                    FlightTime = new Stopwatch();
                    FlightTime.Start();
                    CurrentPort.RunwayQueueFlight.Add(this);
                }
                if (CurrentPort.RunwayQueueFlight.Count > 0)
                {
                    if (CurrentPort.PlaneTookRunway == null) CurrentPort.PlaneTookRunway = CurrentPort.RunwayQueueFlight[0];
                    if (CurrentPort.PlaneTookRunway != CurrentPort.RunwayQueueFlight[0]) return;
                }
            }
            if (FlightTime != null)
                if (FlightTime.Elapsed.Seconds >= 5)
                {
                    Random rnd = new Random();
                    if (PlaneCargo == Cargo.WeightPeoples) OccupiedSeats = rnd.Next(Seats.Value);
                    if (PlaneCargo == Cargo.WeightValuable) CargoWeight = rnd.Next((int)MaxCargoWeight.Value);
                    IsOnFlight = true;
                    FlightTime = null;
                    Status = "Полет";
                    CurrentPort.PlaneTookRunway = null;
                    if (CurrentPort.RunwayQueueFlight.Count > 0)
                    {
                        CurrentPort.RunwayQueueFlight.RemoveAt(0);
                    }
                    CurrentPort.HangarsTaken--;
                    CurrentPort.Status = "ВПП свободна";
                }
                else
                {
                    Status = "Взлет с ВПП, " + FlightTime.Elapsed.Seconds + "/5";
                    CurrentPort.Status = "ВПП занята";
                }
        }

        public void FlyToDestination()
        {
            if (FlightTime == null)
            {
                FlightTime = new Stopwatch();
                FlightTime.Start();
            }
            double speed = 5;
            if (PlaneCargo == Cargo.WeightPeoples) speed -= (double)OccupiedSeats / (double)Seats;
            if (PlaneCargo == Cargo.WeightValuable) speed -= (double)CargoWeight / (double)MaxCargoWeight;
            if (IsOnFlight)
            {
                CalculateDistance();
                ElapsedDistance += speed / 2;
                Status = "Полет | Расстояние " + Math.Round(ElapsedDistance, 2) + "/" + Distance + " | Скорость " + Math.Round(speed, 2);
                if (ElapsedDistance > Distance)
                {
                    Status = "Запрос разрешения от диспетчера";
                }
            }
        }

        public void FlyToRunway()
        {
            if (RespondLanding())
            {
                Destination.RunwayQueueLanding.Add(this);
                if (Destination.RunwayQueueFlight.Count <= 0)
                {
                    if (ServiceMinutesRemaining == null)
                    {
                        ServiceMinutesRemaining = new Stopwatch();
                        ServiceMinutesRemaining.Start();
                    }
                    else if (Destination.HangarsTaken < Destination.HangarsTotal)
                    {
                        if (Destination.PlaneTookRunway == null)
                            Destination.PlaneTookRunway = Destination.RunwayQueueLanding[0];
                        if (Destination.PlaneTookRunway != Destination.RunwayQueueLanding[0]) return;
                        Status = "Посадка " + ServiceMinutesRemaining.Elapsed.Seconds + "/5";
                        Destination.Status = "ВПП занята";
                        if (ServiceMinutesRemaining.Elapsed.Seconds > 5)
                        {
                            FlightFinished = true;
                            ServiceMinutesRemaining = null;
                            Status = "Ожидает след. рейса";
                            Destination.Status = "ВПП свободна";
                            Destination.HangarsTaken++;
                            Destination.PlaneTookRunway = null;
                            if (Destination.RunwayQueueLanding.Count > 0) Destination.RunwayQueueLanding.RemoveAt(0);
                            CurrentPort = Destination;
                            ReadyToFlight = false;
                            IsOnFlight = false;
                            ElapsedDistance = 0;
                            Distance = 0;
                        }
                    }
                }
            }
        }

        private bool RespondLanding()
        {
            if (Destination.RunwayQueueFlight.Count > 0) return false;
            else return true;
        }

        public bool IsFlightTimeOver()
        {
            if (FlightTime != null)
                if (FlightTime.ElapsedMilliseconds / 1000 > MaxFlyingMinutes) return true;
                else return false;
            else return false;
        }

        public void SetNewRandomAirport(List<Airport> ports)
        {
            Random rnd = new Random();
            int portId = rnd.Next(ports.Count);
            Destination = ports[portId];
            while (Destination == CurrentPort)
            {
                Destination = ports[rnd.Next(ports.Count)];
            }
            NewAirportSet = true;
            CalculateDistance();
        }

        public static void SetRandomPlanesInHangars(List<Airplane> planes, List<Airport> ports)
        {
            Random rnd = new Random(planes.Count);
            foreach (var i in planes)
            {
                int portId = rnd.Next(ports.Count);
                while (ports[portId].HangarsTaken >= ports[portId].HangarsTotal)
                {
                    portId = rnd.Next(ports.Count);
                }
                i.CurrentPort = ports[portId];
                ports[portId].HangarsTaken++;
            }
        }

        public static void SetRandomDestAirports(List<Airplane> planes, List<Airport> ports)
        {
            Random rnd = new Random(ports.Count);
            foreach (var i in planes)
            {
                int portId = rnd.Next(ports.Count);
                i.Destination = ports[portId];
                while (i.Destination == i.CurrentPort)
                {
                    i.Destination = ports[rnd.Next(ports.Count)];
                }
            }
        }

        private double CalculateDistance()
        {
            if (Distance == 0)
            {
                if (CurrentPort.Coordinates[0] > Destination.Coordinates[0])
                {
                    Distance += CurrentPort.Coordinates[0] - Destination.Coordinates[0];
                }
                else
                {
                    Distance += Destination.Coordinates[0] - CurrentPort.Coordinates[0];
                }
                if (CurrentPort.Coordinates[1] > Destination.Coordinates[1])
                {
                    Distance += CurrentPort.Coordinates[1] - Destination.Coordinates[1];
                }
                else
                {
                    Distance += Destination.Coordinates[1] - CurrentPort.Coordinates[1];
                }
            }
            return Distance;
        }

        public override string ToString()
        {
            return PlaneName;
        }
    }
}
