import { ITag } from '@/interfaces/tag';
import { getTagsByType } from '@/lib/tag';
import styles from '@/styles/tag/tag.module.css'

export default function ShowTagsByType(props:any)
{
    const {type, tags, setSelectedTags, selectedTags} = props;
    
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
        <div>
            <h3 className={styles.tags_title}>{type}</h3>
            { getTagsByType(type, tags).map((t:ITag) => 
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