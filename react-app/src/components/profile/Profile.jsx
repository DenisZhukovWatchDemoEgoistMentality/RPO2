import './Profile.css';

export default function Header() {
  return (
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
  );
}