using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DIO.Series.Entities;
using DIO.Series.Interfaces;

namespace DIO.Series.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {

        private IList<Serie> _seriesList;
        private IDictionary<int, Serie> _seriesOrdered;

        public SeriesRepository()
        {
            this._seriesList = new List<Serie>();
            this._seriesOrdered = new Dictionary<int, Serie>();
        }

        private void OrderSeries()
        {
            _seriesOrdered = new Dictionary<int, Serie>();
            int index = 1;

            foreach(var serie in GetAll())
            {
                _seriesOrdered.Add(index, serie);
                index++;
            }
                
        }
        public void Create(Serie entity)
        {
            this._seriesList.Add(entity);
            OrderSeries();
        }

        public void Delete(Guid id)
        {
            var entityOld = GetById(id);
            var entity = GetById(id);

            entity.SetDeleted();
            UpdateList(entityOld, entity);
            OrderSeries();
        }

        public IReadOnlyCollection<Serie> GetAll()
        {
            return _seriesList.Where(_ => _.Deleted == false).ToList();
        }

        public Serie GetById(Guid id)
        {
            return _seriesList.FirstOrDefault(_ => _.Id == id && _.Deleted == false);
        }

        public void Update(Guid id, Serie entity)
        {
            var entityOld = GetById(id);
            
            if(entityOld != null)
            {
                entity.SetId(id);
                UpdateList(entityOld, entity);
                OrderSeries();
            }
            
        }

        public void UpdateList(Serie entityOld, Serie entity)
        {
            _seriesList.Remove(entityOld);
            _seriesList.Add(entity);
        }

        public IDictionary<int, Serie> GetOrderedSeries()
        {
            return this._seriesOrdered;
        }
    }
}