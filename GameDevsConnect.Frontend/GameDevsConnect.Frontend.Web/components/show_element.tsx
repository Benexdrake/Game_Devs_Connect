import { useState } from "react";
import styles from '@/styles/showElement.module.css'

export default function ShowElement(props:any)
{
    const {title, children, show, setShow} = props
    // const [show, setShow] = useState<boolean>(false);
    const [load, setLoad] = useState<boolean>(true);

    const showHandler = () =>
    {
        setShow(!show)
        if(!load)
            setLoad(true);
    }

    return (
        <div className={styles.main}>
            <div className={styles.button}onClick={() => showHandler()}>
                <p>{show? 'Close':'Open'} {title} <i className={show? 'fa-solid fa-square-minus':'fa-solid fa-square-caret-down'}></i></p>
            </div>
            <div style={{visibility:show?'visible':'hidden', height:show?'fit-content':'0px'}}>
                {children}
            </div>
        </div>
    )
}