using System;

namespace YahooFinanceClient.Conversion
{
    public class InputConverter
    {
        public DateTime? ConvertStringToDate(string data)
        {
            if (!IsAcceptableInput(data))
            {
                return null;
            }

            var dateWithoutQuotes = data.Replace("\"", string.Empty);

            return DateTime.Parse(dateWithoutQuotes);
        }

        public decimal? ConvertStringToDecimal(string data)
        {
            if (!IsAcceptableInput(data))
            {
                return null;
            }

            return Convert.ToDecimal(data);
        }

        public decimal? ConvertStringToPercentDecimal(string data)
        {
            if (!IsAcceptableInput(data))
            {
                return null;
            }

            var direction = data.ToCharArray()[0];
            var number = data.Substring(1, data.Length - 2);

            if (direction == '-')
            {
                return -Convert.ToDecimal(number);
            }

            return Convert.ToDecimal(number);
        }

        public string CheckIfNotAvailable(string data)
        {
            if (!IsAcceptableInput(data))
            {
                return null;
            }

            return data;
        }

        private bool IsAcceptableInput(string data)
        {
            var dataWithoutSpaces = data.Replace(" ", string.Empty);

            return !(dataWithoutSpaces == ""
                || dataWithoutSpaces == "N/A"
                || dataWithoutSpaces == "N/A\n"
                || dataWithoutSpaces == "N / A\n"
                || dataWithoutSpaces == "n/a"
                || dataWithoutSpaces == "n/a\n"
                || dataWithoutSpaces == "n  / a\n");
        }
    }
}
