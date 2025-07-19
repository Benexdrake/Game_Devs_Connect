import { useEffect, useState } from "react";
import ShowTagsByType from "./show_tags_by_type";
import styles from '@/styles/tag/tag.module.css'
import { ITag } from "@/interfaces/tag";
import { getTags } from "@/services/tag_service";

export default function SelectTags({setSelectedTags, selectedTags}: {setSelectedTags:Function, selectedTags:ITag[]})
{
    const [tags, setTags] = useState<ITag[]>([]);

    useEffect(() => {
        const get = async () =>
        {
            const response = await getTags();
            if(response.status)
                setTags(response.tags);
        }
        get();
    }, [])
        
    return (
        <div className={styles.main}>
            <ShowTagsByType type='Assets' tags={tags} setSelectedTags={setSelectedTags} selectedTags={selectedTags} />
            <ShowTagsByType type='Genres' tags={tags} setSelectedTags={setSelectedTags} selectedTags={selectedTags} />
        </div>       
    )
}