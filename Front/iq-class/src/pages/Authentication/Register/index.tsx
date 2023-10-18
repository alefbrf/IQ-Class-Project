import { useState, useEffect } from 'react';
import styles from '../Authentication.module.scss';
import api from '../../../api/axios';
import Input from '../components/Input';
import {AiOutlineMail} from 'react-icons/ai';
import {BsFillPersonFill} from 'react-icons/bs';
import PasswordInput from '../components/PasswordInput';

export default function Register() {

    const [userEmail, setUserEmail] = useState('');

    const [userName, setUserName] = useState('');

    const [userPassword, setUserPassword] = useState('');

    const [userToken, setUserToken] = useState('');

    const [loginError, setLoginError] = useState('');

    function Logar(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        console.log(userEmail);
        console.log(userPassword);

        api.post(
            '/user/register', {
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
            <div className={styles.login_form}>
                <h2>Bem-vindo</h2>
                <form onSubmit={e => Logar(e)} >                    
                    <Input 
                        type='text' 
                        value={userName} 
                        onChange={setUserName} 
                        label='Nome' 
                        Icon={<BsFillPersonFill/>}
                    />
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
                    <PasswordInput  
                        value={userPassword} 
                        onChange={setUserPassword} 
                        label='Confirme a senha' 
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