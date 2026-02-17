Шаблон для Html сайта
https://www.figma.com/design/sau7g7LP2FmElaOoGMbykv/Untitled?node-id=0-1&t=kWLEXXR4hI6JVGcJ-1

Степан: API.
Романн: px -> %
Никита: axios


Карточка для товара:
html:

    <div id="ProductsDiv">
                <div class="ProductCard">
                    <div class="ProductCardImage"></div>
                    <div class="ProductCardName"> 
                        <span id="Name">Название</span>
                        <span>555 руб.</span>
                    </div>
                </div>
            </div>

style.css:

    #ProductsDiv{
        width: 100%;
        height: 100%;
        display: flex;
        flex-wrap:wrap;
        
    }

    .ProductCard{
        margin-top: 30px;
        margin-left: 30px;
        width: 250px;
        height: 296px;
        background-color: white;

    }

    .ProductCardImage{
    width: 250px;
    height: 250px;
    background-color: #F2F4F7;
    }
    .ProductCardName{
        margin-top: 10px;
        display: flex;
        flex-direction: column;
        font-size: 16px;
        color: #8287B0;
    }
