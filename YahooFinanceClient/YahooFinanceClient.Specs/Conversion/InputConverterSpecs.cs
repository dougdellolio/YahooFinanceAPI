using Machine.Fakes;
using Machine.Specifications;
using System;

namespace YahooFinanceClient.Specs.Conversion
{
    public class InputConverterSpecs : WithSubject<YahooFinanceClient.Conversion.InputConverter>
    {
        static decimal? decimal_result;

        static DateTime? date_result;

        static string string_result;

        public class when_converting_string_to_decimal
        {
            Because of = () =>
                decimal_result = Subject.ConvertStringToDecimal("9.3");

            It should_convert_to_decimal = () =>
                decimal_result.ShouldEqual(9.3M);
        }

        public class when_converting_string_to_datetime
        {
            Because of = () =>
                date_result = Subject.ConvertStringToDate("2/2/2017");

            It should_convert_to_decimal = () =>
                date_result.ShouldEqual(new DateTime(2017, 2, 2));
        }

        public class when_checking_for_an_available_string
        {
            Because of = () =>
                string_result = Subject.CheckIfNotAvailable("2.78B");

            It should_convert_to_decimal = () =>
                string_result.ShouldEqual("2.78B");
        }

        public class when_converting_percent_to_decimal
        {
            public class when_converting_positive_percent
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToPercentDecimal("+2.5%");

                It should_convert_to_decimal = () =>
                    decimal_result.ShouldEqual(2.5M);
            }

            public class when_converting_negative_percent
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToPercentDecimal("-2.5%");

                It should_convert_to_decimal = () =>
                    decimal_result.ShouldEqual(-2.5M);
            }
        }

        public class when_converting_to_null
        {
            public class when_converting_not_available_to_decimal
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToDecimal("N/A");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }

            public class when_converting_not_available_with_spaces_to_decimal
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToDecimal("N / A");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }

            public class when_converting_not_available_with_new_line_to_decimal
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToDecimal("N/A\n");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }

            public class when_converting_not_available_with_new_line_and_spaces_to_decimal
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToDecimal("N / A\n");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }

            public class when_converting_blank
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToDecimal("");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }

            public class when_converting_date
            {
                Because of = () =>
                    date_result = Subject.ConvertStringToDate("N/A");

                It should_convert_to_null = () =>
                    date_result.ShouldBeNull();
            }

            public class when_converting_percent
            {
                Because of = () =>
                    decimal_result = Subject.ConvertStringToPercentDecimal("N/A");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }

            public class when_checking_string_for_not_available
            {
                Because of = () =>
                    string_result = Subject.CheckIfNotAvailable("N/A");

                It should_convert_to_null = () =>
                    decimal_result.ShouldBeNull();
            }
        }
    }
}
