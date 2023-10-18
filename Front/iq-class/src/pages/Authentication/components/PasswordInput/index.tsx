import styles from '../Input.module.scss';
import { useState } from 'react';
import {AiFillEyeInvisible, AiFillEye} from 'react-icons/ai';

interface Props  {
    value: string;
    onChange: React.Dispatch<React.SetStateAction<string>>;
    label: string;
}

export default function PasswordInput({value, onChange, label}: Props ) {

    const [inputType, setInputType] = useState('password');
    
    let Icon = <AiFillEyeInvisible className={styles.password} onClick={changeInputType}/>;

    if(inputType == 'text') {
        Icon = <AiFillEye className={styles.password} onClick={changeInputType}/>
    }

    function changeInputType() {
        if(inputType == 'password'){
            setInputType('text')
        } else {
            setInputType('password')
        }
    }

    return (
        <div className={styles.input_field}>
            <input 
                spellCheck={false} 
                autoComplete='off'
                type={inputType}
                value={value}
                onChange={(e) => onChange(e.target.value)}
                placeholder=''
            />
            <label>{label}</label>
            {Icon}
        </div>
    )
}