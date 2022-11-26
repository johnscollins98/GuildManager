import { FC } from 'react';
import { useParams } from 'react-router-dom';
import { useFetchGuildRoles } from '../../../lib/discord-guild/queries/useFetchGuildRoles';
import { GuildConfigDetailDto } from '../../../lib/guild-config/models/guildConfigDetailDto';
import { useUpdateGuildConfig } from '../../../lib/guild-config/mutations/useUpdateGuildConfig';
import { useFetchGuildConfig } from '../../../lib/guild-config/queries/useFetchGuildConfig';
import ErrorDisplay from '../../common/ErrorDisplay';
import Loader from '../../common/Loader';
import GuildConfigForm from './GuildConfigForm';

interface GuildConfigPageProps {}

const defaultConfig: GuildConfigDetailDto = {
  adminRoleIds: [],
  guildWarsApiKey: '',
  guildWarsGuildId: '',
};

const GuildConfigPage: FC<GuildConfigPageProps> = () => {
  const { guildId } = useParams();
  if (!guildId) throw Error('Missing guild id');

  const config = useFetchGuildConfig(guildId);
  const roles = useFetchGuildRoles(guildId);

  const updateConfigMutation = useUpdateGuildConfig(guildId);

  if (roles.error) return <ErrorDisplay error={roles.error} />;
  if (config.error) return <ErrorDisplay error={config.error} />;
  if (config.isLoading || roles.isLoading || !roles.data) return <Loader />;

  return (
    <GuildConfigForm
      guildConfig={config.data ?? defaultConfig}
      guildRoles={roles.data}
      onSubmit={updateConfigMutation.mutate}
    />
  );
};

export default GuildConfigPage;
