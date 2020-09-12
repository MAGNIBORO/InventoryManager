using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLiteDatabase;

namespace InventoryManager
{
    public partial class AddMenu : Form
    {
        private Database DatabaseToFill;
        private string tableName;

        public AddMenu()
        {
            InitializeComponent();
        }

        public void GetNewItem(Database db, string tablename)
        {
            this.DatabaseToFill = db;
            this.tableName = tablename;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductItem item = new ProductItem();
            string ItemName;
            float ItemPrice;
            int ItemQuantity;

            try{ItemName = textBox1.Text;}
            catch (System.FormatException)
            {
                MessageBox.Show("Nombre Invalido");
                return;
            }
            if(ItemName.Length == 0)
            {
                MessageBox.Show("Nombre Invalido");
                return;
            }
            if(this.DatabaseToFill.AlreadyHas("products", "name", textBox1.Text) > 0)
            {
                MessageBox.Show("Articulo ya existente");
                return;
            }

            try {ItemPrice = float.Parse(textBox2.Text);}
            catch (System.FormatException)
            {
                MessageBox.Show("Precio Invalido");
                return;
            }

            try {ItemQuantity = int.Parse(textBox3.Text);}
            catch (System.FormatException)
            {
                MessageBox.Show("Cantidad Invalida");
                return;
            }
            if(ItemQuantity < 0)
            {
                MessageBox.Show("Cantidad Invalida");
                return;
            }

            item.EditFields(ItemName, ItemPrice, ItemQuantity);

            this.DatabaseToFill.AddRow(tableName, item);

            if (checkBox1.Checked == false)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
