/*
import { useState } from 'react';
import { login } from '../api/api';

const Login = () => {
    const [formData, setFormData] = useState({ email: '', password: '' });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const response = await login(formData.email, formData.password);
        alert(response.message);
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="email" name="email" placeholder="E-mail" onChange={handleChange} required />
            <input type="password" name="password" placeholder="Jelszó" onChange={handleChange} required />
            <button type="submit">Bejelentkezés</button>
        </form>
    );
};

export default Login;
*/