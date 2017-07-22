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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Add passenger window oject
        /// </summary>
        wndAddPassenger wndAddPass;

        /// <summary>
        /// Contains all the flight logic for the given flight
        /// </summary>
        clsFlightLogic flightLogic;

        /// <summary>
        /// The default constuctor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                flightLogic = new clsFlightLogic();

                List<clsFlight> flights = flightLogic.GetAllFlights();

                flights.ForEach(flight => cbChooseFlight.Items.Add(flight));
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #region event handlers
        /// <summary>
        /// The event handler for the Choose Flight combo box
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selection = ((clsFlight)cbChooseFlight.SelectedItem).FlightID.ToString();
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;

                if (selection == "1")
                {
                    CanvasA380.Visibility = Visibility.Visible;
                    Canvas767.Visibility = Visibility.Hidden;
                }
                else
                {
                    Canvas767.Visibility = Visibility.Visible;
                    CanvasA380.Visibility = Visibility.Hidden;
                }
                
                cbChoosePassenger.Items.Clear();

                List<clsPassenger> passengers = flightLogic.GetFlightPassengers(selection);

                passengers.ForEach(passenger => cbChoosePassenger.Items.Add(passenger));
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler for the Add Passenger button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();
                wndAddPass.ShowDialog();
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
        /// The error handling method. Writes out erors to C:\Error.txt
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion
    }
}
