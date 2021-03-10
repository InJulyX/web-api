using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Web.Model;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;

namespace Web.Service.impl
{
    public class SysMenuService : ISysMenuService
    {
        private readonly ILogger<SysMenuService> _logger;
        private readonly ISysMenuRepository _sysMenuRepository;
        private readonly ISysRoleMenuRepository _sysRoleMenuRepository;
        private readonly ISysUserService _sysUserService;

        public SysMenuService(ISysMenuRepository sysMenuRepository, ISysRoleMenuRepository sysRoleMenuRepository,
            ILogger<SysMenuService> logger, ISysUserService sysUserService)
        {
            _sysMenuRepository = sysMenuRepository;
            _sysRoleMenuRepository = sysRoleMenuRepository;
            _logger = logger;
            _sysUserService = sysUserService;
        }

        public AjaxResult<object> GetRoleMenuTree(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     更新菜单信息
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        public int UpdateSysMenu(SysMenu sysMenu)
        {
            // TODO 安全校验，防止传递非法参数
            if (_sysMenuRepository.IsExist(sysMenu))
                // TODO 菜单已存在异常
                throw new NotImplementedException();

            return _sysMenuRepository.Update(sysMenu);
        }

        /// <summary>
        ///     查询去重后的用户权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetPermissionListByUserId(long? userId)
        {
            var sysUser = _sysUserService.GetSysUserByUserId(userId);
            var permissionList = RedisHelper.Get<IEnumerable<string>>("permission:" + sysUser.Username);
            if (permissionList == null)
            {
                permissionList = _sysMenuRepository.GetPermissionListByUserId(userId);
                _logger.LogDebug("从数据库查询用户权限列表");
            }

            var result = new List<string>();
            foreach (var permission in permissionList)
                if (!result.Contains(permission) && !string.IsNullOrEmpty(permission))
                    result.Add(permission);

            RedisHelper.SetAsync("permission:" + sysUser.Username, result, 180);
            return result;
        }

        /// <summary>
        ///     根据菜单ID查询菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysMenu GetSysMenuByMenuId(long id)
        {
            var sysMenu = new SysMenu
            {
                MenuId = id
            };
            var result = _sysMenuRepository.GetSysMenu(sysMenu);
            return result;
        }

        /// <summary>
        ///     添加系统菜单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public AjaxResult<object> AddSysMenu(SysMenu data)
        {
            if (_sysMenuRepository.IsExist(data))
                // todo 添加异常返回值
                throw new Exception("菜单已存在");

            var result = _sysMenuRepository.InsertReturnId(data);
            _sysRoleMenuRepository.Insert(new SysRoleMenu {RoleId = 0, MenuId = result});
            return AjaxResult<object>.Success();
        }

        public IEnumerable<SysMenu> GetSysMenuList(SysMenu sysMenu)
        {
            return _sysMenuRepository.GetSysMenuList(sysMenu);
        }

        /// <summary>
        ///     根据菜单ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSysMenuByMenuId(long id)
        {
            var sysMenu = new SysMenu
            {
                MenuId = id
            };
            _sysRoleMenuRepository.Delete(new SysRoleMenu {MenuId = id});
            return _sysMenuRepository.Delete(sysMenu);
        }

        public IEnumerable<TreeSelect> BuildSysMenuTreeSelect()
        {
            var sysMenuList = _sysMenuRepository.GetSysMenuList();
            // var treeSelectList = new List<TreeSelect>();
            // foreach (var sysMenu in sysMenuList)
            // {
            //     var treeSelect = new TreeSelect()
            //     {
            //         Id = sysMenu.MenuId,
            //         Label = sysMenu.MenuName
            //     };
            //     // var routerVo = new RouterVO
            //     // {
            //     //     hidden = false,
            //     //     name = GetRouterName(sysMenu),
            //     //     path = GetRouterPath(sysMenu),
            //     //     component = GetComponent(sysMenu),
            //     //     ZhName = sysMenu.MenuName,
            //     //     MenuId = sysMenu.MenuId,
            //     //     meta = new MetaVO(sysMenu.MenuName, sysMenu.Icon, sysMenu.IsCache.Equals("1"))
            //     // };
            //     var menuList = sysMenu.Children;
            //
            //     if (menuList.Count > 0)
            //     {
            //         treeSelect.Children = BuildSysMenuTreeSelect(menuList);
            //     }
            //
            //     treeSelectList.Add(treeSelect);
            // }

            var s1 = GetChildPerms(sysMenuList, 0);
            return BuildSysMenuTreeSelect(s1);
        }


        /// <summary>
        ///     生成导航菜单
        /// </summary>
        /// <param name="sysMenuList"></param>
        /// <returns></returns>
        public IEnumerable<RouterVO> BuildMenus(IEnumerable<SysMenu> sysMenuList)
        {
            var routers = new List<RouterVO>();

            foreach (var sysMenu in sysMenuList)
            {
                // Console.WriteLine(sysMenu.MenuName);
                var routerVo = new RouterVO
                {
                    hidden = false,
                    name = GetRouterName(sysMenu),
                    path = GetRouterPath(sysMenu),
                    component = GetComponent(sysMenu),
                    ZhName = sysMenu.MenuName,
                    MenuId = sysMenu.MenuId,
                    meta = new MetaVO(sysMenu.MenuName, sysMenu.Icon, sysMenu.IsCache.Equals("1"))
                };
                var menuList = sysMenu.Children;

                if (menuList.Count > 0 && sysMenu.MenuType.Equals("M"))
                {
                    routerVo.alwaysShow = true;
                    routerVo.redirect = "noRedirect";
                    routerVo.children = BuildMenus(menuList);
                }
                else if (IsMenuFrame(sysMenu))
                {
                    var childrenList = new List<RouterVO>();
                    var children = new RouterVO
                    {
                        path = sysMenu.Path,
                        component = sysMenu.Component,
                        name = sysMenu.Path,
                        meta = new MetaVO(sysMenu.MenuName, sysMenu.Icon, sysMenu.IsCache.Equals("1"))
                    };

                    childrenList.Add(children);
                    routerVo.children = childrenList;
                }


                routers.Add(routerVo);
            }

            return routers;
        }

        /// <summary>
        ///     根据用户ID查询菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SysMenu> GetMenuTreeByUserId(long? userId)
        {
            return GetChildPerms(_sysMenuRepository.GetSysMenuListByUserId(userId), 0);
        }

        private static List<TreeSelect> BuildSysMenuTreeSelect(List<SysMenu> menus)
        {
            var treeSelectList = new List<TreeSelect>();
            foreach (var sysMenu in menus)
            {
                var treeSelect = new TreeSelect
                {
                    Id = sysMenu.MenuId,
                    Label = sysMenu.MenuName
                };
                var menuList = sysMenu.Children;

                if (menuList != null) treeSelect.Children = BuildSysMenuTreeSelect(menuList);

                treeSelectList.Add(treeSelect);
            }

            return treeSelectList;
        }

        private List<SysMenu> BuildSysMenuTree(List<SysMenu> menus)
        {
            var returnList = new List<SysMenu>();
            var tempList = new List<long?>();
            foreach (var menu in menus.Where(menu => !tempList.Contains(menu.ParentId)))
            {
                RecursionFn(menus, menu);
                returnList.Add(menu);
            }

            if (returnList.Count < 1) returnList = menus;

            return returnList;
        }

        private List<SysMenu> GetChildPerms(List<SysMenu> list, long parentId)
        {
            var sysMenuList = new List<SysMenu>();
            foreach (var sysMenu in list.Where(sysMenu => sysMenu.ParentId == parentId))
            {
                RecursionFn(list, sysMenu);
                sysMenuList.Add(sysMenu);
            }

            return sysMenuList;
        }

        private List<SysMenu> GetChildList(List<SysMenu> list, SysMenu sysMenu)
        {
            return list.Where(s1 => s1.ParentId == sysMenu.MenuId).ToList();
        }

        private void RecursionFn(List<SysMenu> sysMenuList, SysMenu sysMenu)
        {
            var childList = GetChildList(sysMenuList, sysMenu);
            sysMenu.Children = childList;
            foreach (var tChild in childList.Where(tChild => HasChild(sysMenuList, tChild)))
                RecursionFn(sysMenuList, tChild);
        }

        private bool HasChild(List<SysMenu> sysMenuList, SysMenu sysMenu)
        {
            return GetChildList(sysMenuList, sysMenu).Count > 0;
        }

        /// <summary>
        ///     获取路由名称
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        private string GetRouterName(SysMenu sysMenu)
        {
            var routerName = string.Empty;
            return IsMenuFrame(sysMenu) ? routerName : sysMenu.Path;
        }

        private bool IsMenuFrame(SysMenu sysMenu)
        {
            return sysMenu.ParentId == 0 && sysMenu.MenuType.Equals("C")
                                         && sysMenu.IsFrame.Equals("1");
        }

        /// <summary>
        ///     获取路由地址
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        private string GetRouterPath(SysMenu sysMenu)
        {
            var routerPath = sysMenu.Path;
            if (sysMenu.ParentId == 0 && sysMenu.MenuType.Equals("M") && sysMenu.IsFrame.Equals("1"))
                routerPath = "/" + sysMenu.Path;
            else if (IsMenuFrame(sysMenu)) routerPath = "/";

            return routerPath;
        }

        /// <summary>
        ///     获取component
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        private string GetComponent(SysMenu sysMenu)
        {
            var component = "Layout";
            if (sysMenu.Component != null && !sysMenu.Component.Equals("") && !IsMenuFrame(sysMenu))
                component = sysMenu.Component;
            else if (sysMenu.Component == null || sysMenu.Component.Equals("") && IsParentView(sysMenu))
                component = "ParentView";

            return component;
        }

        private bool IsParentView(SysMenu sysMenu)
        {
            return sysMenu.ParentId != 0 && sysMenu.MenuType.Equals("M");
        }
    }
}