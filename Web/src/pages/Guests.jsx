import { useEffect, useState } from 'react';
import api from '../api/axios';
import { Modal, Button } from 'react-bootstrap';
import AddGuestModal from '../pages/AddGuestModal'; // vagy a megfelelő útvonalon
const Guests = () => {
  const [guests, setGuests] = useState([]);
  const [selectedGuest, setSelectedGuest] = useState(null);
  const [adopted, setAdopted] = useState(false);

  const user = JSON.parse(localStorage.getItem('user'));

  const fetchGuests = async () => {
    try {
      const res = await api.get('/guests');
      setGuests(res.data);
    } catch (err) {
      console.error(err);
    }
  };

  const checkAdoption = async (guest) => {
    if (!user?.user?.u_id) {
      setAdopted(false);
      return;
    }

    try {
      const res = await api.get('/adoption/check', {
        params: { u_id: user.user.u_id, g_id: guest.g_id }
      });
      console.log('Adoption check response:', res.data);
      setAdopted(res.data.adopted);
    } catch (err) {
      console.error('Adoption check error:', err);
      setAdopted(false);
    }
  };



  useEffect(() => {
    fetchGuests();
  }, []);

  const handleSelect = async (guest) => {
    setSelectedGuest(guest);
    await checkAdoption(guest);
  };

  const handleAdopt = async () => {
    try {
      await api.post('/adoption', {
        g_id: selectedGuest.g_id,
        u_id: user.user.u_id
      });
      alert('Örökbefogadás sikeres!');
      setAdopted(true);
    } catch (err) {
      console.error('Adoption error:', err);
      alert('Hiba az örökbefogadásnál.');
    }
  };

  const handleUndo = async () => {
    try {
      await api.delete('/adoption', {
        data: {
          g_id: selectedGuest.g_id,
          u_id: user.user.u_id
        }
      });
      alert('Örökbefogadás visszavonva!');
      setAdopted(false);
    } catch (err) {
      console.error('Undo adoption error:', err);
      alert('Nem sikerült visszavonni.');
    }
  };

  return (
    <div>
      <h2>Állatok</h2>
      <AddGuestModal onGuestAdded={fetchGuests} />

      <p>Kattintson a "Megnézem" gombra az állat részletes adatainak megtekintéséhez.</p>
      <p>Az örökbefogadott állatoknál a "Örökbe fogadom" gomb helyett a "Örökbefogadás visszavonása" gomb jelenik meg.</p>
      <table className="table table-striped table-hover">
        <thead>
          <tr>
            <th>Kép</th>
            <th>Név</th>
            <th>Faj</th>
            <th>Nem</th>
            <th>Születés</th>
            <th>Részletek</th>
          </tr>
        </thead>
        <tbody>
          {guests.map(g => (
            <tr key={g.g_id}>
              <td>
                {g.g_image && (
                  <img
                    src={`http://localhost:3000/api/guests/images/${g.g_image}`}
                    alt={g.g_name}
                    width="80"
                    height="80"
                    style={{ objectFit: 'cover' }}
                  />
                )}
              </td>
              <td>{g.g_name}</td>
              <td>{g.g_species}</td>
              <td>{g.g_gender}</td>
              <td>{new Date(g.g_birthdate).toLocaleDateString('hu-HU')}</td>
              <td>
                <button
                  className="btn btn-sm btn-info"
                  data-bs-toggle="modal"
                  data-bs-target="#guestModal"
                  onClick={() => handleSelect(g)}
                >
                  Megnézem
                </button>

              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* MODÁLIS ABLAK */}
      <Modal show={selectedGuest !== null} onHide={() => setSelectedGuest(null)}>
        <Modal.Header closeButton>
          <Modal.Title>{selectedGuest?.g_name} fontosabb adatai</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {selectedGuest?.g_image && (
            <img
              src={`http://localhost:3000/api/guests/images/${selectedGuest.g_image}`}
              alt={selectedGuest.g_name}
              className="img-fluid mb-3"
            />
          )}
          <ul className="list-group">
            <li className="list-group-item"><strong>Faj:</strong> {selectedGuest?.g_species}</li>
            <li className="list-group-item"><strong>Nem:</strong> {selectedGuest?.g_gender}</li>
            <li className="list-group-item"><strong>Születés:</strong> {new Date(selectedGuest?.g_birthdate).toLocaleDateString('hu-HU')}</li>
            <li className="list-group-item"><strong>Érkezés:</strong> {new Date(selectedGuest?.g_indate).toLocaleDateString('hu-HU')}</li>
            <li className="list-group-item"><strong>Honnan jött:</strong> {selectedGuest?.g_inplace}</li>
            {selectedGuest?.g_other && (
              <li className="list-group-item"><strong>Megjegyzés:</strong> {selectedGuest.g_other}</li>
            )}
          </ul>
        </Modal.Body>
        <Modal.Footer>
          <button className="btn btn-secondary" data-bs-dismiss="modal">Visszalépés</button>

          {!adopted ? (
            <button className="btn btn-success" onClick={handleAdopt}>Örökbe fogadom</button>
          ) : (
            <button className="btn btn-outline-danger" onClick={handleUndo}>Örökbefogadás visszavonása</button>
          )}
        </Modal.Footer>
      </Modal>
    </div>
    
  );
};

export default Guests;
