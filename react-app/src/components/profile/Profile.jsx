import './Profile.css';

export default function Header() {
  return (
        <div className="container">
        <aside className="sidebar">
            <h1 className="logo">HORVARD</h1>
            <nav className="nav-buttons">
                <a href="#" className="nav-btn">Главная</a>
                <a href="#" className="nav-btn">Сообщения</a>
                <a href="#" className="nav-btn">Профиль</a>
                <a href="#" className="nav-btn">Админ панель</a>
            </nav>
        </aside>

        <main className="main-content">
            <h2>Мой профиль</h2>
            <div className="profile-info">
                <div className="info-item">
                    <span className="label">Баланс:</span>
                    <span className="value">1000 RUB</span>
                </div>
                <div className="info-item">
                    <span className="label">Отзывы:</span>
                    <span className="value">5</span>
                </div>
                <div className="info-item">
                    <span className="label">На сайте с:</span>
                    <span className="value">1 год 3 месяца</span>
                </div>
            </div>
        </main>
    </div>
  );
}