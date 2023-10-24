import Login from './Login';
import Register from './Register';
import styles from './Authentication.module.scss';
import { useEffect, useState } from 'react';

export default function Authentication1() {

    var params =  window.location.hash.split('#')[1]

    if (!params) {
        params = 'login';
    }

    useEffect(() =>{
        if (!!window.location.hash){
            window.location.href = window.location.hash;
        }
    }, [window.location.hash]);

    const [activeTab, setActiveTab] = useState(params);

    function handleLoginTab() {
        setActiveTab('login');
    };

    function handleRegisterTab() {
        setActiveTab('register');
    };

    return (
        <div className={styles.container}>
            <div className={styles.card}>
                <ul className={styles.nav}>
                    <li className={activeTab === 'login' ? styles.active : ""}>
                        <a href='#login' onClick={handleLoginTab}>Login</a>
                    </li>
                    <li className={activeTab === 'register' ? styles.active : ""}>
                        <a href='#register' onClick={handleRegisterTab}>Cadastro</a>
                    </li>
                </ul>
                <div className={styles.outlet}>
                    <Login />
                    <Register />
                </div>
            </div>
        </div>
    )
}