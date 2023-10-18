import { useState } from "react";
import styles from './Authentication.module.scss';
import Login from "./Login";
import Register from "./Register";

export default function Authentication() {

    const [activeTab, setActiveTab] = useState('login');

    function handleLoginTab() {
        setActiveTab('login');
    };

    function handleRegisterTab() {
        setActiveTab('register');
    };

    return (
        <div className={styles.container}>
            <div className={styles.card}>
                <div className={styles.tabs}>
                    <ul className={styles.nav}>
                        <li
                            className={activeTab === 'login' ? styles.active : ""}
                            onClick={handleLoginTab}
                        >
                            Login
                        </li>
                        <li
                            className={activeTab === 'register' ? styles.active : ""}
                            onClick={handleRegisterTab}
                        >
                            Cadastro
                        </li>
                    </ul>
                    <div className={styles.outlet}>
                        {activeTab === 'login' ? <Login /> : <Register />}
                    </div>
                </div>
            </div>
        </div>
    );
}