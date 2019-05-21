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
        private Stopwatch Worldtime = new Stopwatch(); //мировое время, 1 реальная секунда = 1 минута в программе
        private Timer UpdTimer = new Timer(); //таймер для обновления каждую миллисекунду, привязан к методу EveryTick
        private Timer UpdHalfSec = new Timer(); //таймер для обновления каждые полсекунды, привязан к методу EveryHalfSec
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
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
            }
            foreach (var i in Ports)
            {
                dgwPorts.Rows.Add(i.AirportName, i.HangarsTaken + "/" + i.HangarsTotal, i.Status, i.Coordinates[0] + ":" + i.Coordinates[1]);
            }
            Worldtime.Start();
            //UpdTimer.Interval = 1;
            //UpdTimer.Start();
            //UpdTimer.Tick += EveryTick;
            UpdHalfSec.Interval = 500;
            UpdHalfSec.Start();
            UpdHalfSec.Tick += EveryHalfSec;
        }

        private void EveryHalfSec(object sender, EventArgs e)
        {
            dgwPlanes.Rows.Clear();
            dgwPorts.Rows.Clear();
            lblWorldtime.Text = Worldtime.Elapsed.Minutes + ":" + Worldtime.Elapsed.Seconds;
            foreach (var i in Planes)
            {
                if (!i.ReadyToFlight && !i.IsOnFlight) i.PrepareToFlight();
                if (i.ReadyToFlight && !i.IsOnFlight) i.FlyFromRunway();
                if (i.ReadyToFlight && i.IsOnFlight) i.FlyToDestination();
                dgwPlanes.Rows.Add(i.PlaneName, i.CurrentPort, i.Status, i.Destination);
            }
            foreach (var i in Ports)
            {
                dgwPorts.Rows.Add(i.AirportName, i.HangarsTaken + "/" + i.HangarsTotal, i.Status, i.Coordinates[0] + ":" + i.Coordinates[1]);
            }
        }

        private void EveryTick(object sender, EventArgs e)
        {

        }
    }
}
