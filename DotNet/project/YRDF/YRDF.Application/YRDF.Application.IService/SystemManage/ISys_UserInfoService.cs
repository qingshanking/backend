using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRDF.Application.Entity;

namespace YRDF.Application.IService.SystemManage
{
    /// <summary>
    /// 系统业务_用户表
    /// 接口层
    /// 2020年4月26日00:16:03
    /// </summary>
    public interface ISys_UserInfoService
    {
        /// <summary>
        /// 添加用户数据
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        bool AddRowModel(Sys_UserInfo model);
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        Sys_UserInfo GetUserExist(Sys_UserInfo model);

        /// <summary>
        /// 根据登录名 获取数据实体
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        Sys_UserInfo GetModelByLoginName(string LoginName);
    }
}
