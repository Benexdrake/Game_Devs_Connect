import styles from '@/styles/post/post.module.css'

export default function PostContent(props:any)
{
    const {file} = props;

    switch(file.type)
    {
        case 'image':
            return (
                <div>
                    <img src={file.url} alt={file.name} className={styles.file}/>
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