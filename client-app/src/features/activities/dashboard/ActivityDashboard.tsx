import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Grid } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponents';
import { useStore } from '../../../app/stores/store';
import ActivityList from './ActivityList';

export default observer(function ActivityDashboard() {
  const { activityStore } = useStore(); // destructuring the object store to get only activityStore
  const { loadActivities, activityRegistry } = activityStore;

  useEffect(() => {
    if (activityRegistry.size <= 1) activityStore.loadActivities();
  }, [activityRegistry.size, loadActivities]) // [] in the end's gonna assure that our hook runs only once
  // activityStore is a dependency to the use effect


  if (activityStore.loadingInitial) return <LoadingComponent content='Loading app' />

  return (
    <Grid>
      <Grid.Column width='10'>
        <ActivityList />
      </Grid.Column>
      <Grid.Column width='6'>
        <h2> Activity filters </h2>
      </Grid.Column>
    </Grid>
  )
})