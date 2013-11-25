using System;

namespace LyraSoft.Util.Geo
{



    public static class GeoCalculator
    {
        public const Double EarthRadius = 6378137.0;

        private static void Getpos(double STARTLAT, double STARTLONG, double ANGLE1, double DISTANCE, out double lng, out double lat)
        {
            const double a = 6378245;
            const double b = 6356752.3142;
            const double e = 0.082024497124054838;
            //e = Math.Sqrt(a *a - b*b) / a;
            double e2, w, V;
            double B1, L1, B2, L2;
            double s;
            double A1, A2;
            double sinu1, cosu1, sinA0, cotq1, sin2q1, cos2q1, cos2A0;
            double k2, q0, sin2q1q0, cos2q1q0;
            double q;
            double theta;
            double aa, BB, cc, AAlpha, BBeta;
            double sinu2, lamuda;
            double e1, W1;
            B1 = STARTLAT;
            L1 = STARTLONG;
            A1 = ANGLE1;
            s = DISTANCE;
            //e2 = Math.Sqrt(a * a - b * b) / b;
            e2 = 0.08230182848092589;

            if (B1 == 0)
            {
                if (A1 == 90)
                {
                    A2 = 270;
                    B2 = 0;
                    L2 = L1 + s / a * 180 / Math.PI;
                }
                else
                {
                    if (A1 == 270)
                    {
                        A2 = 90;
                        B2 = 0;
                        L2 = L1 - s / a * 180 / Math.PI;
                    }
                    else
                    {
                        //极点不存在东西方向
                        throw new ArgumentOutOfRangeException();
                    }
                }
                lng = L2;
                lat = B2;
                return;
            }
            B1 = angToRad(B1);
            L1 = angToRad(L1);
            A1 = angToRad(A1);
            w = Math.Sqrt(1 - e * e * (Math.Pow(Math.Sin(B1), 2)));
            V = w * (a / b);
            e1 = e;
            W1 = w;
            sinu1 = Math.Sin(B1) * Math.Sqrt(1 - e1 * e1) / W1;
            cosu1 = Math.Cos(B1) / W1;
            sinA0 = cosu1 * Math.Sin(A1);
            cotq1 = cosu1 * Math.Cos(A1);
            sin2q1 = 2 * cotq1 / (cotq1 * cotq1 + 1);
            cos2q1 = (cotq1 * cotq1 - 1) / (cotq1 * cotq1 + 1);
            cos2A0 = 1 - sinA0 * sinA0;
            e2 = Math.Sqrt(a * a - b * b) / b;
            k2 = e2 * e2 * cos2A0;
            aa = b * (1 + k2 / 4 - 3 * k2 * k2 / 64 + 5 * k2 * k2 * k2 / 256);
            BB = b * (k2 / 8 - k2 * k2 / 32 + 15 * k2 * k2 * k2 / 1024);
            cc = b * (k2 * k2 / 128 - 3 * k2 * k2 * k2 / 512);
            e2 = e1 * e1;
            AAlpha = (e2 / 2 + e2 * e2 / 8 + e2 * e2 * e2 / 16) - (e2 * e2 / 16 + e2 * e2 * e2 / 16) * cos2A0 + (3 * e2 * e2 * e2 / 128) * cos2A0 * cos2A0;
            BBeta = (e2 * e2 / 32 + e2 * e2 * e2 / 32) * cos2A0 - (e2 * e2 * e2 / 64) * cos2A0 * cos2A0;
            q0 = (s - (BB + cc * cos2q1) * sin2q1) / aa;
            sin2q1q0 = sin2q1 * Math.Cos(2 * q0) + cos2q1 * Math.Sin(2 * q0);
            cos2q1q0 = cos2q1 * Math.Cos(2 * q0) - sin2q1 * Math.Sin(2 * q0);
            q = q0 + (BB + 5 * cc * cos2q1q0) * sin2q1q0 / aa;
            theta = (AAlpha * q + BBeta * (sin2q1q0 - sin2q1)) * sinA0;
            sinu2 = sinu1 * Math.Cos(q) + cosu1 * Math.Cos(A1) * Math.Sin(q);
            B2 = Math.Atan(sinu2 / (Math.Sqrt(1 - e1 * e1) * Math.Sqrt(1 - sinu2 * sinu2))) * 180 / Math.PI;
            lamuda = Math.Atan(Math.Sin(A1) * Math.Sin(q) / (cosu1 * Math.Cos(q) - sinu1 * Math.Sin(q) * Math.Cos(A1))) * 180 / Math.PI;
            if (Math.Sin(A1) > 0)
            {
                if (Math.Sin(A1) * Math.Sin(q) / (cosu1 * Math.Cos(q) - sinu1 * Math.Sin(q) * Math.Cos(A1)) > 0)
                {
                    lamuda = Math.Abs(lamuda);
                }
                else
                {
                    lamuda = 180 - Math.Abs(lamuda);
                }
            }
            else
            {
                if (Math.Sin(A1) * Math.Sin(q) / (cosu1 * Math.Cos(q) - sinu1 * Math.Sin(q) * Math.Cos(A1)) > 0)
                {
                    lamuda = Math.Abs(lamuda) - 180;
                }
                else
                {
                    lamuda = -Math.Abs(lamuda);
                }

            }
            L2 = L1 * 180 / Math.PI + lamuda - theta * 180 / Math.PI;
            A2 = Math.Atan(cosu1 * Math.Sin(A1) / (cosu1 * Math.Cos(q) * Math.Cos(A1) - sinu1 * Math.Sin(q))) * 180 / Math.PI;
            if (Math.Sin(A1) > 0)
            {
                if (cosu1 * Math.Sin(A1) / (cosu1 * Math.Cos(q) * Math.Cos(A1) - sinu1 * Math.Sin(q)) > 0)
                {
                    A2 = 180 + Math.Abs(A2);
                }
                else
                {
                    A2 = 360 - Math.Abs(A2);
                }
            }
            else
            {
                if (cosu1 * Math.Sin(A1) / (cosu1 * Math.Cos(q) * Math.Cos(A1) - sinu1 * Math.Sin(q)) > 0)
                {
                    A2 = Math.Abs(A2);
                }
                else
                {
                    A2 = 180 - Math.Abs(A2);
                }
            }
            lng = L2;
            lat = B2;
            return;

        }
        private static double Gps2m(double lat_a, double lng_a, double lat_b, double lng_b)
        {
            double radLat1 = (lat_a * Math.PI / 180.0);

            double radLat2 = (lat_b * Math.PI / 180.0);

            double a = radLat1 - radLat2;

            double b = (lng_a - lng_b) * Math.PI / 180.0;

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2)

