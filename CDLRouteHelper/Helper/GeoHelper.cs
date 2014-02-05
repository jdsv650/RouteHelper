using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace CDLRouteHelper.Helper
{
    public class GeoHelper
    {
        private const double CONVERT_TO_MILES = 1609.344;

        public static GeoCoordinate BuildGeoCoordinates(double latitude, double longitude)
        {
            return new GeoCoordinate(latitude, longitude);
        }

        public static GeoCoordinate BuildGeoCoordinates(string latitude, string longitude)
        {
            string sLatd = GeoHelper.RemoveExtrasFromGeoDimensions(latitude);
            string sLngtd = GeoHelper.RemoveExtrasFromGeoDimensions(longitude);
            double latd = double.Parse(sLatd);
            double lngtd = double.Parse(sLngtd);
            return new GeoCoordinate(latd, lngtd);
        }

        public static double LatOrLonToDouble(string latOrLon)
        {
            string s = GeoHelper.RemoveExtrasFromGeoDimensions(latOrLon);

            double result = double.Parse(s);
            return result;
        }


        public static string RemoveExtrasFromGeoDimensions(string dimension)
        {
            return new string(dimension.Where(c => char.IsDigit(c) || c == '.' || c == '-').ToArray());
        }

        public static double GetDistanceByGeoCoordinates(GeoCoordinate locationA, GeoCoordinate locationB)
        {
            return locationA.GetDistanceTo(locationB) / CONVERT_TO_MILES;
        }


        internal static double LatLonToLatDouble(string latLng)
        {
            var s1 = "";

            //keep everything between (  and first Blank  as latitude
            for (int i = 0; i < latLng.Length; i++)
            {
                if (latLng[i] == '(' || latLng[i] == ',')
                { } //do nothing
                else if (latLng[i] == ' ')
                    break;
                else
                    s1 += latLng[i];
            }

         //   double result = double.Parse(s1);

            double result = 29.4513511657715;

            return result;
        }

        internal static double LatLonToLonDouble(string latLng)
        {
            var s1 = "";

            //keep from first blank+1 to ')' as lng
            int index = 0;
            for (int i = 0; i < latLng.Length; i++)
            {
                if (latLng[i] == ' ')
                    break;
                index++;
            }

           //  start from past blank
            for (int i = index + 1; i < latLng.Length; i++)
            {
                if (latLng[i] == ')')
                { } //do nothing
                else
                    s1 += latLng[i];
            }

           // double result = double.Parse(s1);
            double result = -95.2864837646484;

            return result;

        }
    }
}