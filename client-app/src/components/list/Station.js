import React from 'react';
import { format } from 'date-fns';
import ru from 'date-fns/locale/ru';

// Material UI
import { makeStyles } from '@material-ui/core/styles';
import green from '@material-ui/core/colors/green';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles((theme) => ({
  dayOfMonth: {
    marginLeft: theme.spacing(1),
    color: green[500],
    fontWeight: 'bold',
  },
  dateTime: {
    fontWeight: 'bold',
  },
  stationWrapper: {
    width: 150,
  },
  stationName: {
    whiteSpace: 'nowrap',
  },
}));

const Station = ({ date, stationName }) => {
  const classes = useStyles();

  return (
    <div className={classes.stationWrapper}>
      <div>
        <Typography className={classes.dateTime} component="span">
          {format(new Date(date), 'HH:mm')}
        </Typography>
        <Typography
          className={classes.dayOfMonth}
          variant="caption"
          component="span"
        >
          {format(new Date(date), 'dd MMMM', {
            locale: ru,
          })}
        </Typography>
      </div>
      <Typography variant="body2" className={classes.stationName}>
        {stationName}
      </Typography>
    </div>
  );
};

export default Station;
