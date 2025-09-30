using AMartinezTech.Domain.Module.Administration;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Administration.Settings.Interfaces;

public interface ISettingWriteRepository : ICreate<SettingEntity>, IUpdate<SettingEntity>;
