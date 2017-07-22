using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            clsData = new clsDataAccess();
            sql = new clsSQL();
        }
        #endregion

        #region public methods
        /// <summary>
        /// Gets a list of flight objects of all current flights in the database.
        /// </summary>
        /// <returns></returns>
        public List<clsFlight> GetAllFlights()
        {
            DataSet ds = new DataSet();
            int iRet = 0;

            ds = clsData.ExecuteSQLStatement(sql.GetAllFlights(), ref iRet);

            List<clsFlight> flights = new List<clsFlight>();

            for(int i=0; i<iRet; ++i)
            {
                clsFlight flight = new clsFlight();
                flight.FlightID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                flight.FlightNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                flight.FlightType = ds.Tables[0].Rows[i][2].ToString();
                flights.Add(flight);
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
            DataSet ds = new DataSet();
            int iRet = 0;

            ds = clsData.ExecuteSQLStatement(sql.GetAllPassengersForFlight(flightID), ref iRet);

            List<clsPassenger> passengers = new List<clsPassenger>();

            for (int i = 0; i < iRet; ++i)
            {
                clsPassenger passenger = new clsPassenger();
                passenger.PassengerID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                passenger.FirstName = ds.Tables[0].Rows[i][1].ToString();
                passenger.LastName = ds.Tables[0].Rows[i][2].ToString();
                passenger.SeatNumber = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                passengers.Add(passenger);
            }

            return passengers;
        }
        #endregion
    }
}
