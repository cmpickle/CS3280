using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment6
{
    /// <summary>
    /// The class represents a flight. It contains all of the business logic associated with flight bookings.
    /// </summary>
    class clsFlight
    {
#region class fields
        /// <summary>
        /// The database access object. Used for making queries on the database.
        /// </summary>
        clsDataAccess db = new clsDataAccess();
        #endregion

#region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public clsFlight()
        {

        }
#endregion

#region public methods
        /// <summary>
        /// Gets the dataset that is returned by the query on the table
        /// </summary>
        /// <param name="table">The table to be querried apon</param>
        /// <param name="iRet">The number of returned items</param>
        /// <returns></returns>
        public DataSet GetTableContents(String table, ref int iRet)
        {
            DataSet ds = null;

            try
            {
                iRet = 0;

                ds = db.ExecuteSQLStatement(String.Format("SELECT * FROM {0}", table), ref iRet);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return ds;
        }

        /// <summary>
        /// Returns the flight ID of a flight based on it's flight name (Flight_Number & Aircraft_Type)
        /// </summary>
        /// <param name="flightName">The Flight's name (Flight_Number & Aircraft_Type)</param>
        /// <returns>The flight's ID</returns>
        public int GetFlightID(String flightName)
        {
            DataSet ds = null;

            try
            {
                int iRet = 0;

                ds = db.ExecuteSQLStatement(String.Format("SELECT Flight_ID FROM Flight WHERE Flight_Number = '{0}';", flightName.Substring(0, 3)), ref iRet);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// Returns the passengers who have a reserved seat on the flight
        /// </summary>
        /// <param name="flightName">The flight name (Flight_Number & Aircraft_Type)</param>
        /// <param name="iRet">The number of rows returned</param>
        /// <returns>Dataset containing the passengers in the flight</returns>
        public DataSet GetPassengersInFlight(String flightName, ref int iRet)
        {
            DataSet ds = null;

            try
            {
                iRet = 0;

                int flightID = GetFlightID(flightName);

                ds = db.ExecuteSQLStatement(String.Format("SELECT p.Passenger_ID, First_Name, Last_Name FROM Passenger p INNER JOIN Flight_Passenger_Link l ON p.Passenger_ID = l.Passenger_ID WHERE Flight_ID = {0};", flightID), ref iRet);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return ds;
        }

        /// <summary>
        /// Returns the Passenger's seat number
        /// </summary>
        /// <param name="name">The name of the passenger (First_Name & " " & Last_Name)</param>
        /// <param name="iRet">The number of rows returned</param>
        /// <returns>The passenger's seat number</returns>
        public int GetPassengerSeatNum(String name, ref int iRet)
        {
            DataSet ds = null;

            try
            {
                iRet = 0;

                ds = db.ExecuteSQLStatement(String.Format("SELECT Seat_Number FROM Flight_Passenger_Link l INNER JOIN Passenger p ON l.Passenger_ID = p.Passenger_ID WHERE First_Name & ' ' & Last_Name = '{0}'", name), ref iRet);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// Returns a list of the reserved seats on the flight
        /// </summary>
        /// <param name="flightName">The name of the flight (Flight_Number & Aircraft_Type)</param>
        /// <param name="iRet">The number of returned rows</param>
        /// <returns>A list of seats as integers</returns>
        public List<int> GetTakenSeats(String flightName, ref int iRet)
        {
            List<int> results = new List<int>();

            try
            {
                DataSet ds;

                iRet = 0;

                ds = db.ExecuteSQLStatement(String.Format("SELECT Seat_Number FROM Flight_Passenger_Link WHERE Flight_ID = {0}", GetFlightID(flightName)), ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    results.Add(Convert.ToInt32(ds.Tables[0].Rows[i][0]));
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return results;
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
