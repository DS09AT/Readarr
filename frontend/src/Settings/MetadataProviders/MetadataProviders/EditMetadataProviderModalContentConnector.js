import PropTypes from 'prop-types';
import React from 'react';
import { connect } from 'react-redux';
import { createSelector } from 'reselect';
import { clearPendingChanges } from 'Store/Actions/baseActions';
import { cancelSaveMetadataProviders, cancelTestMetadataProviders, saveMetadataProviders, setMetadataProvidersFieldValue, setMetadataProvidersValue, testMetadataProviders } from 'Store/Actions/settingsActions';
import createProviderSettingsSelector from 'Store/Selectors/createProviderSettingsSelector';
import EditMetadataProviderModalContent from './EditMetadataProviderModalContent';

function createMapStateToProps() {
  return createSelector(
    (state) => state.settings.advancedSettings,
    createProviderSettingsSelector('metadataProviders'),
    (advancedSettings, metadataProvider) => {
      return {
        advancedSettings,
        ...metadataProvider
      };
    }
  );
}

const mapDispatchToProps = {
  setMetadataProviderValue: setMetadataProvidersValue,
  setMetadataProviderFieldValue: setMetadataProvidersFieldValue,
  saveMetadataProvider: saveMetadataProviders,
  cancelSaveMetadataProvider: cancelSaveMetadataProviders,
  testMetadataProvider: testMetadataProviders,
  cancelTestMetadataProvider: cancelTestMetadataProviders,
  clearPendingChanges
};

export default connect(createMapStateToProps, mapDispatchToProps)(EditMetadataProviderModalContent);
