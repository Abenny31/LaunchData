import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Launches = () => {
    const [launches, setLaunches] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Pozivamo svoj .NET API
        axios.get('http://localhost:5000/api/SpaceXData') // URL tvoje .NET API aplikacije
            .then((response) => {
                setLaunches(response.data); // Podaci dolaze iz API-a
                setLoading(false); // Postavljamo loading na false
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
                setLoading(false);
            });
    }, []); // Prazan array znaèi da useEffect pokreæe samo jednom kad se komponenta uèita

    if (loading) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h1>SpaceX Launches</h1>
            <ul>
                {launches.map((launch) => (
                    <li key={launch.id}>
                        {launch.name} - {launch.date}
                    </li>
                ))}
            </ul>
        </div>
    ); 
};

export default Launches;
