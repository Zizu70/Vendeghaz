import { useState } from 'react';
import { register } from '../api/api';

const Register = () => {
    const [formData, setFormData] = useState({ username: '', email: '', password: '' });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const response = await register(formData.username, formData.email, formData.password);
        alert(response.message);
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="text" name="username" placeholder="Felhasználónév" onChange={handleChange} required />
            <input type="email" name="email" placeholder="E-mail" onChange={handleChange} required />
            <input type="password" name="password" placeholder="Jelszó" onChange={handleChange} required />
            <button type="submit">Regisztráció</button>
        </form>
    );
};

export default Register;