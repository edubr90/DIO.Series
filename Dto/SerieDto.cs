using System;
using System.Collections.Generic;
using System.Linq;
using DIO.Series.Classes;
using DIO.Series.Entities;
using DIO.Series.Enums;
using DIO.Series.Shared.Extensions;

namespace DIO.Series.Dto
{
    public class SerieDto
    {
        public SerieDto()
        {
        }

        public Serie MapSerie()
        {
            Console.WriteLine(TextSystem.SerieFieldsText.GetCreateGenderText());
            DisplayGenderItems();
            EGender gender = MapGender(Console.ReadLine());

            Console.WriteLine(TextSystem.SerieFieldsText.GetCreateTitleText());
            var title = Console.ReadLine();

            Console.WriteLine(TextSystem.SerieFieldsText.GetCreateDescriptionText());
            var description = Console.ReadLine();

            Console.WriteLine(TextSystem.SerieFieldsText.GetCreateYearText());
            var year = Console.ReadLine().OnlyNumbers();

            return new Serie(gender, title, description, year);
        }

        private EGender MapGender(string genderValue)
        {
            foreach(EGender gender in Enum.GetValues(typeof(EGender)))
            {
                if(gender.ToString() == genderValue)
                {
                    return gender;
                }

                if(genderValue.IsNumber() && (int)gender == genderValue.OnlyNumbers())
                {
                    return gender;
                }

            }

            return EGender.NoSpecified;
        }

        private void DisplayGenderItems()
        {
            var result = new Dictionary<int, string>();

            foreach(EGender gender in Enum.GetValues(typeof(EGender)))
                result.Add((int)gender, gender.ToString());

            Console.WriteLine(TextSystem.SerieFieldsText.GetSequentialItemsWithDescriptionText(result));
        
        }
    }
}