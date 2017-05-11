using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// @author Cameron Pickle
/// @Date 5/10/17
/// </summary>
namespace Program1
{
    /// <summary>
    /// This class is the event handler for the buttons in the windows form.
    /// It takes the users input for the text box and displays it in the 
    /// appropriate Message box based on the user's decision. It also displays
    /// which of the Message box options the user clicked on the windows form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The constructor for the windows form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The onClick handler for the first submit button. 
        /// This displays the message in a information Message box with an OK button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Your message was: " + txtBox1.Text, "MessageBox!",MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblResult.Text = "You clicked: " + result.ToString();
        }

        /// <summary>
        /// The onClick handler for the second submit button. 
        /// This displays the message in a warning Message box with OK and CANCEL buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Your message was: " + txtBox2.Text, "MessageBox!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            lblResult.Text = "You clicked: " + result.ToString();
        }

        /// <summary>
        /// The onClick handler for the third submit button. 
        /// This displays the message in a error Message box with YES and NO buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Your message was: " + txtBox3.Text, "MessageBox!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            lblResult.Text = "You clicked: " + result.ToString();
        }
    }
}
