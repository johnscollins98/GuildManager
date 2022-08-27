import { FC, FormEvent, useState } from 'react';
import { RoleListDto } from '../../lib/discord-guild/models/roleListDto';
import { GuildConfigDetailDto } from '../../lib/guild-config/models/guildConfigDetailDto';

interface GuildConfigFormProps {
  guildConfig: GuildConfigDetailDto;
  guildRoles: RoleListDto[];
  onSubmit: (newConfig: GuildConfigDetailDto) => void;
}

const GuildConfigForm: FC<GuildConfigFormProps> = ({
  onSubmit,
  guildConfig,
  guildRoles,
}) => {
  const [guildConfigEdit, setGuildConfigEdit] = useState(guildConfig);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    e.stopPropagation();
    onSubmit(guildConfigEdit);
  };

  const toggleRole = (role: RoleListDto) => {
    const checked = guildConfigEdit.adminRoleIds.includes(role.id);
    const newList = checked ? guildConfigEdit.adminRoleIds.filter(r => r !== role.id) : [...guildConfigEdit.adminRoleIds, role.id];
    setGuildConfigEdit({ ...guildConfigEdit, adminRoleIds: newList });
  }

  return (
    <form onSubmit={handleSubmit}>
      <div className="mb-3">
        <label htmlFor="gw2-guild" className="form-label">
          GW2 Guild Id
        </label>
        <input
          type="text"
          className="form-control"
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
      <div className="mb-3">
        <label htmlFor="gw2-api-key" className="form-label">
          GW2 API Key
        </label>
        <input
          type="password"
          className="form-control"
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
      <div className="mb-3">
        <label className="form-label">Admin Roles</label>
        {guildRoles.map((role) => (
          <div className="form-check" key={role.id}>
            <input
              className="form-check-input"
              type="checkbox"
              checked={guildConfigEdit.adminRoleIds.includes(role.id)}
              onChange={() => { toggleRole(role) }}
              id={role.id}
            />
            <label className="form-check-label" htmlFor={role.id}>
              {role.name}
            </label>
          </div>
        ))}
      </div>
      <button className="btn btn-primary">
        Submit
      </button>
    </form>
  );
};

export default GuildConfigForm;
