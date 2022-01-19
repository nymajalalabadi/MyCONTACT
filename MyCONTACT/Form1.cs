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

namespace MyCONTACT
{
    public partial class Contact : Form
    {
       
        public Contact()
        {
           
            InitializeComponent();
        }

        

        private void Contact_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (contact_DBEntities db = new contact_DBEntities())
            {
                dgContacts.AutoGenerateColumns = false;
                dgContacts.DataSource = db.MyContacts.ToList();
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if(dgContacts.CurrentRow!=null)
            {
                string name = dgContacts.CurrentRow.Cells[1].Value.ToString();
                string famliy = dgContacts.CurrentRow.Cells[2].Value.ToString();
                string FullName = name + "" + famliy;
                if (MessageBox.Show($"آیا از حذف {FullName} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    using(contact_DBEntities db = new contact_DBEntities())
                    {
                        var contact = db.MyContacts.Single(i => i.ContactID == contactId);
                        db.MyContacts.Remove(contact);
                    }
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک کاربر را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgContacts.CurrentRow != null)
            {
                int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.contactId = contactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (contact_DBEntities db = new contact_DBEntities())
            {
                dgContacts.DataSource = db.MyContacts.Where(i => i.Name.Contains(txtSearch.Text) || i.Name.Contains(txtSearch.Text)).ToList();
            }
             
        }
    }
}
