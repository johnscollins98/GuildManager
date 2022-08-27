import { FC } from 'react';
import { useParams } from 'react-router-dom';
import { useFetchGuildRoles } from '../../lib/discord-guild/queries/useFetchGuildRoles';
import { GuildConfigDetailDto } from '../../lib/guild-config/models/guildConfigDetailDto';
import { useUpdateGuildConfig } from '../../lib/guild-config/mutations/useUpdateGuildConfig';
import { useFetchGuildConfig } from '../../lib/guild-config/queries/useFetchGuildConfig';
import ErrorDisplay from '../common/ErrorDisplay';
import Loader from '../common/Loader';
import GuildConfigForm from './GuildConfigForm';

interface GuildConfigPageProps {}

const defaultConfig: GuildConfigDetailDto = {
  adminRoleIds: [],
  guildWarsApiKey: '',
  guildWarsGuildId: ''
}

const GuildConfigPage: FC<GuildConfigPageProps> = () => {
  const { guildId } = useParams();
  if (!guildId) throw Error('Missing guild id');

  const { data: config, error, isLoading } = useFetchGuildConfig(guildId);
  const { data: roles, error: roleError, isLoading: rolesLoading } = useFetchGuildRoles(guildId);

  const updateConfigMutation = useUpdateGuildConfig(guildId);

  if (roleError) return <ErrorDisplay error={roleError} />
  if (error && error.response?.status !== 404) return <ErrorDisplay error={error} />;
  if (isLoading || rolesLoading || !roles) return <Loader />;

  return <GuildConfigForm guildConfig={config ?? defaultConfig} guildRoles={roles} onSubmit={updateConfigMutation.mutate} />
};

export default GuildConfigPage;
