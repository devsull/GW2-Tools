
namespace Gw2Api.Core.EndPoints.CharacterInformation
{
    using System;

    public class CharacterInformation
    {
        public string Name { get; set; }

        public string Birthday { get; set; }

        public string Race { get; set; }

        public string Profession { get; set; }

        public int DaysUntilBirthday
        {
            get
            {
                if (string.IsNullOrEmpty(this.Birthday))
                {
                    return -1;
                }

                var today = DateTime.Today;
                var bday = DateTime.Parse(this.Birthday);
                var next = new DateTime(today.Year, bday.Month, bday.Day);

                if (next < today)
                {
                    next = next.AddYears(1);
                }

                return (next - today).Days;
            }
        }
    }
}