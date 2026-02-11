import './Product.css';

export default function Product() {
    return (
        <div id="ProductsDiv">
            <div className="ProductCard">
                <div className="ProductCardImage"></div>
                <div className="ProductCardName">
                    <span id="Name">Название</span>
                    <span>555 руб.</span>
                </div>
            </div>
        </div>
    );
}
