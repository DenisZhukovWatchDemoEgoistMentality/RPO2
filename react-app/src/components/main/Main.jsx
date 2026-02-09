import './Main.css';
import axios from "axios"
import {React, useEffect, useInsertionEffect, useState} from 'react';

export default function Main() {
    useEffect(() => {
        try {
            const response = axios.get(url);
            console.log(response.data);
        } catch (error) {
            console.error("Error fetching data:", error)
        }
    }, []);
    return (
        <main>

        </main>
  );
}

