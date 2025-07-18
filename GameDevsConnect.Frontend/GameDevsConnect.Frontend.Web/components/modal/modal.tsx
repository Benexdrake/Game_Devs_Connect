import styles from '@/styles/modal.module.css'

export default function Modal(props:any)
{
    const {setOpenModal, openModal, children} = props;

    const innerElementHandler = (e:any) =>
    {
        e.stopPropagation();
    }

    return (
        <div className={styles.main} style={{visibility:openModal ? 'visible':'hidden'}} onClick={() => setOpenModal(!openModal)}>
            <div className={styles.modal} onClick={innerElementHandler}>
                {children}
            </div>
        </div>
    )
}