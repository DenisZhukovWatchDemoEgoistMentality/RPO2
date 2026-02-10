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
                    <img src="MainImage/Vector.png" alt="" style={{ padding: "5px" }} />
                    Главная
                </button>
                <button className="ButtonMenu">
                    <img src="MainImage/Vector (1).png" alt="" style={{ padding: "5px" }} />
                    Сообщения
                </button>
                <Link to="/profile" className="ButtonMenu">
                    <img src="/MainImage/Vector (2).png" alt="" style={{ padding: "5px" }} />
                    Профиль
                </Link>
                <button className="ButtonMenu">
                    <img src="MainImage/Vector (3).png" alt="" style={{ padding: "5px" }} />
                    Админ панель
                </button>
            </div>
        </main>
    );
}

