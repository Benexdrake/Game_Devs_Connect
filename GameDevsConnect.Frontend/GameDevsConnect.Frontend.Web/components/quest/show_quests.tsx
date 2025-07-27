import ShowQuest from "./show_quest"

export default function ShowQuests({ids, userId=""}: {ids:string[], userId:string})
{   
    return (
        <div style={{display:'grid', gap:'8px'}}>
        {
            ids.map((x:string, index) => <ShowQuest key={x} id={x} index={index + 1} userId={userId}/> )
        }
        </div>
    )
}