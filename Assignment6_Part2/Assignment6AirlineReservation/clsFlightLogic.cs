using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Contains all of the business logic for a flight
    /// </summary>
    class clsFlightLogic
    {
        #region class fields
        /// <summary>
        /// Data access object
        /// </summary>
        clsDataAccess clsData;

        /// <summary>
        /// SQL queries class
        /// </summary>
        clsSQL sql;
        #endregion

        #region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public clsFlightLogic()
        {
            try
            {
                clsData = new clsDataAccess();
                sql = new clsSQL();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Gets a list of flight objects of all current flights in the database.
        /// </summary>
        /// <returns></returns>
        public List<clsFlight> GetAllFlights()
        {
            List<clsFlight> flights = new List<clsFlight>();

            try
            {
                DataSet ds = new DataSet();
                int iRet = 0;

                ds = clsData.ExecuteSQLStatement(sql.GetAllFlights(), ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    clsFlight flight = new clsFlight();
                    flight.FlightID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    flight.FlightNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    flight.FlightType = ds.Tables[0].Rows[i][2].ToString();
                    flights.Add(flight);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return flights;
        }

        /// <summary>
        /// Gets a list of all of the passengers for a given flight
        /// </summary>
        /// <param name="flightID">The flights id</param>
        /// <returns>List of passenger objects</returns>
        public List<clsPassenger> GetFlightPassengers(String flightID)
        {
            List<clsPassenger> passengers = new List<clsPassenger>();

            try
            {
                DataSet ds = new DataSet();
                int iRet = 0;

                ds = clsData.ExecuteSQLStatement(sql.GetAllPassengersForFlight(flightID), ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    clsPassenger passenger = new clsPassenger();
                    passenger.PassengerID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    passenger.FirstName = ds.Tables[0].Rows[i][1].ToString();
                    passenger.LastName = ds.Tables[0].Rows[i][2].ToString();
                    passenger.SeatNumber = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                    passengers.Add(passenger);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return passengers;
        }

        /// <summary>
        /// Gets a passenger object that is in the selected seat of the selected flight
        /// </summary>
        /// <param name="flightID">The flight's ID</param>
        /// <param name="seatNumber">The seat number</param>
        /// <returns></returns>
        public clsPassenger GetPassengerBySeat(String flightID, String seatNumber)
        {
            clsPassenger passenger = new clsPassenger();

            try
            {
                DataSet ds = new DataSet();
                int iRet = 0;

                ds = clsData.ExecuteSQLStatement(sql.GetPassengerFromSeat(flightID, seatNumber), ref iRet);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                passenger.PassengerID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                passenger.FirstName = ds.Tables[0].Rows[0][1].ToString();
                passenger.LastName = ds.Tables[0].Rows[0][2].ToString();
                passenger.SeatNumber = Convert.ToInt32(seatNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return passenger;
        }

        /// <summary>
        /// Update the passenger's seat number for their specified flight
        /// </summary>
        /// <param name="flightID">The flight ID</param>
        /// <param name="passengerID">The passenger's ID</param>
        /// <param name="seatNumber">The new seat number</param>
        public bool UpdatePassengerSeatNumber(String flightID, String passengerID, String seatNumber)
        {
            bool seatChanged = false;

            try
            {

                seatChanged = (GetPassengerBySeat(flightID, seatNumber) == null) ? true : false;

                if (seatChanged)
                {
                    clsData.ExecuteNonQuery(sql.UpdatePassengerSeat(flightID, passengerID, seatNumber));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return seatChanged;
        }

        /// <summary>
        /// Used to insert a passenger to a flight
        /// </summary>
        /// <param name="passenger">The new passenger</param>
        /// <returns>If the passenger was inserted</returns>
        public bool InsertPassenger(String flightID, clsPassenger passenger)
        {
            try
            {
                clsData.ExecuteNonQuery(sql.CreatePassenger(passenger));

                passenger.PassengerID = Convert.ToInt32(GetPassengerID(passenger.FirstName, passenger.LastName));

                clsData.ExecuteNonQuery(sql.CreateFlightPassengerLink(flightID, passenger, 0));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return true;
        }

        /// <summary>
        /// Gets the passenger's ID for the passenger with the given name
        /// </summary>
        /// <param name="first">The passenger's first name</param>
        /// <param name="last">The passenger's last name</param>
        /// <returns>The passenger's ID</returns>
        public String GetPassengerID(String first, String last)
        {
            DataSet ds = new DataSet();
            int iRet = 0;

            try
            {
                ds = clsData.ExecuteSQLStatement(sql.GetPassengerID(first, last), ref iRet);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// Deletes the passenger and their flight from the database
        /// </summary>
        /// <param name="flightID">The flight's ID</param>
        /// <param name="passengerID">The passenger's ID</param>
        public void DeletePassenger(String flightID, String passengerID)
        {
            try
            {
                DataSet ds = new DataSet();
                clsData.ExecuteNonQuery(sql.DeleteFlightPassengerLink(flightID, passengerID));

                int iRet = 0;

                ds = clsData.ExecuteSQLStatement(sql.GetFlightLinksForPassenger(passengerID), ref iRet);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    clsData.ExecuteNonQuery(sql.DeletePassenger(passengerID));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
