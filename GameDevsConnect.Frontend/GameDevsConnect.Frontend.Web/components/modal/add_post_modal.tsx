import { IFile } from '@/interfaces/file';
import { IPost } from '@/interfaces/post';
import { IQuest } from '@/interfaces/quest';
import { IUpsertPostRequest } from '@/interfaces/requests/post/api_add_post_request';
import { ITag } from '@/interfaces/tag';
import { addFileAsync } from '@/services/file_service';
import { addPostAsync } from '@/services/post_service';
import { addQuestAsync } from '@/services/quest_service';
import stylesModal from '@/styles/modal.module.css'
import styles from '@/styles/post/add_post.module.css'
import { useRouter } from 'next/router';
import { useState } from 'react';
import ShowElement from '../show_element';
import AddQuest from '../quest/add_quest';
import SelectTags from '../tag/select_tags';
import PreviewQuest from '../quest/preview_quest';

export default function AddPostModal({setOpenModal, openModal, postId, userId} : 
                            {setOpenModal:Function, openModal:boolean, postId:string, userId:string})
{
    const [selectedTags, setSelectedTags] = useState<ITag[]>([])

    const [quests, setQuests] = useState<IQuest[]>([])

    const [message, setMessage] = useState<string>('');

    const [addFile, setAddFile] = useState<boolean>(false);

    const [showTags, setShowTags] = useState<boolean>(false);
    const [showQuest, setShowQuest] = useState<boolean>(false);

    const router = useRouter();

    const innerElementHandler = (e:any) =>
    {
        e.stopPropagation();
    }

    const onCloseHandler = () =>
    {
        setQuests([]);
        setMessage('');
        setSelectedTags([]);
        setAddFile(false);
        setOpenModal(false)
        setShowQuest(false);
        setShowTags(false);
    }

        const onQuestDeleteHandler = (quest:IQuest) =>
    {
        const filteredQuests = quests.filter(x => x !== quest)
        
        setQuests(filteredQuests)
    }

        const sendHandler = async () => 
        {
            // Upload File and get Url
    
            // Add File
            let fileId = '';
            if (addFile) 
            {
                const file: IFile = { id: '', url: 'https://fantasyanime.com/finalfantasy/ff/maps/Final-Fantasy-1-GBA-World-Map-Labeled.png', size: 1000, type: 'image', ownerId: userId, created: null }
                const fileResponse = await addFileAsync(file)
    
                if (fileResponse.status)
                    fileId = fileResponse.id;
            }
    
            const post: IPost = { id: '', parentId: postId, hasQuest: quests.length > 0, message, created: null, projectId: '', ownerId: userId, fileId, isDeleted: false, completed: false }
            const addPost: IUpsertPostRequest = { post, tags: selectedTags }
    
            // Validation
            // Message min x Zeichen
            // Tags min 1 Tag
            // File nicht nötig.
            //
    
            const response = await addPostAsync(addPost);
    
            for(const quest of [...quests])
            {
                quest.postId = response.id
                await addQuestAsync(quest);
            }
    
            onCloseHandler();
            router.push('/')
        }

    return (
        <div className={stylesModal.main} style={{visibility:openModal ? 'visible':'hidden'}} onClick={() => onCloseHandler()}>
            <div className={stylesModal.modal} onClick={innerElementHandler}>
                        <div className={styles.main}>
            <div className={styles.message}>
                <textarea name="message" id="message" value={message} onChange={(text) => setMessage(text.target.value)} placeholder='Add Message here...'/>
            </div>
            <div className={styles.buttons}>
                <div className={styles.button} onClick={() => setAddFile(!addFile)}>
                    <i className="fa-regular fa-image"></i>
                </div>
                <div className={styles.button}>
                    <i className="fa-solid fa-video"></i>
                </div>
                <div className={styles.button}>
                    <i className="fa-solid fa-arrow-up-from-bracket"></i>
                </div>
                <div className={styles.projects}>
                    <select name="projects" id="projects">
                        <option value="" defaultChecked>-</option>
                        <option value="GameDevsConnect">Game Devs Connect</option>
                    </select>
                </div>
            </div>
            <div className={styles.show_files}>
                {addFile && (
                    <div className={styles.show_file}>
                        <div className={styles.show_file__type}><i className="fa-regular fa-image"></i></div>
                        <div className={styles.show_file__name}><p>gamedevsconnect.png</p></div>
                        <div className={styles.show_file__delete}><i className="fa-solid fa-xmark"></i></div>
                    </div>
                )}
            </div>
            
                    <ShowElement title='Quests' show={showQuest} setShow={setShowQuest}>
                        <AddQuest ownerId={userId} setQuests={setQuests}/>
                        <div style={{display:'grid', gap:'8px', marginTop:'8px'}}>
                            {quests.map((x,index) => <PreviewQuest quest={x} favorited={false} preview={true} index={index + 1} onQuestDeleteHandler={onQuestDeleteHandler} key={index+x.title+index}/>)}
                        </div>
                    </ShowElement>
                    <br />
                    <div className={styles.tags}>
                        <ShowElement title='Tags' show={showTags} setShow={setShowTags}>
                            <SelectTags setSelectedTags={setSelectedTags} selectedTags={selectedTags} />
                        </ShowElement>
                    </div>
            <div className={styles.footer}>
                <div className={styles.send_button} onClick={sendHandler}>
                    <p>Send</p>
                </div>
            </div>
        </div>
            </div>
        </div>
    )
}