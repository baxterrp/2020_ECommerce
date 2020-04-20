using BaxterCommerce.CommonClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Base
{
    /// <summary>
    /// contract for handling data base interactions
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public interface IDataRepository<TResource> where TResource : BaseResource
    {

        /// <summary>
        /// Insert command for <see cref="TResource"/>
        /// </summary>
        /// <param name="resource">The <see cref="TResource"/> to add</param>
        Task Insert(TResource resource);

        /// <summary>
        /// Runs update on given <see cref="TResource"/>
        /// </summary>
        /// <param name="resource"><see cref="TResource"/> with updated properties</param>
        Task Update(TResource resource);

        /// <summary>
        /// Searches for <see cref="TResource"/> based on given <see cref="BaseSearchParameters"/>
        /// </summary>
        /// <param name="parameters"><see cref="BaseSearchParameters"/></param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="TResource"/></returns>
        Task<IEnumerable<TResource>> Find(BaseSearchParameters parameters);

        /// <summary>
        /// Searches for <see cref="TResource"/> using <see cref="BaseResource.Id"/>
        /// </summary>
        /// <param name="id"><see cref="BaseResource.Id"/></param>
        /// <returns><see cref="TResource"/></returns>
        Task<TResource> FindById(string id);
    }
}
