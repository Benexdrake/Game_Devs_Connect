import styles from '@/styles/post/add_post.module.css'
import { useRouter } from 'next/router';
import { IPost } from "@/interfaces/post";
import { useState } from "react";
import { IUpsertPostRequest } from '@/interfaces/requests/post/api_add_post_request';
import { addPostAsync } from '@/services/post_service';

export default function AddComment({userId, postId}:{userId:string, postId:string}) 
{    
    const [message, setMessage] = useState<string>('');
    const router = useRouter();

    const sendHandler = async () => 
    {
        const post: IPost = { id: '', parentId: postId, hasQuest: false, message, created: null, projectId: '', ownerId: userId, fileId:'', isDeleted: false, completed: false }
        const addPost: IUpsertPostRequest = { post, tags: [] }


        const response = await addPostAsync(addPost)
        router.reload();

    }

    return (
        <div className={styles.main}>
            <div className={styles.message}>
                <textarea name="message" id="message" onChange={(text) => setMessage(text.target.value)} placeholder='Add Message here...'></textarea>
            </div>
            <div className={styles.footer}>
                <div className={styles.send_button} onClick={sendHandler}>
                    <p>Send</p>
                </div>
            </div>
        </div>
    );
}