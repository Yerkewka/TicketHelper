import React, { useState } from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Autocomplete from '@material-ui/lab/Autocomplete';
import DateFnsUtils from '@date-io/date-fns';
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker,
} from '@material-ui/pickers';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
  root: {
    margin: 10,
    display: 'flex',
    flexFlow: 'row nowrap',
    justifyContent: 'space-between',
    alignItems:'center'
  },
  autocomplete: {
    width: 300
  }
}));

const stations = [
  { id: 'AD', name: 'Andorra' },
  { id: 'AE', name: 'United Arab Emirates' },
  { id: 'AF', name: 'Afghanistan' },
  { id: 'AG', name: 'Antigua and Barbuda' }
];

const Form = () => {
  const classes = useStyles();

  const [startStation, setStartStation] = useState(stations[0]);
  const [startStationText, setStartStationText] = useState('');
  const [endStation, setEndStation] = useState(stations[0]);
  const [endStationText, setEndStationText] = useState('');
  const [date, setDate] = useState(Date.now);
  const [price, setPrice] = useState(0);

  return (
    <form className={classes.root}>
      <Autocomplete 
        className={classes.autocomplete}
        value={startStation}
        onChange={(_, newValue) => setStartStation(newValue)}
        inputValue={startStationText}
        onInputChange={(_, newInputValue) => setStartStationText(newInputValue)}
        options={stations}
        getOptionLabel={(option) => {
          return option.name;
        }}
        renderOption={(option) => 
          <span>{option.name}</span>
        }
        renderInput={(params) => 
          <TextField 
            {...params} 
            label="Откуда"
            variant="outlined"
          />
        }
      />
      <Autocomplete 
        className={classes.autocomplete}
        value={endStation}
        onChange={(_, newValue) => setEndStation(newValue)}
        inputValue={endStationText}
        onInputChange={(_, newInputValue) => setEndStationText(newInputValue)}
        options={stations}
        getOptionLabel={(option) => {
          return option.name;
        }}
        renderOption={(option) => 
          <span>{option.name}</span>
        }
        renderInput={(params) => 
          <TextField 
            {...params} 
            label="Куда"
            variant="outlined"
          />
        }
      />
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
        <KeyboardDatePicker
          autoOk
          disableToolbar
          variant="inline"
          inputVariant="outlined"
          format="MM/dd/yyyy"
          margin="normal"
          label="Дата отправления"
          value={date}
          onChange={setDate}
        />
      </MuiPickersUtilsProvider>
      <TextField 
        type="number"
        value={price} 
        onChange={e => setPrice(e.target.value)} 
        label="Предельная цена"
        variant="outlined" 
      />
      <Button
        variant="contained"
        color="primary"
      >
        Найти
      </Button>
    </form>
  )
}

export default Form;