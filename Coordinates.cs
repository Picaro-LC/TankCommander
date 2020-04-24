using System;
using System.Text.RegularExpressions;

namespace TankCommander
{
    public struct Coordinates
    {
        public static readonly Coordinates NO_COORDINATES = new Coordinates(double.NaN, double.NaN);
        public const string NO_COORDINATES_STRING = "<None>";
        public const string UNKNOWN_COORDINATES_STRING = "<Unknown>";

        // This is the only data stored by each instance of the struct
        public double NS, EW;

        public Coordinates(double NS, double EW)
        {
            this.NS = NS;
            this.EW = EW;
        }

        public Coordinates(int landcell, double yOffset, double xOffset)
        {
            this.NS = LandblockToNS(landcell, yOffset);
            this.EW = LandblockToEW(landcell, xOffset);
        }

        public Coordinates(int landcell, double yOffset, double xOffset, int precision)
        {
            this.NS = Math.Round(LandblockToNS(landcell, yOffset), precision);
            this.EW = Math.Round(LandblockToEW(landcell, xOffset), precision);
        }

        public Coordinates(Decal.Adapter.Wrappers.CoordsObject obj)
        {
            this.NS = obj.NorthSouth;
            this.EW = obj.EastWest;
        }

        public Coordinates(Decal.Adapter.Wrappers.CoordsObject obj, int precision)
        {
            this.NS = Math.Round(obj.NorthSouth, precision);
            this.EW = Math.Round(obj.EastWest, precision);
        }

        public static explicit operator Decal.Adapter.Wrappers.CoordsObject(Coordinates coords)
        {
            return new Decal.Adapter.Wrappers.CoordsObject(coords.NS, coords.EW);
        }

        // Latitude
        public static double LandblockToNS(int landcell, double yOffset)
        {
            uint l = (uint)((landcell & 0x00FF0000) / 0x2000);
            return (l + yOffset / 24.0 - 1019.5) / 10.0;
        }

        // Longitude
        public static double LandblockToEW(int landcell, double xOffset)
        {
            uint l = (uint)((landcell & 0xFF000000) / 0x200000);
            return (l + xOffset / 24.0 - 1019.5) / 10.0;
        }
    }
}