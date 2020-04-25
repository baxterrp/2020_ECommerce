using Dapper;
using BaxterCommerce.CommonClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Base
{
    //TODO: handle exceptions better
    /// <summary>
    /// Base Repository class for handling data base interactions
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public abstract class BaseDataRepository<TResource> : IDataRepository<TResource> 
        where TResource : BaseResource
    {
        private readonly ConnectionConfiguration _connectionConfiguration;
        private readonly BaseTableConfiguration _tableConfiguration;

        protected BaseDataRepository(ConnectionConfiguration connectionConfiguration, BaseTableConfiguration tableConfiguration)
        {
            _connectionConfiguration = connectionConfiguration ?? throw new ArgumentNullException(nameof(connectionConfiguration));
            _tableConfiguration = tableConfiguration ?? throw new ArgumentNullException(nameof(tableConfiguration));
        }

        /// <summary>
        /// Implements <see cref="IDataRepository{TResource}.Find(BaseSearchParameters)"/>
        /// </summary>
        public async Task<IEnumerable<TResource>> Find(BaseSearchParameters parameters)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.GetConnectionString()))
            {
                try
                {
                    var results = await connection.QueryAsync<TResource>(_tableConfiguration.BuildWhereClause(_tableConfiguration.Find, parameters), parameters);

                    return results;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Implements <see cref="IDataRepository{TResource}.FindById(string)"/>
        /// </summary>
        public async Task<TResource> FindById(string id)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.GetConnectionString()))
            {
                try
                {
                    var result = await connection.QuerySingleAsync<TResource>(_tableConfiguration.Find, new { Id = id });

                    return result;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Implements <see cref="IDataRepository{TResource}.Insert(TResource)"/>
        /// </summary>
        public virtual async Task Insert(TResource resource)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.GetConnectionString()))
            {
                try
                {
                    await connection.ExecuteAsync(_tableConfiguration.Insert, resource);
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Implements <see cref="IDataRepository{TResource}.Update(TResource)"/>
        /// </summary>
        public virtual async Task Update(TResource resource)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.GetConnectionString()))
            {
                try
                {
                    await connection.ExecuteAsync(_tableConfiguration.Update, resource);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
