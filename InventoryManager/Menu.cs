using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using SQLiteDemo;

namespace InventoryManager
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Database IMDatabase = new Database("InventoryManagerDB");
            IMDatabase.AddTable("Products");
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            Database IMDatabase = new Database("InventoryManagerDB");

            AddMenu PromptNewItem = new AddMenu();
            PromptNewItem.ShowDialog();
        //    IMDatabase.AddRow("Products", );

            IMDatabase.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
