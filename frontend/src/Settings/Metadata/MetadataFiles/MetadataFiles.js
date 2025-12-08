import PropTypes from 'prop-types';
import React from 'react';
import FieldSet from 'Components/FieldSet';
import PageSectionContent from 'Components/Page/PageSectionContent';
import translate from 'Utilities/String/translate';
import MetadataFile from './MetadataFile';
import styles from './MetadataFiles.css';

function MetadataFiles(props) {
  const {
    items,
    ...otherProps
  } = props;

  return (
    <FieldSet legend={translate('MetadataConsumers')}>
      <PageSectionContent
        errorMessage={translate('UnableToLoadMetadata')}
        {...otherProps}
      >
        <div className={styles.metadatafiles}>
          {
            items.map((item) => {
              return (
                <MetadataFile
                  key={item.id}
                  {...item}
                />
              );
            })
          }
        </div>
      </PageSectionContent>
    </FieldSet>
  );
}

MetadataFiles.propTypes = {
  isFetching: PropTypes.bool.isRequired,
  error: PropTypes.object,
  items: PropTypes.arrayOf(PropTypes.object).isRequired
};

export default MetadataFiles;
