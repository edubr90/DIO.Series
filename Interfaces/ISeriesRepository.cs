using System.Collections.Generic;
using DIO.Series.Entities;

namespace DIO.Series.Interfaces
{
    public interface ISeriesRepository : IRepository<Serie>
    {
        IDictionary<int, Serie> GetOrderedSeries();
    }
}