
namespace Gw2Api.Core.EndPoints.CharacterInformation
{
    using System;

    public class CharacterInformation
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Race { get; set; }

        public string Profession { get; set; }

        public int DaysUntilBirthday
        {
            get
            {
                var today = DateTime.Today;
                var next = new DateTime(today.Year, Birthday.Month, Birthday.Day);

                if (next < today)
                {
                    next = next.AddYears(1);
                }
                
                return (next - today).Days;
            }
        }
    }
}