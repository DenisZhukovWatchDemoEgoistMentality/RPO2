import { useState } from "react";
import './Cart.css';

export default function Cart() {
    const [cartOpen, setCartOpen] = useState(false);
    const [cartItems, setCartItems] = useState([
        { id: 1, name: 'НАЗВАНИЕ', price: 150, quantity: 1, image: '' },
        { id: 2, name: 'НАЗВАНИЕ', price: 150, quantity: 1, image: '' },
        { id: 3, name: 'НАЗВАНИЕ', price: 150, quantity: 1, image: '' },
        { id: 4, name: 'НАЗВАНИЕ', price: 150, quantity: 1, image: '' },
    ]);

    const toggleCart = () => {
        setCartOpen(!cartOpen);
    };

    const updateQuantity = (id, change) => {
        setCartItems(cartItems.map(item =>
            item.id === id
                ? { ...item, quantity: Math.max(1, item.quantity + change) }
                : item
        ));
    };

    const removeItem = (id) => {
        setCartItems(cartItems.filter(item => item.id !== id));
    };

    return (
        <div className="cart-container">
            <button id="Cart" onClick={toggleCart}>
                КОРЗИНА
            </button>

            {cartOpen && (
                <div
                    className="cart-modal-content"
                    onClick={(e) => e.stopPropagation()}
                >
                    <div className="cart-modal-body">
                        {cartItems.length === 0 ? (
                            <p>Корзина пуста</p>
                        ) : (
                            cartItems.map(item => (
                                <div key={item.id} className="cart-item">
                                    <div className="cart-item-image">
                                        {item.image ? (
                                            <img src={item.image} alt={item.name} />
                                        ) : (
                                            <div className="placeholder-image"></div>
                                        )}
                                    </div>

                                    <div className="cart-item-info">
                                        <h3>{item.name}</h3>
                                        <p className="price">{item.price} РУБ.</p>

                                        <div className="quantity-controls">
                                            <button
                                                className="qty-btn minus"
                                                onClick={() => updateQuantity(item.id, -1)}
                                            >
                                                −
                                            </button>

                                            <span className="quantity">
                                                {item.quantity}
                                            </span>

                                            <button
                                                className="qty-btn plus"
                                                onClick={() => updateQuantity(item.id, 1)}
                                            >
                                                +
                                            </button>
                                        </div>
                                    </div>

                                    <button
                                        className="remove-btn"
                                        onClick={() => removeItem(item.id)}
                                    >
                                        🗑
                                    </button>
                                </div>
                            ))
                        )}
                    </div>
                </div>
            )}
        </div>
    );
}
