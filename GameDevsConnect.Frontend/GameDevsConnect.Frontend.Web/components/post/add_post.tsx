import styles from '@/styles/post/add_post.module.css'
import { useRouter } from 'next/router';
import { IPost } from "@/interfaces/post";
import { ITag } from "@/interfaces/tag";
import { useState } from "react";
import SelectTags from "../tag/select_tags";
import { IUpsertPostRequest } from '@/interfaces/requests/post/api_add_post_request';
import { addPostAsync } from '@/services/post_service';
import { addFileAsync } from '@/services/file_service';
import { IFile } from '@/interfaces/file';
import ShowElement from '../show_element';
import AddQuest from '../quest/add_quest';
import { IQuest } from '@/interfaces/quest';
import PreviewQuest from '../quest/preview_quest';
import { addQuestAsync } from '@/services/quest_service';
import Modal from '../modal/add_post_modal';

export default function AddPost(props: any) {
    const {userId, postId} = props;

    const [message, setMessage] = useState<string>('');

    const router = useRouter();





    // Quests - Falls Quest Post

    // File

    // Choose Project or none
    // Need Project Names with IDs

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