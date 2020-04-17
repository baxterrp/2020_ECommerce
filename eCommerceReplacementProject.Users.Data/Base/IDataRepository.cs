using eCommerceReplacementProject.CommonClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Data.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public interface IDataRepository<TResource> where TResource : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        Task Insert(TResource resource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        Task Update(TResource resource);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<TResource>> Find(BaseSearchParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TResource> FindById(string id);
    }
}
