using UnityEngine;
using System.Globalization;

namespace BallBlast
{
    public class NumberFomatter : MonoBehaviour
    {
        public static string ToKMB(float number)
        {
            if (number  > 999999999 || number < -999999999)
            {
                return number.ToString("0,,,.###B", CultureInfo.InvariantCulture);
            }
            else if (number > 999999 || number < -999999)
            {
                return number.ToString("0,,.##B", CultureInfo.InvariantCulture);
            }
            else if (number > 999 || number < -999)
            {
                return number.ToString("0,.#B", CultureInfo.InvariantCulture);
            }
            else
            {
                return ((int)number).ToString();
            }
        }
    }

}
