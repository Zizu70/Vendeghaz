import { useEffect, useState } from 'react';
import api from '../api/axios';
import { Modal, Button, Form } from 'react-bootstrap';

const Tickets = () => {
  const [tickets, setTickets] = useState([]);
  const [show, setShow] = useState(false);
  const [formData, setFormData] = useState({
    t_date: '',
    t_time: '',
    t_piece: 1
  });

  const user = JSON.parse(localStorage.getItem('user'));
  const formatter = new Intl.NumberFormat('hu-HU', {
    style: 'decimal',
    useGrouping: true,
    maximumFractionDigits: 0
  });

  useEffect(() => {
    fetchTickets();
  }, []);

  const fetchTickets = async () => {
    try {
      const res = await api.get('/tickets');
      setTickets(res.data);
    } catch (err) {
      console.error(err);
    }
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!user?.user?.u_id) return alert('Jelentkezz be a vásárláshoz.');

    const pricePerTicket = 1500;
    const totalAmount = formData.t_piece * pricePerTicket;

    try {
      await api.post('/tickets', {
        ...formData,
        t_piece: Number(formData.t_piece),
        t_amount: totalAmount,
        u_id: user.user.u_id
      });
      alert('Jegyvásárlás sikeres!');
      setFormData({ t_date: '', t_time: '', t_piece: 1 });
      setShow(false);
      fetchTickets();
    } catch (err) {
      console.error(err);
      if (err.response?.status === 400) {
        alert('Hiba: A kiválasztott időpont már foglalt!');
      } else if (err.response?.status === 500) {
        alert('Hiba: Kérjük, próbálja újra később.');
      } else {
        alert('Hiba a jegyvásárlás során.');
      }
    }
  };

  return (
    <div>
      <h2>Jegyvásárlások</h2>

      {user?.role === 'user' && (
        <Button className="mb-3" variant="success" onClick={() => setShow(true)}>
          Vásárolok jegyet
        </Button>
      )}

      <Modal show={show} onHide={() => setShow(false)}>
        <Form onSubmit={handleSubmit}>
          <Modal.Header closeButton>
            <Modal.Title>Jegyvásárlás</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Form.Group className="mb-3">
              <Form.Label>Dátum</Form.Label>
              <Form.Control type="date" name="t_date" required onChange={handleInputChange} />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Időpont</Form.Label>
              <Form.Select name="t_time" required onChange={handleInputChange}>
                <option value="">Válassz időpontot</option>
                <option value="de_9_óra">Délelőtt 9</option>
                <option value="de_10_óra">Délelőtt 10</option>
                <option value="de_11_óra">Délelőtt 11</option>
                <option value="du_13_óra">Délután 13</option>
                <option value="du_15_óra">Délután 15</option>
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Darabszám</Form.Label>
              <Form.Control type="number" name="t_piece" min="1" required value={formData.t_piece} onChange={handleInputChange} />
            </Form.Group>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={() => setShow(false)}>
              Mégse
            </Button>
            <Button variant="primary" type="submit">
              Jegyet veszek
            </Button>
          </Modal.Footer>
        </Form>
      </Modal>

      <table className="table table-sm">
        <thead>
          <tr>
            <th>ID</th>
            <th>Dátum</th>
            <th>Időpont</th>
            <th>Darab</th>
            <th>Összeg (Ft)</th>
          </tr>
        </thead>
        <tbody>
          {tickets.map(t => (
            <tr key={t.t_id}>
              <td>{t.t_id}</td>
              <td>{new Date(t.t_date).toLocaleDateString('hu-HU')}</td>
              <td>{t.t_time}</td>
              <td>{t.t_piece}</td>
              <td>{formatter.format(t.t_amount)} Ft</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Tickets;
