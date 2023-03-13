using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp.FilmArsivi.Frm
{
    public partial class FrmFilmEkle : Form
    {
        public FrmFilmEkle()
        {
            InitializeComponent();
        }
        public int ID { get; set; }

        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=FilmArsiv;Integrated Security=True");
       
        void GetList()
        {
            SqlDataAdapter adap = new SqlDataAdapter("SELECT ID,AD,LINK FROM TBLFILMLER", connect);
            DataTable table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand comm = new SqlCommand($@"INSERT INTO TBLFILMLER (AD, KATEGORI, LINK) VALUES ('{txtAd.Text}','{txtKategori.Text}','{txtLink.Text}')", connect);
            comm.ExecuteNonQuery();
            connect.Close();
            GetList();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand comm = new SqlCommand($@"DELETE FROM TBLFILMLER WHERE ID = {ID}", connect);
            comm.ExecuteNonQuery();
            connect.Close();
            GetList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand comm = new SqlCommand($@"UPDATE TBLFILMLER SET 
            AD = '{txtAd.Text}',
            KATEGORI = '{txtKategori.Text}',
            LINK = '{txtLink.Text}'
            WHERE ID = {ID}
            ", connect);
            comm.ExecuteNonQuery();
            connect.Close();
            GetList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
        }

        private void FrmFilmEkle_Load(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
