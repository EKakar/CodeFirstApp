using DataAccess.ConctreteRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private CodeFirstDbContext _codeFirstDbContext;
        private SchoolRepository _schoolRepository;
        private TeacherRepository _teacherRepository;
        public Form1()
        {
            _codeFirstDbContext = new CodeFirstDbContext(); //DbSetlerin oluşması için
            _schoolRepository = new SchoolRepository(_codeFirstDbContext);
            _teacherRepository = new TeacherRepository(_codeFirstDbContext);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            School eklenecekOkul = new School();
            eklenecekOkul.Name = txtSchoolName.Text;
            eklenecekOkul.NumberOfEmploye = Convert.ToInt32(txtNumberOfEmploye.Text);
            eklenecekOkul.NumberOfStudent = Convert.ToInt32(txtNumberOfStudent.Text);

            _schoolRepository.Add(eklenecekOkul);
            Clear();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dgwOkul.DataSource = _schoolRepository.GetAll();
        }

        int aranacakOkulID;
        private void dgwOkul_SelectionChanged(object sender, EventArgs e)
        {
            aranacakOkulID = Convert.ToInt32(dgwOkul.CurrentRow.Cells["ID"].Value); // İlk okulumID' si 1
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecekOkul = _schoolRepository.GetById(aranacakOkulID);
            silinecekOkul.DeletedDate = DateTime.Now;
            _schoolRepository.Delete(silinecekOkul);
            dgwOkul.DataSource = _schoolRepository.GetAll();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var guncellenecekOkul = _schoolRepository.GetById(aranacakOkulID);

            guncellenecekOkul.Name = txtSchoolName.Text;
            guncellenecekOkul.NumberOfStudent = Convert.ToInt32(txtNumberOfStudent.Text);
            guncellenecekOkul.NumberOfEmploye = Convert.ToInt32(txtNumberOfEmploye.Text);
            guncellenecekOkul.ModifiedDate = DateTime.Now;
            guncellenecekOkul.ModifiedBy = "Şahin Uzun";
            _schoolRepository.Update(guncellenecekOkul);

            dgwOkul.DataSource = _schoolRepository.GetAll();
            Clear();
        }

        private void Clear()
        {
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = " ";
            }
        }
    }
}
