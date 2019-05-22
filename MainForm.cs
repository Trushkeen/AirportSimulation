using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportSimulation
{
    public partial class MainForm : Form
    {
        List<Airplane> Planes = new List<Airplane>(); //список всех самолетов
        List<Airport> Ports = new List<Airport>(); //список всех аэропортов
        List<Airplane> Crashed = new List<Airplane>(); //список всех аэропортов
        private Stopwatch Worldtime = new Stopwatch(); //мировое время, 1 реальная секунда = 1 минута в программе
        private Timer UpdTimer = new Timer(); //таймер для обновления каждую миллисекунду, привязан к методу EveryTick
        private Timer UpdHalfSec = new Timer(); //таймер для обновления каждые полсекунды, привязан к методу EveryHalfSec
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                Planes.Add(new Airplane(Planes.Count));
                if (i < 5)
                {
                    Ports.Add(new Airport(Planes.Count));
                }
            }
            Airplane.SetRandomPlanesInHangars(Planes, Ports);
            Airplane.SetRandomDestAirports(Planes, Ports);
            foreach (var i in Planes)
            {
                dgwPlanes.Rows.Add(i.PlaneName, i.CurrentPort, i.Status, i.Destination);
                lbAirplanes.Items.Add(i);
            }
            foreach (var i in Ports)
            {
                dgwPorts.Rows.Add(i.AirportName, i.HangarsTaken + "/" + i.HangarsTotal, i.Status, i.Coordinates[0] + ":" + i.Coordinates[1]);
                lbAirports.Items.Add(i);
            }
            lbAirplanes.SelectedIndex = 0;
            lbAirports.SelectedIndex = 0;
            Worldtime.Start();
            UpdHalfSec.Interval = 100;
            UpdHalfSec.Start();
            UpdHalfSec.Tick += EveryHalfSec;
        }

        private void EveryHalfSec(object sender, EventArgs e)
        {
            dgwPlanes.Rows.Clear();
            dgwPorts.Rows.Clear();
            lblWorldtime.Text = Worldtime.Elapsed.Minutes + ":" + Worldtime.Elapsed.Seconds;
            foreach (var plane in Planes)
            {
                if (!plane.Crashed)
                {
                    if (!plane.IsFlightTimeOver())
                    {
                        if (!plane.ReadyToFlight && !plane.IsOnFlight) plane.PrepareToFlight();
                        else
                        if (plane.ReadyToFlight && !plane.IsOnFlight) plane.FlyFromRunway();
                        else
                        if (plane.ReadyToFlight && plane.IsOnFlight && !plane.FlightFinished) plane.FlyToDestination();
                        if (plane.ElapsedDistance > plane.Distance) plane.FlyToRunway();
                        if (plane.FlightFinished && !plane.NewAirportSet) plane.SetNewRandomAirport(Ports);
                    }
                    else
                    {
                        plane.Crashed = true;
                        Crashed.Add(plane);
                        plane.Status = "Потерпел крушение";
                    }
                }
                dgwPlanes.Rows.Add(plane.PlaneName, plane.CurrentPort, plane.Status, plane.Destination);
            }
            foreach (var port in Ports)
            {
                dgwPorts.Rows.Add(port.AirportName, port.HangarsTaken + "/" + port.HangarsTotal, port.Status, port.Coordinates[0] + ":" + port.Coordinates[1]);
            }
        }

        private void BtnShowPassengersInFlight_Click(object sender, EventArgs e)
        {
            int passengers = 0;
            foreach (var plane in Planes)
            {
                if (plane.OccupiedSeats != null)
                    if (plane.IsOnFlight) passengers += plane.OccupiedSeats.Value;
            }
            MessageBox.Show("В данный момент летят " + passengers + " пассажиров");
        }

        private void BtnShowPlanesInAir_Click(object sender, EventArgs e)
        {
            int planes = 0;
            foreach (var plane in Planes)
            {
                if (plane.IsOnFlight) planes++;
            }
            MessageBox.Show("В воздухе находится " + planes + " самолетов");
        }

        private void BtnShowAllCargo_Click(object sender, EventArgs e)
        {
            double weight = 0;
            foreach (var plane in Planes)
            {
                if (plane.MaxCargoWeight != null)
                    if (plane.IsOnFlight) weight += plane.CargoWeight.Value;
            }
            MessageBox.Show("В данный момент летит " + weight + " кг груза");
        }

        private void BtnShowCrashedPlanes_Click(object sender, EventArgs e)
        {
            int totalCrashed = 0, lostLives = 0;
            double lostCargo = 0;
            foreach (var plane in Crashed)
            {
                if (plane.Crashed)
                {
                    if (plane.OccupiedSeats != null)
                    {
                        lostLives += plane.OccupiedSeats.Value;
                    }
                    else if (plane.MaxCargoWeight != null)
                    {
                        lostCargo += plane.CargoWeight.Value;
                    }
                    totalCrashed++;
                }
            }
            MessageBox.Show($"Всего упало {totalCrashed} самолетов" +
                $"\nПогибло {lostLives} человек" +
                $"\nПотеряно {lostCargo} кг груза");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string planes = string.Empty;
            foreach (var i in Planes)
            {
                if (!i.Crashed && i.RemainingFlyingMinutes < nudMinutes.Value && i.RemainingFlyingMinutes != 0)
                {
                    planes += i.PlaneName + "\n";
                }
            }
            if (planes == string.Empty)
                MessageBox.Show("Таких самолетов нет!");
            else
                MessageBox.Show(planes);
        }

        private void BtnPlaneInfo_Click(object sender, EventArgs e)
        {
            string info = string.Empty;
            var plane = lbAirplanes.SelectedItem as Airplane;
            info += $"Самолет {plane.PlaneName}\n" +
                $"Остаток времени полета: {plane.RemainingFlyingMinutes}\n";
            if (plane.PlaneCargo == Airplane.Cargo.WeightPeoples) info += "Людей на борту " + plane.OccupiedSeats + "\n";
            else if (plane.PlaneCargo == Airplane.Cargo.WeightValuable) info += "Груза на борту " + plane.CargoWeight + "\n";
            info += $"Статус: {plane.Status}\n";
            MessageBox.Show(info);
        }

        private void BtnPortInfo_Click(object sender, EventArgs e)
        {
            string info = string.Empty;
            var port = lbAirports.SelectedItem as Airport;
            info += $"Аэропорт {port.AirportName}\n" +
                $"Координаты: {port.Coordinates[0]}:{port.Coordinates[1]}\n" +
                $"Самолеты, в этом аэропорту или последний раз вылетавшие из него:\n";
            foreach (var i in Planes)
            {
                if (i.CurrentPort == port) info += i.PlaneName + "\n";
            }
            MessageBox.Show(info);
        }
    }
}
