import { FC, FormEvent, useState } from 'react';
import { RoleListDto } from '../../lib/discord-guild/models/roleListDto';
import { GuildConfigDetailDto } from '../../lib/guild-config/models/guildConfigDetailDto';
import { Button } from '../common/Button';
import { Input } from '../common/Input';

interface GuildConfigFormProps {
  guildConfig: GuildConfigDetailDto;
  guildRoles: RoleListDto[];
  onSubmit: (newConfig: GuildConfigDetailDto) => void;
}

const GuildConfigForm: FC<GuildConfigFormProps> = ({ onSubmit, guildConfig, guildRoles }) => {
  const [guildConfigEdit, setGuildConfigEdit] = useState(guildConfig);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    e.stopPropagation();
    onSubmit(guildConfigEdit);
  };

  const toggleRole = (role: RoleListDto) => {
    const checked = guildConfigEdit.adminRoleIds.includes(role.id);
    const newList = checked
      ? guildConfigEdit.adminRoleIds.filter((r) => r !== role.id)
      : [...guildConfigEdit.adminRoleIds, role.id];
    setGuildConfigEdit({ ...guildConfigEdit, adminRoleIds: newList });
  };

  return (
    <form onSubmit={handleSubmit} className="flex flex-col flex-1 gap-3 overflow-hidden">
      <div className="flex items-center gap-4">
        <label htmlFor="gw2-guild">GW2 Guild Id</label>
        <Input
          type="text"
          id="gw2-guild"
          required
          value={guildConfigEdit.guildWarsGuildId}
          onChange={(e) =>
            setGuildConfigEdit({
              ...guildConfigEdit,
              guildWarsGuildId: e.target.value,
            })
          }
        />
      </div>
      <div className="flex items-center gap-4">
        <label htmlFor="gw2-api-key">GW2 API Key</label>
        <Input
          type="password"
          id="gw2-api-key"
          required
          value={guildConfigEdit.guildWarsApiKey}
          onChange={(e) =>
            setGuildConfigEdit({
              ...guildConfigEdit,
              guildWarsApiKey: e.target.value,
            })
          }
        />
      </div>
      <div className="flex flex-col flex-1 overflow-hidden">
        <label>Admin Roles</label>
        <div className="flex flex-col flex-1 overflow-y-auto gap-1">
          {guildRoles.map((role) => (
            <div key={role.id} className="flex items-center">
              <input
                type="checkbox"
                checked={guildConfigEdit.adminRoleIds.includes(role.id)}
                className="appearance-none mr-3 border w-4 h-4 rounded-sm bg-slate-200 border-slate-500 checked:bg-slate-500 dark:border-slate-400 dark:bg-slate-700 dark:checked:bg-slate-400"
                onChange={() => {
                  toggleRole(role);
                }}
                id={role.id}
              />
              <label htmlFor={role.id}>{role.name}</label>
            </div>
          ))}
        </div>
      </div>
      <Button className="w-fit self-end">Submit</Button>
    </form>
  );
};

export default GuildConfigForm;
