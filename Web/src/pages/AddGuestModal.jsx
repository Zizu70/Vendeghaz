import { useState } from 'react';
import api from '../api/axios';
import { Modal, Button, Form } from 'react-bootstrap';

const AddGuestModal = ({ onGuestAdded }) => {
    const [show, setShow] = useState(false);
    const [formData, setFormData] = useState({
        g_name: '',
        g_species: '',
        g_gender: '',
        g_birthdate: '',
        g_indate: '',
        g_inplace: '',
        g_other: '',
        g_image: null
    });

    const user = JSON.parse(localStorage.getItem('user'));

    const handleChange = (e) => {
        const { name, value, files } = e.target;
        setFormData({
            ...formData,
            [name]: files ? files[0] : value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const data = new FormData();
        for (let key in formData) data.append(key, formData[key]);

        try {
            await api.post('/guests', data, {
                headers: { 'Content-Type': 'multipart/form-data' }
            });
            alert('Állat rögzítve!');
            setShow(false);
            setFormData({ g_name: '', g_species: '', g_gender: '', g_birthdate: '', g_indate: '', g_inplace: '', g_other: '', g_image: null });
            onGuestAdded();
        } catch (err) {
            console.error(err);
            alert('Hiba az állat rögzítésekor.');
        }
    };

    if (user?.role !== 'admin') return null;

    return (
        <div className="mb-3">
            <Button variant="primary" onClick={() => setShow(true)}>
                Új állat rögzítése
            </Button>

            <Modal show={show} onHide={() => setShow(false)} size="lg">
                <Form onSubmit={handleSubmit} encType="multipart/form-data">
                    <Modal.Header closeButton>
                        <Modal.Title>Új állat rögzítése</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form.Group className="mb-2">
                            <Form.Label>Név</Form.Label>
                            <Form.Control name="g_name" required onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Faj</Form.Label>
                            <Form.Control name="g_species" required onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Nem</Form.Label>
                            <Form.Select name="g_gender" required onChange={handleChange}>
                                <option value="">Válassz nemet</option>
                                <option value="hím">Hím</option>
                                <option value="nőstény">Nőstény</option>
                                <option value="ivartalanított">Ivartalanított</option>
                            </Form.Select>
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Születés dátuma</Form.Label>
                            <Form.Control type="date" name="g_birthdate" required onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Beérkezés dátuma</Form.Label>
                            <Form.Control type="date" name="g_indate" required onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Honnan jött</Form.Label>
                            <Form.Control name="g_inplace" required onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Megjegyzés</Form.Label>
                            <Form.Control as="textarea" name="g_other" rows={2} onChange={handleChange} />
                        </Form.Group>

                        <Form.Group className="mb-2">
                            <Form.Label>Kép (opcionális)</Form.Label>
                            <Form.Control type="file" name="g_image" accept="image/*" onChange={handleChange} />
                        </Form.Group>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={() => setShow(false)}>Mégse</Button>
                        <Button type="submit" variant="success">Rögzítés</Button>
                    </Modal.Footer>
                </Form>
            </Modal>
        </div>
    );
};

export default AddGuestModal;
