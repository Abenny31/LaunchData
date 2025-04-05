import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Launches = () => {
    const [launches, setLaunches] = useState([]);
    const [loading, setLoading] = useState(true);
    const [year, setYear] = useState('');

    useEffect(() => {
        axios.get('https://localhost:7068/api/SpaceXData/getData')
            .then((response) => {
                console.log('GET DATA response:', 'been there');
                setLaunches(response.data);
                setLoading(false);
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
                setLoading(false);
            });
    }, []);

    const handleSearch = () => {
        if (!year) return;

        setLoading(true);
        axios.get(`https://localhost:7068/api/SpaceXData/filter?year=${year}`)
            .then((response) => {
                setLaunches(response.data);
                setLoading(false);
            })
            .catch((error) => {
                console.error(error);
                setLoading(false);
            });
    };

    if (loading) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h1>SpaceX Launches</h1>

            <input
                type="number"
                value={year}
                onChange={(e) => setYear(e.target.value)}
                placeholder="Enter Year"
            />
            <button onClick={handleSearch}>Search</button>

            <ul>
                {launches.map((launch) => (
                    <li key={launch.id}>
                        <h3>{launch.name}</h3>
                        <p>{launch.dateUtc || launch.date}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Launches;
