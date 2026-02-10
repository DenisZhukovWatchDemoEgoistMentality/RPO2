import './Main.css';
import axios from "axios"
import { React, useEffect, useInsertionEffect, useState } from 'react';
import { Navigate, Links, Link } from 'react-router-dom'
import Search from '../search/Search';

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
                    <img src="MainImage/Vector.png" alt="" />
                    Главная
                </Link>
                <Link to="/messages" className="ButtonMenu">
                    <img src="MainImage/Vector (1).png" alt="" />
                    Сообщения
                </Link>
                <Link to="/profile" className="ButtonMenu">
                    <img src="/MainImage/Vector (2).png" alt="" />
                    Профиль
                </Link>
                <Link to="/adminka-huinka" className="ButtonMenu">
                    <img src="MainImage/Vector (3).png" alt="" />
                    Админ панель
                </Link>
            </div>

        <div id="ProductsDiv">
            <div className="ProductCard">
                <div className="ProductCardImage"></div>
                <div className="ProductCardName">
                    <span id="Name">Название</span>
                    <span>555 руб.</span>
                </div>
            </div>
        </div>
        </main>
    );
}
