import { getFavoritedQuestIdsAsync } from "@/services/quest_service";
import { useEffect, useState } from "react";
import { useInView } from "react-intersection-observer";
import ShowQuests from "./show_quests";

export default function InfiniteScrollQuests({initialIds, search, userId}: {initialIds:string[], search:string, userId:string})
{
    const [ids, setIds] = useState<string[]>(initialIds)
    const [page, setPage] = useState<number>(1);
    const [ref, inView] = useInView();

        const loadMoreIds = async () =>
        {
            const next = page + 1;
            const response = await getFavoritedQuestIdsAsync(userId, next, 5, search);
            
            if(response.status && response.ids.length > 0)
            {
                setPage(next)
                setIds(prev => [...[...new Set([...prev, ...response.ids])]])
            }
        }
    
        useEffect(() => {
            if(inView)
                loadMoreIds();
        }, [inView])
    
        return (
            <div>
                <ShowQuests ids={ids} />
                <div ref={ref}>
                    LOADING ...
                </div>
            </div>
        )
}