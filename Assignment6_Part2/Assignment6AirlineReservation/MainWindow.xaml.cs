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
        #region class fields
        /// <summary>
        /// Add passenger window oject
        /// </summary>
        wndAddPassenger wndAddPass;

        /// <summary>
        /// Contains all the flight logic for the given flight
        /// </summary>
        clsFlightLogic flightLogic;

        /// <summary>
        /// A list of all the seat labels for a given flight
        /// </summary>
        List<Label> seats;

        /// <summary>
        /// The current flights ID
        /// </summary>
        string currentFlightID;

        /// <summary>
        /// The currently selected passenger
        /// </summary>
        clsPassenger selectedPassenger;

        /// <summary>
        /// The passenger getting inserted
        /// </summary>
        clsPassenger addPassenger;

        /// <summary>
        /// Set to true when a passenger's seat is being changed
        /// </summary>
        bool changeSeat = false;

        /// <summary>
        /// Set to true when adding a new passenger
        /// </summary>
        bool addingPassenger = false;

        /// <summary>
        /// The blue color brush
        /// </summary>
        SolidColorBrush blue;

        /// <summary>
        /// The red color brush
        /// </summary>
        SolidColorBrush red;

        /// <summary>
        /// The green color brush
        /// </summary>
        SolidColorBrush green;
        #endregion

        #region constructor
        /// <summary>
        /// The default constuctor
        /// </summary>
        public MainWindow()
        {
            try
            {
                blue = new SolidColorBrush(Color.FromRgb(0x00, 0x23, 0xFD));
                red = new SolidColorBrush(Color.FromRgb(0xFD, 0x00, 0x00));
                green = new SolidColorBrush(Color.FromRgb(0x00, 0xFD, 0x00));

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
        #endregion

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
                cbChoosePassenger.Items.Clear();

                currentFlightID = ((clsFlight)cbChooseFlight.SelectedItem).FlightID.ToString();
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;
                cmdChangeSeat.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;

                if (currentFlightID == "1")
                {
                    seats = new List<Label>{    SeatA1, SeatA2, SeatA3, SeatA4, SeatA5,
                                                SeatA6, SeatA7, SeatA8, SeatA9, SeatA10,
                                                SeatA11, SeatA12, SeatA13, SeatA14, SeatA15,
                                                SeatA16, SeatA17, SeatA18};
                    CanvasA380.Visibility = Visibility.Visible;
                    Canvas767.Visibility = Visibility.Hidden;
                }
                else
                {
                    seats = new List<Label>{    Seat1, Seat2, Seat3, Seat4, Seat5,
                                                Seat6, Seat7, Seat8, Seat9, Seat10,
                                                Seat11, Seat12, Seat13, Seat14, Seat15,
                                                Seat16, Seat17, Seat18, Seat19, Seat20,
                                                Seat21, Seat22, Seat23, Seat24};
                    Canvas767.Visibility = Visibility.Visible;
                    CanvasA380.Visibility = Visibility.Hidden;
                }

                RefreshPassengerList();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler for the Choose Passenger combo box
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmdChangeSeat.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;

                if (selectedPassenger != null)
                {
                    seats[selectedPassenger.SeatNumber - 1].Background = red;
                }
                selectedPassenger = (clsPassenger)cbChoosePassenger.SelectedItem;
                if(selectedPassenger != null)
                {
                    seats[selectedPassenger.SeatNumber - 1].Background = green;

                    lblPassengersSeatNumber.Content = selectedPassenger.SeatNumber;
                }
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
                wndAddPass = new wndAddPassenger(this);
                wndAddPass.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler for the seat labels
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void lblSeat_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label seat = (Label)sender;

                if (changeSeat)
                {
                    clsPassenger clickedPassenger = flightLogic.GetPassengerBySeat(currentFlightID, seat.Content.ToString());
                    if (clickedPassenger == null)
                    {
                        if(addingPassenger)
                        {
                            flightLogic.InsertPassenger(currentFlightID, addPassenger);

                            addingPassenger = false;

                            flightLogic.UpdatePassengerSeatNumber(currentFlightID, addPassenger.PassengerID.ToString(), seat.Content.ToString());
                        }
                        else
                        {
                            flightLogic.UpdatePassengerSeatNumber(currentFlightID, selectedPassenger.PassengerID.ToString(), seat.Content.ToString());
                        }

                        ExitChangeSeatMode();

                        selectedPassenger = flightLogic.GetPassengerBySeat(currentFlightID, seat.Content.ToString());

                        RefreshPassengerList();

                        lblSeat_Click(sender, null);
                    }
                }
                else
                {
                    clsPassenger clickedPassenger = flightLogic.GetPassengerBySeat(currentFlightID, seat.Content.ToString());
                    if (clickedPassenger != null)
                    {
                        cbChoosePassenger.SelectedIndex = cbChoosePassenger.Items.IndexOf(clickedPassenger);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler for the Change Seat button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EnterChangeSeatMode();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler for the Delete Passenger button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                flightLogic.DeletePassenger(currentFlightID, selectedPassenger.PassengerID.ToString());

                selectedPassenger = null;

                RefreshPassengerList();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Sets the Main Window in the add passenger view
        /// </summary>
        /// <param name="passenger"></param>
        public void AddPassenger(clsPassenger passenger)
        {
            try
            {
                addPassenger = passenger;

                addingPassenger = true;

                EnterChangeSeatMode();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region helper methods
        /// <summary>
        /// Sets up the GUI for when changing the seat of a passenger
        /// </summary>
        private void EnterChangeSeatMode()
        {
            try
            {
                changeSeat = true;

                cmdChangeSeat.IsEnabled = false;
                cmdAddPassenger.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;
                cbChooseFlight.IsEnabled = false;
                cbChoosePassenger.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the GUI to the normal selection mode
        /// </summary>
        private void ExitChangeSeatMode()
        {
            try
            {
                changeSeat = false;

                cmdChangeSeat.IsEnabled = true;
                cmdAddPassenger.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;
                cbChooseFlight.IsEnabled = true;
                cbChoosePassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the list of passengers for the current flight
        /// </summary>
        private void RefreshPassengerList()
        {
            try
            {
                cbChoosePassenger.Items.Clear();

                List<clsPassenger> passengers = flightLogic.GetFlightPassengers(currentFlightID);

                passengers.ForEach(passenger => cbChoosePassenger.Items.Add(passenger));

                seats.ForEach(seat =>
                {
                    List<int> seatsTaken = new List<int>();
                    passengers.ForEach(passenger => seatsTaken.Add(passenger.SeatNumber));
                    if (seatsTaken.Contains(Convert.ToInt32(seat.Content)))
                    {
                        seat.Background = red;
                    }
                    else
                    {
                        seat.Background = blue;
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
