import './App.css';
import Header from './components/header/Header';
import Main from './components/main/Main';
import Profile from './components/profile/Profile'
import './fonts/Intro.ttf';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

export default function App() {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path="/profile" element={<Profile />} />
      </Routes>
    </BrowserRouter>
  );
}

