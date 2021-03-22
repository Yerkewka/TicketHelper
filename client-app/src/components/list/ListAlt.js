import React, { Fragment } from 'react';
import { format } from 'date-fns';
import ru from 'date-fns/locale/ru';
import Station from './Station';
import Prices from './Prices';

// Material UI
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import TrainIcon from '@material-ui/icons/Train';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    margin: theme.spacing(1),
    padding: theme.spacing(1),
  },
  title: {
    margin: theme.spacing(2),
  },
  gridContainer: {
    marginBottom: theme.spacing(2),
    padding: theme.spacing(2),
  },
  trainName: {
    fontWeight: 'bold',
  },
  trainCodeWrapper: {
    display: 'flex',
    alignItems: 'center',
  },
  trainCode: {
    marginLeft: theme.spacing(2),
    display: 'block',
    borderBottom: '1px dotted',
    paddingBottom: 3,
  },
  durationWrapper: {
    background: `linear-gradient(180deg, transparent calc(50% - 1px), #dedede 50%, transparent calc(50% + 1px))`,
    width: 220,
    textAlign: 'center',
    margin: theme.spacing(0, 3),
    alignSelf: 'flex-start',
  },
  duration: {
    backgroundColor: theme.palette.common.white,
    padding: theme.spacing(2),
  },
  detailsWrapper: {
    display: 'flex',
    flexFlow: 'row wrap',
  },
}));

const List = ({ formData, searchResult }) => {
  const classes = useStyles();

  if (formData === null) return null;

  const calculateDuration = (startDateStr, endDateStr) => {
    const startDate = new Date(startDateStr);
    const endDate = new Date(endDateStr);

    const diffInSeconds = (endDate - startDate) / 1000;
    const hours = Math.floor(diffInSeconds / (60 * 60));
    const mins = diffInSeconds / 60 - hours * 60;
    return `${hours} ч. ${mins} мин.`;
  };

  return (
    <div className={classes.root}>
      <Typography variant="h6" className={classes.title}>
        {formData.startStationName} - {formData.endStationName},{' '}
        {format(formData.departureDate, 'dd MMMM', { locale: ru })}
      </Typography>
      <Grid container direction="column">
        {searchResult.map((result, index) => (
          <Grid
            container
            item
            key={index}
            component={Paper}
            className={classes.gridContainer}
            spacing={1}
          >
            {result.trains.map((train, idx) => (
              <Fragment key={idx}>
                <Grid item xs={12} sm={3}>
                  <Typography className={classes.trainName}>
                    {train.trainName}
                  </Typography>
                  <div className={classes.trainCodeWrapper}>
                    <TrainIcon color="primary" />
                    <span className={classes.trainCode}>{train.trainCode}</span>
                  </div>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <div className={classes.detailsWrapper}>
                    <Station
                      date={train.departureStationDepartureDate}
                      stationName={train.departureStationName}
                    />
                    <div className={classes.durationWrapper}>
                      <Typography
                        variant="caption"
                        component="span"
                        className={classes.duration}
                      >
                        {calculateDuration(
                          train.departureStationDepartureDate,
                          train.arrivalStationArrivalDate,
                        )}
                      </Typography>
                    </div>
                    <Station
                      date={train.arrivalStationArrivalDate}
                      stationName={train.arrivalStationName}
                    />
                  </div>
                </Grid>
                <Grid item xs={12} sm={3}>
                  <Prices prices={train.prices} />
                </Grid>
              </Fragment>
            ))}
          </Grid>
        ))}
      </Grid>
    </div>
  );
};

export default List;
