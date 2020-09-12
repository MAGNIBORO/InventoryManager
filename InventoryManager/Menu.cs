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
using SQLiteDatabase;

namespace InventoryManager
{
    public partial class Menu : Form
    {
        private Database IMDatabase;
        private List<ProductItem> DatabaseList;
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IMDatabase = new Database("InventoryManagerDB");
            IMDatabase.AddTable("Products");
            this.UpdateList("Products");
        }

        private void UpdateList(string tablename)
        {
            this.DatabaseList = this.IMDatabase.GetProductListFromTable(tablename);
            dataGridView1.DataSource = this.DatabaseList;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMenu PromptNewItem = new AddMenu();
            PromptNewItem.GetNewItem(this.IMDatabase, "Products");
            this.UpdateList("Products");
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0)
            {
                MessageBox.Show("Seleccione al menos un elemento para eliminar");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar los Elementos Seleccionados?", "Eliminar Elementos", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.No)
            {
                return;
            }

            for (int i = 0; i < selectedRows; i++)
            {
                int index = dataGridView1.SelectedRows[i].Index;
                string itemname = dataGridView1.Rows[index].Cells[0].Value.ToString();
                this.IMDatabase.DeleteRowsByName("products", itemname);
            }

            this.UpdateList("products");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Menu_SizeChanged(object sender, EventArgs e)
        {
            this.UpdateList("Products");
        }

    }
}
