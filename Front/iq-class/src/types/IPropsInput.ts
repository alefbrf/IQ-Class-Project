interface Props {
    type: string | 'text';
    value: string;
    onChange: React.Dispatch<React.SetStateAction<string>>;
    label: string;
    Icon?: JSX.Element;
}