using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace In_Class_2025_04_08
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmdOK.Click += button1_Click; // Hooks the event to our code
        }
        // We need an event handler method
        // that runs when the user clicks cmdOK on our page
        private void button1_Click(object sender, EventArgs e)
        {
            // code will go here
            // lblResult.Text = "You Clicked!";
            // 1. Compute the number of days between the 2 calendar controls
            // 2. multiply that value by $200 (per day)
            // 3. apply 15% sales tax to that total
            // 4. display the total with tax in our label

            DateTime checkIn = CalCheckInDate.SelectedDate;
            DateTime checkOut = CalCheckOutDate.SelectedDate;
            if (checkIn == DateTime.MinValue || checkOut == DateTime.MinValue)
            {
                lblResult.Text = "Please select both check-in and check-out dates.";
                return;
            }
            if (checkOut <= checkIn)
            {
                lblResult.Text = "Check-out date must be after check-in date.";
                return;
            }
            // number of days
            int totalDays = (checkOut - checkIn).Days;

            // cost before tax
            double baseRate = 200.0;
            double totalBeforeTax = totalDays * baseRate;

            // apply the tax
            double totalAfterTax = totalBeforeTax * 1.15;

            // display the result
            lblResult.Text = $"Total with tax: {totalAfterTax:C}";
           
        }
    }
}