using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace books_examples___96
{
    public partial class Form1 : Form
    {
        BindingList<Kitap> kitaplar = new BindingList<Kitap> ();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kitap kitap1 = new Kitap(1, "Süt ve Bal - Rupi Kaur", "177", "Şiir", false, new DateTime(2023, 12, 25));
            Kitap kitap2 = new Kitap(2, "Bu Beden Benim Evim - Rupi Kaur", "77", "Şiir", false, new DateTime(2023, 12, 25));
            Kitap kitap3 = new Kitap(3, "Emare Sarmaşık - Aslı Arslan", "738", "Roman", true, new DateTime(2023, 12, 23));
            Kitap kitap4 = new Kitap(4, "Kelebeği Öldürmek - Maral Atmaca", "400", "Roman", true, new DateTime(2023, 08, 13));

            kitaplar.Add(kitap1);
            kitaplar.Add(kitap2);
            kitaplar.Add(kitap3);
            kitaplar.Add(kitap4);

            dataGridView1.DataSource = kitaplar; //kitaplar listesini datagrid içine ekler

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //DataGridView üzerindeki seçili satırı Kitap türünde alır.

                Kitap kitap = (Kitap)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = kitap.Id.ToString();
                txtAd.Text = kitap.AdYazar;
                txtSayfa.Text = kitap.SayfaSayisi;
                cmbTur.Text = kitap.Tur;
                cbOkundu.Checked = kitap.Okundu;
                dateTimePicker1.Value = kitap.Tarih;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string adyazar = txtAd.Text;
            string sayfa = txtSayfa.Text;
            string tur = cmbTur.Text;
            bool okundu = cbOkundu.Checked;
            DateTime tarih = DateTime.Now;
            Kitap kitap = new Kitap(id, adyazar, sayfa, tur, okundu, tarih);

            kitaplar.Add(kitap); //kitaplar listesini datagrid içine ekler

            txtId.Clear();
            txtAd.Clear();
            txtSayfa.Clear();
            cbOkundu.Checked = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Kitap kitap = (Kitap)dataGridView1.SelectedRows[0].DataBoundItem;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult sonuc = MessageBox.Show(kitap.AdYazar + " Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (sonuc == DialogResult.Yes)
                {
                    kitaplar.Remove(kitap);
                }
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Kitap kitap = (Kitap)dataGridView1.SelectedRows[0].DataBoundItem;

                kitap.AdYazar = txtAd.Text;
                kitap.SayfaSayisi = txtSayfa.Text;
                kitap.Tur = cmbTur.Text;
                kitap.Tarih = dateTimePicker1.Value;

                dataGridView1.Refresh();  //datagridview yeniden yüklenir.
            }
        }
    }
}
