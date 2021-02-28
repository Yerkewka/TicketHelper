import React from 'react'

const List = (props) => {
    return (    
        <div>
            {props.searchResult.map((result,index)=>{
                return <div>
                    {result.trains.map((train, idx)=>(
                    <div>
                        <table style={{border: "1px solid black"}}>
                            <tr>
                            <th>Поезд</th>
                            <th>Код поезда</th>
                            <th>Время отъезда</th>
                            <th>Станция отъезда</th>
                            <th>Время приезда</th>
                            <th>Станция презда</th>
                            <th>Цена</th>
                            </tr>
                            <tr>
                    <td>{train.trainName}</td>
                    <td>{train.trainCode}</td>
                    <td>{train.departureStationDepartureDate}</td>
                    <td>{train.departureStationName}</td>
                    <td>{train.arrivalStationArrivalDate}</td>
                    <td>{train.arrivalStationName}</td>
                    <td>{train.price}</td>
                    <td></td>
                            </tr>
                        </table>
                    </div>
                ))}
                    
                    </div>
            })}
        </div>
    )
}

export default List