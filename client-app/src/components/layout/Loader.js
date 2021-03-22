import React from 'react';
import Backdrop from '@material-ui/core/Backdrop';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  root: {
    zIndex: theme.zIndex.drawer + 1,
    backgroundColor: '#fff',
  },
}));

const Loader = ({ open }) => {
  const classes = useStyles();

  return (
    <Backdrop open={open} className={classes.root}>
      <img src="img/google-train.gif" alt="Loader icon" />
    </Backdrop>
  );
};

export default Loader;
