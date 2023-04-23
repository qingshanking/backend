using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRDF.Application.IService.SystemManage;
using YRDF.Application.Service.SystemManage;
using YRDF.Application.Entity;
using YRDF.Util.Log;
using YRDF.Util;

namespace YRDF.Application.Busines.SystemManage
{
    /// <summary>
    /// 用户表
    /// 业务逻辑层
    /// 2020年4月26日00:19:03
    /// </summary>
    public class Sys_UserInfoBusines
    {
        /// <summary>
        /// 用户表接口层引用
        /// </summary>
        private readonly ISys_UserInfoService _server = new Sys_UserInfoService();

        public object SaveUserForm(Sys_UserInfo model)
        {
            try
            {
                //添加
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    //只要 登录名 手机号 邮箱 存在 就返回该用户也存在
                    var exist = _server.GetUserExist(model);
                    if (exist != null)
                        return new { code = 1, msg = "账户已存在" };
                    //加密密码
                    var passwordmd5 = Md5Helper.Encrypt(model.LoginName, 32);
                    var password = passwordmd5.ToLower() + model.LoginName;
                    model.PassWord = Md5Helper.Encrypt(password, 32);//添加时自动将登陆名作为密码 且加密处理
                    model.CreateTime = DateTime.Now;
                    model.RegTime = DateTime.Now;
                    model.RegIP = "127.0.0.1";
                    model.LoginTime = DateTime.Now;

                    model.State = 0;//(0正常 1审核 2删除)
                    if (_server.AddRowModel(model))
                        return new { code = 0, msg = "操作成功" };
                    return new { code = 1, msg = "数据异常" };
                }
                //修改
                else
                {

                }
                return "";
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex.ToString());
                return new { code = 1, msg = "内部错误" };
            }
        }
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="username">账户</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public object CheckLogin(string username, string password)
        {
            var model = _server.GetModelByLoginName(username);
            if (model == null)
                return new { code = 1, data = "", msg = "账户不存在" };
            password = password.ToLower() + model.LoginName;
            password = Md5Helper.Encrypt(password, 32);
            if (model.PassWord == password)
            {
                //后端账户
                if (model.IsSys == 0)
                {
                    //正常登录
                    if (model.State == 0)
                    {
                        WebHelper.WriteSession<Sys_UserInfo>("session_login_userInfo", model);
                        //更新登录数据 ip和时间

                        //生成token
                        return new { code = 0, data = new { access_token = "c262e61cd13ad99fc650e6908c7e5e65b63d2f32185ecfed6b801ee3fbdd5c0a" }, msg = "登录成功" };
                    }
                    if (model.State == 1)
                        return new { code = 1, msg = "账户审核中" };
                    return new { code = 1, msg = "账户禁止登录" };
                }
                //前端账户
                else return new { code = 1, msg = "前端账户禁止登录" };
            }
            return new { code = 1, msg = "密码错误" };
        }

    }
}
