using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRDF.Application.Entity;

namespace YRDF.Application.IService.SystemManage
{
    /// <summary>
    /// 角色表
    /// 接口层
    /// </summary>
    public interface ISys_RoleService
    {
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="k">主键</param>
        /// <returns></returns>
        Sys_Role GetRowModel(string k);
        /// <summary>
        /// 添加实体数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool AddRowModel(Sys_Role model);

        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        bool ModifyRowModel(Sys_Role model);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        List<Sys_Role> GetListByState(int state = 0);
    }
}
