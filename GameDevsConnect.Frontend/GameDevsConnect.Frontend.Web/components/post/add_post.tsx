import styles from '@/styles/post/add_post.module.css'

import { IPost } from "@/interfaces/post";
import { ITag } from "@/interfaces/tag";
import { useEffect, useState } from "react";

import { getTags } from "@/services/tag_service";
import SelectTags from "../tag/select_tags";
import { IUpsertPostRequest } from '@/interfaces/requests/post/api_add_post_request';

export default function AddPost(props:any)
{
    const {userId} = props;
    const [tags, setTags] = useState<ITag[]>([]);
    const [selectedTags, setSelectedTags] = useState<ITag[]>([])

    const [message, setMessage] = useState<string>('');


    useEffect(() => {
        const get = async () =>
        {
            const response = await getTags();
            if(response.status)
                setTags(response.tags);
        }
        get();
    }, [])

    // Quests - Falls Quest Post
    
    // File

    // Choose Project or none
    // Need Project Names with IDs
    
    const sendHandler = () =>
    {
        const post:IPost = { id:'', parentId:'', hasQuest:false, message, created:new Date().toUTCString(), projectId:'', ownerId: userId, fileId:'', isDeleted:false, completed:false}



        const addPost:IUpsertPostRequest = {post, tags:selectedTags}
        console.log(addPost);
        
        // Validation
        // Message min x Zeichen
        // Tags min 1 Tag
        // File nicht nötig.
        //
    }

    return (
        <div className={styles.main}>
            <div className={styles.message}>
                <textarea name="message" id="message" onChange={(text) => setMessage(text.target.value)}></textarea>
            </div>
            <div className={styles.buttons}>
                <div className={styles.button}>
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
                <div className={styles.show_file}>
                    <div className={styles.show_file__type}><i className="fa-regular fa-image"></i></div>
                    <div className={styles.show_file__name}><p>gamedevsconnect.png</p></div>
                    <div className={styles.show_file__delete}><i className="fa-solid fa-xmark"></i></div>
                </div>
            </div>

            <div className={styles.tags}>
                <SelectTags tags={tags} setSelectedTags={setSelectedTags} selectedTags={selectedTags}/>
            </div>
            <div className={styles.footer}>
                <div className={styles.send_button} onClick={sendHandler}>
                    <p>Send</p>
                </div>
            </div>
        </div>
    );
}