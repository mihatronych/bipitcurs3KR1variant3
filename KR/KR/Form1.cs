using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
        bool isInsert = false;
        bool isUpdate = false;
        ServiceRef.Service1Client client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Insert.Enabled = false;
            Delete.Enabled = false;
            Update.Enabled = false;
            Approve.Enabled = false;
        }

        void ConnectUser()
        {
            if (textBox1.Text != "")
            {
                if (!isConnected)
                {
                    isConnected = true;
                    client = new ServiceRef.Service1Client();
                    client.Open();
                    dataGridView1.DataSource = client.Select(DateTime.Parse("01.01.2000 12:12:00"), DateTime.Parse("01.01.2050 12:12:00")).Tables["T1"];
                    textBox1.ReadOnly = true;
                    button1.Text = "Закончить работу";
                    Insert.Enabled = true;
                    Delete.Enabled = true;
                    Update.Enabled = true;
                    Approve.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Имя автора не введено");
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Close();
                client = null;
                dataGridView1.DataSource = null;
                textBox1.ReadOnly = false;
                button1.Text = "Написать заявки";
                Insert.Enabled = false;
                Delete.Enabled = false;
                Update.Enabled = false;
                Approve.Enabled = false;
                isConnected = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                numericUpDown1.Value = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                numericUpDown1.Value = (int)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value;
                textBox2.Text = DateTime.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString()).ToShortDateString();
                textBox3.Text = DateTime.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString()).ToShortTimeString();
                textBox4.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            var list = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                list.Add(int.Parse(row.Cells[0].Value.ToString()));
            }
            numericUpDown1.Value = list.Max() + 1;
            textBox4.Text = textBox1.Text;
            textBox3.Text = DateTime.Now.ToShortTimeString();
            textBox2.Text = DateTime.Now.ToShortDateString();
            textBox5.ReadOnly = false;
            textBox5.Text = "";
            Delete.Enabled = false;
            Insert.Enabled = false;
            Update.Enabled = false;
            Approve.Enabled = true;
            isInsert = true;
        }

        private void Approve_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                if (textBox5.Text != "")
                {
                    dataGridView1.Enabled = true;
                    isInsert = false;
                    client.Insert((int)numericUpDown1.Value, DateTime.Parse(textBox2.Text + " " + textBox3.Text), textBox4.Text, textBox5.Text);
                    textBox5.ReadOnly = true;
                    Delete.Enabled = true;
                    Insert.Enabled = true;
                    Update.Enabled = true;
                    Approve.Enabled = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = client.Select(DateTime.Parse("01.01.2000 12:12:00"), DateTime.Parse("01.01.2050 12:12:00")).Tables["T1"];
                }
            }
            if (isUpdate)
            {
                if (textBox5.Text != "")
                {
                    dataGridView1.Enabled = true;
                    isUpdate = false;
                    client.Update((int)numericUpDown1.Value, DateTime.Parse(textBox2.Text + " " + textBox3.Text), textBox4.Text, textBox5.Text);
                    textBox5.ReadOnly = true;
                    Delete.Enabled = true;
                    Insert.Enabled = true;
                    Update.Enabled = true;
                    Approve.Enabled = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = client.Select(DateTime.Parse("01.01.2000 12:12:00"), DateTime.Parse("01.01.2050 12:12:00")).Tables["T1"];
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            client.Delete((int)numericUpDown1.Value);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = client.Select(DateTime.Parse("01.01.2000 12:12:00"), DateTime.Parse("01.01.2050 12:12:00")).Tables["T1"];
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox4.Text)
            {
                dataGridView1.Enabled = false;
                textBox3.Text = DateTime.Now.ToShortTimeString();
                textBox2.Text = DateTime.Now.ToShortDateString();
                textBox5.ReadOnly = false;
                Delete.Enabled = false;
                Insert.Enabled = false;
                Update.Enabled = false;
                Approve.Enabled = true;
                isUpdate = true;
            }
            else
            {
                MessageBox.Show("Это не ваш запрос, вы не можете его менять");
            }
        }
    }
}
