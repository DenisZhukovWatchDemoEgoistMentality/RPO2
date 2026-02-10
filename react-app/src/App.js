import './App.css';
import Header from './components/header/Header';
import Main from './components/main/Main';
import Profile from './components/profile/Profile'
import Messages from './components/messages/Messages'
import Adminka from './components/adminka/Adminka'

import './fonts/Intro.ttf';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Search from "./components/search/Search";

export default function App() {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/" element={ <Main /> } />
        {/* <Route path="/message" element={<Message />} />  */}
        <Route path="/profile" element={<Profile />} />
        {/* <Route path="/adminka-huinka" element={<Adminka />} /> */}
      </Routes>
    </BrowserRouter>
  );
}

