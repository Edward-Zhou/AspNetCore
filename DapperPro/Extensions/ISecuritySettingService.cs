using DapperPro.Models.IdentityOption;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPro.Extensions
{
    public interface ISecuritySettingService
    {
        LockoutOption GetSecuritySetting();
        LockoutOption UpdateSecuritySetting(LockoutOption lockoutOption);
    }
    public class SecuritySettingService : ISecuritySettingService
    {
        private readonly ISecuritySettingRepository _securitySettingRepository;
        private readonly IdentityOptions _identityOptions;

        public SecuritySettingService(ISecuritySettingRepository securitySettingRepository
            , IOptions<IdentityOptions> identityOptions)
        {
            _securitySettingRepository = securitySettingRepository;
            _identityOptions = identityOptions.Value;
        }
        public LockoutOption GetSecuritySetting()
        {
            return _securitySettingRepository.GetSecuritySetting();
        }

        public LockoutOption UpdateSecuritySetting(LockoutOption lockoutOption)
        {
            var option = _securitySettingRepository.UpdateSecuritySetting(lockoutOption);
            //update identity options
            _identityOptions.Lockout.MaxFailedAccessAttempts = option.MaxFailedAccessAttempts;
            return option;
        }
    }
}
