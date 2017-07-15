using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
#region class fields
        /// <summary>
        /// The flight object represents the current flight and contains the business logic for flights.
        /// </summary>
        clsFlight flight = new clsFlight();
        /// <summary>
        /// A list of the stack panels that are the flight "seats". This makes it easier to access them and use them as a collection.
        /// </summary>
        List<StackPanel> seats;
        /// <summary>
        /// The seat that is currently selected.
        /// </summary>
        int currentSeatSelected = 1;
        /// <summary>
        /// The current flight's flight name (Flight_Num & " " & Aircraft_Type
        /// </summary>
        String flightName;
        #endregion

#region constructor
        /// <summary>
        /// The window default constructor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                seats = new List<StackPanel> { spnl1, spnl2, spnl3, spnl4, spnl5, spnl6, spnl7, spnl8, spnl9, spnl10, spnl11, spnl12, spnl13, spnl14, spnl15, spnl16, spnl17, spnl18, spnl19, spnl20, spnl21, spnl22, spnl23, spnl24 };

                int iRet = 0; 
                DataSet ds = flight.GetTableContents("Flight", ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    cboChooseFlight.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

#region event handlers
        /// <summary>
        /// The on selection changed listener for the Choose Flight combo box
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cboChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cBox = (ComboBox)sender;

                spFlights.Visibility = Visibility.Visible;

                cboChoosePassenger.IsEnabled = true;

                flightName = cBox.SelectedItem.ToString();

                int iRet = 0;
                switch (flightName)
                {
                    case "102 Airbus A380":
                        for (int i = 16; i < 24; ++i)
                        {
                            seats[i].Visibility = Visibility.Hidden;
                        }
                        break;
                    case "412 Boeing 767":
                        for (int i = 16; i < 24; ++i)
                        {
                            seats[i].Visibility = Visibility.Visible;
                        }
                        flight.GetPassengersInFlight(flightName, ref iRet);
                        break;
                    default:
                        break;
                }

                DataSet ds;
                iRet = 0;
                ds = flight.GetPassengersInFlight(flightName, ref iRet);

                cboChoosePassenger.Items.Clear();
                for (int i = 0; i < iRet; ++i)
                {
                    cboChoosePassenger.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }

                iRet = 0;
                List<int> seatsTaken = flight.GetTakenSeats(flightName, ref iRet);

                for (int i = 0; i < seats.Count; ++i)
                {
                    if (seatsTaken.Contains(i + 1))
                    {
                        seats[i].Background = new SolidColorBrush(Color.FromRgb(0xF0, 0x17, 0x17));
                    }
                    else
                    {
                        seats[i].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0));
                    }
                }

                btnAddPassenger.IsEnabled = true;
                btnChangeSeat.IsEnabled = false;
                btnDeletePassenger.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The on selection changed listener for the Choose Passenger combo box
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cboChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cBox = (ComboBox)sender;

                if (cBox.SelectedItem == null)
                {
                    seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0));
                    currentSeatSelected = 1;
                    txtPassengersSeat.Text = "";
                    return;
                }
                String passengerName = cBox.SelectedItem.ToString();

                int iRet = 0;
                int seatNum = flight.GetPassengerSeatNum(passengerName, ref iRet);

                iRet = 0;
                List<int> seatsTaken = flight.GetTakenSeats(flightName, ref iRet);

                if (seatsTaken.Contains(currentSeatSelected))
                {
                    seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0xF0, 0x17, 0x17));
                }
                else
                {
                    seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0));
                }

                currentSeatSelected = seatNum;
                txtPassengersSeat.Text = "" + currentSeatSelected;

                seats[seatNum - 1].Background = new SolidColorBrush(Color.FromRgb(0x00, 0xFF, 0x00));

                btnChangeSeat.IsEnabled = true;
                btnDeletePassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The on click listener for the Add Passenger button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddPassenger addPassenger = new AddPassenger();
                addPassenger.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region error handling
        /// <summary>
        /// The error handling method. This prints out a user readable stack trace for debugging purposes.
        /// </summary>
        /// <param name="sClass">The class the error originated from</param>
        /// <param name="sMethod">The method the error originated from</param>
        /// <param name="sMessage">The error message</param>
        private void HandleError(String sClass, String sMethod, String sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
        #endregion
    }
}
