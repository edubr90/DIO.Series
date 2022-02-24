using System;
using System.Collections.Generic;
using System.Linq;
using DIO.Series.Classes;
using DIO.Series.Dto;
using DIO.Series.Entities;
using DIO.Series.Interfaces;
using DIO.Series.Interfaces.Command;
using DIO.Series.Shared.Extensions;

namespace DIO.Series.Command
{
    public class SerieCommand : ICommand
    {

        private readonly ISeriesRepository _rep;
        private Serie _entityOld;

        public SerieCommand(ISeriesRepository rep)
        {
            _rep = rep;
        }
        public bool ClearConsole()
        {
            Console.Clear();
            return true;
        }

        public bool CreateSerie()
        {
            var serieEntity = new SerieDto().MapSerie();
            _rep.Create(serieEntity);
            return true;
        }

        public bool DeleteSerie()
        {
            _entityOld = EntityOld();

            if(_entityOld != null)
            {
                _rep.Delete(_entityOld.Id);
            }

            return true;
        }

        public bool ExitSystem()
        {
            Console.WriteLine(TextSystem.GetExitText());
            Console.ReadKey();
            return true;
        }

        public bool GetAllSeries()
        {
            
            var avaliableSeries = GetSeriesCollection();

            if(avaliableSeries == null)
                return true;
            
            foreach(var item in avaliableSeries)
            {
                Console.WriteLine(item.ToString());
            }

            return true;
        }

        public bool UpdateSerie()
        {
            _entityOld = EntityOld();

            if(_entityOld != null)
            {
                var entityNew = new SerieDto().MapSerie();
                _rep.Update(_entityOld.Id, entityNew);
            }
            
            return true;
            
        }

        public bool ViewSerie()
        {
            _entityOld = EntityOld();
            
            if(_entityOld != null)
                Console.WriteLine(_entityOld.ToString());
                
            return true;
        }

        private Serie EntityOld()
        {
            var seriesSaved = _rep.GetOrderedSeries();

            if(!seriesSaved.Any())
            {
                Console.WriteLine(TextSystem.NotFoundSeriesText());
                return default(Serie);
            }

            var seriesOrdered = seriesSaved
                .ToDictionary(_ => _.Key, __ => __.Value);

            var seriesToDisplay = seriesSaved
                .ToDictionary(_ => _.Key, __ => __.Value.Title);

            Console.WriteLine(TextSystem.SerieFieldsText.GetSerieIdText());
            Console.WriteLine(TextSystem.SerieFieldsText.GetSequentialItemsWithDescriptionText(seriesToDisplay));

            var serieId = Console.ReadLine().OnlyNumbers();
            var targetSerie = seriesOrdered.FirstOrDefault(_ => _.Key == serieId);

            var entity = _rep.GetById(targetSerie.Value.Id);

            if(entity == null)
                Console.WriteLine(TextSystem.SerieFieldsText.GetSerieNotFountExceptionText());

            return entity;
        }

        private IReadOnlyCollection<Serie> GetSeriesCollection()
        {
            var avaliableSeries = this._rep.GetAll();

            if(!avaliableSeries.Any())
            {
                Console.WriteLine(TextSystem.NotFoundSeriesText());
                return default(IReadOnlyCollection<Serie>);
            }

            return avaliableSeries;
        }
    }
}