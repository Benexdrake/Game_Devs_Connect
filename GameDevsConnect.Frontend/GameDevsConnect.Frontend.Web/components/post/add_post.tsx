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

export default function AddPost(props: any) {
    const { userId, postId, page } = props;
    const [selectedTags, setSelectedTags] = useState<ITag[]>([])
    const [showtags, setShowTags] = useState<boolean>(false)
    const [message, setMessage] = useState<string>('');

    const [addFile, setAddFile] = useState<boolean>(false);

    const router = useRouter();


    // Quests - Falls Quest Post

    // File

    // Choose Project or none
    // Need Project Names with IDs

    const sendHandler = async () => 
    {
        // Upload File and get Url

        // Add File
        let fileId = '';
        if (addFile) {
            const file: IFile = { id: '', url: 'https://fantasyanime.com/finalfantasy/ff/maps/Final-Fantasy-1-GBA-World-Map-Labeled.png', size: 1000, type: 'image', ownerId: userId, created: null }
            const fileResponse = await addFileAsync(file)

            if (fileResponse.status)
                fileId = fileResponse.id;
        }



        const post: IPost = { id: '', parentId: postId, hasQuest: false, message, created: null, projectId: '', ownerId: userId, fileId, isDeleted: false, completed: false }
        const addPost: IUpsertPostRequest = { post, tags: selectedTags }
        console.log(addPost);

        // Validation
        // Message min x Zeichen
        // Tags min 1 Tag
        // File nicht nötig.
        //

        const response = await addPostAsync(addPost)

        if(postId)
            router.reload();
        else if (router.pathname === '/')
            router.reload();
        else
            router.push('/')
    }

    return (
        <div className={styles.main}>
            <div className={styles.message}>
                <textarea name="message" id="message" onChange={(text) => setMessage(text.target.value)}></textarea>
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
            {!page && (
                <>
                    <div onClick={() => setShowTags(!showtags)}>
                        {!showtags ?
                            (
                                <div className={styles.show_tags_button}>
                                    <p>Show Tags <i className="fa-solid fa-square-caret-down"></i></p>
                                </div>
                            )
                            :
                            (
                                <div className={styles.show_tags_button}>
                                    <p>Close Tags <i className="fa-solid fa-square-minus"></i></p>
                                </div>
                            )
                        }
                    </div>

                    <div className={styles.tags}>
                        {showtags && (
                            <SelectTags setSelectedTags={setSelectedTags} selectedTags={selectedTags} />
                        )}
                    </div>
                </>
            )}
            <div className={styles.footer}>
                <div className={styles.send_button} onClick={sendHandler}>
                    <p>Send</p>
                </div>
            </div>
        </div>
    );
}