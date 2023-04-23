using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRDF.Application.Entity;
using YRDF.Application.IService.SystemManage;
using YRDF.Application.Service.SystemManage;
using YRDF.Util.Log;

namespace YRDF.Application.Busines.SystemManage
{
    public class Sys_RoleBusines
    {
        /// <summary>
        /// 服务引用
        /// </summary>
        private readonly ISys_RoleService _server = new Sys_RoleService();

        /// <summary>
        /// 公共：获取角色下拉选择数据
        /// </summary>
        /// <returns></returns>
        public object GetSelectList()
        {
            var list = _server.GetListByState();
            var result = from r in list
                         select new
                         {
                             id = r.Id,
                             name = r.Name,
                         };
            return new { code = 0, data = result, msg = "获取成功" };
        }


        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="k">主键</param>
        /// <returns></returns>
        public Sys_Role GetRowModel(string k)
        {
            return _server.GetRowModel(k);
        }

        /// <summary>
        /// 保存或修改数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public object SaveRoleForm(Sys_Role model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CreateTime = DateTime.Now;
                    //todo用户修改数据
                    if (_server.AddRowModel(model))
                        return new { code = 0, msg = "操作成功" };
                    else return new { code = 1, msg = "内部错误" };
                }
                else
                {
                    var m = _server.GetRowModel(model.Id);
                    if (m == null)
                        return new { code = 1, msg = "数据异常" };
                    m.Name = model.Name;
                    m.Explain = model.Explain;
                    m.ModifyTime = DateTime.Now;
                    m.ModifyUser = "";
                    m.ModifyUserName = "";
                    if (_server.ModifyRowModel(m))
                        return new { code = 0, msg = "操作成功" };
                    return new { code = 1, msg = "数据异常" };
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex.ToString());
                return new { code = 1, msg = "内部错误" };
            }
        }

        /// <summary>
        /// 获取表格数据
        /// </summary>
        /// <returns></returns>
        public object GetTableJson()
        {
            var list = _server.GetListByState();
            var redata = from i in list
                         select new
                         {
                             i.Id,
                             i.Name,
                             i.Explain
                         };
            return new { code = 0, data = redata, };
        }
    }
}
