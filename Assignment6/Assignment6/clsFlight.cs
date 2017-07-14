using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class clsFlight
    {
        clsDataAccess db = new clsDataAccess();

        public DataSet GetDataSet(String query, ref int iRet)
        {
            DataSet ds;

            iRet = 0;

            ds = db.ExecuteSQLStatement(query, ref iRet);

            return ds;
        }

        public int GetFlightID(String flightName)
        {
            DataSet ds;

            int iRet = 0;

            ds = db.ExecuteSQLStatement(String.Format("SELECT Flight_ID FROM Flight WHERE Flight_Number = '{0}';", flightName.Substring(0,3)), ref iRet);

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        public DataSet GetPassengersInFlight(String flight, ref int iRet)
        {
            DataSet ds;

            iRet = 0;

            int flightID = GetFlightID(flight);

            ds = db.ExecuteSQLStatement(String.Format("SELECT p.Passenger_ID, First_Name, Last_Name FROM Passenger p INNER JOIN Flight_Passenger_Link l ON p.Passenger_ID = l.Passenger_ID WHERE Flight_ID = {0};", flightID), ref iRet);

            return ds;
        }

        public int GetPassengerSeatNum(String name, ref int iRet)
        {
            DataSet ds;

            iRet = 0;

            ds = db.ExecuteSQLStatement(String.Format("SELECT Seat_Number FROM Flight_Passenger_Link l INNER JOIN Passenger p ON l.Passenger_ID = p.Passenger_ID WHERE First_Name & ' ' & Last_Name = '{0}'", name), ref iRet);

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        public List<int> GetTakenSeats(ref int iRet)
        {
            DataSet ds;

            iRet = 0;

            ds = db.ExecuteSQLStatement("SELECT Seat_Number FROM Flight_Passenger_Link", ref iRet);

            List<int> results = new List<int>();
            for(int i = 0; i < iRet; ++i)
            {
                results.Add(Convert.ToInt32(ds.Tables[0].Rows[i][0]));
            }

            return results;
        }
    }
}
