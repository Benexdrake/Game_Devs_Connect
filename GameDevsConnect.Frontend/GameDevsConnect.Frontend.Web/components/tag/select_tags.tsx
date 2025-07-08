import { ITag } from '@/interfaces/tag';
import styles from '@/styles/tag/tag.module.css'

export default function SelectTags(props:any)
{
    const {tags, setSelectedTags, selectedTags} = props;
    
    const changeTagHandler = (tag:ITag) =>
    {
        const findTag = selectedTags.find((x:ITag) => x.tag === tag.tag)
        if(findTag)
        {
            setSelectedTags((prev:ITag[]) => [...prev.filter(x => x.tag !== tag.tag)])
        }
        else
        {
            if(selectedTags.length < 5)
                setSelectedTags((prev:ITag[]) => [...prev, tag])
        }
    }

    const selectedHandler = (tag:ITag) =>
    {
        return selectedTags.includes(tag);
    }

    return (
        <div className={styles.tags}>
            { tags.map((t:ITag) => 
                <span className={styles.tag}
                    key={t.tag} 
                    onClick={ () => changeTagHandler(t)}
                    style={{ 
                        backgroundColor:selectedHandler(t)? 'var(--color4)':'',
                        color:selectedHandler(t)? 'var(--color1)':''}}>
                        {t.tag}
                </span>
            )}
        </div>
    )
}