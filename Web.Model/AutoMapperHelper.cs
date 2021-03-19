using AutoMapper;
using Web.Model.Database;
using Web.Model.VO;

namespace Web.Model
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            // 角色
            CreateMap<SysRole, SysRoleVo>();
            // 登录日志
            CreateMap<LoginLog, LoginLogVo>();
            // 操作日志
            CreateMap<OperaLog, OperaLogVo>();
            // 系统用户
            CreateMap<SysUser, SysUserVo>();
        }
    }
}