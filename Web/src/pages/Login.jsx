import { useState } from 'react';
import api from '../api/axios';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [emailOrName, setEmailOrName] = useState('');
  const [password, setPassword] = useState('');
  const [isWorker, setIsWorker] = useState(false);
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    const endpoint = isWorker ? '/auth/worker-login' : '/auth/user-login';
    const payload = isWorker
      ? { w_name: emailOrName, w_password: password }
      : { u_email: emailOrName, u_password: password };

    try {
      const res = await api.post(endpoint, payload);
      localStorage.setItem('user', JSON.stringify(res.data));
      window.dispatchEvent(new Event('loginChange'));
      setError(''); // töröljük a hibát, ha sikeres a bejelentkezés
      // navigálás a főoldalra vagy a dashboard-ra
      navigate('/'); // vagy külön dashboard
    } catch (err) {
      setError('Sikertelen belépés: ' + err.response?.data?.message || 'Ismeretlen hiba');
    }
  };

  return (
    <div className="container">
      <h2 className="mt-4">Bejelentkezés</h2>
      <form onSubmit={handleLogin}>
        <div className="form-check mb-2">
          <input className="form-check-input" type="checkbox" id="workerCheck" checked={isWorker} onChange={() => setIsWorker(!isWorker)} />
          <label className="form-check-label" htmlFor="workerCheck">Dolgozó vagyok</label>
        </div>

        <div className="mb-3">
          <label className="form-label">{isWorker ? 'Felhasználónév' : 'Email cím'}</label>
          <input
            type="text"
            className="form-control"
            value={emailOrName}
            onChange={(e) => setEmailOrName(e.target.value)}
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

        <button type="submit" className="btn btn-primary">Belépés</button>
      </form>
    </div>
  );
};

export default Login;
