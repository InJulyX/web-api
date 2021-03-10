using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToolBox.UserAgentParse;
using Web.Model;
using Web.Model.Database;
using Web.Model.ResponseModel;
using Web.Model.VO;
using Web.Service;

namespace Web.Api.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginLogService _loginLogService;
        private readonly ISysMenuService _sysMenuService;
        private readonly ISysRoleService _sysRoleService;
        private readonly ISysUserService _sysUserService;


        public LoginController(IConfiguration configuration, ISysMenuService sysMenuService,
            ILoginLogService loginLogService, ISysUserService sysUserService, ISysRoleService sysRoleService)
        {
            _configuration = configuration;
            _sysMenuService = sysMenuService;
            _loginLogService = loginLogService;
            _sysUserService = sysUserService;
            _sysRoleService = sysRoleService;
        }

        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public AjaxResult<TokenModel> Login([FromBody] SysUser sysUser)
        {
            if (string.IsNullOrEmpty(sysUser.Username) || string.IsNullOrEmpty(sysUser.Password))
                throw new Exception("用户名或密码不能为空");

            var ua = new UaUnit(Request.Headers["User-Agent"]).Parse();
            var loginLog = new LoginLog
            {
                Username = sysUser.Username,
                ClientIp = GetClientIp(),
                Browser = ua.BrowserName,
                Os = ua.SystemName + " " + ua.SystemVersion,
                BrowserVersion = ua.BrowserVersion
            };

            var loginUser = _sysUserService.Login(sysUser.Username, sysUser.Password);
            if (loginUser == null)
            {
                loginLog.Status = 1;
                loginLog.Msg = "用户名或密码错误";
                Task.Factory.StartNew(() => { _loginLogService.Insert(loginLog); });
                throw new Exception("用户名或密码错误");
            }

            var jwtSettings = new JwtSettings();
            _configuration.GetSection("JwtSettings").Bind(jwtSettings);


            var claims = new[]
            {
                new Claim("user_id", loginUser.Id.ToString()),
                new Claim("username", loginUser.Username)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(jwtSettings.ExpiredTime),
                signingCredentials
            );

            loginLog.Status = 0;
            loginLog.Msg = "登录成功";
            Task.Factory.StartNew(() => { _loginLogService.Insert(loginLog); });
            // TODO 用户信息存入REDIS
            return AjaxResult<TokenModel>.Success(new TokenModel
                {token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token)});
        }

        [HttpGet]
        [Route("/getInfo")]
        public AjaxResult<object> GetInfo()
        {
            RedisHelper.DelAsync("permission:" + GetUserName());
            var result = new Dictionary<string, object>();
            var sysUser = _sysUserService.GetSysUserByUserId(GetUserId());

            var roles = _sysRoleService.GetSysRoleNameByUserId(GetUserId());
            var permissions = _sysMenuService.GetPermissionListByUserId(sysUser.Id);
            result.Add("user", sysUser);
            result.Add("roles", roles);
            result.Add("permissions", permissions);

            return AjaxResult<object>.Success(result);
        }

        [HttpGet]
        [Route("/getRouters")]
        public AjaxResult<IEnumerable<RouterVO>> GetRouters()
        {
            var sysUser = _sysUserService.GetSysUserByUserId(GetUserId());
            var sysMenuList = _sysMenuService.GetMenuTreeByUserId(sysUser.Id);
            var s2 = _sysMenuService.BuildMenus(sysMenuList);

            return AjaxResult<IEnumerable<RouterVO>>.Success(s2);
        }

        [HttpPost]
        [Route("/logout")]
        public AjaxResult<object> Logout()
        {
            var ua = new UaUnit(Request.Headers["User-Agent"]).Parse();

            var loginLog = new LoginLog
            {
                Username = GetUserName(),
                ClientIp = GetClientIp(),
                Browser = ua.BrowserName,
                Os = ua.SystemName + " " + ua.SystemVersion,
                BrowserVersion = ua.BrowserVersion,
                Status = 0,
                Msg = "退出成功"
            };
            Task.Factory.StartNew(() => { _loginLogService.Insert(loginLog); });
            // TODO 从REDIS删除用户信息
            return AjaxResult<object>.Success();
        }
    }
}