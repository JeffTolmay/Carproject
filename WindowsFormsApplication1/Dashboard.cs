using Car_Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Dashboard : Form 
    {
        List<Car> newcar = new List<Car>();
        public Dashboard()
        {
            InitializeComponent();

            Carfoundlistbox.DataSource = newcar;
            Carfoundlistbox.DisplayMember = "Fullinfo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            newcar = db.GetCar(Querytext.Text);
            Carfoundlistbox.DataSource = newcar;
            Carfoundlistbox.DisplayMember = "Fullinfo";
        }
    }
}
