import './Main.css';
import axios from "axios"
import { React, useEffect, useInsertionEffect, useState } from 'react';

export default function Main() {
    const [joke, setJoke] = useState("");
    useEffect(() => {
        axios.get("https://api.chucknorris.io/jokes/random")
            .then(function (response) {
                console.log(response.data.value);
                setJoke(response.data.value);
            })
            .catch(function (error) {
                console.error(error);
            });
    }, []);
    return (
        <main>
            <h2>{joke}</h2>
        </main>
    );
}

