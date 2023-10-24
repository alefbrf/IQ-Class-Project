import { useState, useEffect } from 'react';
import styles from '../Authentication.module.scss';
import api from '../../../api/axios';
import Input from '../components/Input';
import {AiOutlineMail} from 'react-icons/ai';
import PasswordInput from '../components/PasswordInput';
import { useNavigate } from 'react-router-dom';

export default function Login() {

    const [userEmail, setUserEmail] = useState('');

    const [userPassword, setUserPassword] = useState('');

    const [userToken, setUserToken] = useState('');

    const [loginError, setLoginError] = useState('');

    function Logar(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();

        api.post(
            '/user/login', {
            email: userEmail,
            password: userPassword
        }
        ).then(
            (response) => {
                setUserToken(response.data);
            }
        ).catch(
            (error) => {
                setLoginError(error.message)
            }
        )
    }

    useEffect(() => {
        console.log(userToken);
    }, [userToken]);

    return (
        <>
            <div id='login' className={styles.form}>
                <h2>Bem-vindo</h2>
                <form onSubmit={e => Logar(e)} >                    
                    <Input 
                        type='text' 
                        value={userEmail} 
                        onChange={setUserEmail} 
                        label='Email' 
                        Icon={<AiOutlineMail/>}
                    />
                    <PasswordInput  
                        value={userPassword} 
                        onChange={setUserPassword} 
                        label='Senha' 
                    />
                    <p className={styles.error}>asdas</p>
                    <div className={styles.button_field}>
                        <button>Entrar</button>
                    </div>
                </form>
            </div>
        </>
    )
}