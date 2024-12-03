using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lbl_locationCount.Text = db.TblLocation.Count().ToString();
            lbl_sumCapacityCount.Text = db.TblLocation.Sum(x => x.Capacity).ToString();
            lbl_guideCount.Text = db.TblGuide.Count().ToString();
            lbl_averageCapacity.Text = $"{db.TblLocation.Average(x => x.Capacity):F2}".ToString();
            lbl_averageTourPrice.Text = $"{db.TblLocation.Average(x => x.Price):F2} ₺";
            int lastCountryId = db.TblLocation.Max(x => x.LocationId);
            lbl_lastCountry.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            lbl_kapadokyaTourCapacity.Text = db.TblLocation.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lbl_ortalamaTurKapasite.Text = db.TblLocation.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
            var romeGuideId = db.TblLocation.Where(x => x.City == "Roma Turistik").Select(y => y.GuidId).FirstOrDefault();
            lbl_RomeGuideName.Text = db.TblGuide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            var maxCapacity = db.TblLocation.Max(x => x.Capacity);
            lbl_maxCapacityTour.Text = db.TblLocation.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
            var maxPrice = db.TblLocation.Max(x => x.Price);
            lbl_maxPrice.Text = db.TblLocation.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();
            var guideIdByNameAysegulCinar = db.TblGuide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lbl_AysegulCinarLocationCount.Text = db.TblLocation.Where(x => x.GuidId == guideIdByNameAysegulCinar).Count().ToString();
        }

    }
}
