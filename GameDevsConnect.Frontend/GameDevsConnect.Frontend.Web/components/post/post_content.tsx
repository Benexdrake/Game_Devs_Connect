import { IFile } from '@/interfaces/file';
import styles from '@/styles/post/post.module.css'

export default function PostContent({file}: {file:IFile})
{
    if(file.type.includes("image"))
        return (
                <div>
                    <img src={file.url} alt={file.type} className={styles.file}/>
                </div>
        )
}