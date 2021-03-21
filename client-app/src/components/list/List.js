import React, { Fragment } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper'; 
import {format} from 'date-fns';

const useStyles = makeStyles(theme => ({
    head: {
        backgroundColor: theme.palette.primary.main,
        color: theme.palette.common.white,
        fontWeight: 'bold'
    }
}))

const List = (props) => {
    const classes = useStyles();

    return (    
        <TableContainer component={Paper}>
            <Table style={{border: "1px solid black"}}>
                <TableHead>
                    <TableRow>
                        <TableCell className={classes.head}>Поезд</TableCell>
                        <TableCell className={classes.head}>Код поезда</TableCell>
                        <TableCell className={classes.head}>Время отъезда</TableCell>
                        <TableCell className={classes.head}>Станция отъезда</TableCell>
                        <TableCell className={classes.head}>Время приезда</TableCell>
                        <TableCell className={classes.head}>Станция презда</TableCell>
                        <TableCell className={classes.head}>Цена (плацкарт)</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {props.searchResult.map((result,index)=>{
                        return <Fragment key={index}>
                            {index !== 0 && <TableRow>
                                <TableCell colSpan={7}></TableCell>
                            </TableRow>}
                            {result.trains.map((train, idx)=>(  
                                <TableRow key={idx}>
                                    <TableCell>{train.trainName}</TableCell>
                                    <TableCell>{train.trainCode}</TableCell>
                                    <TableCell>{train.departureStationDepartureDate}</TableCell>
                                    <TableCell>{train.departureStationName}</TableCell>
                                    <TableCell>{train.arrivalStationArrivalDate}</TableCell>
                                    <TableCell>{train.arrivalStationName}</TableCell>
                                    {idx === 0 && <TableCell rowSpan={result.trains.length}>{result.price} KZT </TableCell>} 
                                </TableRow>                                 
                            ))}   
                        </Fragment>
                    })}
                </TableBody>
            </Table>
        </TableContainer>
    )
}

export default List