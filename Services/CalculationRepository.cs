using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Services
{
    public class CalculationRepository
    {
        private CalculationData[] Data = new CalculationData[3];

        private int GetEmptyDataSlot()
        {
            return Array.FindIndex(Data, i => i == null);
        }
        public void AddData(CalculationData data)
        {
            Data[GetEmptyDataSlot()] = data;
        }

        public Coordinates CalculateCoordinates()
        {
            double Xp1; double Yp1; double Dp1;
            double Xp2; double Yp2; double Dp2;
            double Xp3; double Yp3; double Dp3;
            double S; double T; double x; double y;

            Xp1 = Data[0].GetX(); Yp1 = Data[0].GetY(); Dp1 = Data[0].GetDistance();
            Xp2 = Data[1].GetX(); Yp2 = Data[1].GetY(); Dp2 = Data[1].GetDistance();
            Xp3 = Data[2].GetX(); Yp3 = Data[2].GetY(); Dp3 = Data[2].GetDistance();

            S = (Math.Pow(Xp3, 2) - Math.Pow(Xp2, 2) + Math.Pow(Yp3, 2) - Math.Pow(Yp2, 2) + Math.Pow(Dp2, 2) - Math.Pow(Dp3, 2)) / 2;
            T = (Math.Pow(Xp1, 2) - Math.Pow(Xp2, 2) + Math.Pow(Yp1, 2) - Math.Pow(Yp2, 2) + Math.Pow(Dp2, 2) - Math.Pow(Dp1, 2)) / 2;
            y = ((T * (Xp2 - Xp3)) - (S * (Xp2 - Xp1))) / (((Yp1 - Yp2) * (Xp2 - Xp3)) - ((Yp3 - Yp2) * (Xp2 - Xp1)));
            x = ((y * (Yp1 - Yp2)) - T) / (Xp2 - Xp1);

            return new Coordinates(x, y);
        }
        public string CalculateMessage()
        {
            string message = string.Empty;
            bool complete = false;
            int pos = 0;
            string lastWord = string.Empty;

            while (!complete)
            {
                complete = true;
                foreach (CalculationData data in Data)
                {
                    if (pos <= data.GetMessage().Length - 1 && data.GetMessage()[pos] != null && !data.GetMessage()[pos].Equals(string.Empty) && !data.GetMessage()[pos].Equals(lastWord))
                    {
                        lastWord = data.GetMessage()[pos];
                        message += (message.Equals(string.Empty) ? "" : " ") + lastWord;
                    }

                    if (pos <= data.GetMessage().Length) complete = false;
                }
                pos++;

            }

            return message;
        }
    }
}