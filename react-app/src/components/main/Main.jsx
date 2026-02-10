import './Main.css';
import axios from "axios"
import { React, useEffect, useInsertionEffect, useState } from 'react';
import { Navigate, Links, Link } from 'react-router-dom'

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
                <button className="ButtonMenu">
                    <img src="MainImage/Vector.png" alt="" />
                    Главная
                </button>
                <button className="ButtonMenu">
                    <img src="MainImage/Vector (1).png" alt="" />
                    Сообщения
                </button>
                <Link to="/profile" className="ButtonMenu">
                    <img src="/MainImage/Vector (2).png" alt="" />
                    Профиль
                </Link>
                <button className="ButtonMenu">
                    <img src="MainImage/Vector (3).png" alt="" />
                    Админ панель
                </button>
            </div>

        <div id="ProductsDiv">
            <div class="ProductCard">
                <div class="ProductCardImage"></div>
                <div class="ProductCardName"> 
                    <span id="Name">Название</span>
                    <span>555 руб.</span>
                </div>
            </div>
        </div>
        </main>
    );
}

