import { useState } from 'react';
import api from '../api/axios';
import { useNavigate } from 'react-router-dom';

const AddGuest = () => {
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
  const navigate = useNavigate();

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
      navigate('/guests');
    } catch (err) {
      console.error(err);
      alert('Hiba a rögzítés során.');
    }
  };

  return (
    <div className="container">
      <h2>Új állat rögzítése</h2>
      <form onSubmit={handleSubmit} encType="multipart/form-data">
        <input name="g_name" placeholder="Név" className="form-control mb-2" onChange={handleChange} required />
        <input name="g_species" placeholder="Faj" className="form-control mb-2" onChange={handleChange} required />
        <select name="g_gender" className="form-select mb-2" onChange={handleChange} required>
          <option value="">Nem</option>
          <option value="hím">Hím</option>
          <option value="nőstény">Nőstény</option>
          <option value="ivartalanított">Ivartalanított</option>
        </select>
        <input type="date" name="g_birthdate" className="form-control mb-2" onChange={handleChange} required />
        <input type="date" name="g_indate" className="form-control mb-2" onChange={handleChange} required />
        <input name="g_inplace" placeholder="Honnan került be" className="form-control mb-2" onChange={handleChange} required />
        <textarea name="g_other" placeholder="Egyéb megjegyzés" className="form-control mb-2" onChange={handleChange} />
        <input type="file" name="g_image" className="form-control mb-2" accept="image/*" onChange={handleChange} />
        <button className="btn btn-success">Rögzítés</button>
      </form>
    </div>
  );
};

export default AddGuest;
