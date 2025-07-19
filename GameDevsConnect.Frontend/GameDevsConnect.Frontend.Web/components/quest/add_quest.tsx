import { IQuest } from '@/interfaces/quest';
import styles from '@/styles/quest/add_quest.module.css'
import { useState } from 'react';

export default function AddQuest({ownerId, setQuests}:{ownerId:string, setQuests:Function})
{
    const [title, setTitle] = useState<string>('')
    const [difficulty, setDifficulty] = useState<number>(1)
    const [description, setDescription] = useState<string>('')
    
    const onTitleValueChangeHandler = (e:any) =>
    {
        setTitle(e.target.value);
    }

    const onDifficultyValueChangeHandler = (e:any) =>
    {
        setDifficulty(e.target.value);
    }

    const onDescriptionValueChangeHandler = (e:any) =>
    {
        setDescription(e.target.value);
    }

    const onSendHandler = () =>
    {
        setQuests((prev:IQuest[]) => [...prev, {id:'', title, description, difficulty, postId:'', ownerId}])
        setTitle('');
        setDifficulty(1);
        setDescription('');
    }

    return (
        <div className={styles.main}>
            <div className={styles.title}>
                <div>
                    <input type="text" value={title} onChange={onTitleValueChangeHandler} placeholder='Quest Title'/>
                </div>
                <select value={difficulty} onChange={onDifficultyValueChangeHandler}>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
                <div className={styles.button} onClick={() => onSendHandler()}>ADD</div>
            </div>
            <div className={styles.message}>
                <textarea value={description} onChange={onDescriptionValueChangeHandler} placeholder='Quest Description'></textarea>
            </div>
            
        </div>
    )
}