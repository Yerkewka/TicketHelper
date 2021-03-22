import React from 'react';

// Material UI
import { makeStyles } from '@material-ui/core/styles';
import green from '@material-ui/core/colors/green';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';

const useStyles = makeStyles((theme) => ({
  root: {
    display: 'flex',
    flexFlow: 'row nowrap',
    justifyContent: 'space-around',
    margin: theme.spacing(0, 1),
    backgroundColor: theme.palette.background.default,
  },
  priceWrapper: {
    textAlign: 'center',
    flex: 1,
    padding: theme.spacing(1),
  },
  btn: {
    marginTop: theme.spacing(1),
    backgroundColor: green[500],
    color: theme.palette.common.white,
    '&:hover': {
      backgroundColor: green[300],
    },
  },
}));

const Prices = ({ prices }) => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      {prices.map((price, idx) => (
        <div key={idx} className={classes.priceWrapper}>
          <Typography variant="caption" component="p">
            {price.carriageTypeName}
          </Typography>
          <Button variant="contained" size="small" className={classes.btn}>
            {price.carriageTypePrice} ₸
          </Button>
        </div>
      ))}
    </div>
  );
};

export default Prices;
