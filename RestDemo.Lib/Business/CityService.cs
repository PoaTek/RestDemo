using RestDemo.Lib.Data;
using RestDemo.Lib.Entities;

using System;
using System.Linq;

namespace RestDemo.Lib.Business
{
    /// <summary>
    /// Business Layer
    /// </summary>
    public class CityService
    {
        /// <summary>
        /// List Cities by criteria
        /// </summary>
        public City[] List(CityCriteria criteria)
        {
            // Instantiate database contect
            var context = new DataContext();

            // Build the query
            IQueryable<City> query = context.Cities;

            if (criteria != null)
            {
                // Business validation
                if (criteria.PopulationTo < criteria.PopulationFrom)
                    throw new InvalidOperationException("Invalid population criteria!");

                // Apply name criteria
                if (criteria.Name != null)
                    query = query.Where(i => i.Name.StartsWith(criteria.Name));

                // Apply population range criteria
                if (criteria.PopulationFrom != null)
                    query = query.Where(i => i.Population >= criteria.PopulationFrom);

                // Apply population range criteria
                if (criteria.PopulationTo != null)
                    query = query.Where(i => i.Population <= criteria.PopulationTo);
            }

            // Fetch data from the database
            return query.ToArray();
        }
    }
}