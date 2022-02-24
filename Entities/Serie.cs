using System;
using DIO.Series;
using DIO.Series.Enums;

namespace DIO.Series.Entities
{
    public class Serie : EntityBase
    {
        public Serie(EGender gender, string title, string description, int year)
        {
            Id = Guid.NewGuid();
            Gender = gender;
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            string result = Environment.NewLine + "======" + Environment.NewLine;
            result += "Id: " + this.Id + Environment.NewLine;
            result += "Gender: " + this.Gender.ToString() + Environment.NewLine;
            result += "Title: " + this.Title + Environment.NewLine;
            result += "Description: " + this.Description + Environment.NewLine;
            result += "Start Year: " + this.Year;
            result += Environment.NewLine + "======";

            return result;

        }

        public EGender Gender { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }
    }
}