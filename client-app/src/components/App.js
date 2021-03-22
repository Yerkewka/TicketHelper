import React, { useState } from 'react';
import Form from './form/Form';
import List from './list/List';
import ListAlt from './list/ListAlt';
import Loader from './layout/Loader';
import TopBar from './layout/TopBar';

// Material UI
import CssBaseline from '@material-ui/core/CssBaseline';

const App = () => {
  const [trains, setTrains] = useState([]);
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState(null);

  return (
    <div>
      <CssBaseline />
      <TopBar />
      <Loader open={loading} />
      <Form
        setFormData={setFormData}
        setTrains={setTrains}
        setLoading={setLoading}
        loading={loading}
      />
      {/* <List searchResult={trains} /> */}
      <ListAlt searchResult={trains} formData={formData} />
    </div>
  );
};

export default App;
