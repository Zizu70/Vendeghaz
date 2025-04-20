import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import Navbar from './components/Navbar';
import Footer from './components/Footer';

import Home from './pages/Home';
import Guests from './pages/Guests';
import Adoptions from './pages/Adoptions';
import Tickets from './pages/Tickets';
import Login from './pages/Login';
import Register from './pages/Registration';
import About from './pages/About';
import './App.css';

function App() {
  return (
    <Router>
      <Header />
      <Navbar />
      <main className="container my-4">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/guests" element={<Guests />} />
          <Route path="/adoptions" element={<Adoptions />} />
          <Route path="/tickets" element={<Tickets />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/about" element={<About />} />
          <Route path="*" element={<h2>404 - Page Not Found</h2>} />
        </Routes>
      </main>
      <Footer />
    </Router>
  );
}
export default App;
