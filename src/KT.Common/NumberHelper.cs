namespace KT.Common;

 public static class NumberHelper
{
    private static readonly string[] _numberUnitNames;
    private static readonly string[] _numberTenUnitNames;

    static NumberHelper()
    {
        _numberUnitNames = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        _numberTenUnitNames = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    }

    public static string ToWord(this int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + ToWord(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += ToWord(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += ToWord(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += ToWord(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            if (number < 20)
                words += _numberUnitNames[number];
            else
            {
                words += _numberTenUnitNames[number / 10];
                if ((number % 10) > 0)
                    words += "-" + _numberUnitNames[number % 10];
            }
        }

        return words;
    }
}