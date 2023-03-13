using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp.FilmArsivi.Frm;

namespace WindowsFormsApp.FilmArsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=FilmArsiv;Integrated Security=True");

        void Filmler()
        {
            SqlDataAdapter adap = new SqlDataAdapter("SELECT AD,LINK FROM TBLFILMLER", connect);
            DataTable table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void filmListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmFilmEkle().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Film Arşiv App Celil Çavuş tarafından 13.03.2023 Yılında Yapılmıştır.","Hakkımda",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void filmEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmFilmEkle().ShowDialog();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedCells[0].RowIndex.ToString());
            string link = dataGridView1.Rows[id].Cells[1].Value.ToString();
            webBrowser1.Navigate(link.ToString());
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filmler();
        }
    }
}
