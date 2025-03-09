import "./App.css";
import "bootstrap/dist/css/bootstrap.css";  /* npm install react - bootstrap@5 */
import "bootstrap/dist/js/bootstrap.bundle";  /*npm install react-bootstrap */

import { RouterProvider, createBrowserRouter } from "react-router-dom";   /*npm install react-router-dom */
import { AuthProvider } from "./context/AuthContext";
import Layout from "./components/Layout";
import UserProfilePage from "./website/UserProfilePage";

import HomeSite from "./website/HomeSite"; //
import UserSite from "./website/UserSite";  //
import GuestsSite from "./website/GuestsSite"; //
import AdoptSite from "./website/AdoptSite"; //
import ContactSite from "./website/ContactSite"; //
import IndividualSite from "./website/IndividualSite"; //

/*
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './components/Register';
import Login from './components/Login';
*/

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout/>,
      children: [
        {
          path: "/",
          element: <HomeSite/>, //
        },
        
        {
          path: "/user",
          element: <UserSite/>, 
        },
      
        {
          path: "/adopt",
          element: <AdoptSite/>,  
        },

        {
          path: "/guests",
          element: <GuestsSite/>, 
        },

        {
          path: "/individual",
          element: <IndividualSite/>, 
        },
       
        {
          path: "/contact",
          element: <ContactSite />,
        },

        {
          path: "/contact",
          element: <ContactSite />,
        },

        {
          path: "/user-profile",
          element: <UserProfilePage />,
        },
      ],
    },
  ]);

 
  return (
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  );
 
  /*
  return (
    <Router>
        <Routes>
            <Route path="./components/Register.jsx" element={<Register />} />
            <Route path="./components/Login.jsx" element={<Login />} />
        </Routes>
    </Router>
  );
  */
}

export default App
