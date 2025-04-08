import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Modal from './Modal';

const Launches = () => {
    const [launches, setLaunches] = useState([]);
    const [filteredLaunches, setFilteredLaunches] = useState([]);
    const [loading, setLoading] = useState(true);
    const [selectedLaunch, setSelectedLaunch] = useState(null);
    //paginacija
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 20;
    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentItems = filteredLaunches.slice(indexOfFirstItem, indexOfLastItem);
    const totalPages = Math.ceil(filteredLaunches.length / itemsPerPage);

    //sortiranje 
    const [sortCriteria, setSortCriteria] = useState('date');
    const [sortOrder, setSortOrder] = useState('asc');

    const sortedLaunches = [...filteredLaunches].sort((a, b) => {

        const aValue = sortCriteria === 'date' ? new Date(a.date_utc) : a[sortCriteria];
        const bValue = sortCriteria === 'date' ? new Date(b.date_utc) : b[sortCriteria];

        if (sortOrder === 'asc') {
            return aValue > bValue ? 1 : -1;
        } else {
            return aValue < bValue ? 1 : -1;
        }

    });

    const [favorites, setFavorites] = useState(() => {

        const savedFavorites = sessionStorage.getItem('favorites');

        return savedFavorites ? JSON.parse(savedFavorites) : [];

    });
    //filteri
    const [year, setYear] = useState('');
    const [name, setName] = useState('');
    const [flightNumber, setFlightNumber] = useState('');
    const [showFavorites, setShowFavorites] = useState(false);

    //omiljeni



    const toggleFavorite = (launch) => {
        const isFavorite = favorites.some(fav => fav.id === launch.id);
        let updatedFavorites;

        if (isFavorite) {
            updatedFavorites = favorites.filter(fav => fav.id !== launch.id);
        } else {
            updatedFavorites = [...favorites, launch];
        }

        setFavorites(updatedFavorites);
        sessionStorage.setItem('favorites', JSON.stringify(updatedFavorites));
    };

    const isFavorite = (launch) => favorites.some(fav => fav.id === launch.id);


    useEffect(() => {
        axios.get('https://localhost:7068/api/SpaceXData/getData')
            .then((response) => {
                console.log('GET DATA response:', 'been there');
                setLaunches(response.data);
                setFilteredLaunches(response.data);
                setLoading(false);
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
                setLoading(false);
            });
    }, []);

    useEffect(() => {
        let filtered = launches;

        if (year) {
            filtered = filtered.filter(l => new Date(l.date_utc).getFullYear() === parseInt(year));
        }

        if (name) {
            filtered = filtered.filter(l => l.name.toLowerCase().includes(name.toLowerCase()));
        }

        if (flightNumber) {
            filtered = filtered.filter(l => l.flightNumber?.toString() === flightNumber);
        }
        if (showFavorites) {

            filtered = filtered.filter(l => favorites.some(fav => fav.id === l.id));

        }

        setFilteredLaunches(filtered);
    }, [year, name, flightNumber, launches, showFavorites, favorites]);

    if (loading) {
        return <p>Loading...</p>;
    }


    return (
        <div>
            <h1>SpaceX Launches</h1>

            {/* Filteri */}
            <div style={{ marginBottom: '1rem', display: 'flex', gap: '1rem' }}>
                <input
                    type="number"
                    value={year}
                    onChange={(e) => setYear(e.target.value)}
                    placeholder="Filter by Year"
                />
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    placeholder="Filter by Name"
                />
                <input
                    type="number"
                    value={flightNumber}
                    onChange={(e) => setFlightNumber(e.target.value)}
                    placeholder="Filter by Flight Number"
                />
                <button onClick={() => {
                    setYear('');
                    setName('');
                    setFlightNumber('');
                    setShowFavorites(false);
                }}>Clear Filters</button>
            </div>
            <div>

                <label>
                    <input
                        type="checkbox"
                        checked={showFavorites}
                        onChange={() => setShowFavorites(!showFavorites)}
                    />
                    Prikaži samo omiljene
                </label>
            </div>
            {/* Opcije za sortiranje */}
            <div style={{ marginBottom: '1rem' }}>
                <label>
                    Sortiraj po:
                    <select onChange={(e) => setSortCriteria(e.target.value)}>
                        <option value="date">Datum</option>
                        <option value="name">Naziv</option>
                        <option value="flight_number">Broj leta</option>
                    </select>
                </label>
                <label>
                    Redoslijed:
                    <select onChange={(e) => setSortOrder(e.target.value)}>
                        <option value="asc">Rastuće</option>
                        <option value="desc">Opadajuće</option>
                    </select>
                </label>
            </div>
            {/* Tablica */}
            <table border="1" cellPadding="8" cellSpacing="0" style={{ width: '100%', textAlign: 'left' }}>
                <thead>
                    <tr>
                        <th>Flight #</th>
                        <th>Name</th>
                        <th>Date (UTC)</th>
                        <th>Success</th>
                        <th>Details</th>
                        <th>Payloads</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {filteredLaunches.map((launch) => (
                        <tr key={launch.id}>
                            <td>{launch.flight_number}</td>
                            <td>{launch.name}</td>
                            <td>{launch.date_utc ? new Date(launch.date_utc).toLocaleDateString() : 'N/A'}</td>
                            <td>
                                {launch.success === true ? '✅' :
                                    launch.success === false ? '❌' : '⏳'}
                            </td>
                            <td>
                                {launch.details
                                    ? launch.details.slice(0, 80) + (launch.details.length > 80 ? '...' : '')
                                    : 'N/A'}
                            </td>
                            <td>
                                {launch.payloadIds && launch.payloadIds.length > 0
                                    ? launch.payloadIds.join(', ')
                                    : 'N/A'}
                            </td>
                            <td>
                                <button
                                    onClick={() => setSelectedLaunch(launch)}
                                    style={{
                                        padding: '6px 12px',
                                        border: '1px solid #007BFF',
                                        borderRadius: '4px',
                                        backgroundColor: 'white',
                                        color: '#007BFF',
                                        cursor: 'pointer',
                                        fontWeight: 'bold'
                                    }}
                                    onMouseOver={(e) => e.currentTarget.style.backgroundColor = '#e6f0ff'}
                                    onMouseOut={(e) => e.currentTarget.style.backgroundColor = 'white'}
                                >
                                    Detalji
                                </button>
                                <button onClick={() => toggleFavorite(launch)}
                                    style={{
                                        padding: '6px 12px',
                                        border: '1px solid #007BFF',
                                        borderRadius: '4px',
                                        backgroundColor: 'white',
                                        color: '#007BFF',
                                        cursor: 'pointer',
                                        fontWeight: 'bold'
                                    }}
                                    onMouseOver={(e) => e.currentTarget.style.backgroundColor = '#e6f0ff'}
                                    onMouseOut={(e) => e.currentTarget.style.backgroundColor = 'white'}>

                                    {isFavorite(launch) ? 'Ukloni iz omiljenih' : 'Dodaj u omiljene'}

                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div>
                {Array.from({ length: totalPages }, (_, index) => (
                    <button key={index} onClick={() => setCurrentPage(index + 1)}>
                        {index + 1}
                    </button>
                ))}
            </div>
            <Modal isOpen={selectedLaunch !== null} onClose={() => setSelectedLaunch(null)}>
                {selectedLaunch && (
                    <div>
                        <h2>{selectedLaunch.name}</h2>
                        <p><strong>Flight #: </strong>{selectedLaunch.flightNumber}</p>
                        <p><strong>Date (UTC): </strong>{new Date(selectedLaunch.dateUtc).toLocaleString()}</p>
                        <p><strong>Success: </strong>{
                            selectedLaunch.success === true ? 'Yes' :
                                selectedLaunch.success === false ? 'No' : 'Pending'
                        }</p>
                        <p><strong>Details: </strong>{selectedLaunch.details || 'N/A'}</p>
                        <p><strong>Payloads: </strong>{selectedLaunch.payloadIds?.join(', ') || 'N/A'}</p>
                        {/* Dodaj još što želiš */}
                    </div>
                )}
            </Modal>

        </div>
    );
};


export default Launches;
