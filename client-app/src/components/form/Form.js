import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useForm, Controller } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Autocomplete from '@material-ui/lab/Autocomplete';
import FormHelperText from '@material-ui/core/FormHelperText';
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
    alignItems:'flex-start'
  },
  autocomplete: {
    width: 300
  },
  datePicker: {
    margin: 0
  }
}));

const validationSchema = yup.object().shape({
  startStationId: yup.number().required('Выберите станцию отъезда'),
  endStationId: yup.number().required('Выберите станцию приезда'),
  departureDate: yup.date().required('Выберите дату отправления'),
  price: yup.number().positive('Цена должна быть положетельной').required('Укажите предельную цену')
})


const Form = () => {
  const classes = useStyles();
  const [stations, setStations] = useState([]);
  const [loading, setLoading] = useState(false);
  const { control, handleSubmit, errors } = useForm({
    resolver: yupResolver(validationSchema),
    reValidateMode: 'onBlur',
    mode: 'onBlur',
    defaultValues: {
      startStationId: undefined,
      endStationId: undefined,
      departureDate: new Date(),
      price: 0
    }
  });

  const onSubmit = async data => {
    setLoading(true);
    
    const result = 
      await axios.get('https://localhost:5001/api/process', { params: data }).finally(() => setLoading(false));

    console.log(result);
  }

  useEffect(() => {
    const fetchStations = async () => {
      const result = await axios.get('https://localhost:5001/api/dictionary/stations');
  
      if (result.data) {
        setStations(result.data);
      }
    }

    fetchStations();
  }, [])

  return (
    <form className={classes.root} onSubmit={handleSubmit(onSubmit)}>
      <div>
        <Controller 
          name="startStationId"
          control={control}
          render={({ onChange, onBlur, value }) => 
            <Autocomplete 
              className={classes.autocomplete}
              value={value}
              onChange={(_, newValue) => onChange(newValue?.id)}
              onBlur={onBlur}
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
          }
        />
        {errors?.startStationId && <FormHelperText error>{errors?.startStationId?.message}</FormHelperText>}
      </div>
      <div>
        <Controller 
          name="endStationId"
          control={control}
          render={({ onChange, onBlur, value }) => 
            <Autocomplete 
              className={classes.autocomplete}
              value={value}
              onChange={(_, newValue) => onChange(newValue?.id)}
              onBlur={onBlur}
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
          }
        />
        {errors?.endStationId && <FormHelperText error>{errors?.endStationId?.message}</FormHelperText>}
      </div>
      <Controller 
        name="departureDate"
        control={control}
        render={({ onChange, onBlur, value }) => 
          <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <KeyboardDatePicker
              autoOk
              disableToolbar
              variant="inline"
              inputVariant="outlined"
              format="dd/MM/yyyy"
              margin="normal"
              label="Дата отправления"
              value={value}
              onChange={onChange}
              onBlur={onBlur}
              minDate={new Date()}
              maxDate={new Date().setTime(new Date().getTime() + (40 * 24 * 60 * 60 * 1000))}
              className={classes.datePicker}
              error={!!errors?.departureDate}
              helperText={errors?.departureDate?.message}
            />
          </MuiPickersUtilsProvider>
        }
      />
      <Controller 
        name="price"
        control={control}
        render={({ onChange, onBlur, value }) => 
          <TextField 
            type="number"
            value={value} 
            onChange={onChange} 
            onBlur={onBlur} 
            label="Предельная цена"
            variant="outlined" 
            error={!!errors?.price}
            helperText={errors?.price?.message}
            inputProps={{
              step: 100
            }}
          /> 
        }
      />      
      <Button
        variant="contained"
        color="primary"
        type="submit"
        disabled={loading}
      >
        Найти
      </Button>
    </form>
  )
}

export default Form;