import { IFile } from '@/interfaces/file';
import styles from '@/styles/post/post.module.css'

export default function PostContent({file}: {file:IFile})
{
    switch(file.type)
    {
        case 'image':
            return (
                <div>
                    <img src={file.url} alt={file.type} className={styles.file}/>
                </div>
            )
        case 'video':
            return (
                <div>
                    YOUTUBE
                </div>
            )
        default:
            return (
                <div>

                </div>
            )
    }
}