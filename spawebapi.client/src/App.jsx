import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);

    const contents = forecasts === undefined
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
                </tr>
            </thead>
            <tbody>
                {forecasts.map(d =>
                    <tr key={d.id}>
                        <td>{d.brand}</td>
                        <td>{d.model}</td>
                        <td>{d.year}</td>
                        <td>{d.engineVolume}</td>
                        <td>{d.color}</td>
                        <td>{d.distance}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
        console.log(data);
    }
}

export default App;