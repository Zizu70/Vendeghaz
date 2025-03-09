/*
const API_URL = 'http://localhost:3000/api'; // Backend címe

//*****Regisztráció API hívás*****
export const register = async (username, email, password) => {
    const response = await fetch(`${API_URL}/register`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, email, password })
    });
    return response.json();
};

// **Bejelentkezés API hívás**
export const login = async (email, password) => {
    const response = await fetch(`${API_URL}/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });
    const data = await response.json();

    if (data.token) {
        localStorage.setItem('token', data.token); // Token mentése
    }

    return data;
};

//*****Felhasználói adatok frissítése*****
export const updateUser = async (id, userData) => { //userData ?
    const response = await fetch(`${API_URL}/update/${id}`, {
        method: 'PUT',
        headers: { 
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}` // Hitelesítés
        },
        body: JSON.stringify(userData)
    });
    return response.json();
};

//*****Felhasználó törlése*****
export const deleteUser = async (id) => {
    const response = await fetch(`${API_URL}/delete/${id}`, {
        method: 'DELETE',
        headers: { 
            'Authorization': `Bearer ${localStorage.getItem('token')}` 
        }
    });
    return response.json();
};

*/