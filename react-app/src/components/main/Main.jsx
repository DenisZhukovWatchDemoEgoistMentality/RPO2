import './Main.css';
import axios from "axios"
import { React, useEffect, useInsertionEffect, useState } from 'react';
import { Navigate, Links, Link } from 'react-router-dom'
import Search from '../search/Search';

import main_img from '../image/main.png';
import message_img from '../image/messages.png';
import profile_img from '../image/profile.png';
import adminka_img from '../image/adminka.png';

export default function Main() {
    // const [joke, setJoke] = useState("");
    // useEffect(() => {
    //     axios.get("https://api.chucknorris.io/jokes/random")
    //         .then(function (response) {
    //             console.log(response.data.value);
    //             setJoke(response.data.value);
    //         })
    //         .catch(function (error) {
    //             console.error(error);
    //         });
    // }, []);}
    return (
        <main>
            <div id="TrueMain">
                <Link to="/" className="ButtonMenu">
                    <img src={main_img} alt="" />
                    Главная
                </Link>
                <Link to="/messages" className="ButtonMenu">
                    <img src={message_img} alt="" />
                    Сообщения
                </Link>
                <Link to="/profile" className="ButtonMenu">
                    <img src={profile_img} alt="" />
                    Профиль
                </Link>
                <Link to="/adminka-huinka" className="ButtonMenu">
                    <img src={adminka_img} alt="" />
                    Админ панель
                </Link>
            </div>
        </main>
    );
}
