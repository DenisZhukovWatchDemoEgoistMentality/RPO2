import './App.css';
import Header from './components/header/Header';
import Main from './components/main/Main';
import Profile from './components/profile/Profile'
import Messages from './components/messages/Messages'
import Adminka from './components/adminka/Adminka'
import Product from "./components/product/Product";
import Rules from "./components/rules/Rules";
import Privacy from "./components/privacy/Privacy";

import './fonts/Intro.ttf';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Search from "./components/search/Search";

export default function App() {
  return (
      <BrowserRouter>
          <Header/>
              <div className="AppLayout">
                  <Main />
                  <Routes>
                      <Route path="/" element={ <Product /> } />
                      {/* <Route path="/message" element={<Message />} />  */}
                      <Route path="/profile" element={<Profile />} />
                      <Route path="/rules" element={<Rules />} />
                      <Route path="/privacy" element={<Privacy />} />
                  </Routes>
              </div>
      </BrowserRouter>
  );
}

