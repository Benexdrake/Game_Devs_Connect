import ShowQuest from "./show_quest"

export default function ShowQuests({ids}: {ids:string[]})
{   
    return (
        <div style={{display:'grid', gap:'8px'}}>
        {
            ids.map((x:string, index) => <ShowQuest id={x} index={index + 1}/> )
        }
        </div>
    )
}