                   + Math.Cos(radLat1) * Math.Cos(radLat2)

                   * Math.Pow(Math.Sin(b / 2), 2)));

            s = s * EarthRadius;

            s = Math.Round(s * 10000) / 10000;

            return s;

        }
        private static double angToRad(double angle_d)
        {
            return Math.PI * angle_d / 180;

        }
        private static double gps2d_2(double lat1, double lng1, double lat2, double lng2)
        {
            double azimuth;
            double averageLat = (lat1 + lat2) / 2;
            if (lat1 - lat2 == 0)
            {
                azimuth = 90;
            }
            else
            {
                azimuth = Math.Atan((lng1 - lng2) * Math.Cos(angToRad(averageLat)) / (lat1 - lat2)) * 180 / Math.PI;
            }
            if (lat1 > lat2)
            {
                azimuth = azimuth + 180;
            }
            if (azimuth < 0)
            {
                azimuth = 360 + azimuth;
            }
            return azimuth;
        }





        public static double GetDirection(double lng_a, double lat_a, double lng_b, double lat_b)
        {
            return gps2d_2(lat_a, lng_a, lat_b, lng_b);
        }
        public static double GetDistance(double lng_a, double lat_a, double lng_b, double lat_b, LengthUnit Unit = LengthUnit.Meter)
        {
            double distance_meter = Gps2m(lat_a, lng_a, lat_b, lng_b);
            switch (Unit)
            {
                case LengthUnit.Meter:
                    return distance_meter;
                case LengthUnit.Kilometer:
                    return distance_meter / 1000.0;
                case LengthUnit.Knot:
                    return distance_meter / 1852.00;
                default:
                    return distance_meter;
            }
        }
        public static void GetPostion(double lng_begin, double lat_bengin, double angle, double distance, out double lng, out double lat)
        {
            Getpos(lat_bengin, lng_begin, angle, distance, out lng, out lat);
        }
    }
}
