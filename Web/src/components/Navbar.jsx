import { useEffect, useState } from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faPaw, faHeart, faTicketAlt,
  faSignInAlt, faUserPlus, faInfoCircle, faSignOutAlt
} from '@fortawesome/free-solid-svg-icons';


const Navbar = () => {
  const [user, setUser] = useState(() => JSON.parse(localStorage.getItem('user')));

  const navigate = useNavigate();

  useEffect(() => {
    const handleLoginChange = () => {
      setUser(JSON.parse(localStorage.getItem('user')));
    };

    window.addEventListener('loginChange', handleLoginChange);
    return () => window.removeEventListener('loginChange', handleLoginChange);
  }, []);

  const handleLogout = () => {
    localStorage.removeItem('user');
    window.dispatchEvent(new Event('loginChange'));
    navigate('/');
  };
  
  


  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark px-4">
      <div className="container-fluid">
        <button 
          className="navbar-toggler" 
          type="button" 
          data-bs-toggle="collapse" 
          data-bs-target="#navbarNav"
          aria-controls="navbarNav" 
          aria-expanded="false" 
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
          <li className="nav-item">
              <NavLink className="nav-link" to="/about">
                <FontAwesomeIcon icon={faInfoCircle} className="me-2" />
                Rólunk
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/guests">
                <FontAwesomeIcon icon={faPaw} className="me-2" />
                Vendégeink
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/adoptions">
                <FontAwesomeIcon icon={faHeart} className="me-2" />
                Örökbefogadások
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/tickets">
                <FontAwesomeIcon icon={faTicketAlt} className="me-2" />
                Jegyek
              </NavLink>
            </li>           

            {!user && (
              <>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/login">
                    <FontAwesomeIcon icon={faSignInAlt} className="me-2" />
                    Bejelentkezés
                  </NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/register">
                    <FontAwesomeIcon icon={faUserPlus} className="me-2" />
                    Regisztráció
                  </NavLink>
                </li>
              </>
            )}

            {user && (
              <li className="nav-item">
                <NavLink className="nav-link" to="#" onClick={handleLogout}>
                  <FontAwesomeIcon icon={faSignOutAlt} className="me-2" />
                  Kilépés ({user.user.u_name || user.user.w_name})
                </NavLink>
              </li>
            )}

          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;