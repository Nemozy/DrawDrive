using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarsData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SaveData();
        }

        private void SaveData()
        {
            CarData data = new CarData();
            data.Model = "FireGTO";
            data.EnginePower = 2.8f;
            data.DriveUnit = 0;
            data.GasolineMax = 20;
            data.MaxSpeed = 160;
            data.GasolineConsumption = 18;
            data.Health = 100;
            data.Weight = 1540;

            data.Cost = 0;
            var item = new Types.Tuple<string, List<CarItemData>>("EnginePower", new List<CarItemData>());
            item.second.Add(new CarItemData() { Model = "EnginePower", Level = 1, Cost = 0, EnginePower = 0, DriveUnit = 0, GasolineMax = 0, MaxSpeed = 1, GasolineConsumption = 0.1f, Health = 0, Weight = 10 });
            item.second.Add(new CarItemData() { Model = "EnginePower", Level = 2, Cost = 10, EnginePower = 0.05f, DriveUnit = 0, GasolineMax = 0, MaxSpeed = 1, GasolineConsumption = 0.1f, Health = 0, Weight = 10 });
            item.second.Add(new CarItemData() { Model = "EnginePower", Level = 3, Cost = 30, EnginePower = 0.1f, DriveUnit = 0, GasolineMax = 0, MaxSpeed = 1, GasolineConsumption = 0.2f, Health = 0, Weight = 10 });
            data.Items.Add(item);

            Serializator.SaveFile(data, @"F:/aatestf");
        }
    }
}
