using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCONTACT.REPOSITORY;
using MyCONTACT.Servies;
using System.Data.Entity;


namespace MyCONTACT
{
    public partial class frmAddOrEdit : Form
    {
        contact_DBEntities db = new contact_DBEntities();

        public  int contactId = 0;

        public frmAddOrEdit()
        {
            
            InitializeComponent();
        }

        bool ValiDateInputs()
        {


            if (txtName.Text == null)
            {

                MessageBox.Show("لطفا نام را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFamliy.Text == null)
            {

                MessageBox.Show("لطفا نام خانوادگی را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (txtMobail.Text == null)
            {
                MessageBox.Show("لطفا موبایل را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }
            if (txtEmail.Text == null)
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }


            return true;
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValiDateInputs())
            {
                //MyContact contact = new MyContact();
                //contact.Name = txtName.Text;
                //contact.Family = txtFamliy.Text;
                //contact.Email = txtEmail.Text;
                //contact.Mobile = txtMobail.Text;
                //contact.Age = (int)txtAge.Value;
                //contact.Address = txtAdress.Text;

                if(contactId==0)
                {
                    MyContact contact = new MyContact();
                    contact.Name = txtName.Text;
                    contact.Family = txtFamliy.Text;
                    contact.Email = txtEmail.Text;
                    contact.Mobile = txtMobail.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Address = txtAdress.Text;
                    db.MyContacts.Add(contact);
                }
                else
                {
                    //contact.ContactID = contactId;
                    //db.Entry(contact).State = EntityState.Modified;

                    var contact = db.MyContacts.Find(contactId);

                    contact.Name = txtName.Text;
                    contact.Family = txtFamliy.Text;
                    contact.Email = txtEmail.Text;
                    contact.Mobile = txtMobail.Text; 
                    contact.Age = (int)txtAge.Value;
                    contact.Address = txtAdress.Text;
                }
                db.SaveChanges();
                
                
                    MessageBox.Show("عملیات با انجام شد ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                

                
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if(contactId==0)
            {
                this.Text = "افوزدن شخص حدید ";
            }
            else
            {
                this.Text = "ویرایش شخص  ";

                MyContact contact = db.MyContacts.Find(contactId);
                txtName.Text = contact.Name;
                txtFamliy.Text = contact.Family;
                txtEmail.Text = contact.Email;
                txtMobail.Text = contact.Mobile;
                txtAge.Text = contact.Age.ToString();
                txtAdress.Text = contact.Address;
                btnSubmit.Text = "ویرایش";
                
            }
            
        }
    }
}
