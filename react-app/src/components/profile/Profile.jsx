import './Profile.css';

export default function Header() {
  return (
        <div class="container">
        <aside class="sidebar">
            <h1 class="logo">HORVARD</h1>
            <nav class="nav-buttons">
                <a href="#" class="nav-btn">Главная</a>
                <a href="#" class="nav-btn">Сообщения</a>
                <a href="#" class="nav-btn">Профиль</a>
                <a href="#" class="nav-btn">Админ панель</a>
            </nav>
        </aside>

        <main class="main-content">
            <h2>Мой профиль</h2>
            <div class="profile-info">
                <div class="info-item">
                    <span class="label">Баланс:</span>
                    <span class="value">1000 RUB</span>
                </div>
                <div class="info-item">
                    <span class="label">Отзывы:</span>
                    <span class="value">5</span>
                </div>
                <div class="info-item">
                    <span class="label">На сайте с:</span>
                    <span class="value">1 год 3 месяца</span>
                </div>
            </div>
        </main>
    </div>
  );
}