import { useState } from 'react';
import api from '../api/axios'; // a saját axios API konfigurációd
import { useNavigate } from 'react-router-dom';

const Registration = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();

    const payload = {
      name: name,
      email: email,
      password: password,
    };

    try {
      const res = await api.post('/auth/register', payload); // Backend regisztrációs végpontja

      // Ha sikeres a regisztráció, elmentjük a választ (pl. felhasználó adatai) a localStorage-ba
      localStorage.setItem('user', JSON.stringify(res.data));

      setError(''); // töröljük a hibát, ha sikeres a regisztráció

      // Navigálás a bejelentkezés oldalra
      navigate('/login');
    } catch (err) {
      setError('Sikertelen regisztráció: ' + err.response?.data?.message || 'Ismeretlen hiba');
    }
  };

  return (
    <div className="container">
      <h2 className="mt-4">Regisztráció</h2>
      <form onSubmit={handleRegister}>
        <div className="mb-3">
          <label className="form-label">Név</label>
          <input
            type="text"
            className="form-control"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>

        <div className="mb-3">
          <label className="form-label">Email cím</label>
          <input
            type="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <div className="mb-3">
          <label className="form-label">Jelszó</label>
          <input
            type="password"
            className="form-control"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>

        {error && <div className="alert alert-danger">{error}</div>}

        <button type="submit" className="btn btn-primary">Regisztráció</button>
      </form>
    </div>
  );
};

export default Registration;