import React, { useRef } from 'react';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { Input } from 'reactstrap';
function CarList() {
    const [cars, setCars] = useState();
    const [current, setCurrent] = useState({ id: 0 });
    const [ordered, setOrdered] = useState(false);

    useEffect(() => {
        populateCarData();
    }, []);

    function Update(id) {
        const item = cars.find(c => c.id == id);
        setCurrent(item);
    }

    function OrderByYear() {
        if (ordered) {
            const list = [...cars].sort((a, b) => a.year - b.year);
            setCars(list);
            setOrdered(false);
        }
        else {
            const list = [...cars].sort((a, b) => b.year - a.year);
            setCars(list);
            setOrdered(true);
        }
    }
    function SubmitUpdate() {
        axios.put('car',current)
            .then(response => {
                populateCarData();
                console.log(response);
            })
            .catch(error => {
                console.log(error);
            });

        setCurrent({ id: 0 });
    }
    function DeleteCar(id) {
        axios.delete('car\\' + id)
            .then(response => {
                populateCarData();
            })
            .catch(error => {
                console.log(error);
            });
        //const response = await fetch('car');
        //const data = await response.json();
        //setCars(data);
    }

    const contents = cars === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Brand</th>
                    <th>Model</th>
                    <th>Year</th>
                    <th>Engine Volume</th>
                    <th>Color</th>
                    <th>Distance</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {cars.map(d =>
                    current.id != d.id ?
                        < tr key={d.id} >

                            <td>{d.brand}
                            </td>
                            <td>{d.model}</td>
                            <td>{d.year}</td>
                            <td>{d.engineVolume}</td>
                            <td>{d.color}</td>
                            <td>{d.distance}</td>


                            <td >
                                <button className='btn btn-warning' onClick={() => { DeleteCar(d.id); }}>Delete</button>
                            </td>
                            <td >
                                <button className='btn btn-info' onClick={() => { Update(d.id); }}>Update</button>
                            </td>
                        </tr>
                        : < tr key={d.id} >

                            <td> <Input value={current.brand} onChange={(e) => {
                                setCurrent({ ...current, 
                                    brand: e.target.value
                                })
                            }} />
                            </td>


                            <td><Input value={current.model} onChange={(e) => {
                                setCurrent({
                                    ...current,
                                    model: e.target.value
                                })
                            }}  />
                            </td>

                            <td><Input value={current.year} onChange={(e) => {
                                setCurrent({
                                    ...current,
                                    year: e.target.value
                                })
                            }} /></td>


                            <td><Input value={current.engineVolume} onChange={(e) => {
                                setCurrent({
                                    ...current,
                                    engineVolume: e.target.value
                                })
                            }} /></td>


                            <td><Input value={current.color} onChange={(e) => {
                                setCurrent({
                                    ...current,
                                    color: e.target.value
                                })
                            }} /></td>


                            <td><Input value={current.distance} onChange={(e) => {
                                setCurrent({
                                    ...current,
                                    distance: e.target.value
                                })
                            }} /></td>


                            <td >
                                <button className='btn btn-warning' onClick={() => { DeleteCar(d.id); }}>Delete</button>
                            </td>
                            <td >
                                <button className='btn btn-info mx-3' onClick={() => { SubmitUpdate(); }}>Submit</button>

                            </td>
                        </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Car List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <button className='btn btn-outline-success' onClick={OrderByYear} >Order By Year</button>
            {current.id != 0 &&
                (<section >
                    <h2>Current Car</h2>
                    <h2 style={{ color: "springgreen", fontSize: "3em" }}>{current.brand} - {current.model}</h2>
                </section>)}
            {contents}
        </div>
    );

    async function populateCarData() {
        const response = await fetch('car');
        const data = await response.json();
        setCars(data);
        console.log(data);
    }
}

export default CarList;