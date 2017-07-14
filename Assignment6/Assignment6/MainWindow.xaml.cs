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
        clsFlight flight = new clsFlight();
        int flightID;
        List<StackPanel> seats;
        int currentSeatSelected = 1;

        public MainWindow()
        {
            InitializeComponent();

            seats =  new List<StackPanel> { spnl1, spnl2, spnl3, spnl4, spnl5, spnl6, spnl7, spnl8, spnl9, spnl10, spnl11, spnl12, spnl13, spnl14, spnl15, spnl16, spnl17, spnl18, spnl19, spnl20, spnl21, spnl22, spnl23, spnl24};

            try
            {
                int iRet = 0; 
                DataSet ds = flight.GetDataSet("SELECT * FROM Flight", ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    cboChooseFlight.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        private void cboChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = (ComboBox)sender;

            spFlights.Visibility = Visibility.Visible;

            cboChoosePassenger.IsEnabled = true;

            String flightName = cBox.SelectedItem.ToString();

            flightID = flight.GetFlightID(flightName.Substring(0,3));

            int iRet = 0;
            switch (flightName)
            {
                case "102 Airbus A380":
                    for(int i = 16; i < 24; ++i)
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
            List<int> seatsTaken = flight.GetTakenSeats(ref iRet);

        }

        private void cboChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = (ComboBox)sender;

            if(cBox.SelectedItem == null)
            {
                seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0));
                currentSeatSelected = 1;
                txtPassengersSeat.Text = "";
                return;
            }
            String passengerName = cBox.SelectedItem.ToString();

            int iRet = 0;
            int seatNum = flight.GetPassengerSeatNum(passengerName, ref iRet);


            seats[currentSeatSelected-1].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0));

            currentSeatSelected = seatNum;
            txtPassengersSeat.Text = "" + currentSeatSelected;

            seats[seatNum-1].Background = new SolidColorBrush(Color.FromRgb(0x00, 0xFF, 0x00));
        }
    }
}
