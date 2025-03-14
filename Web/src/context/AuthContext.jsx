import { createContext, useEffect, useState } from "react";
import PropTypes from "prop-types";

export const AuthContext = createContext();

export function AuthProvider(props) {
  const apiUrl = "http://localhost:3000/api";
  const { children } = props;
  const [authToken, setAuthToken] = useState(null);
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      setAuthToken(token);
    }
  }, []);

  useEffect(() => {
    const loadUserData = async () => {
      const url = apiUrl + "/user";
      const response = await fetch(url, {
        method: "GET",
        headers: {
          Accept: "application/json",
          Authorization: "Bearer " + authToken,
        },
      });
      const data = await response.json();
      if (response.ok) {
        setUser(data);
      } else if (response.status == 401) {
        localStorage.removeItem("token");
        setAuthToken(null);
      }
    };

    if (authToken) {
      loadUserData();
    } else {
      setUser(null);
    }
  }, [authToken]);

  

  
  

  const authObj = {
    authToken: authToken,
    user: user,
    error: error,
    register: async (email, password, name, address, phone, role) => {
      const url = apiUrl + "/register";
      const registerDTO = {
        email: email,
        password: password,
        name: name,
        address: address,
        phone: phone,
        role: role,
      };
      const response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(registerDTO),
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
      const data = await response.json();
      if (response.ok) {
        setError(null);
        return true;
      } else {
        console.error(data);
        setError(data.message);
        return false;
      }
    },
    updateUser:  async (name, address, phone, email) => {
      const url = apiUrl + "/users/" + user.id + "/profile";
      const userDTO = {
        name: name,
        address: address,
        phone: phone,
        email: email,
      };
      const response = await fetch(url, {
        method: "PUT",
        body: JSON.stringify(userDTO),
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + authToken,
        },
      });
      const data = await response.json();
      if (response.ok) {
        setUser(data);
        setError(null);
      } else {
        console.error(data);
        setError(data.message);
      }
      return response;
    },
    deleteUser: async () => {
      const url = apiUrl + "/users/" + user.id;
      const response = await fetch(url, {
        method: "DELETE",
        headers: {
          Accept: "application/json",
          Authorization: "Bearer " + authToken,
        },
      });
      if (response.ok) {
        setUser(null);
        setError(null);
      } else {
        const data = await response.json();
        console.error(data);
        setError(data.message);
      }
    },
      changePassword: async (oldPassword, newPassword) => {
        const url = apiUrl + "/users/" + user.id + "/password";
        const passwordDTO = {
          oldPassword: oldPassword,
          newPassword: newPassword,
        };
        const response = await fetch(url, {
          method: "PUT",
          body: JSON.stringify(passwordDTO),
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: "Bearer " + authToken,
          },
        });
        const data = await response.json();
        if (response.ok) {
          setError(null);
        } else {
          console.error(data);
          setError(data.message);
        }
        return response;
      },
    login: async (email, password) => {
      const url = apiUrl + "/login";
      // DTO - Data Transfer Object - Laravel "Request" objektumnak felel meg.
      const loginDTO = {
        email: email,
        password: password,
      };
      const response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(loginDTO),
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
      const data = await response.json();
      if (response.ok) {
        const token = data.token;
        localStorage.setItem("token", token);
        setAuthToken(token);
        setError(null);
      } else {
        console.error(data);
        setError(data.message);
      }
    },
    logout: async () => {
      const url = apiUrl + "/logout";
      const response = await fetch(url, {
        method: "POST",
        headers: {
          Accept: "application/json",
          Authorization: "Bearer " + authToken,
        },
      });
      if (response.ok || response.status == 401) {
        localStorage.removeItem("token");
        setAuthToken(null);
        setError(null);
      } else {
        const data = await response.json();
        console.error(data);
        setError(data.message);
      }
    },
    logoutEverywhere: async () => {
      const url = apiUrl + "/logout-everywhere";
      const response = await fetch(url, {
        method: "POST",
        headers: {
          Accept: "application/json",
          Authorization: "Bearer " + authToken,
        },
      });
      if (response.ok || response.status == 401) {
        localStorage.removeItem("token");
        setAuthToken(null);
        setError(null);
      } else {
        const data = await response.json();
        console.error(data);
        setError(data.message);
      }
    },
    
  };

  return (
    <AuthContext.Provider value={authObj}>{children}</AuthContext.Provider>
  );
}

AuthProvider.propTypes = {
  children: PropTypes.node,
};
