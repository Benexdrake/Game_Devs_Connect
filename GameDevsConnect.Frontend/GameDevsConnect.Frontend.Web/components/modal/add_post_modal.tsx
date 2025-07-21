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

    const [images, setImages] = useState<File[]>([])

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
        setImages([]);
        setOpenModal(false)
        setShowQuest(false);
        setShowTags(false);
    }

    const onQuestDeleteHandler = (quest:IQuest) =>
    {
        const filteredQuests = quests.filter(x => x !== quest)    
        setQuests(filteredQuests)
    }

    const onAddImage = (e:React.ChangeEvent<HTMLInputElement>) =>
    {
            if (e.target.files?.[0])
            {
                const file = e.target.files[0];

                if(images.length < 4 && file)
                    setImages(prev => [...prev, file]);
            }
    }

    const sendHandler = async () => 
    {
        let fileId = '';
        // if (addFile) 
        // {
        //     const file: IFile = { id: '', url: 'https://fantasyanime.com/finalfantasy/ff/maps/Final-Fantasy-1-GBA-World-Map-Labeled.png', size: 1000, type: 'image', ownerId: userId, created: null, extension:'' }
        //     const fileResponse = await addFileAsync(file)

        //     if (fileResponse.status)
        //         fileId = fileResponse.id;
        // }

        // File ID entfernen, POST_FILE Table erstellen, PostId, FileID.

        // Get Post array fileIds
        // Laden der Files und angepasst anzeigen, image, video, file

        // Liste mit anzeigen der Files, bei Image, mini preview und delete button einbauen.

        // In der File API die Url erstellen. base addresse / userid / fileId

        // Quest Absolvieren einbauen, File übergabem, anzeigen der Datei unter Quest
        // Quest_File Tabelle bauen questId, fileId

        // Beim senden, for each schleife, images durchgehen und zusammen mit upload nach azure blob ausführen, vllt eine Methode dazu bauen.
        // lib upload file

        //   const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        //     if (e.target.files?.[0]) {
        //       setFile(e.target.files[0]);
        //     }
        //   };
        
        //   const handleUpload = async () =>
        //   {
        //     if(!file) return;
        
        //     console.log(file);
            
        //     const responseFile = await addFileAsync({id:'', url:'', type:'', size:0, ownerId:user.id, created:null, extension:''})
        
        //     const requestJson = {
        //       FileName: `${user.id}/${responseFile.id}`,
        //       ContainerName:process.env.NEXT_PUBLIC_AZURE_STORAGE_CONTAINERNAME
        //     }
        
        //     const request = JSON.stringify(requestJson)
        
        //     const azureResponse = await uploadFile(file, request)
        //     console.log(azureResponse);
        //   }

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
                <div className={styles.button}>
                    <label htmlFor="imageUpload">
                        <i className="fa-regular fa-image"></i>
                    </label>
                    <input type="file" name="imageUpload" id="imageUpload" style={{display:'none'}} onChange={onAddImage}/>
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
                {images.map(x => (
                    <div className={styles.show_file}>
                        <div className={styles.show_file__type}><i className="fa-regular fa-image"></i></div>
                        <div className={styles.show_file__name}><p>{x.name}</p></div>
                        <div className={styles.show_file__delete}><i className="fa-solid fa-xmark"></i></div>
                    </div>
                ))}
                {/* {addFile && (
                    <div className={styles.show_file}>
                        <div className={styles.show_file__type}><i className="fa-regular fa-image"></i></div>
                        <div className={styles.show_file__name}><p>gamedevsconnect.png</p></div>
                        <div className={styles.show_file__delete}><i className="fa-solid fa-xmark"></i></div>
                    </div>
                )} */}
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