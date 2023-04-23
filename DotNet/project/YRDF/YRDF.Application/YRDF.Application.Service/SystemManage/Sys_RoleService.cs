using System.Collections.Generic;
using YRDF.Application.Entity;
using YRDF.Application.IService.SystemManage;
using YRDF.Data.Repository;

namespace YRDF.Application.Service.SystemManage
{
    /// <summary>
    /// 角色
    /// 数据层
    /// </summary>
    public class Sys_RoleService : Repository<Sys_Role>, ISys_RoleService
    {
        /// <summary>
        /// 添加实体数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddRowModel(Sys_Role model)
        {
            return Add(model) == 1 ? true : false;
        }

        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public bool ModifyRowModel(Sys_Role model)
        {
            return Modify(model) == 1 ? true : false;
        }

        /// <summary>
        /// 获取数据列表(根据状态)
        /// </summary>
        /// <returns></returns>
        public List<Sys_Role> GetListByState(int state = 0)
        {
            var list = GetListBy(t => t.State == state);
            return list;
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="k">主键</param>
        /// <returns></returns>
        public Sys_Role GetRowModel(string k)
        {
            return GetModel(t => t.Id == k && t.State == 0);
        }
    }
}
