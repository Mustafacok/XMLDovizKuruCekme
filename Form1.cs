using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLDovizKuruCekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(bugun);
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);


            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;
            label1.Text = string.Format("AMERİKAN DOLARI: Tarih {0} USD; {1}", tarih.ToShortDateString(), USD);

            string EURO = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml;
            label2.Text = string.Format("EURO : Tarih {0} EUR; {1}", tarih.ToShortDateString(), EURO);

            string STERLIN = xmldoc.SelectSingleNode(" Tarih_Date/Currency [@Kod='GBP']/BanknoteSelling").InnerXml;
            label3.Text = string.Format("İNGİLİZ STERLİNİ: Tarih {0} GBP; {1}", tarih.ToShortDateString(), STERLIN);


            string KATARRIYALI = xmldoc.SelectSingleNode(" Tarih_Date/Currency [@Kod='QAR']/ForexBuying").InnerXml;
            label4.Text = string.Format("KATAR RİYALİ: Tarih {0} QAR; {1}", tarih.ToShortDateString(), KATARRIYALI);
        }
    }
}
