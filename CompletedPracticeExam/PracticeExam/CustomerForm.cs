using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeExam
{
    public partial class CustomerForm : Form
    {
        CustomerBL cbl = new CustomerBL();
        Customer currentCustomer = new Customer();
        bool editMode = false;
        bool newMode = false;
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCustomersDropDown();
            ClearForm();
        }

        private void PopulateCustomersDropDown()
        {
            List<Customer> customers = cbl.GetCustomers();
            cboCustomers.ValueMember = "CustomerID";
            cboCustomers.DisplayMember = "CompanyName";
            cboCustomers.DataSource = customers;
            cboCustomers.SelectedIndex = -1;
        }

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomers.SelectedIndex > -1)
            {
                currentCustomer = cbl.GetCustomer(cboCustomers.SelectedValue.ToString());
                PopulateForm(currentCustomer);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editMode = !editMode;
            newMode = false;
            ToggleReadOnly();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCustomerID.ReadOnly = !txtCustomerID.ReadOnly;
            cboCustomers.SelectedIndex = -1;
            ToggleReadOnly();
            editMode = false;
            newMode = !newMode;
            ClearForm();
        }

        private void ClearForm()
        {
            txtCustomerID.Text = "";
            txtCompName.Text = "";
            txtContName.Text = "";
            txtContTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtRegion.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            txtPostCode.Text = "";
            txtFax.Text = "";

        }

        private void ToggleReadOnly()
        {
            txtCompName.ReadOnly = (!txtCompName.ReadOnly);
            txtContName.ReadOnly = !txtContName.ReadOnly;
            txtContTitle.ReadOnly = !txtContTitle.ReadOnly;
            txtAddress.ReadOnly = !txtAddress.ReadOnly;
            txtCity.ReadOnly = !txtCity.ReadOnly;
            txtRegion.ReadOnly = !txtRegion.ReadOnly;
            txtPostCode.ReadOnly = !txtPostCode.ReadOnly;
            txtCountry.ReadOnly = !txtCountry.ReadOnly;
            txtPhone.ReadOnly = !txtPhone.ReadOnly;
            txtFax.ReadOnly = !txtFax.ReadOnly;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer customer = CreateCustomerFromForm();
            ValidationContext context = new ValidationContext(customer, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(customer, context, errors, true))
            {
                string msg = "";
                foreach (ValidationResult result in errors)
                {
                    msg += result.ErrorMessage + Environment.NewLine;
                }
                MessageBox.Show(msg);
                return;
            }
            else
            {
                if (editMode)
                {
                    try
                    {
                        if (cbl.EditCustomer(customer) == 1)
                        {
                            MessageBox.Show($"{customer.CompanyName} successfully updated");
                            cboCustomers.SelectedIndex = -1;
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Update failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (newMode)
                {
                    try
                    {
                        if (cbl.CreateCustomer(customer) == 1)
                        {
                            MessageBox.Show($"{customer.CompanyName} successfully created");
                            cboCustomers.SelectedIndex = -1;
                            ClearForm();

                        }
                        else
                        {
                            MessageBox.Show("Creation failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


        }

        private void PopulateForm(Customer c)
        {
            txtCustomerID.Text = c.CustomerID;
            txtCompName.Text = c.CompanyName;
            txtContName.Text = c.ContactName;
            txtContTitle.Text = c.ContactTitle;
            txtAddress.Text = c.Address;
            txtCity.Text = c.City;
            txtRegion.Text = c.Region;
            txtPostCode.Text = c.PostalCode;
            txtCountry.Text = c.Country;
            txtPhone.Text = c.Phone;
            txtFax.Text = c.Fax;
        }

        private Customer CreateCustomerFromForm()
        {
            Customer c = new Customer();
            c.CustomerID = txtCustomerID.Text;
            c.CompanyName = txtCompName.Text;
            c.ContactName = txtContName.Text;
            c.ContactTitle = txtContTitle.Text;
            c.Address = txtAddress.Text;
            c.City = txtCity.Text;
            c.Region = txtRegion.Text;
            c.PostalCode = txtPostCode.Text;
            c.Country = txtCountry.Text;
            c.Phone = txtPhone.Text;
            c.Fax = txtFax.Text;
            return c;
        }
    }
}
