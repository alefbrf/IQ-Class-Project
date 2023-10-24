import styles from '../Input.module.scss';

interface Props  {
    type: string | 'text';
    value: string;
    onChange: React.Dispatch<React.SetStateAction<string>>;
    label: string;
    Icon?: JSX.Element;
}

export default function Input({type, value, onChange, label, Icon}: Props ) {
    return (
        <div className={styles.input_field}>
            <input 
                spellCheck={false} 
                autoComplete='off'
                type={type}
                value={value}
                onChange={(e) => onChange(e.target.value)}
                placeholder=''
            />            
            <label>{label}</label>
            {Icon}
        </div>
    )
}