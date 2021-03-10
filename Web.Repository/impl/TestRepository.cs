using SqlSugar;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class TestRepository : ITestRepository
    {
        public object Test()
        {
            var db = SqlSugarHelper.GetInstance();
            var result =
                db.Queryable<SysUserRole, SysRoleMenu, SysMenu>
                    ((sur, srm, sm) => new JoinQueryInfos(
                        JoinType.Left, sur.RoleId == srm.RoleId,
                        JoinType.Left, srm.MenuId == sm.MenuId
                    ))
                    .Where(sur => sur.UserId == 0)
                    .Select((sur, srm, sm) => sm.Perms)
                    .GroupBy("Perms")
                    .ToList();
            return result;
        }
    }
}