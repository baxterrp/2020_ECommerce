using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.DataRepository
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
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TResource>> Find(object parameters)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.ConnectionString))
            {
                try
                {
                    var results = await connection.QueryAsync<TResource>(_tableConfiguration.Find, parameters);

                    return results;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TResource> FindById(string id)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.ConnectionString))
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
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public virtual async Task Insert(TResource resource)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.ConnectionString))
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
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public virtual async Task Update(TResource resource)
        {
            using (var connection = new SqlConnection(_connectionConfiguration.ConnectionString))
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
