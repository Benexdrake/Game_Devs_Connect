import styles from '@/styles/quest/quest.module.css'

export default function PreviewQuest(props:any)
{
    const {quest, onQuestDeleteHandler, preview} = props;

    return (
        <div className={styles.main}>

        <div className={styles.main_content}>
            <div className={styles.icon}>
                <i className="fa-solid fa-shield"></i>
                <p>{quest?.difficulty}</p>
            </div>
            <div className={styles.content}>
                <div className={styles.content_title}>
                    <p>{quest?.title}</p>
                </div>
                <div className={styles.content_message}>
                    <p>
                        {quest?.description}
                    </p>
                </div>
            </div>
        </div>
        {preview && (
            <div className={styles.buttons}>
                <div className={styles.button} ><i className="fa-solid fa-pen"></i></div>
                <div className={styles.button} onClick={() => onQuestDeleteHandler(quest)}><i className="fa-solid fa-trash-can"></i></div>
            </div>
        )}
        </div>
    )
}